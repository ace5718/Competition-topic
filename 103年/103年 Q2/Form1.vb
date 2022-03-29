Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            For Each i In My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName).Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim s = i.Split(" ")
                ListBox1.Items.Add(ListBox1.Items.Count & vbTab & s(0) & vbTab & s(1))
            Next
        End If
    End Sub
    Class node
        Public n, h, w, number As Integer
        Public Sub New(a%, b%, c%)
            n = a : w = b : h = c
        End Sub
    End Class
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 2 To 5
            CType(Controls("ListBox" & i), ListBox).Items.Clear()
        Next
        Dim tt As New List(Of node)
        get_tt(tt)
        get_ran_tt(tt)
        Dim a1, a2, a3 As node '分堆平均
        a1 = get_a(tt, 0) : a2 = get_a(tt, 1) : a3 = get_a(tt, 2)
        For i = 1 To 200
            Dim c As Integer
            For Each j In tt
                Dim d As New List(Of Decimal)
                d.Add(get_d(j, a1)) : d.Add(get_d(j, a2)) : d.Add(get_d(j, a3))
                If j.number <> Array.IndexOf(d.ToArray, d.Min) Then
                    j.number = Array.IndexOf(d.ToArray, d.Min)
                Else
                    c += 1
                End If
                If c = tt.Count Then Exit For
                a1 = get_a(tt, 0) : a2 = get_a(tt, 1) : a3 = get_a(tt, 2)
            Next
        Next
        For i = 0 To tt.Count - 1
            ans(tt(i).number, tt(i))
            ListBox2.Items.Add("第" & i & "筆屬於" & tt(i).number)
        Next
    End Sub

    Sub get_tt(tt As List(Of node))
        For Each i As String In ListBox1.Items
            Dim s() As String = i.Split(vbTab)
            tt.Add(New node(s(0), s(1), s(2)))
        Next
    End Sub
    Sub get_ran_tt(tt As List(Of node))
        tt(0).number = 0
        tt(1).number = 1
        tt(2).number = 2
        Dim r As New Random
        For Each i In tt.Skip(3)
            i.number = r.Next(0, 3)
        Next
    End Sub

    Function get_a(tt As List(Of node), s%) As node
        Dim a As New List(Of node)
        For Each i In tt
            If i.number = s Then a.Add(i)
        Next
        Dim h, w As Integer
        If a.Count = 0 Then Return New node(Nothing, 0, 0)
        For Each i In a
            h += i.h : w += i.w
        Next
        Return New node(Nothing, w / a.Count, h / a.Count)
    End Function
    Function get_d(x As node, a As node)
        Return Math.Sqrt((x.w - a.w) ^ 2 + (x.h - a.h) ^ 2)
    End Function

    Sub ans(n%, tt As node)
        Select Case n
            Case 0
                ListBox3.Items.Add(tt.n & vbTab & tt.w & vbTab & tt.h)
            Case 1
                ListBox4.Items.Add(tt.n & vbTab & tt.w & vbTab & tt.h)
            Case 2
                ListBox5.Items.Add(tt.n & vbTab & tt.w & vbTab & tt.h)
        End Select
    End Sub
End Class

