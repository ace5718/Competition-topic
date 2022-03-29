Public Class Form1
    Dim ran As New Random
    Dim str() As String = {"KB", "MB", "GB", "TB"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        re()
        TextBox1.Text = ran.Next(16, 53)
        TextBox2.Text = ran.Next(1, 9) & "B"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As Integer = TextBox1.Text, b As Integer = TextBox2.Text.Replace("B", "")
        Dim c = (2 ^ (a Mod 10)) * b
        a = a \ 10 - 1
        If a > 3 Then a -= 1 : c *= 1024
        TextBox3.Text = c & str(a)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        re()
        TextBox5.Text = ran.Next(1, 9) & "B"
        TextBox6.Text = ran.Next(512, 32769) & str(ran.Next(0, 4))
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a = Array.IndexOf(str, Mid(TextBox6.Text, TextBox6.Text.Count - 1, 2)) + 1
        Dim b = Math.Log(Val(TextBox6.Text.Replace(Mid(TextBox6.Text, TextBox6.Text.Count - 1, 2), "")) / Val(TextBox5.Text)) / Math.Log(2)
        a += b \ 10
        TextBox4.Text = Math.Round(Val(a & (b Mod 10)))
    End Sub
    Sub re()
        For i = 1 To 6
            Controls("TextBox" & i).Text = ""
        Next
    End Sub
End Class
