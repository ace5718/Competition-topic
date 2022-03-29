Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str() As String = TextBox1.Text.Split(" ")
        Dim level As Integer
        Select Case Val(str(0))
            Case < 50
                level += 1
            Case 50 To 100
                level += 2
            Case > 101
                level += 3
        End Select
        Select Case Val(str(1))
            Case < 100
                level += 1
            Case 100 To 200
                level += 2
            Case > 200
                level += 3
        End Select
        Dim s As Integer = ((Val(str(0)) + Val(str(1))) / 2) * 5
        If level = 2 Then
            TextBox2.Text = s * 0.6
        ElseIf level = 3 Then
            TextBox2.Text = s * 0.8
        ElseIf level = 6 Then
            TextBox2.Text = s + s * 0.4
        ElseIf level = 5 Then
            TextBox2.Text = s + s * 0.2
        Else
            TextBox2.Text = s
        End If
    End Sub
End Class
