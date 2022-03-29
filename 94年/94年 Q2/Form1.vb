Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bm As Bitmap = PictureBox1.Image
        For x = 0 To bm.Width - 1
            For y = 0 To bm.Height - 1
                Dim g = bm.GetPixel(x, y)
                Dim c = g.R / 3 + g.G / 3 + g.B / 3
                bm.SetPixel(x, y, Color.FromArgb(c, c, c))
            Next
        Next
        PictureBox3.Image = bm
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog Then
            PictureBox2.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bm As Bitmap = PictureBox2.Image
        For x = 0 To bm.Width - 1
            For y = 0 To bm.Height - 1
                Dim g = bm.GetPixel(x, y)
                Dim c = g.R / 3 + g.G / 3 + g.B / 3
                bm.SetPixel(x, y, Color.FromArgb(c, c, c))
            Next
        Next
        PictureBox4.Image = bm
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim p1 As Bitmap = PictureBox1.Image
        Dim p2 As Bitmap = PictureBox2.Image
        Dim p3 As New Bitmap(Math.Min(p1.Width, p2.Width), Math.Min(p1.Height, p2.Height))
        For x = 0 To p3.Width - 1
            For y = 0 To p3.Height - 1
                If p1.GetPixel(x, y).Name = p2.GetPixel(x, y).Name Then
                    p3.SetPixel(x, y, Color.FromArgb(255, 255, 255))
                Else
                    p3.SetPixel(x, y, Color.FromArgb(p2.GetPixel(x, y).R, p2.GetPixel(x, y).G, p2.GetPixel(x, y).B))
                End If
            Next
        Next
        PictureBox5.Image = p3
    End Sub
End Class
