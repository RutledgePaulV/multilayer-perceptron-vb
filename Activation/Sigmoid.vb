Imports MLP.Utilities

Namespace Activation
    Public Class Sigmoid
        Inherits BaseActivation

        Public Property Alpha As Double

        Public Sub New()
            Alpha = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(0, 1)
        End Sub

        Public Sub New(ByVal alpha As Double)
            Me.Alpha = alpha
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(0, 1)
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Return Alpha * value * (1 - value)
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Dim exp = Math.Exp(Alpha * value)
            Return (Alpha * exp) / ((exp + 1) * (exp + 1))
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return 1 / (1 + Math.Exp(-Alpha * value))
        End Function

    End Class
End Namespace
