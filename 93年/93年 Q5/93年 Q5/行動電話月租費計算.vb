Public Class 行動電話月租費計算
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        input1.Text = ""
        output1.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        output1.Text = ""
        Dim str() As String = input1.Text.Split(" ")
        Select Case str(0)
            Case 1
                output1.Text = get_ans1(str(1))
            Case 2
                output1.Text = get_ans2(str(1))
            Case 3
                output1.Text = get_ans3(str(1))
        End Select
    End Sub
    Function get_ans1(ByVal a As Integer) As Integer
        Dim ans As Integer
        ans = 600 + (a * 5)
        Return ans
    End Function
    Function get_ans2(ByVal b As Integer) As Integer
        Dim ans As Integer
        ans = ((b * 60) * 0.15) - 200
        Return ans
    End Function
    Function get_ans3(ByVal c As Integer) As Integer
        Dim ans As Integer
        ans = (((c * 60) - 300) * 0.2) - 66
        Return ans
    End Function
End Class
