Namespace Neurons
    Public Class Weight

        Public Property Value
        Public Property Previous As Double

        Public Property Child As Neuron
        Public Property Parent As Neuron

        Public Sub New(ByVal value As Double, ByRef parent_node As Neuron, ByRef child_node As Neuron)
            Previous = 0
            Me.Value = value
            Me.Child = child_node
            Me.Parent = parent_node
        End Sub

    End Class
End Namespace