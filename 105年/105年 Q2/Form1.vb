Public Class Form1
    Dim left_bottom, left_top As Integer
    Dim right_bottom, right_top As Integer
    Dim left_hight As Decimal
    Dim tf As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button3.Enabled = True
        Dim b As Bitmap = PictureBox1.Image
        left_picture_hight(b)
        right_picture_hight(b)
        left_hight = 830 / (left_top - left_bottom)
        TextBox1.Text = Math.Round(left_hight * (right_top - right_bottom), 1)
    End Sub
    Sub left_picture_hight(b As Bitmap)
        For left_bottom = 0 To b.Height - 1
            tf = False
            For x = 0 To b.Width / 2
                Dim c As Color = b.GetPixel(x, left_bottom)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next

        For left_top = b.Height - 1 To 0 Step -1
            tf = False
            For x = 0 To b.Width / 2
                Dim c As Color = b.GetPixel(x, left_top)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next
    End Sub

    Sub right_picture_hight(b As Bitmap)
        For right_top = b.Height - 1 To 0 Step -1
            tf = False
            For x = b.Width / 2 To b.Width - 1
                Dim c As Color = b.GetPixel(x, right_top)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next
        For right_bottom = 0 To b.Height - 1
            tf = False
            For x = b.Width / 2 To b.Width - 1
                Dim c As Color = b.GetPixel(x, right_bottom)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next
    End Sub

    Dim left_width, right_width As Integer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim b As Bitmap = PictureBox1.Image
        right_picture_width(b)
        TextBox2.Text = Math.Round(left_hight * (right_width - left_width), 1)
    End Sub

    Sub right_picture_width(b As Bitmap)
        For left_width = b.Width / 2 To b.Width - 1
            tf = False
            For y = 0 To b.Height - 1
                Dim c As Color = b.GetPixel(left_width, y)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next

        For right_width = b.Width - 1 To b.Width / 2 Step -1
            tf = False
            For y = 0 To b.Height - 1
                Dim c As Color = b.GetPixel(right_width, y)
                Dim cv As Decimal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
                If cv >= 0 AndAlso cv < 200 Then tf = True : Exit For
            Next
            If tf = True Then Exit For
        Next

    End Sub
End Class
