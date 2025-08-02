Imports System.Windows.Forms

Public Class ResidentRecord
    Private Sub ResidentRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Resident Record"
    End Sub

    Private Sub ResidentRecord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Add any cleanup code here if needed
    End Sub
End Class