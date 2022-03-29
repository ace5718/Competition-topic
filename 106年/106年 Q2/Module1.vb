Module Module1
    Class node1
        Public ans_ti As New ArrayList '時間
        Public ans_na As New ArrayList '執行哪個

        Public Sub New()
            Me.ans_na = ans_na
            Me.ans_ti = ans_ti
        End Sub
    End Class '答案
    Class node2
        Public p_num As Integer '正在執行的行程跑的時間
        Public p_chk As Boolean '能否繼續跑
        Public ans_wa As Integer '等待時間
        Public Sub New(p_num As Integer, p_chk As Boolean, ans_wa As Integer)
            Me.p_num = p_num
            Me.p_chk = p_chk
            Me.ans_wa = ans_wa
        End Sub
    End Class '判斷
    Sub Main()
        Dim sc As New List(Of node1)
        Dim sc2 As New List(Of node2)
        Console.Write("請輸入行程processes數量(MAX 5)：")
        Dim pr As Integer = Console.ReadLine()
        If pr > 5 Then MsgBox("輸入數字過大") : End
        Console.WriteLine("")

        Console.WriteLine("請輸入每個行程的執行時間burst_time...")
        Dim p As New List(Of Integer)
        For i = 1 To pr
            Console.Write("P" & i & "：")
            p.Add(Console.ReadLine)
        Next
        Dim pn(p.Count - 1) As Integer
        Console.WriteLine("")

        Console.Write("請輸入時間配額time_quantum：")
        Dim ti As Integer = Console.ReadLine
        For i = 0 To p.Count - 1
            sc2.Add(New node2(i + 1, True, 0))
        Next
        get_ans2(ti, p, sc, sc2, pn)
        Console.WriteLine("")

        Console.WriteLine("個行程processes執行順序為...")
        For i = 0 To sc.Count - 1
            Console.Write(sc(i).ans_ti(0) & ":P" & sc(i).ans_na(0) & "  ")
        Next
        Console.WriteLine(p.Sum)
        Console.WriteLine("")

        For i = 0 To p.Count - 1
            Console.Write("P" & i + 1 & "等待時間：" & sc2(i).ans_wa & "  ")
        Next
        Console.Read()
    End Sub
    Sub get_ans(sc As List(Of node1), sc2 As List(Of node2), pnn As Integer, num As Integer)
        sc.Add(New node1())
        sc(sc.Count - 1).ans_na.Add(sc2(pnn).p_num)
        sc(sc.Count - 1).ans_ti.Add(Format(num, "00"))
    End Sub
    Sub get_ans2(ti As Integer, p As List(Of Integer), sc As List(Of node1), sc2 As List(Of node2), pn As Integer())
        Dim tin As New Integer '計時數
        Dim num As Integer = 0 '現在第幾圈
        Dim pnn As New Integer '第幾個行程
        Dim f As Boolean = True

        Do
            tin += 1

            If tin = ti Or f = True Then

                If f = True Then tin -= 1 : f = False
                If pn(pnn) = p(pnn) Then sc2(pnn).p_chk = False
                If tin <> 0 Then pnn += 1
                Do
                    If pnn > p.Count - 1 Then pnn -= p.Count
                    If sc2(pnn).p_chk = True Then
                        get_ans(sc, sc2, pnn, num)
                        tin = 0
                    Else
                        pnn += 1
                    End If
                Loop Until tin = 0
            End If

            If p(pnn) <> pn(pnn) And sc2(pnn).p_chk = True Then
                pn(pnn) += 1
            Else
                If sc2(pnn).p_chk = True Then
                    sc2(pnn).p_chk = False
                    pnn += 1
                    If pnn > p.Count - 1 Then pnn -= p.Count
                    pn(pnn) += 1
                    get_ans(sc, sc2, pnn, num)
                    tin = 0
                End If
            End If

            For i = 0 To sc2.Count - 1
                If sc2(i).p_chk = True And i <> pnn Then
                    sc2(i).ans_wa += 1
                End If
            Next

            num += 1
        Loop Until num = p.Sum
    End Sub
End Module
