Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.ImageLocation = "Cola.PNG"
        PictureBox2.ImageLocation = "Diet Cola.PNG"
        PictureBox3.ImageLocation = "Diet PEPSO.PNG"
        PictureBox4.ImageLocation = "PEPSO.PNG"
    End Sub

    Private Sub PictureBox4_Click(sender As PictureBox, e As EventArgs) Handles PictureBox4.Click, PictureBox3.Click, PictureBox2.Click, PictureBox1.Click
        Select Case sender.TabIndex
            Case 0
                If TextBox1.Text >= 35 Then
                    Label5.Text &= If(Label5.Text = "", "送出 Cola ", ",送出 Cola ")
                    TextBox1.Text = TextBox1.Text - 35 & ".0"
                End If
            Case 1
                If TextBox1.Text >= 30 Then
                    Label5.Text &= If(Label5.Text = "", "送出 PEPSO ", ",送出 PEPSO ")
                    TextBox1.Text = TextBox1.Text - 30 & ".0"
                End If
            Case 2
                If TextBox1.Text >= 25 Then
                    Label5.Text &= If(Label5.Text = "", "送出 Diet Cola ", ",送出 Diet Cola ")
                    TextBox1.Text = TextBox1.Text - 25 & ".0"
                End If
            Case 3
                If TextBox1.Text >= 30 Then
                    Label5.Text &= If(Label5.Text = "", "送出 Diet PEPSO ", ",送出 Diet PEPSO ")
                    TextBox1.Text = TextBox1.Text - 30 & ".0"
                End If
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then : TextBox1.Text = TextBox1.Text + 5 & ".0"
        ElseIf RadioButton2.Checked Then : TextBox1.Text = TextBox1.Text + 10 & ".0"
        ElseIf RadioButton3.Checked Then : TextBox1.Text = TextBox1.Text + 50 & ".0"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "0.0" Then
            Label5.Text = ""
        Else
            Label5.Text &= String.Format("退還{0}元", TextBox1.Text)
            TextBox1.Text = "0.0"
        End If
    End Sub
End Class
