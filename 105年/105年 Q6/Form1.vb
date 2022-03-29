Public Class Form1
    '拖拉資料
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        PictureBox1.ImageLocation = e.Data.GetData(DataFormats.FileDrop)(0)
        Button1.Text = "Reveal The Image Behind"
        Button1.Enabled = True
    End Sub

    '處理影像
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b = New Bitmap(PictureBox1.ImageLocation)
        For y = 0 To b.Height - 1
            For x = 0 To b.Width - 1
                Dim c = b.GetPixel(x, y)
                b.SetPixel(x, y, Color.FromArgb(If(c.R And 1, 16, 235), If(c.G And 1, 16, 235), If(c.B And 1, 16, 235)))
            Next
        Next
        PictureBox1.Image = b
    End Sub
End Class
