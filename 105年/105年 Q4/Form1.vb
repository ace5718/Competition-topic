Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            arrange()
        End If
    End Sub
    Sub arrange() '整理        
        Dim d As New Dictionary(Of String, Integer)
        For Each i In TextBox1.Text
            If i = "：" Then Continue For
            If d.ContainsKey(i) Then d.Item(i) += 1 Else d.Add(i, 1)
        Next
        Dim sp = d.OrderByDescending(Function(n) n.Value).ToArray(0).Key
        Dim a = Regex.Replace(TextBox1.Text.Replace(vbCrLf, "").Replace("  ", " ").Replace("：：", "："), "((\w+):(\w+))", "\w : \w").Split(sp)
        Dim ar As New ArrayList

        For i = 0 To a.Count - 1
            If a(i).Contains("：") Then
                If (count(a(i), "?") > 1) Then a(i) = a(i).Replace(New String("?", count(a(i), "?")), "")
                ar.Add(a(i))
            Else
                Dim str As String = a(i)
                While i + 1 <> a.Count AndAlso Not (a(i + 1).Contains("："))
                    i += 1 : str &= " " & a(i) & " "
                End While
                ar(ar.Count - 1) &= str
            End If
        Next
        TextBox2.Text = Join(ar.ToArray, vbCrLf)
    End Sub
    Function count(ByVal str, ByVal spar)
        Return str.split(spar).length - 1
    End Function
End Class
