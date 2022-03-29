Public Class Form1
    'Dim t As String() = "1,2,3,4,5".Split({","}, StringSplitOptions.RemoveEmptyEntries) 多重分割
    Dim w As Decimal()
    Dim e As Decimal
    Private Sub Button1_Click(sender As Object, e1 As EventArgs) Handles Button1.Click
        w = (From t In TextBox4.Text.Split(";") Select CDec(t)).ToArray
        Dim E As Integer = 0
        Do
            E = 0
            For Each i In TextBox1.Lines
                Dim xy As Decimal() = (From t In i.Split(" ") Select CDec(t)).ToArray
                Dim f As New Decimal
                For j = 0 To 2
                    f += w(j) * xy(j)
                Next
                If sing(f) <> xy(3) Then
                    For j = 0 To 2
                        w(j) = w(j) + Val(TextBox3.Text) * (xy(3) - sing(f)) * xy(j)
                    Next
                End If
                E = E + 0.5 * Math.Abs(xy(3) - sing(f)) ^ 2
            Next
        Loop While E > 0
        TextBox5.Text = Join((From x In w Select CStr(x)).ToArray, ";")

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim t As Decimal() = (From x In TextBox9.Text.Split(";") Select CDec(x)).ToArray
        Dim f As Integer
        For j = 0 To 2
            f += t(j) * w(j)
        Next
        Label9.Text = "機器人向:" & If(sing(f) = -1, "右", "左")
    End Sub
    Function sing(f As Decimal) As Integer
        If f >= 0 Then Return 1 Else Return -1
    End Function


End Class
