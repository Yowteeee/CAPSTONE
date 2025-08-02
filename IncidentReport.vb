Imports System.Windows.Forms

Public Class IncidentReport
    Private Sub IncidentReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Incident Report"
    End Sub

    Private Sub IncidentReport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Add any cleanup code here if needed
    End Sub
End Class