Public Class Form1
    Dim a As String() = {"09,12,33,47,53,67,78,92",
        "48,81",
        "13,41,62",
        "01,03,45,79",
        "14,16,24,44,46,55,57,64,74,82,87,98",
    "10,31",
    "06,25",
      "23,39,50,56,65,68",
      "32,70,73,83,88,93",
      "15"} 'A~J的值
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} 
        Dim ar As New ArrayList
        For Each i In TextBox1.Text.ToLower
            If i = "" Then MsgBox("請勿輸入超過A~J") : End
            If Asc(i) - 97 < 0 Or Asc(i) - 97 > 9 Then
                MsgBox("請勿輸入超過A~J") : End
            Else
                Dim n = Asc(i) - 97
                Dim t As String() = a(n).Split(",")
                ar.Add(t(g(n)))
                g(n) = (g(n) + 1) Mod t.Length
            End If
        Next
        TextBox2.Text = Join(ar.ToArray, " ")
    End Sub
End Class
