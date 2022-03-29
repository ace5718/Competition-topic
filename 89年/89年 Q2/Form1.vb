Public Class Form1
    Dim m(255) As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim b As Bitmap = PictureBox1.Image
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                Dim a = b.GetPixel(i, j)
                Dim c = a.R * 0.299 + a.G * 0.587 + a.B * 0.114
                b.SetPixel(i, j, Color.FromArgb(c, c, c))
                m(c) += 1
            Next
        Next
        PictureBox2.Image = b
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim t As Decimal, b As Bitmap = PictureBox2.Image
        For i = 0 To 255 : t += i * m(i) : Next
        t = 0.7 * (t / (b.Width * b.Height))
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                Dim a = b.GetPixel(i, j)
                Dim c = a.R * 0.299 + a.G * 0.587 + a.B * 0.114
                If c > t Then
                    b.SetPixel(i, j, Color.White)
                Else
                    b.SetPixel(i, j, Color.Black)
                End If
            Next
        Next
        PictureBox3.Image = b
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
