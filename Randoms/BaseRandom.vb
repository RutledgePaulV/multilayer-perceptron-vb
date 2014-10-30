Imports MLP.Utilities

Namespace Randoms
    Public MustInherit Class BaseRandom

        Public Property Range As Range

        Public Sub New(ByVal range As Range)
            Me.Range = range
        End Sub

        Public MustOverride Function Generate() As Double

    End Class
End Namespace