Public Class ControlMove
    Public controls As Label

    Public x As Integer = 110
    Public y As Integer = 70

    Public dx As Integer = 2
    Public dy As Integer = -2
    Public Sub New()
        Me.x = 180 + 30
        Me.y = 100 + 30
    End Sub
    Public Sub move()
        If ((Me.x + Me.dx) > (800 + 30) Or (Me.x + Me.dx < 130)) Then
            Me.dx = Me.dx * -1
        End If

        If ((Me.y + Me.dy) > (460 + 30) Or (Me.y + Me.dy < 80)) Then
            Me.dy = Me.dy * -1
        End If

        Me.x += Me.dx
        Me.y += Me.dy

        Me.updateUI()
    End Sub

    Public Sub updateUI()
        Me.controls.Top = Me.y
        Me.controls.Left = Me.x
    End Sub
End Class
