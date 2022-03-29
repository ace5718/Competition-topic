Public Class Form1
    Dim Er As New Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Er < 2 Then
            If IsNumeric(TextBox1.Text) And Val(TextBox1.Text) > 0 And Val(TextBox1.Text) < 11 Then
                Er = 0
                Dim s = Val(TextBox1.Text)
                For i = 0 To s - 1
                    For l = 1 To s - i
                        TextBox2.Text &= " "
                    Next
                    TextBox2.Text &= s - i
                    For j = 1 To i
                        TextBox2.Text &= " 1"
                    Next
                    TextBox2.Text &= vbCrLf
                Next
                Exit Sub
            End If
            Er += 1
        Else
            Label2.Visible = True
            TextBox1.ForeColor = Color.Red
            If TextBox1.Text = "***" Then
                Label2.Visible = False
                TextBox1.ForeColor = Color.Black
                Er = 0
            Else
                TextBox1.Text = "???"
            End If
        End If
    End Sub
End Class
