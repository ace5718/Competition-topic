Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Decimal = TextBox1.Text, b As Decimal = TextBox2.Text, c As Decimal = TextBox3.Text
        Dim ans As Decimal = 1
        For i = 1 To b
            ans = (ans * a) Mod c
        Next
        TextBox4.Text = ans
    End Sub
End Class
