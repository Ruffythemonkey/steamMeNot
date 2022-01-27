Imports IWshRuntimeLibrary
Public Class CreateDesktopShortcutCommand : Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
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

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return Not (String.IsNullOrEmpty(SaveData.Instance.SteamSavePath) Or String.IsNullOrEmpty(SaveData.Instance.SelectedUser))
    End Function
End Class
