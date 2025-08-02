Imports System.Windows.Forms

Public Class BackupNRestore
    Private Sub BackupNRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Backup and Restore"
    End Sub

    Private Sub BackupNRestore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Add any cleanup code here if needed
    End Sub
End Class