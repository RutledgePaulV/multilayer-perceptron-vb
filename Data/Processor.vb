Imports MLP.Activation
Imports MLP.Utilities

Namespace Data
    Public Class Processor

        Public Property InputRange As Range
        Public Property OutputRange As Range

        Public Sub New(ByRef input_function As BaseActivation, ByRef output_function As BaseActivation)


        End Sub

        Public Function PreProcess(ByVal data As List(Of Training)) As List(Of Training)
            Dim result = New List(Of Training)
            For Each item In data
                Dim temp As New Training()
                For Each entry In item.Input
                    temp.Input.Add(entry / InputRange.Delta + InputRange.Minimum)
                Next

                For Each entry In item.Output
                    temp.Output.Add(entry / OutputRange.Delta + OutputRange.Minimum)
                Next
            Next
            Return result
        End Function

    End Class
End Namespace