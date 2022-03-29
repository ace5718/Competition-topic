Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = get_ans(TextBox1.Text)
    End Sub
    Function get_ans(t As String) As String
        Dim n As Integer = t.Count
        Dim k As New Integer
        Do Until 2 ^ k >= n + k + 1
            k += 1
        Loop
        t = StrReverse(t)
        For i = 0 To k - 1
            t = t.Insert(2 ^ i - 1, "0")
        Next
        Dim ar As New List(Of String)
        For i = 1 To t.Count
            If (Mid(t, i, 1) = "1") Then ar.Add(Convert.ToString(i, 2).PadLeft(4, "0"))
        Next
        Dim tt As String = ar(0)
        For Each i As String In ar.Skip(1)
            Dim yy As String = i
            For j = 1 To 4
                Mid(tt, j, 1) = Mid(tt, j, 1) Xor Mid(yy, j, 1)
            Next
        Next
        Dim a1 As Integer
        tt = StrReverse(tt)
        For i = 0 To k - 1
            a1 += 1
            Mid(t, 2 ^ i, 1) = Mid(tt, a1, 1)
        Next
        t = StrReverse(t)
        Return t
    End Function
End Class