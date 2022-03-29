Module Module1
    Dim se As String()
    Sub Main()
        Console.Write("請輸入大地遊戲關卡文字檔檔名：")
        Dim name As String = Console.ReadLine
        Dim input As String() = IO.File.ReadAllLines(name)
        Console.WriteLine("你輸入檔名為： '{0}'", name)
        Console.WriteLine("大地遊戲關卡文字檔內容為")
        Console.WriteLine(Join(input, vbCrLf))
        se = input(input.Count - 1).Split(" ")
        Get_data(input)
        Console.WriteLine("最快闖關路線[{0} -> {1}]：{2} (路途險峻程度 {3})", se(0), se(1), ans(1), ans(0))
        Console.Read()
    End Sub
    Dim ans As Array = {Integer.MaxValue, ""}

    Class node
        Public ed As Integer
        Public cost As Decimal
        Public Sub New(a As Integer, b As Decimal)
            ed = a : cost = b
        End Sub
    End Class

    Sub Get_data(input As String())
        Dim dic As New Dictionary(Of Integer, List(Of node))
        For i = 1 To input.Count - 2
            dic.Add(i, New List(Of node))
            Dim data As String() = input(i).Split(" ")
            For j = 0 To data.Count - 1
                dic(i).Add(New node(j + 1, data(j)))
            Next
        Next

        For Each i In dic(se(0))
            If i.cost > 0 Then chk.Add(i.ed) : Get_ans(dic, i.ed, se(1), i.cost, se(0))
        Next
    End Sub

    Dim chk As New HashSet(Of Integer)
    Sub Get_ans(dic As Dictionary(Of Integer, List(Of node)), st As Integer, ed As Integer, total As Decimal, path As String)
        If st = ed Then
            If ans(0) > total Then
                ans = {total, Join((path & " " & ed).Split(" "), "->")}
            End If
        Else
            For Each i In dic(st)
                If Array.IndexOf(chk.ToArray, i.ed) = -1 Then
                    chk.Add(i.ed)
                    Get_ans(dic, i.ed, ed, total + i.cost, path & " " & st)
                End If
            Next
        End If
    End Sub
End Module
