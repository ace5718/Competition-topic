Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To 8
            Controls("textbox" & i).Text = ""
        Next
        Dim r As New Random
        For i = 1 To 8
            TextBox1.Text &= r.Next(0, 2)
            TextBox3.Text &= r.Next(0, 2)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox5.Text = ""
        Dim ans(8) As String
        For i = 8 To 1 Step -1
            ans(i) += Val(Mid(TextBox1.Text, i, 1)) + Val(Mid(TextBox3.Text, i, 1))
            If ans(i) > 1 Then ans(i - 1) += 1 : ans(i) -= 2
        Next
        For i = 1 To 8
            TextBox5.Text &= ans(i)
        Next

        If Mid(TextBox1.Text, 1, 1) = 1 And Mid(TextBox3.Text, 1, 1) = 1 AndAlso Mid(TextBox5.Text, 1, 1) = 0 Then
            TextBox7.Text = "underflow"
        ElseIf Mid(TextBox1.Text, 1, 1) = 0 And Mid(TextBox3.Text, 1, 1) = 0 AndAlso Mid(TextBox5.Text, 1, 1) = 1 Then
            TextBox7.Text = "overflow"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 1 To 5 Step 2
            Dim test As String = Controls("TextBox" & i).Text
            Controls("TextBox" & i + 1).Text = ten(test)
        Next

        If Mid(TextBox1.Text, 1, 1) = 1 And Mid(TextBox3.Text, 1, 1) = 1 AndAlso Mid(TextBox5.Text, 1, 1) = 0 Then
            TextBox8.Text = "不足位"
        ElseIf Mid(TextBox1.Text, 1, 1) = 0 And Mid(TextBox3.Text, 1, 1) = 0 AndAlso Mid(TextBox5.Text, 1, 1) = 1 Then
            TextBox8.Text = "溢位"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Function ten(test As String)
        Dim ans As Decimal
        test = StrReverse(test)
        For i = 1 To 7
            ans += Val(Mid(test, i, 1)) * 2 ^ (i - 1)
        Next
        test = StrReverse(test)
        Return IIf(Mid(test, 1, 1) = 0, ans, ans - 128)
    End Function


End Class
