Public Class Form1
    Class node
        Public start, ending, cost As Integer
        Public Sub New(a%, b%, c%)
            start = a : ending = b : cost = c
        End Sub
    End Class
    Class answer
        Public total As Integer
        Public path, con As String
        Public Sub New(a%, b$, c$)
            total = a : path = b : con = c
        End Sub
    End Class
    Dim sc As New List(Of node), ans As New List(Of answer)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim min, max As New Integer
        sc.Clear() : ans.Clear()
        For Each i In TextBox1.Text.Replace(vbCrLf, "!").Split("!")
            sc.Add(New node(i.Split(" ")(0), i.Split(" ")(1), i.Split(" ")(2)))
        Next
        sc = sc.OrderBy(Function(n) n.start).ToList
        min = sc(0).start : max = sc(sc.Count - 1).ending
        DFS(min, max, 0, sc(0).start, 0)
        ans = ans.OrderBy(Function(n) n.total).ToList
        TextBox2.Text = String.Format("最低成本總和值：{0}" & vbCrLf & "路徑次序：{1}" & vbCrLf & "連線數值 :{2}", ans(0).total, ans(0).path, ans(0).con)
    End Sub

    Sub DFS(min%, max%, total%, path$, con$)
        If min = max Then
            ans.Add(New answer(total, path, con))
        Else
            For Each i In sc
                If i.start = min Then DFS(i.ending, max, total + i.cost, path & " " & i.ending, con & " " & i.cost)
            Next
        End If
    End Sub
End Class
