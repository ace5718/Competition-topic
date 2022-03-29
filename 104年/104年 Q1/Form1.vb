Public Class Form1
    Dim num As String
    Dim la(3, 3) As Label

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim n As Integer = 1
        For y = 0 To 3
            For x = 0 To 3
                la(y, x) = Controls("Label" & n)
                n += 1
            Next
        Next
    End Sub

    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button7.Click
        num = sender.Text
    End Sub

    Private Sub Label_Click(sender As Label, e As EventArgs) Handles Label1.Click, Label2.Click, Label3.Click, Label4.Click, Label5.Click, Label6.Click, Label7.Click, Label8.Click, Label9.Click, Label10.Click, Label11.Click, Label12.Click, Label13.Click, Label14.Click, Label15.Click, Label16.Click
        sender.Text = num
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For i = 0 To 3
            Dim chk, chk2 As New Integer
            For j = 0 To 3
                If IsNumeric(la(i, j).Text) Then chk += Val(la(i, j).Text) Else Label17.Text = "錯誤" : Exit Sub
                If IsNumeric(la(j, i).Text) Then chk2 += Val(la(i, i).Text) Else Label17.Text = "錯誤" : Exit Sub
            Next
            If chk <> 10 And chk2 <> 10 Then Label17.Text = "錯誤" : Exit Sub
        Next

        For y = 0 To 2 Step 2
            Dim chk As Integer
            For x = 0 To 2 Step 2
                chk = Val(la(y, x).Text) + Val(la(y, x + 1).Text) + Val(la(y + 1, x).Text) + Val(la(y + 1, x + 1).Text)
                If chk <> 10 Then Label17.Text = "錯誤" : Exit Sub
            Next
        Next
        Label17.Text = "正確"
    End Sub '檢查

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click '提示
        For y = 0 To 3
            For x = 0 To 3
                If Not IsNumeric(la(y, x).Text) Then
                    Dim n As New List(Of String) : num1(n)
                    For i = 0 To 3
                        If IsNumeric(la(y, i).Text) Then n.Remove(la(y, i).Text)
                        If IsNumeric(la(i, x).Text) Then n.Remove(la(i, x).Text)
                    Next
                    For i = 0 To 1
                        For j = 0 To 1
                            If IsNumeric(la((y \ 2) * 2 + i, (x \ 2) * 2 + j).Text) Then n.Remove(la((y \ 2) * 2 + i, (x \ 2) * 2 + j).Text)
                        Next
                    Next
                    la(y, x).Text = Join(n.ToArray, ",")
                End If
            Next
        Next
    End Sub '提示

    Sub num1(n As List(Of String))
        For i = 1 To 4
            n.Add(i)
        Next
    End Sub
End Class
