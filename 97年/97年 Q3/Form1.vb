Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ar As New List(Of Single)
        Dim real As String = TextBox1.Text
        If Val(real) < 0 Then real = Val(real) * -1 : ar.Add(1) Else ar.Add(0)
        Dim t As String = ""
        For Each i In real.ToString & " "
            If IsNumeric(i) Then t &= i Else ar.Add(CSng(t)) : t = ""
        Next
        t = ar(0) & Convert.ToString(CInt(ar(1)), 2).PadLeft(15, "0") & "." & get_ans(ar(2))
        If t.Count > 25 Then TextBox2.Text = "Overflow" Else TextBox2.Text = t
    End Sub
    Function get_ans(t As Single)
        t = CSng("0." & t)
        Dim s As String = ""
        Do Until t = 0 Or s.Count > 8
            t *= 2
            If t >= 1 Then s &= 1 : t -= 1 Else s &= 0
        Loop
        Return s.PadRight(8, "0")
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
