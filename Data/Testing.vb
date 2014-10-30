Namespace Data
    Public Class Testing

        Public Property Input As List(Of Double)

        Public Sub New(ByVal input As IEnumerable(Of Double))
            Me.Input = New List(Of Double)
            Me.Input.AddRange(input)
        End Sub

    End Class
End Namespace