Imports escsoft.IO.Json
Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Protected Overrides Sub OnExit(e As ExitEventArgs)
        If Not Environment.CommandLine.Contains("%1") Then
            JsonWrite(SaveData.Instance, SaveData.Instance.SaveGame, New Text.Json.JsonSerializerOptions With {.IgnoreReadOnlyProperties = True})
        End If
        MyBase.OnExit(e)
    End Sub

    Protected Overrides Sub OnStartup(e As StartupEventArgs)

        JsonRead(SaveData.Instance, SaveData.Instance.SaveGame)
        If Environment.CommandLine.Contains("%1") Then
            steammethodes.CallAllSteamMethods()
            Application.Current.Shutdown()
        End If
        MyBase.OnStartup(e)
    End Sub

End Class
