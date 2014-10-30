Imports MLP.Utilities

Namespace Activation

    Public Class Linear
        Inherits BaseActivation

        Public Property Slope As Double

        Public Sub New()
            Slope = 1
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
        End Sub

        Public Sub New(ByVal slope As Double)
            Me.Slope = slope
            in_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
            out_range = New Range(Double.NegativeInfinity, Double.PositiveInfinity)
        End Sub

        Public Sub New(ByVal slope As Integer)
            Me.Slope = slope
        End Sub

        Public Overrides Function AbstractedDerivative(ByVal value As Double) As Double
            Return Slope
        End Function

        Public Overrides Function Derivative(ByVal value As Double) As Double
            Return Slope
        End Function

        Public Overrides Function Evaluate(ByVal value As Double) As Double
            Return Slope * value
        End Function

    End Class
End Namespace
