Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r, g, b, h, s, i As Decimal
        Dim rgb As Integer = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text)
        r = TextBox1.Text / rgb : g = TextBox2.Text / rgb : b = TextBox3.Text / rgb
        s = 1 - 3 * Math.Min(r, Math.Min(g, b))
        i = rgb / (3 * 255)
        h = Math.Acos((0.5 * ((r - g) + (r - b))) / (((r - g) ^ 2) + (r - b) * (g - b)) ^ 2)
        If b > g Then h = 2 * Math.PI - h
        TextBox4.Text = Math.Round(h * 180 / Math.PI)
        TextBox5.Text = Math.Round(s * 255)
        TextBox6.Text = Math.Round(i * 255)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim h, s, i, r, g, b, x, y, z As Decimal
        h = Val(TextBox4.Text) * Math.PI / 180
        s = Val(TextBox5.Text) / 255
        i = Val(TextBox6.Text) / 255
        x = i * (1 - s)
        If h < 2 * Math.PI / 3 Then
            y = i * (1 + ((s * Math.Cos(h)) / (Math.Cos(Math.PI / 3 - h))))
            z = 3 * i - (x + y)
            r = y : g = z : b = x
        ElseIf 2 * Math.PI / 3 <= h And h < 4 * Math.PI / 3 Then
            h = h - 2 * Math.PI / 3
            y = i * (1 + ((s * Math.Cos(h)) / (Math.Cos(Math.PI / 3 - h))))
            z = 3 * i - (x + y)
            r = x : g = y : b = z
        ElseIf 4 * Math.PI / 3 <= h And h < 2 * Math.PI Then
            h = h - 4 * Math.PI / 3
            y = i * (1 + ((s * Math.Cos(h)) / (Math.Cos(Math.PI / 3 - h))))
            z = 3 * i - (x + y)
            r = z : b = y : g = x
        End If
        TextBox1.Text = Math.Round(r * 255)
        TextBox2.Text = Math.Round(g * 255)
        TextBox3.Text = Math.Round(b * 255)
    End Sub
End Class
