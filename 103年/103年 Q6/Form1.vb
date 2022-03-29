Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 3
            Controls("TextBox" & i).Text = ""
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x% = TextBox1.Text, p% = TextBox2.Text, n% = TextBox3.Text
        Dim t As Integer = x
        For i = 1 To p - 1
            t = t * x Mod n
        Next
        Label4.Text = String.Format("餘數= {0}", t)
    End Sub
End Class
