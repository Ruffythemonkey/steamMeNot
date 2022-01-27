Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class SaveData : Implements ComponentModel.INotifyPropertyChanged

    Private Shared _Instance As SaveData
    Public Property EPersonaState As EPersonaState = EPersonaState.Online
    Public Property SteamSavePath As String
    Public Property SelectedUser As String


    Public Shared ReadOnly Property Instance As SaveData
        Get
            If _Instance Is Nothing Then _Instance = New SaveData
            Return _Instance
        End Get
    End Property

    Public ReadOnly Property SaveGame As String = IO.Path.GetDirectoryName(Environment.ProcessPath) & "\test.json"

    Public ReadOnly Property SteamDirectory As String
        Get
            If String.IsNullOrEmpty(SteamSavePath) Then Return Nothing
            Return IO.Path.GetDirectoryName(SteamSavePath)
        End Get
    End Property

    Public ReadOnly Property SteamUserDataFolder As String
        Get
            If String.IsNullOrEmpty(SteamDirectory) Then Return Nothing
            Return SteamDirectory & "\userdata"
        End Get
    End Property

    Public ReadOnly Property AvailableUser As String()
        Get
            If String.IsNullOrEmpty(SteamUserDataFolder) Then Return Nothing
            Dim d = IO.Directory.GetDirectories(SteamUserDataFolder)
            Return d.Select(Of String)(Function(x) x.Replace(SteamUserDataFolder & "\", "")).ToArray()
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub PropUpdate(<CallerMemberName> Optional propname As String = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propname))
    End Sub


End Class