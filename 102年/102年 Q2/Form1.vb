Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As New Random
        TextBox1.Text = r.Next(0, 10000) & "." & r.Next(0, 1000000)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim t1 As String = TextBox1.Text.Split(".")(0)
        Dim a As String = ""
        Do
            a &= Val(t1) Mod 2
            t1 = t1 \ 2
        Loop Until t1 = 0
        a = StrReverse(a)
        Dim b As String = ""
        Dim t2 As Decimal = Val(TextBox1.Text) - Val(TextBox1.Text.Split(".")(0))
        For i = 1 To 10
            t2 *= 2
            If t2 > 1 Then b &= 1 : t2 -= 1 Else b &= 0
        Next
        TextBox2.Text = a & "." & b

        For i = Len(b) To 1 Step -1
            If Mid(b, i, 1) = 0 Then b = b.Remove(i - 1, 1) Else Exit For
        Next
        TextBox3.Text = a & "." & b
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
