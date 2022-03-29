Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label61.Text = 0
        Dim k = 1
        For i = 1 To 37
            If Controls("GroupBox" & k).Contains(Controls("GroupBox" & k).Controls("TextBox" & i)) Then
                Dim a As Integer = Val(Controls("GroupBox" & k).Controls("TextBox" & i).Text)
                Dim b As Integer = Val(Controls("GroupBox" & k).Controls("NumericUpDown" & i).Text)
                Label61.Text += a * b
            Else
                i -= 1 : k += 1
            End If
        Next
        Label61.Text += CInt(Val(Label61.Text) * 0.5)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label61.Text = "等待客人點餐中"
        Dim k = 1
        For i = 1 To 37
            If Controls("GroupBox" & k).Contains(Controls("GroupBox" & k).Controls("TextBox" & i)) Then
                Controls("GroupBox" & k).Controls("NumericUpDown" & i).Text = 0
            Else
                i -= 1 : k += 1
            End If
        Next
    End Sub
End Class
