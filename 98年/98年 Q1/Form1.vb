Public Class Form1
    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button4.Click, Button2.Click, Button3.Click, Button1.Click
        Select Case sender.Text
            Case "Ld"
                If cheek() Then sender.Text = "Ih" Else sender.Text = "En"
            Case "En"
                sender.Text = "Ih"
            Case "Ih"
                sender.Text = "Ld"
        End Select
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ran As New Random
        For i = 1 To 4
            Controls("Button" & i).Text = "Ih"
            Controls("TextBox" & i).Text = ""
            For j = 1 To 8
                Controls("TextBox" & i).Text &= ran.Next(0, 2)
            Next
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If cheek() Then
            For i = 1 To 4
                If Controls("Button" & i).Text = "En" Then
                    For j = 1 To 4
                        If Controls("Button" & j).Text = "Ld" Then Controls("TextBox" & j).Text = Controls("TextBox" & i).Text
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        End
    End Sub
    Function cheek()
        For i = 1 To 4
            If Controls("Button" & i).Text = "En" Then Return True
        Next
        Return False
    End Function
End Class
