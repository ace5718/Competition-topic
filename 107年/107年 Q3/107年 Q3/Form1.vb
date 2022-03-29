Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim n As String = InputBox("請輸入密碼：")
        Dim BE, SE, NUM, STR, CHK As Integer
        Dim ans As String
        For Each i In n
            Select Case i
                Case "A" To "Z"
                    BE += 1
                Case "a" To "z"
                    SE += 1
                Case "0" To "9"
                    NUM += 1
                Case "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "="
                    STR += 1
            End Select
        Next
        If BE > 0 Then CHK += 1 : If SE > 0 Then CHK += 1 : If STR > 0 Then CHK += 1 : If NUM > 0 Then CHK += 1
        If (CHK > 2 And n.Count >= 8 And n.Count <= 128) Then ans = "符合密碼規則" Else ans = "不符合密碼規則"
        MsgBox("密碼長度：" & n.Count & vbCrLf & "大寫英文字母長度：" & BE & vbCrLf & "小寫英文字母長度：" & SE & vbCrLf & "數字長度：" & NUM & vbCrLf & "符號長度：" & STR & vbCrLf & ans)
        Close()

    End Sub
End Class
