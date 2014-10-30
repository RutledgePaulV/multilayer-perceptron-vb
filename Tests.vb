Imports MLP
Imports MLP.Data
Imports MLP.Network
Imports MLP.Randoms
Imports MLP.Activation
Imports MLP.Utilities

Module Main

    Sub Main()

        Scenario1()

    End Sub

    Public Sub Scenario1()

        Dim standard As New Standard(New Range(-1, 1), DateTime.Now.Millisecond)

        Dim Network As New MultilayerPerceptron(2, {5}, 1, 0.5, 0.8, standard, New BipolarSigmoid(0.5))
        Dim Training As New List(Of Training)
        Training.Add(New Training({0, 1}, {1}))
        Training.Add(New Training({0, 0}, {0}))
        Training.Add(New Training({1, 0}, {1}))
        Training.Add(New Training({1, 1}, {0}))

        Dim result = False

        While Not result
            Network.Train(Training, 5, 0.1)
            Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
            Console.ReadLine()
        End While

    End Sub

End Module
