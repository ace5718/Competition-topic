Public Class Form1
    Class node
        Public te1, te2, total As Integer?
        Public str As String
        Public number As Integer
        Public Sub New(a%, b%, c%, d$, e%)
            te1 = a : te2 = b : total = c : str = d : number = e
        End Sub
    End Class
    Class answer
        Public total As Integer
        Public str As String
        Public Sub New(a%, b$)
            total = a : str = b
        End Sub
    End Class

    Private Sub Num1_TextChanged(sender As Object, e As EventArgs) Handles num1.TextChanged
        If num1.Text <> "" AndAlso (num1.Text >= 3 And num1.Text <= 10) Then
            Dim num As Integer = num1.Text
            GroupBox1.Text = String.Format("請輸入m1~m{0}的矩陣大小<維度>", num)
            For i = 1 To 10
                GroupBox1.Controls("TextBox" & i * 2 - 1).Visible = If(i <= num, True, False)
                GroupBox1.Controls("TextBox" & i * 2).Visible = If(i <= num, True, False)
                GroupBox1.Controls("Label" & i).Visible = If(i <= num, True, False)
                GroupBox1.Controls("Label" & i).Text = String.Format("m{0}的矩陣大小：", i, Nothing)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If num1.Text <> "" AndAlso (num1.Text >= 3 And num1.Text <= 10) Then
            Dim ans As New List(Of answer)
            Dim chk_num As New Integer
            Dim chk2_num As New Integer
            Do
                chk_num += 1
                Dim sc As New List(Of node)
                input_data(sc)
                Dim chk As String() = sort_num(chk_num, num1.Text)
                sc = sort_sc(sc, chk)
                Do
                    Dim tf As Boolean = False
                    Dim min = Integer.MaxValue, num = 0
                    For i = 0 To sc.Count - 2
                        If (sc(i).te2 = sc(i + 1).te1) AndAlso (sc(i).te1 * sc(i + 1).te1 * sc(i + 1).te2 < min) Then
                            tf = True
                            min = sc(i).te1 * sc(i + 1).te1 * sc(i + 1).te2
                            num = i
                        End If
                    Next
                    If tf Then
                        sc(num) = New node(sc(num).te1, sc(num + 1).te2, min + sc(num).total + sc(num + 1).total, String.Format("<{0} {1}>", sc(num).str, sc(num + 1).str), 0)
                        sc.RemoveAt(num + 1)
                        chk2_num = 1
                    Else
                        chk2_num += 1
                        Dim chk2 As String() = sort_num(chk2_num, sc.Count)
                        sc = sort_sc(sc, chk2)
                    End If
                Loop Until sc.Count = 1 Or chk2_num > num1.Text
                ans.Add(New answer(sc(sc.Count - 1).total, sc(sc.Count - 1).str))
            Loop Until chk_num = num1.Text
            ans = ans.OrderBy(Function(x) x.total).ToList
            ans1.Text = "矩陣相乘的次序為：" & ans(0).str
            ans2.Text = "最少的乘法運算次數：" & ans(0).total
        End If
    End Sub

    Function sort_num(num As Integer, n As Integer)
        Dim str As New List(Of String)
        For i = 0 To n - 1
            str.Add(If(num + i > n, num + i - n, num + i) & " ")
        Next
        Return str.ToArray
    End Function

    Function sort_sc(sc As List(Of node), chk As String())
        Dim test_sc As New List(Of node)
        Dim num As New Integer
        For i = 0 To sc.Count - 1
            sc(i).number = i + 1
        Next
        Do
            For i = 0 To sc.Count - 1
                If sc(i).number = chk(num) Then
                    test_sc.Add(sc(i))
                    sc.RemoveAt(i)
                    num += 1
                    Exit For
                End If
            Next
        Loop Until sc.Count = 0
        Return test_sc
    End Function

    Sub input_data(sc As List(Of node))
        For i = 1 To Val(num1.Text)
            If GroupBox1.Controls("TextBox" & i * 2 - 1).Text > 100 Or GroupBox1.Controls("TextBox" & i * 2).Text > 100 Then
                MsgBox("輸入錯誤") : Exit Sub
            Else
                sc.Add(New node(GroupBox1.Controls("TextBox" & i * 2 - 1).Text, GroupBox1.Controls("TextBox" & i * 2).Text, 0, "m" & i, i))
            End If
        Next
    End Sub
End Class
