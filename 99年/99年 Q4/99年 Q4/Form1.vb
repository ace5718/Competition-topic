Public Class Form1
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label1.Text = ""
        Dim r1 As Boolean = RadioButton1.Checked '正
        Dim r2 As Boolean = RadioButton2.Checked '反
        Dim c1 As Boolean = CheckBox1.Checked '中空
        Dim num As Integer = NumericUpDown1.Value
        Label1.Text &= "數值：" & num & vbCrLf
        If r1 Then
            Label1.Text &= "顯示方向：正向" & vbCrLf
            Label1.Text &= get_ans1(r1, c1, num)
        Else
            Label1.Text &= "顯示方向：反向" & vbCrLf
            Label1.Text &= get_ans2(r2, c1, num)
        End If
    End Sub
    Function get_ans1(p As Boolean, h As Boolean, n As Integer) As String '正
        Dim str As String
        If h Then
            For i = 1 To n Step 2
                str &= "＊"
                If i <> 1 And i <> n Then
                    For j = 1 To i - 2
                        str &= "　"
                    Next
                End If
                If i = n Then
                    For k = 1 To i - 1
                        str &= "＊"
                    Next
                ElseIf i <> 1 Then
                    str &= "＊"
                End If
                str &= vbCrLf
            Next
        Else
            For i = 1 To n Step 2
                For j = 1 To i
                    str &= "＊"
                Next
                str &= vbCrLf
            Next
        End If
        Return str
    End Function
    Function get_ans2(r As Boolean, h As Boolean, n As Integer) As String '反
        Dim str As String
        If h Then
            For i = n To 1 Step -2
                If i = n Then
                    For j = 1 To n
                        str &= "＊"
                    Next
                End If
                If i <> n Then
                    str &= "＊"
                    If i <> 1 And i <> n Then
                        For j = i - 2 To 1 Step -1
                            str &= "　"
                        Next
                    End If
                    If i <> n And i <> 1 Then str &= "＊"
                End If
                str &= vbCrLf
            Next
        Else
            For i = 1 To n Step 2
                For j = n To i Step -1
                    str &= "＊"
                Next
                str &= vbCrLf
            Next
        End If
        Return str
    End Function
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label1.Text = ""
    End Sub
End Class
