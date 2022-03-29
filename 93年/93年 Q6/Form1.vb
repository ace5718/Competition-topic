Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNumeric(TextBox1.Text) OrElse TextBox1.Text > 16 Or TextBox1.Text < 2 Then MsgBox("輸入錯誤") : Exit Sub
        Dim tf As Boolean = (TextBox2.Text.IndexOf(".") <> -1)
        TextBox3.Text = If(tf, b(TextBox2.Text.Split("."), Val(TextBox1.Text)), a(TextBox2.Text, Val(TextBox1.Text)))
    End Sub

    Function a(str As String, num As Integer)
        Dim ans As New Integer
        For i = 0 To str.Count - 1
            Dim m As String = If(IsNumeric(Mid(str, str.Count - i, 1)), Mid(str, str.Count - i, 1), Asc(Mid(str, str.Count - i, 1)) - 55)
            If m > TextBox1.Text Then Return "輸入錯誤" Else ans += m * num ^ i
        Next
        Return ans
    End Function

    Function b(str As String(), num As Integer)
        Dim ans As Single = a(str(0), num)
        For i = 1 To str(1).Count
            Dim m As String = If(IsNumeric(Mid(str(1), i, 1)), Mid(str(1), i, 1), Asc(Mid(str(1), i, 1)) - 55)
            If m > TextBox1.Text Then Return "輸入錯誤" Else ans += m * num ^ (i * -1)
        Next
        Return ans
    End Function
End Class
