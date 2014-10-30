Imports MLP
Imports MLP.Data
Imports MLP.Network
Imports MLP.Randoms
Imports MLP.Activation

Module Main

    Sub Main()

        Scenario1()

    End Sub

    Public Sub Scenario1()

        Dim pre = New Predefined(Nothing, {0.1, 0.4, 0.8, 0.6, 0.3, 0.9})
        Dim standard = New Standard(New Range(-0.1, 0.1), DateTime.Now.Millisecond)

        Dim Network As New MultilayerPerceptron(2, {10, 10}, 1, 1, 0.8, standard, New BipolarSigmoid())
        Network.OutputLayer.ActivationFunction = New Linear()

        Dim Training As New List(Of Data.Training)
        Training.Add(New Data.Training({0.35, 0.9}, {0.5}))

        While True
            Network.Train(Training, 1, 0)
            Console.WriteLine(Network.TotalError)
            Console.ReadLine()
        End While

    End Sub

    Public Sub Scenario2()

        Dim pre = New Predefined(Nothing, {0.1, 0.3, 0.5, 0.2, 0.2, 0.1})
        Dim standard = New Standard(New Range(-1, 1), DateTime.Now.Millisecond)

        Dim Network As New MultilayerPerceptron(2, {2}, 1, 1, 0, pre, New BipolarSigmoid(2))
        Dim training As New List(Of Training)
        training.Add(New Training({0.1, 0.7}, {1}))

        While True
            Network.Train(training, 50, 0)
            Console.WriteLine(Network.TotalError)
            Console.ReadLine()
        End While

    End Sub

    Public Sub Scenario3()

        Dim standard As New Standard(New Range(-1, 1), DateTime.Now.Millisecond)

        Dim Network As New MultilayerPerceptron(2, {2}, 1, 0.5, 0.3, standard, New BipolarSigmoid(0.5))
        Dim Training As New List(Of Training)
        Training.Add(New Training({0, 1}, {1}))
        Training.Add(New Training({0, 0}, {0}))
        Training.Add(New Training({1, 0}, {1}))
        Training.Add(New Training({1, 1}, {0}))

        Dim result = False

        While Not result
            Network.Train(Training, 1, 0)
            Console.WriteLine(Network.TotalError)
            Console.ReadLine()
        End While

    End Sub

End Module
