Public Class SteamStartCommand : Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        steammethodes.SteamStart()
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return Not (String.IsNullOrEmpty(SaveData.Instance.SteamSavePath) Or String.IsNullOrEmpty(SaveData.Instance.SelectedUser))
    End Function
End Class
