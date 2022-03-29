Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        re()
        Dim total As New Integer
        For i = 1 To RichTextBox1.Text.Count
            If Mid(RichTextBox1.Text, i, TextBox2.Text.Count) = TextBox2.Text Then
                RichTextBox1.Select(i - 1, TextBox2.Text.Count)
                RichTextBox1.SelectionBackColor = Color.Yellow
                total += 1
            End If
        Next
        Label3.Text = total
    End Sub
    Sub re()
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionBackColor = Color.White
    End Sub
End Class
