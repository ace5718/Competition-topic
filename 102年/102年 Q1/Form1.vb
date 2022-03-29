Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim te1(5, 5) As Integer, LC(2, 2) As Integer
        Dim p As Point = New Point(Val(TextBox46.Text), Val(TextBox47.Text))
        Dim x, y, total As New Integer
        For i = 1 To 36
            If GroupBox1.Controls("TextBox" & i).Text <> "" And GroupBox1.Controls("TextBox" & i).Text > 0 Then
                If y Mod 6 <> 0 Or y = 0 Then te1(x, y) = Val(GroupBox1.Controls("TextBox" & i).Text) : y += 1 Else x += 1 : y = 0 : i -= 1
            Else
                Exit Sub
            End If
        Next

        x = 0 : y = 0

        For i = 37 To 45
            If GroupBox2.Controls("TextBox" & i).Text <> "" AndAlso Mid(Convert.ToString(CInt(GroupBox2.Controls("TextBox" & i).Text), 2), 1, 1) = 1 Or x = 1 And y = 1 Then
                If y Mod 3 <> 0 Or y = 0 Then LC(x, y) = Val(GroupBox2.Controls("TextBox" & i).Text) : y += 1 Else x += 1 : y = 0 : i -= 1
            Else
                Exit Sub
            End If
        Next

        For x = 0 To 2
            For y = 0 To 2
                If New Point(x + p.X, y + p.Y) <> New Point(p.X + 1, p.Y + 1) AndAlso (te1(x + p.X, y + p.Y) - te1(p.X + 1, p.Y + 1)) * LC(x, y) >= 0 Then
                    total += LC(x, y)
                End If
            Next
        Next

        TextBox48.Text = total
        'Stop
    End Sub
End Class
