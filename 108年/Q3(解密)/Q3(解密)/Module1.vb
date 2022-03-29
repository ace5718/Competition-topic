Module Module1

    Sub Main()
        Console.Write("input：")
        Dim inp As Integer() = Convert_int(Console.ReadLine.Split(" "))
        Dim data As Integer() = {&HABCD, &HCDEF, &H2266, &HCEED, &HACCD}

        Dim a = inp(0) - data(0), b = inp(1) - data(1), c = inp(2) - data(2), d = inp(3) - data(3), e = inp(4) - data(4), temp

        For i = 0 To 4
            temp = a : a = b : b = c : c = d : d = e : e = data(i)

            Dim k = &H5A82
            Dim f = b + c

            inp(i) = temp - (4 * a + f + e + k) + Asc(" ")
        Next

        Console.WriteLine(StrReverse(Join(inp.Select(Function(x) Chr(x).ToString).ToArray, "")))
        Console.Read()
    End Sub

    Function Convert_int(input As String())
        Dim temp As New List(Of Integer)
        For Each i In input
            Dim c As New Integer, total As New Integer
            For Each j In StrReverse(i)
                total += Convert.ToInt64(j, 16) * 16 ^ c : c += 1
            Next
            temp.Add(total)
        Next
        Return temp.ToArray
    End Function
End Module
