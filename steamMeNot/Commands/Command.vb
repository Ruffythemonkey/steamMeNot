Public Class Commandos : Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Private Action As Action(Of Object)
    Private Func As Func(Of Object, Boolean)

    Public Sub New(Action As Action(Of Object), Func As Func(Of Object, Boolean))
        Me.Action = Action
        Me.Func = Func
    End Sub
    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Action(parameter)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return Func(parameter)
    End Function
End Class
