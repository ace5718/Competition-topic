Public Class Form1
    Dim so() As String = {"B,P,F,V",
    "C,S,K,G,J,Q,X,Z",
    "D,T",
    "L",
    "M,N",
    "R"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str() As String = TextBox1.Text.Replace(vbCrLf, "!").Split("!")
        Dim ans As New ArrayList
        Dim b As New Integer
        For Each i In str
            Dim a As String = ""
            For j = 1 To Len(i)
                For k = 0 To 5
                    If so(k).IndexOf(Mid(i, j, 1)) <> -1 Then
                        If k + 1 <> b And Len(a) < 3 Then
                            If j <> 1 Then a &= k + 1
                            b = k + 1
                            Exit For
                        Else
                            b = 0
                        End If
                    End If
                Next
            Next
            ans.Add(a.PadRight(3, "0"))
        Next

        For i = 0 To str.Count - 1
            TextBox2.Text &= Mid(str(i), 1, 1) & ans(i) & vbCrLf
        Next

    End Sub
End Class
