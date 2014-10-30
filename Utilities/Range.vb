Namespace Utilities
    Public Class Range

        Public Property Minimum As Double
        Public Property Maximum As Double

        Public ReadOnly Property Delta As Double
            Get
                Return Maximum - Minimum
            End Get
        End Property

        Public Sub New(ByVal min As Double, ByVal max As Double)
            Minimum = min
            Maximum = max
        End Sub

    End Class
End Namespace