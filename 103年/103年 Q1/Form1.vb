Public Class Form1
    Dim x, y, z, a, b, c As Decimal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        d()
        If chk(x, y, z, a, b, c) Then Exit Sub
        TextBox7.Text = "在台北市的上班族遲到的機率為：" & x * a + y * b + z * c
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        d()
        If chk(x, y, z, a, b, c) Then Exit Sub
        TextBox7.Text = "如果已知有一個人上班遲到，那他是自己開車的機率為：" & (z * c) / (x * a + y * b + z * c)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Sub d()
        x = TextBox1.Text : y = TextBox2.Text : z = TextBox3.Text : a = TextBox4.Text : b = TextBox5.Text : c = TextBox6.Text
    End Sub

    Function chk(x@, y@, z@, a@, b@, c@) As Boolean
        If (x + y + z) <> 1 Then Return True
        For i = 1 To 6
            Dim t As Decimal = Controls("TextBox" & i).Text
            If t < 0 Or t > 1 Then Return True
        Next
        Return False
    End Function
End Class
