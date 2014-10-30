Imports MLP.Activation
Imports MLP.Neurons

Namespace Layers
    Public Class HiddenLayer
        Inherits BaseLayer

        Public Sub New(ByVal Size As Integer, ByRef Activation As BaseActivation)
            MyBase.New(Size, Activation)
            For x = 1 To Size
                Neurons.Add(New Neuron(NeuronType.Hidden))
            Next
        End Sub

    End Class
End Namespace

