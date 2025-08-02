Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class DashboardForm
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs)
        Dim frm As New CertificateProcessing
        frm.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs)
        Dim frm As New CedulaTracker
        frm.Show()
    End Sub

    Private Sub Guna2ImageButton4_Click(sender As Object, e As EventArgs)
        Dim frm As New ResidentRecord
        frm.Show()

    End Sub

    Private Sub Guna2ImageButton3_Click(sender As Object, e As EventArgs)
        Dim frm As New IncidentReport
        frm.Show()
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class