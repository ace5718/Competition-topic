Module Module1

    Sub Main()
        Console.Write("input：")

        Dim inp As String() = Console.ReadLine.Select(Function(x) CStr(x)).ToArray

        Dim h As Integer() = {&HABCD, &HCDEF, &H2266, &HCEED, &HACCD}
        Dim h0 = &HABCD, h1 = &HCDEF, h2 = &H2266, h3 = &HCEED, h4 = &HACCD

        Dim a = h(0), b = h(1), c = h(2), d = h(3), e = h(4)

        For i = 0 To 4
            Dim f = b + c

            Dim k = &H5A82

            Dim temp = 4 * a + f + e + k + Asc(inp(i)) - Asc(" ")

            e = d : d = c : c = b : b = a : a = temp
        Next

        h(0) += a : h(1) += b : h(2) += c : h(3) += d : h(4) += e

        Console.WriteLine(Join(h.Select(Function(x) Convert.ToString(CInt(x), 16).PadLeft(8, "0")).ToArray, " "))
        Console.Read()
    End Sub

End Module
