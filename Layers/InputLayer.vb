Imports MLP.Activation
Imports MLP.Neurons

Namespace Layers
    Public Class InputLayer
        Inherits BaseLayer

        Public Sub New(ByVal Size As Integer, ByRef Activation As BaseActivation)
            MyBase.New(Size, Activation)
            For x = 1 To Size
                Neurons.Add(New Neuron(NeuronType.Input))
            Next
        End Sub

        Public Sub SetInput(ByVal input As List(Of Double))
            For x = 0 To (Size - 1)
                Neurons(x).Input = input(x)
                Neurons(x).Output = input(x)
            Next
        End Sub

    End Class
End Namespace
