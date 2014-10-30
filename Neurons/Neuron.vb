Namespace Neurons
    Public Class Neuron

        Public Property NumericalFormat As String = "0.000"
        Public Property Input As Double
        Public Property Output As Double
        Public Property ErrorDelta As Double
        Public Property Primed As Double

        Public Property Type As NeuronType
        Public Property WeightsToChild As List(Of Weight)
        Public Property WeightsToParent As List(Of Weight)
        Public Property WeightToBias As Weight


        Public Sub New(ByVal type As NeuronType)
            Input = 0
            Output = 0
            Primed = 0
            ErrorDelta = 0
            Me.Type = type
            Select Case type
                Case NeuronType.Input
                    WeightsToChild = New List(Of Weight)
                Case NeuronType.Hidden
                    WeightsToChild = New List(Of Weight)
                    WeightsToParent = New List(Of Weight)
                Case NeuronType.Output
                    WeightsToParent = New List(Of Weight)
            End Select
        End Sub

        Public Overrides Function ToString() As String
            Dim result = "Input = " & Input.ToString(NumericalFormat) & vbCr
            result &= "Output = " & Output.ToString(NumericalFormat) & vbCr
            result &= "Error = " & ErrorDelta.ToString(NumericalFormat)
            Return result
        End Function

    End Class
End Namespace