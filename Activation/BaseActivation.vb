Imports MLP.Utilities

Namespace Activation
    Public MustInherit Class BaseActivation

        Protected in_range As Range
        Protected out_range As Range

        Public ReadOnly Property InputRange As Range
            Get
                Return in_range
            End Get
        End Property

        Public ReadOnly Property OutputRange As Range
            Get
                Return out_range
            End Get
        End Property

        Public MustOverride Function Evaluate(ByVal value As Double) As Double
        Public MustOverride Function Derivative(ByVal value As Double) As Double
        Public MustOverride Function AbstractedDerivative(ByVal value As Double) As Double

    End Class
End Namespace
