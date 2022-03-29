Public Class 自由落體
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = ""
        Dim str() As String = TextBox1.Text.Split(" ")
        Dim h, s As Integer
        Dim arr As New ArrayList
        arr.Add(Val(str(0)))
        h = 1 : s = 0
        Do Until h = 0
            Dim ans As Integer = arr(s) \ 2 - (Val(str(1) \ 5))
            TextBox2.Text &= arr(s) & " "
            If ans <= 0 Then h = 0
            arr.Add(ans)
            s += 1
        Loop
        TextBox2.Text &= "0" & " " & arr.Count - 2
    End Sub
End Class
