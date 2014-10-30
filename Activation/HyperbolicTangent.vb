Imports MLP.Utilities

Namespace Activation

    Public Class HyperbolicTangent
        Inherits BaseActivation

        Public Property Alpha As Double

        Public Sub New()
            Alpha = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(-1, 1)
        End Sub

        Public Sub New(ByVal Alpha As Double)
            Me.Alpha = Alpha
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(-1, 1)
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Return Alpha * (1 - value * value)
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Return Alpha * (1 - Math.Tanh(Alpha * value) ^ 2)
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return Math.Tanh(Alpha * value)
        End Function

    End Class
End Namespace
