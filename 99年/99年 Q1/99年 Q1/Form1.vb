Public Class Form1
    '結束
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    '取亂數 36個0 4個1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        Dim ran As New Random
        TextBox1.Text = New String("0", 36)
        For i = 1 To 4
            TextBox1.Text = TextBox1.Text.Insert(ran.Next(1, Len(TextBox1.Text) + 1), "1")
        Next
    End Sub
    '計算
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        Dim ans$ = ""
        Dim arr As New List(Of String)
        For Each i In TextBox1.Text
            If i = "1" Then
                arr.Add(ans)
                ans = ""
            Else
                ans &= i
            End If
        Next
        For i = 0 To arr.Count - 1
            TextBox2.Text &= Convert.ToString(Len(arr(i)), 2) & " " '轉二進
        Next
        TextBox2.Text = TextBox2.Text.Remove(Len(TextBox2.Text) - 1, 1)
        TextBox3.Text = Len(TextBox2.Text) / Len(TextBox1.Text) * 100 & "%"
    End Sub
End Class
