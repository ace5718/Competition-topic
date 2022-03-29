Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t = My.Computer.FileSystem.ReadAllText(TextBox1.Text)
        TextBox4.Text = t
        t = t.Replace(vbCrLf, " ")
        If t.IndexOf(TextBox2.Text) = -1 Then
            TextBox3.Text = "未找到" & TextBox2.Text & "字串"
        Else
            TextBox3.Text = t.IndexOf(TextBox2.Text) + 1
        End If
    End Sub
End Class
