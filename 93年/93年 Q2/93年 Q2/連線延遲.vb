Public Class 連線延遲
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As String() = TextBox1.Text.Split(" ")
        Dim str As String
        For Each i In t(2)
            If i <> "p" Then
                str &= i
            Else
                t(2) = str
            End If
        Next
        If t(0) < 0 Or t(1) < 200 Or t(2) < 0.4 Then TextBox2.Text = "輸入數值錯誤" : Exit Sub
        Select Case t(0)
            Case > 0
                TextBox2.Text = (350 + (t(1) / 2)) * ((t(2) / 2) + (t(0) * 0.04)) + 350 + ((350 / t(0)) + (t(1) / 2)) * ((t(2) / 2) + 0.2) & "ps"
            Case = 0
                TextBox2.Text = (350 + t(1)) * (0.2 + t(2)) & "ps"
        End Select

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
