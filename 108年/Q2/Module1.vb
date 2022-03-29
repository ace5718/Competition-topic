Module Module1

    Sub Main()
        Console.WriteLine("讀入 ./10809.txt 檔")
        Get_Data(IO.File.ReadAllLines("10809.txt"))
        Console.WriteLine("漲跌價最高的3支股票(漲價元)：" & Print_ans1())
        Console.WriteLine("漲跌價最低的3支股票(跌價元)：" & Print_ans2())
        Console.WriteLine("漲跌幅最高的3支股票(漲幅%)：" & Print_ans3())
        Console.WriteLine("漲跌價最高的3支股票(跌幅%)：" & Print_ans4())
        Console.WriteLine("所有漲停股票(漲停價元)：" & Print_ans5())
        Console.WriteLine("所有跌停股票(跌停價元)：" & Print_ans6())

        Console.Read()
    End Sub

    Class node
        Public name As String
        Public a, b, c, d As Decimal
        Public e As Boolean? = Nothing
        Public Sub New(t1 As Decimal, t2 As Decimal, t3 As String)
            a = t1 : b = t2 : name = t3
        End Sub
    End Class

    Dim sc As New List(Of node)
    Sub Get_Data(input As String())
        For Each i In input.Skip(1)
            Dim data As String() = i.Split(" ")
            Dim temp As node = New node(data(2), data(6), data(1))
            temp.c = temp.b - temp.a
            temp.d = Format((temp.c / temp.a) * 100, "0.00")

            Dim bb As Decimal = temp.a * 1.1, cc As Decimal = temp.a * 0.9

            If CInt(temp.b) >= CInt(bb) Then : temp.e = True
            ElseIf CInt(cc) >= CInt(temp.b) Then : temp.e = False
            End If

            sc.Add(temp)
        Next
    End Sub

    Function Print_ans1()
        sc = sc.OrderByDescending(Function(x) x.c).ToList
        Return String.Format("{0}({1}) {2}({3}) {4}({5})", sc(0).name, sc(0).c, sc(1).name, sc(1).c, sc(2).name, sc(2).c)
    End Function

    Function Print_ans2()
        sc = sc.OrderBy(Function(x) x.c).ToList
        Return String.Format("{0}({1}) {2}({3}) {4}({5})", sc(0).name, sc(0).c, sc(1).name, sc(1).c, sc(2).name, sc(2).c)
    End Function

    Function Print_ans3()
        sc = sc.OrderByDescending(Function(x) x.d).ToList
        Return String.Format("{0}({1}%) {2}({3}%) {4}({5}%)", sc(0).name, sc(0).d, sc(1).name, sc(1).d, sc(2).name, sc(2).d)
    End Function

    Function Print_ans4()
        sc = sc.OrderBy(Function(x) x.d).ToList
        Return String.Format("{0}({1}%) {2}({3}%) {4}({5}%)", sc(0).name, sc(0).d, sc(1).name, sc(1).d, sc(2).name, sc(2).d)
    End Function

    Function Print_ans5()
        Dim str As String = ""
        For Each i In sc
            If i.e Then str &= String.Format("{0}({1})", i.name, i.c)
        Next
        Return str
    End Function

    Function Print_ans6()
        Dim str As String = ""
        For Each i In sc
            If i.e = False Then str &= String.Format("{0}({1})", i.name, i.c)
        Next
        Return str
    End Function
End Module
