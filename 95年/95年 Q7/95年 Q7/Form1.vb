Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r, c, f, frc As Decimal
        r = TextBox1.Text : c = TextBox2.Text : f = TextBox3.Text
        frc = 2 * Math.PI * f * r * c
        TextBox4.Text = Math.Round(20000 * Math.Log10(1 / Math.Sqrt(1 + frc ^ 2))) / 1000 & "dB"
        TextBox5.Text = Math.Round(-1000 * Math.Atan(frc) * 180 / Math.PI) / 1000
    End Sub
End Class
