Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inp As Integer = TextBox1.Text, base As Integer = TextBox2.Text
        Dim ans As String = ""
        Do
            ans &= convert(inp Mod base, base)
            inp = If(base < 0, Math.Ceiling(inp / base), Math.Floor(inp / base))
        Loop Until inp = 0
        TextBox3.Text = StrReverse(ans)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 3
            Controls("TextBox" & i).Text = ""
        Next
    End Sub
    Function convert(inp As Integer, base As Integer)
        Dim ans As Integer = inp
        If ans < 0 Then ans -= base
        If ans > 9 Then Return Chr(ans + 55)
        Return ans
    End Function
End Class
