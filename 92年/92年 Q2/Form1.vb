Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
        Label3.Text = ""
        Label4.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim b As Bitmap = PictureBox1.Image
        For x = 1 To b.Width - 1
            For y = 1 To b.Height - 1
                Dim g = b.GetPixel(x, y)
                Dim c = (0.299 * g.R + 0.587 * g.G + 0.114 * g.B)
                b.SetPixel(x, y, Color.FromArgb(c, c, c))
            Next
        Next
        PictureBox1.Image = b
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim b As Bitmap = PictureBox1.Image
        For x = 1 To b.Width - 1
            For y = 1 To b.Height - 1
                Dim g = b.GetPixel(x, y)
                Dim c = 255 - (0.299 * g.R + 0.587 * g.G + 0.114 * g.B)
                b.SetPixel(x, y, Color.FromArgb(c, c, c))
            Next
        Next
        PictureBox1.Image = b
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim b As Bitmap = PictureBox1.Image
        Dim col As New List(Of Single)
        For x = 1 To b.Width - 1
            For y = 1 To b.Height - 1
                Dim g = b.GetPixel(x, y)
                Dim c = (0.299 * g.R + 0.587 * g.G + 0.114 * g.B)
                col.Add(c)
            Next
        Next
        Dim min As Decimal = col.Min
        Dim max As Decimal = col.Max
        Label3.Text = max : Label4.Text = min
        For x = 1 To b.Width - 1
            For y = 1 To b.Height - 1
                Dim g = b.GetPixel(x, y)
                Dim c = (g.R - min) / (max - min) * 255
                b.SetPixel(x, y, Color.FromArgb(c, c, c))
            Next
        Next
        PictureBox1.Image = b
    End Sub
End Class
