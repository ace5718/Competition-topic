Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            TextBox4.Text = "" : TextBox5.Text = ""
            Dim a As Integer = TextBox1.Text, b As Integer = TextBox2.Text, c As Integer = TextBox3.Text
            If a = 0 And b = 0 And c <> 0 Then
                TextBox4.Text = "無解"
            ElseIf a = 0 And b = 0 And c = 0 Then
                TextBox4.Text = "無限多組解"
            ElseIf a = 0 And b <> 0 Then
                TextBox4.Text = -c / b
                TextBox5.Text = "只有一解"
            ElseIf a <> 0 And b <> 0 Then
                Select Case (b ^ 2) - (4 * a * c)
                    Case = 0
                        TextBox4.Text = -b / (2 * a)
                        TextBox5.Text = "同根"
                    Case > 0
                        TextBox4.Text = ((-b) + Math.Sqrt(b ^ 2 - (4 * a * c))) / (2 * a)
                        TextBox5.Text = ((-b) - Math.Sqrt(b ^ 2 - (4 * a * c))) / (2 * a)
                    Case < 0
                        TextBox4.Text = Math.Round(-b / (2 * a), 2) & "+" & Math.Round(Math.Sqrt((4 * a * c) - (b ^ 2)) / (2 * a), 2) & "i"
                        TextBox5.Text = Math.Round(-b / (2 * a), 2) & "-" & Math.Round(Math.Sqrt((4 * a * c) - (b ^ 2)) / (2 * a), 2) & "i"
                End Select
            End If
            Label5.Text = String.Format("{0}X2 + {1}X + {2} = 0", a, b, c)
        End If
    End Sub
End Class
