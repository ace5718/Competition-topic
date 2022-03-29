Module Module1
    Sub Main()
START:
        Console.WriteLine("輸入比值：")
        Dim a(3, 3), b(3, 3), w(3), temp(1), sum As Double

        For i = 1 To 3
            a(i, i) = 1
        Next

        Console.Write("請輸入「專業能力」對「通識素養」的指標比值<輸入2個數值>：")
        temp = Console.ReadLine.Split(" ").Select(Function(x) CDbl(x)).ToArray
        a(1, 2) = temp(0) / temp(1) : a(2, 1) = temp(1) / temp(0)

        Console.Write("請輸入「專業能力」對「合群性」的指標比值<輸入2個數值>：")
        temp = Console.ReadLine.Split(" ").Select(Function(x) CDbl(x)).ToArray
        a(1, 3) = temp(0) / temp(1) : a(3, 1) = temp(1) / temp(0)

        Console.Write("請輸入「通識素養」對「合群性」的指標比值<輸入2個數值>：")
        temp = Console.ReadLine.Split(" ").Select(Function(x) CDbl(x)).ToArray
        a(2, 3) = temp(0) / temp(1) : a(3, 2) = temp(1) / temp(0)

        Console.WriteLine("顯示比值矩陣：")
        For i = 1 To 3
            Console.WriteLine("{0} {1} {2}", Format(a(i, 1), "0.000"), Format(a(i, 2), "0.000"), Format(a(i, 3), "0.000"))
        Next

        For y = 1 To 3
            For x = 1 To 3
                b(y, x) = a(y, x) / (a(1, x) + a(2, x) + a(3, x))
            Next
            w(y) = (b(y, 1) + b(y, 2) + b(y, 3)) / 3
            sum += w(y) * (a(1, y) + a(2, y) + a(3, y))
        Next
        Console.WriteLine("顯示指標的權重：w1：{0}  w2：{1}  w3：{2}", Format(w(1), "0.000"), Format(w(2), "0.000"), Format(w(3), "0.000"))
        Console.WriteLine("顯示最大特徵值 LundaMax={0}", Format(sum, "0.000"))

        Dim CR = Format((sum - 3) / ((3 - 1) * 0.58), "0.000")
        Console.WriteLine("顯示一致性比率 CR={0}。CR{1}", CR, If(CR < 0.1, "小於0.1， 符合一致性。", "大於0.1， 不符合一致性。"))
        Console.WriteLine("繼續否？<y or n>")
        If Console.ReadLine = "y" Then GoTo START Else Console.Write("請按任意健繼續．．．") : Console.ReadKey()
    End Sub
End Module
