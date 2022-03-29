Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim n As Integer = Val(InputBox("輸入N="))
        Select Case n
            Case < 13
                MsgBox("輸入過小") : End
            Case > 99
                MsgBox("輸入過大") : End
        End Select
        Dim m, k, s As New Integer
        Dim ar As New ArrayList
        Do
            Dim tf As Boolean
            ar.Clear()
            m += 1
            s = m - 1
            k = 0
            Do
                s += 1
                k += 1
                Do
                    If k > n Then k -= n
                    If ar.IndexOf(k) <> -1 Then s -= 1 : tf = False
                Loop Until tf = False
                If s = m Then ar.Add(k) : s = 0
            Loop Until ar.Count = n
        Loop Until ar(ar.Count - 1) = 13
        MsgBox("輸出M=" & m)
        Close()
    End Sub
End Class
