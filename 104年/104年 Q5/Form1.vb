Public Class Form1
    Dim t1(6, 6), t2(2, 2), t3(6, 6) As TextBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For x = 0 To 6
            For y = 0 To 6
                Dim ta, tb As New TextBox
                ta.Text = 0 : tb.Text = 0
                ta.TextAlign = HorizontalAlignment.Center
                ta.Size = New Size(30, 20)
                tb.TextAlign = HorizontalAlignment.Center
                tb.Size = New Size(30, 20)
                t1(x, y) = ta : t3(x, y) = tb
                FLP1.Controls.Add(t1(x, y))
                FLP3.Controls.Add(t3(x, y))
            Next
        Next
        For x = 0 To 2
            For y = 0 To 2
                Dim tc As New TextBox
                tc.Text = 0
                tc.TextAlign = HorizontalAlignment.Center
                tc.Size = New Size(30, 20)
                t2(x, y) = tc
                FLP2.Controls.Add(t2(x, y))
            Next
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        out_put()
        Dim MSE, MAE As New Decimal
        For y = 0 To 6
            For x = 0 To 6
                Dim a = t1(x, y).Text
                Dim b = t3(x, y).Text
                MSE += (a - b) ^ 2
                MAE += Math.Abs(a - b)
            Next
        Next
        TextBox1.Text = MSE / 49
        TextBox2.Text = MAE / 49
        TextBox3.Text = 10 * Math.Log10(255 * 255 / TextBox1.Text)
    End Sub
    Sub out_put()
        For x = 0 To 6
            For y = 0 To 6
                t3(x, y).Text = 0
            Next
        Next

        For y = 0 To 6
            For x = 0 To 6
                Dim a = t1(x, y).Text
                For y1 = -1 To 1
                    For x1 = -1 To 1
                        Try
                            Dim b = t2(x1 + 1, y1 + 1).Text
                            t3(x + x1, y + y1).Text += a * b
                        Catch ex As Exception
                        End Try
                    Next
                Next
            Next
        Next
    End Sub
End Class
