Class MainWindow
    Private Sub FileDialog(sender As Object, e As RoutedEventArgs)
        vm.OpenDialog()
    End Sub

    Private Sub ComboBox_DropDownClosed(sender As Object, e As EventArgs)
        steammethodes.EPersonaState()
    End Sub

    Private Sub ComboBox_DropDownClosed_1(sender As Object, e As EventArgs)
        vm.PropUpdate()
    End Sub

End Class
