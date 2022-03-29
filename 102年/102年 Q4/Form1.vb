Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            If OpenFileDialog1.FileName <> "" Then PictureBox1.ImageLocation = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bm As Bitmap = PictureBox1.Image
        Dim nb As New Bitmap(bm.Width, bm.Height)
        For x = 0 To bm.Width - 1
            For y = 0 To bm.Height - 1
                nb.SetPixel(x, y, Color.White)
            Next
        Next

        For x = 0 To bm.Width - 1
            For y = 0 To bm.Height - 1
                If bm.GetPixel(x, y).Name <> "ffffffff" Then
                    For i = -1 To 1 Step 2
                        If x + i > 0 And x + i < bm.Width - 1 Then nb.SetPixel(x + i, y, Color.Black)
                        If y + i > 0 And y + i < bm.Height - 1 Then nb.SetPixel(x, y + i, Color.Black)
                    Next
                End If
            Next
        Next
        PictureBox1.Image = nb

    End Sub
End Class
