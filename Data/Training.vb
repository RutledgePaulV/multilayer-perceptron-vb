Namespace Data
    Public Class Training
        Public Property Input As List(Of Double)
        Public Property Output As List(Of Double)

        Public Sub New()
            Me.Input = New List(Of Double)
            Me.Output = New List(Of Double)
        End Sub

        Public Sub New(ByVal input As IEnumerable(Of Double), ByVal output As IEnumerable(Of Double))
            Me.Input = New List(Of Double)
            Me.Output = New List(Of Double)
            Me.Input.AddRange(input)
            Me.Output.AddRange(output)
        End Sub

    End Class
End Namespace
