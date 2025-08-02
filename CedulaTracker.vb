Imports System.Windows.Forms

Public Class CedulaTracker
    Private Sub CedulaTracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Cedula Tracker"
    End Sub

    Private Sub CedulaTracker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Add any cleanup code here if needed
    End Sub
End Class