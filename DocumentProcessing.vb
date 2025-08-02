Imports System.Windows.Forms

Public Class DocumentProcessing
    Private Sub DocumentProcessing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Document Processing"
    End Sub

    Private Sub DocumentProcessing_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Add any cleanup code here if needed
    End Sub
End Class