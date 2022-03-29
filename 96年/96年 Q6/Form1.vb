Public Class Form1
    Private Sub Button1_Click(sender As Object, ee As EventArgs) Handles Button1.Click
        Dim e As Integer = TextBox1.Text, n As Integer = TextBox2.Text : TextBox4.Text = ""
        For Each i In TextBox3.Text
            Dim m As Integer = Asc(i), r As Decimal = 1
            If m < 0 Then m += 65536
            For j = 1 To e
                r = (r * m) Mod n
            Next
            TextBox4.Text &= r
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim d As Integer = TextBox1.Text, n As Integer = TextBox2.Text : TextBox3.Text = ""
        For i = 1 To TextBox4.Text.Count Step 5
            Dim c As Integer = Val(Mid(TextBox4.Text, i, 5)), r As Decimal = 1
            For j = 1 To d
                r = (r * c) Mod n
            Next
            TextBox3.Text &= Chr(r)
        Next
    End Sub
End Class
