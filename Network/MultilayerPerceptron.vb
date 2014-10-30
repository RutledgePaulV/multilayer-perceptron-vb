Imports MLP.Layers
Imports MLP.Activation
Imports MLP.Data
Imports MLP.Neurons
Imports MLP.Randoms

Namespace Network
    Public Class MultilayerPerceptron

        Public Property TotalError As Double

        Public Property Momentum As Double
        Public Property LearningRate As Double

        Public Property Bias As Neuron
        Public Property Randomizer As BaseRandom
        Public Property ActivationFunction As BaseActivation

        Public Property Layers As List(Of BaseLayer)

        Public Property InputLayer As InputLayer
        Public Property OutputLayer As OutputLayer
        Public Property HiddenLayers As List(Of HiddenLayer)

        Public Sub New(ByVal num_input As Integer, ByVal num_hidden As Integer(), ByVal num_output As Integer, _
                       ByVal learning_rate As Double, ByVal momentum As Double, ByRef randomizer As BaseRandom, ByRef activation As BaseActivation)

            'setting properties
            Me.Momentum = momentum
            Me.Randomizer = randomizer
            Me.LearningRate = learning_rate
            Me.ActivationFunction = activation

            'setting bias
            Me.Bias = New Neuron(NeuronType.Input)
            Me.Bias.Input = 1
            Me.Bias.Output = 1

            'initializing lists
            Layers = New List(Of BaseLayer)
            HiddenLayers = New List(Of HiddenLayer)

            'creating layers
            InputLayer = New InputLayer(num_input, ActivationFunction)
            Layers.Add(InputLayer)
            For Each i In num_hidden
                Dim hiddenLayer = New HiddenLayer(i, ActivationFunction)
                HiddenLayers.Add(hiddenLayer)
                Layers.Add(hiddenLayer)
            Next
            OutputLayer = New OutputLayer(num_output, ActivationFunction)
            Layers.Add(OutputLayer)

            'connecting layers (creating weights)
            For x As Integer = 0 To (Layers.Count - 2)
                Layers(x).ConnectChild(Layers(x + 1), randomizer)

                'connecting bias
                Layers(x + 1).ConnectBias(Bias, randomizer)
            Next

        End Sub

        Public Function Test(ByVal data As Testing) As List(Of Double)
            InputLayer.SetInput(data.Input)
            ForwardPropogate()
            Return OutputLayer.ExtractOutputs()
        End Function

        Public Sub Train(ByVal data As List(Of Training), ByVal epochs As Integer, ByVal min_error As Double)

            Do
                TotalError = 0.0
                For Each item In data
                    InputLayer.SetInput(item.Input)
                    ForwardPropogate()
                    OutputLayer.AssignErrors(item.Output)
                    BackwardPropogate()
                    TotalError += OutputLayer.CalculateSquaredError()
                Next
                epochs -= 1
            Loop While epochs > 0 And TotalError > min_error

        End Sub

        Public Sub ForwardPropogate()

            For x As Integer = 1 To (Layers.Count - 1)
                For Each node In Layers(x).Neurons
                    node.Input = 0.0
                    For Each w In node.WeightsToParent
                        node.Input += w.Parent.Output * w.Value
                    Next
                    'adding bias
                    node.Input += node.WeightToBias.Parent.Output * node.WeightToBias.Value
                    node.Output = Layers(x).ActivationFunction.Evaluate(node.Input)
                Next
            Next

        End Sub

        Public Sub BackwardPropogate()

            'updating weights for all other layers
            For x = (Layers.Count - 1) To 1 Step -1
                For Each node In Layers(x).Neurons

                    'if not output layer, then errors need to be backpropogated from child layer to parent
                    If node.Type <> NeuronType.Output Then
                        node.ErrorDelta = 0.0
                        For Each w In node.WeightsToChild
                            node.ErrorDelta += w.Value * w.Child.ErrorDelta * w.Child.Primed
                        Next
                    End If

                    'calculating derivative value of input
                    'node.Primed = Layers(x).ActivationFunction.AbstractDerivative(node.Output)
                    node.Primed = Layers(x).ActivationFunction.Derivative(node.Input)

                    'adjusting weight values between parent layer
                    For Each w In node.WeightsToParent
                        Dim adjustment = LearningRate * (node.ErrorDelta * node.Primed * w.Parent.Output)
                        w.Value += adjustment + w.Previous * Momentum
                        w.Previous = adjustment
                    Next

                    'adjusting weights between bias
                    Dim biasAdjustment = LearningRate * (node.ErrorDelta * node.Primed * node.WeightToBias.Parent.Output)
                    node.WeightToBias.Value += biasAdjustment + node.WeightToBias.Previous * Momentum
                    node.WeightToBias.Previous = biasAdjustment
                Next
            Next

        End Sub

    End Class
End Namespace