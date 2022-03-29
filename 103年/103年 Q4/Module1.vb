Imports System.Text.RegularExpressions
Module Module1
    Dim p As String() = {"大隊接力", "一顆球的距離", "天旋地轉", "滾大球袋鼠跳", "牽手同心", "100公尺", "400公尺接力", "800公尺", "跳高"}
    Dim str As String() = {"批次輸入", "選手查詢", "刪除資料", "逐筆輸入", "顯示所有資料"}

    Class node
        Public _class, ID, name, gender, project, group As String
        Public Sub New(a$, b$, c$, d$, e$, f$)
            _class = a : ID = b : name = c : gender = d : project = e : group = f
        End Sub
    End Class
    Dim sc As New List(Of node)

    Sub Main()
start:
        Console.Clear()
        Console.Write("請輸入操作項目：
　　　　<1>{0}：
        <2>{1}：
        <3>{2}：
        <4>{3}：
        <5>{4}：
請選擇：", str(0), str(1), str(2), str(3), str(4))
        Dim sel As String = Console.ReadLine
        Console.WriteLine(str(sel - 1) & "，")
        Select Case sel
            Case 1 : get_1()
            Case 2 : get_2()
            Case 3 : get_3()
            Case 4 : get_4()
            Case 5 : get_5()
            Case Else : Console.WriteLine("輸入錯誤")
        End Select

        Console.Write("繼續：請按1，結束：請按0：")
        If Console.ReadLine = "1" Then Console.WriteLine() : GoTo start Else End
    End Sub

    Sub get_1()
        Console.Write("輸入資料名稱")
        For Each i In My.Computer.FileSystem.ReadAllText(Console.ReadLine, System.Text.Encoding.GetEncoding(950)).Replace(vbCrLf, "!").Split("!")
            Dim str = i.Split(" ")
            sc.Add(New node(str(0), str(1), str(2), str(3), str(4), chk_group(str(4))))
        Next
        Console.WriteLine("輸入完成")
    End Sub

    Sub get_2()
        Console.Write("請輸入 班級、學號、姓名及性別：")
        Dim data As String = Console.ReadLine.Replace(" ", "")
        If sc.Count = 0 Then
            Console.WriteLine("查無此人")
        Else
            For Each i In sc
                Dim str As String = i._class & i.ID & i.name & i.gender
                If str = data Then
                    Console.WriteLine("{0} {1} {2} {3} {4}", i._class, i.ID, i.name, i.gender, i.project)
                End If
            Next
        End If
    End Sub

    Sub get_3()
        Console.Write("請輸入 班級、學號、姓名及性別：")
        Dim data As String = Console.ReadLine.Replace(" ", "")
        For i = 0 To sc.Count - 1
            If data = (sc(i)._class & sc(i).ID & sc(i).name & sc(i).project) Then
                Console.WriteLine("被刪除的選手資料：{0} {1} {2} {3} {4}", sc(i)._class, sc(i).ID, sc(i).name, sc(i).project)
                sc.RemoveAt(i)
            End If
        Next
    End Sub

    Sub get_4()
        Console.Write("請輸入 班級、學號、姓名及性別：")
        Dim data As String() = Console.ReadLine.Split(" ")
        Dim t As New List(Of node)
        If data.Count <> 4 Then Console.WriteLine("輸入格式錯誤") : Exit Sub

        Console.Write("報名項目：
a：{0}
b：{1}
c：{2}
d：{3}
e：{4}
f：{5}
g：{6}
h：{7}
i：{8}
請選擇：", p(0), p(1), p(2), p(3), p(4), p(5), p(6), p(7), p(8))

        Dim n As Integer = Asc(Console.ReadLine) - 97
        Dim g As String = chk_group(p(n))
        Console.WriteLine("輸入班級：{0}、學號：{1}、姓名：{2}、性別：{3}、報名項目：{4}", data(0), data(1), data(2), data(3), p(n))
        If sc.Count = 0 Then sc.Add(New node(data(0), data(1), data(2), data(3), p(n), g)) : Console.WriteLine("報名完成") : Exit Sub
        For Each i In sc
            If (i._class = data(0) And i.ID = data(1)) AndAlso (i.name = data(2) And i.gender = data(3)) Then
                t.Add(New node(i._class, i.ID, i.name, i.gender, i.project, i.group))
            End If
        Next
        Dim str As String = data(0) & data(1) & data(2) & data(3)
        If g = 3 Or chk_project(t, g) Then
            print(sc, str)
            sc.Add(New node(data(0), data(1), data(2), data(3), p(n), g))
            Console.WriteLine("報名完成")
        Else
            print(sc, str)
            Console.WriteLine("已報名" & "{0}" & ",不能報名超過兩項", If(g = 1, "個人賽", "團體賽"))
        End If
    End Sub

    Sub get_5()
        For Each i In sc
            Console.WriteLine("{0} {1} {2} {3} {4}", i._class, i.ID, i.name, i.gender, i.project)
        Next
    End Sub

    Sub print(t As List(Of node), str As String)
        For Each i In t
            If (i._class & i.ID & i.name & i.gender) = str Then
                Console.WriteLine("{0} {1} {2} {3} {4}", i._class, i.ID, i.name, i.gender, i.project)
            End If
        Next
    End Sub

    Function chk_project(t As List(Of node), g As String)
        If t.Count = 0 Then Return True
        Dim n As String = ""
        For Each i In t
            If i.group <> 3 Then n = i.group
        Next
        If g = n Then Return True Else Return False
    End Function

    Function chk_group(str As String)
        Dim chk As String() = {"100公尺", "400公尺接力", "800公尺", "跳高"}
        If str = "大隊接力" Then
            Return 3
        Else
            If Array.IndexOf(chk, str) <> -1 Then Return 2 Else Return 1
        End If
    End Function
End Module
