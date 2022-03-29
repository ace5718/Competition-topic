Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 4
            Controls("num" & i).Visible = False
        Next
        Label4.Visible = False
        Label6.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim r As New Random
        Dim n As Integer = r.Next(1, 10)
        TextBox1.Text = n & r.Next(1, 10)
        TextBox2.Text = n & r.Next(1, 10)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 3
            Controls("TextBox" & i).Text = ""
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(TextBox1.Text) * Val(TextBox2.Text) = Val(TextBox3.Text) Then
            Label4.Visible = True
        Else
            For i = 1 To 4
                Controls("num" & i).Visible = True
            Next
            Dim a, b, c, d As Integer
            a = Val(TextBox1.Text) + Val(Mid(TextBox2.Text, 2, 1))
            b = a * 10
            c = Mid(TextBox1.Text, 2, 1) * Mid(TextBox2.Text, 2, 1)
            d = b + c

            num1.Text = "(1)" & TextBox1.Text & "＋" & Mid(TextBox2.Text, 2, 1) & "＝" & a
            num2.Text = "(2)" & Val(TextBox1.Text) + Val(Mid(TextBox2.Text, 2, 1)) & "X" & "10＝" & b
            num3.Text = "(3)" & Mid(TextBox1.Text, 2, 1) & "X" & Mid(TextBox2.Text, 2, 1) & "＝" & c
            num4.Text = "(4)" & b & "＋" & c & "＝" & d
        End If
    End Sub
End Class
