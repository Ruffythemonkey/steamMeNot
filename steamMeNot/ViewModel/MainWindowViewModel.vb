Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Microsoft.Win32
Imports IWshRuntimeLibrary
Imports escsoft

Public Class MainWindowViewModel : Implements ComponentModel.INotifyPropertyChanged

    Public Property SaveData As SaveData = SaveData.Instance
    Public Property CommandSteamStart As ICommand = New Commandos(AddressOf SteamStart, AddressOf CanExecute)
    Public Property CommandCreateShortcut As ICommand = New Commandos(AddressOf CreateShortcut, AddressOf CanExecute)

    Private Sub CreateShortcut(obj As Object)
        Dim shDesktop As Object = CObj("Desktop")
        Dim shell As WshShell = New WshShell()
        Dim shortcutAddress As String = CStr(shell.SpecialFolders.Item(shDesktop)) & "\SteamMeNot.lnk"
        Dim shortcut As IWshShortcut = CType(shell.CreateShortcut(shortcutAddress), IWshShortcut)
        'shortcut.Description = "New shortcut for a Notepad"
        'shortcut.Hotkey = "Ctrl+Shift+N"
        shortcut.Arguments = "%1"
        shortcut.TargetPath = ControlChars.Quote & Environment.ProcessPath & ControlChars.Quote
        shortcut.Save()
    End Sub

    Private Function CanExecute(arg As Object) As Boolean
        Debug.WriteLine("Yolo" & Not (String.IsNullOrEmpty(SaveData.SelectedUser) Or String.IsNullOrEmpty(SaveData.SteamSavePath)))
        Return Not (String.IsNullOrEmpty(SaveData.SelectedUser) Or String.IsNullOrEmpty(SaveData.SteamSavePath))
    End Function

    Private Sub SteamStart(obj As Object)
        Process.Start(SaveData.SteamSavePath)
    End Sub

    Public Sub PropUpdate()
        PropUpdate(NameOf(SaveData))
        CommandCreateShortcut.CanExecute(Nothing)

        'CommandSteamStart.CanExecute(Nothing)
    End Sub

    Public Sub OpenDialog()
        Dim openDialog As New OpenFileDialog
        openDialog.FileName = "steam.exe"
        openDialog.DefaultExt = ".exe"
        openDialog.Filter = "Steam Execute |steam.exe"
        If openDialog.ShowDialog Then
            SaveData.SteamSavePath = openDialog.FileName
            PropUpdate()
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub PropUpdate(<CallerMemberName> Optional propname As String = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propname))
    End Sub

End Class
