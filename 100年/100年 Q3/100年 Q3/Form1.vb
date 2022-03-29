Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox1.Text = "" Then
            MsgBox("請輸入時間")
        ElseIf TextBox1.Text > "60" Or TextBox2.Text > "60" Then
            MsgBox("輸入的時間超過")
        ElseIf TextBox1.Text < "0" Or TextBox2.Text < "0" Then
            MsgBox("輸入的時間過小")
        Else
            Timer1.Enabled = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text = 0 And TextBox2.Text = 0 Then
            Timer1.Enabled = False
            MsgBox("時間到了")
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        Else
            If TextBox2.Text = 0 Then
                If TextBox1.Text > 0 Then
                    TextBox1.Text -= 1
                    TextBox2.Text = 59
                End If
            Else
                TextBox2.Text -= 1
            End If
        End If
    End Sub
End Class
