Imports MLP.Activation
Imports MLP.Neurons
Imports MLP.Randoms

Namespace Layers
    Public Class BaseLayer

        Public Property Size As Integer
        Public Property Neurons As List(Of Neuron)
        Public Property ActivationFunction As BaseActivation

        Public Sub New(ByVal Size As Integer, ByRef Activation As BaseActivation)
            Me.Size = Size
            Me.Neurons = New List(Of Neuron)
            Me.ActivationFunction = Activation
        End Sub

        Public Sub ConnectParent(ByRef layer As BaseLayer, ByRef Random As BaseRandom)
            For Each n2 As Neuron In Me.Neurons
                For Each n As Neuron In layer.Neurons
                    Dim weight = New Weight(Random.Generate(), n, n2)
                    n.WeightsToChild.Add(weight)
                    n2.WeightsToParent.Add(weight)
                Next
            Next
        End Sub

        Public Sub ConnectChild(ByRef layer As BaseLayer, ByRef Random As BaseRandom)
            For Each n2 As Neuron In Me.Neurons
                For Each n As Neuron In layer.Neurons
                    Dim weight = New Weight(Random.Generate(), n2, n)
                    n.WeightsToParent.Add(weight)
                    n2.WeightsToChild.Add(weight)
                Next
            Next
        End Sub

        Public Sub ConnectBias(ByRef bias As Neuron, ByRef Random As BaseRandom)
            For Each n As Neuron In Me.Neurons
                Dim weight = New Weight(Random.Generate(), bias, n)
                n.WeightToBias = weight
                bias.WeightsToChild.Add(weight)
            Next
        End Sub

    End Class
End Namespace