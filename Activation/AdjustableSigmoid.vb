Imports MLP.Utilities

Namespace Activation
    Public Class AdjustableSigmoid
        Inherits BaseActivation

        Public Property Alpha As Double

        Public Sub New()
            Alpha = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(-1, 1)
        End Sub

        Public Sub New(ByVal Alpha As Double, ByVal OutputRange As Range)
            Me.Alpha = Alpha
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = OutputRange
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Throw New NotImplementedException
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Dim exp = Math.Exp(Alpha * value)
            Return OutputRange.Delta * (Alpha * exp) / ((exp + 1) * (exp + 1))
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return OutputRange.Delta / (1 + Math.Exp(-Alpha * value)) + OutputRange.Minimum
        End Function

    End Class
End Namespace
