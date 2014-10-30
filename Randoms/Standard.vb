Imports MLP.Utilities

Namespace Randoms
    Public Class Standard
        Inherits BaseRandom

        Private Random As Random

        Public Sub New(ByVal range As Range, ByVal seed As Long)
            MyBase.New(range)
            Random = New Random(seed)
        End Sub

        Public Overrides Function Generate() As Double
            Return Random.NextDouble() * Range.Delta + Range.Minimum
        End Function

    End Class
End Namespace