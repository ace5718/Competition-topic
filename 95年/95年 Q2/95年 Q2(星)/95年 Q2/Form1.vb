Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = TextBox1.Text
        Dim n As Integer = str.Count
        If n > 11 Then TextBox2.Text = "欲傳遞訊號的長度不超過11位元" : Exit Sub
        For Each i In str
            If i <> "1" And i <> "0" Then TextBox2.Text = "欲傳遞訊息的值應是0或1" : Exit Sub
        Next
        Dim k As Integer
        Do Until 2 ^ k >= n + k + 1
            k += 1
        Loop
        str = StrReverse(str)
        For i = 0 To k - 1
            str = str.Insert(2 ^ i - 1, "0")
        Next
        Dim s As New List(Of String)
        For i = 1 To str.Count
            If Mid(str, i, 1) = "1" Then s.Add(Convert.ToString(i, 2).PadLeft(4, "0"))
        Next
        Dim t As String = s(0)
        For Each i As String In s.Skip(1)
            For j = 1 To 4
                Mid(t, j, 1) = Mid(t, j, 1) Xor Mid(i, j, 1)
            Next
        Next
        t = StrReverse(t)
        Dim g As Integer
        For i = 0 To k - 1
            g += 1
            Mid(str, 2 ^ i, 1) = Mid(str, 2 ^ i, 1).Replace(Mid(str, 2 ^ i, 1), Mid(t, g, 1))
        Next
        str = StrReverse(str)
        TextBox2.Text = str

    End Sub
End Class
