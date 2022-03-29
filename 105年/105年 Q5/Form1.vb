Public Class Form1
    Dim ha_num As New HashSet(Of Integer)
    Dim ar As New List(Of node)
    Class node
        Public right, left As node
        Public value As Integer
        Public Sub New(a As Integer)
            value = a
        End Sub
    End Class '樹狀結構
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ran As New Random
        Dim ha_str As New HashSet(Of Integer)
        ha_num.Clear() : text_clear()
        Do Until ha_num.Count > 4 And ha_str.Count > 4
            ha_num.Add(ran.Next(1, 1000)) : ha_str.Add(ran.Next(97, 123))
        Loop
        For i = 1 To 4
            Controls("TextBox" & i).Text = Chr(ha_str(i - 1)) : Controls("TextBox" & i + 4).Text = ha_num(i - 1)
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim total As New Integer
        ha_num.Clear() : ar.Clear()
        For i = 5 To 8
            ha_num.Add(Controls("TextBox" & i).Text)
        Next
        arr(ha_num) : Hoffman(ar(0), total, 0)
        TextBox9.Text = Traditional(ha_num)
        TextBox10.Text = total
        TextBox11.Text = Format(Val(TextBox9.Text) / total, "0.####")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Sub text_clear()
        For i = 9 To 11
            Controls("TextBox" & i).Text = ""
        Next
    End Sub

    Function Traditional(ha_num As HashSet(Of Integer))
        Dim total As New Integer
        For i = 0 To 3
            total += ha_num(i)
        Next
        Return total * 2
    End Function '傳統編碼

    Sub arr(ha As HashSet(Of Integer))
        For i = 0 To ha.Count - 1
            ar.Add(New node(ha(i)))
        Next
        While ar.Count > 1
            ar = ar.OrderBy(Function(n) n.value).ToList
            Dim c As New node(ar(0).value + ar(1).value)
            c.left = ar(0)
            c.right = ar(1)
            ar.RemoveAt(1)
            ar.RemoveAt(0)
            ar.Add(c)
        End While '精華
    End Sub  '結構化
    Sub Hoffman(ByVal ar As node, ByRef total%, ByRef b%)
        If Not IsNothing(ar.right) Then
            Hoffman(ar.right, total, b + 1)
        End If
        If Not IsNothing(ar.left) Then
            Hoffman(ar.left, total, b + 1)
        End If
        If IsNothing(ar.right) And IsNothing(ar.left) Then
            total += ar.value * b
        End If
    End Sub '霍夫曼編碼


End Class
