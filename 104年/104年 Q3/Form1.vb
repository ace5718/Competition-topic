Public Class Form1
    Dim r As New Random
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To 4
            Controls("TextBox" & i).Text = ""
        Next
        TextBox1.Text = r.Next(0, 2)
        For i = 1 To 8
            TextBox2.Text &= r.Next(0, 2)
        Next
        For i = 1 To 23
            TextBox3.Text &= r.Next(0, 2)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As Decimal = Convert.ToInt32(TextBox2.Text, 2) - 127
        If a > 0 Then
            Dim b As String = Mid(1 & TextBox3.Text, 1, a + 1)
            Dim c As String = Mid(1 & TextBox3.Text, a + 2, TextBox3.Text.Count)
            Dim d As Decimal
            b = Convert.ToInt32(b, 2)
            For i = 1 To c.Count
                d += Val(Mid(c, i, 1)) * 2 ^ -i
            Next
            TextBox4.Text = IIf(TextBox1.Text = 1, "-" & Val(b) + d, Val(b) + d)
        Else
            Dim b As String = 1 & TextBox3.Text
            b = b.PadLeft(Math.Abs(a) + b.Count - 1, "0")
            Dim c As Decimal

            For i = 1 To b.Count
                If Mid(b, i, 1) = 1 Then c += Mid(b, i, 1) * 2 ^ -i
            Next

            If c <> 0 Then TextBox4.Text = IIf(TextBox1.Text = 1, "-" & Mid(c, 1, 12), Mid(c, 1, 12)) Else TextBox4.Text = c
        End If
    End Sub
End Class
