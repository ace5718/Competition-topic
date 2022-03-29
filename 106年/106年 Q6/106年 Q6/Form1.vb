Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = ""
        Dim s As String = 1
        Dim ss As New Integer
        For i = 2 To Val(TextBox1.Text)
            Dim a = s.Reverse.Select(Function(x) Val(x)).ToArray
            Dim b = i.ToString.Reverse.Select(Function(x) Val(x)).ToArray
            Dim c(a.Count + b.Count) As Integer
            For aa = 0 To a.Count - 1
                For bb = 0 To b.Count - 1
                    c(aa + bb) += a(aa) * b(bb)
                    If c(aa + bb) > 9 Then
                        c(aa + bb + 1) += c(aa + bb) \ 10
                        c(aa + bb) = c(aa + bb) Mod 10
                    End If
                Next
            Next
            s = ""
            For j = c.Count - 1 To 0 Step -1
                If c(j) <> 0 Then
                    For k = j To 0 Step -1
                        s &= c(k)
                    Next
                    Exit For
                End If
            Next
            Dim n As Integer = i
            For j = 2 To i
                If n Mod j = 0 Then
                    n \= j
                    j = 1
                    ss += 1
                End If
                If j > n Then Exit For
            Next
        Next
        TextBox2.Text &= s & vbCrLf & vbCrLf & s.Select(Function(x) Val(x)).Sum & vbCrLf & vbCrLf & ss
    End Sub
End Class
