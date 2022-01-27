Imports escsoft.StringExtension
Public Class steammethodes
    Private Shared ReadOnly Property steam As SaveData = SaveData.Instance

    Public Shared Sub EPersonaState()
        If steam.SelectedUser Is Nothing Then Return

        Dim p = steam.SteamUserDataFolder & "\" & steam.SelectedUser & "\config\localconfig.vdf"
        If Not IO.File.Exists(p) Then Return

        Dim r = IO.File.ReadAllText(p)
        Dim i As Integer = steam.EPersonaState

        Dim selectedInteger = r.Between(FindSequenz.PersoaState, ",")
        If Not selectedInteger.Any Then Return

        Dim w = r.Replace($"{FindSequenz.PersoaState}{selectedInteger(0)}", $"{FindSequenz.PersoaState}{i}")
        IO.File.WriteAllText(p, w)
    End Sub

    Public Shared Sub SteamStart()
        If Not IO.File.Exists(steam.SteamSavePath) Then Return
        Process.Start(steam.SteamSavePath)
    End Sub

    Public Shared Sub CallAllSteamMethods()
        EPersonaState()
        SteamStart()
    End Sub

    Public Class FindSequenz
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns>$"ePersonaState\{ControlChars.Quote}:"</returns>
        Public Shared ReadOnly Property PersoaState As String = $"ePersonaState\{ControlChars.Quote}:"
    End Class

End Class
