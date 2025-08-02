Imports System.Data
Imports MySql.Data.MySqlClient

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize login form
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()

        ' Set form title
        Me.Text = "CAP101 - User Login"

        ' Initialize database on form load
        InitializeDatabase()
    End Sub

    Private Sub InitializeDatabase()
        Try
            ' Create database and tables if they don't exist
            Dim createResult = DatabasesConfig.CreateDatabaseIfNotExists()
            If Not createResult.Success Then
                MessageBox.Show($"Database initialization failed: {createResult.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Test database connection
            Dim testResult = DatabasesConfig.TestDatabaseConnection()
            If Not testResult.Success Then
                MessageBox.Show($"Database connection failed: {testResult.Message}", "Connection Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ' Show success message only in debug mode or first run
                ' MessageBox.Show("Database connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Database initialization error: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        ' Disable login button to prevent multiple clicks
        BtnLogin.Enabled = False
        BtnLogin.Text = "Logging In..."

        Try
            ' Validate input first
            If Not ValidateInput() Then
                Return
            End If

            ' Perform login
            PerformLogin()
        Finally
            ' Re-enable login button
            BtnLogin.Enabled = True
            BtnLogin.Text = "Log In"
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text.Trim()) Then
            MessageBox.Show("Please enter a username", "Input Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter a password", "Input Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        ' Additional validation
        If txtUsername.Text.Trim().Length < 3 Then
            MessageBox.Show("Username must be at least 3 characters long", "Input Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If txtPassword.Text.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters long", "Input Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub PerformLogin()
        Dim connection As MySqlConnection = Nothing
        Dim command As MySqlCommand = Nothing
        Dim reader As MySqlDataReader = Nothing

        Try
            ' Create connection
            connection = New MySqlConnection(DatabasesConfig.GetConnectionString())
            connection.Open()

            ' Create command with parameters
            Dim query As String = "SELECT username, password FROM log_in WHERE username = @username AND password = @password"
            command = New MySqlCommand(query, connection)

            ' Add parameters to prevent SQL injection
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtUsername.Text.Trim()
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtPassword.Text.Trim()

            ' Execute query
            reader = command.ExecuteReader()

            If reader.Read() Then
                ' Login successful
                Dim username As String = reader.GetString("username")
                Dim password As String = reader.GetString("password")

                MessageBox.Show($"Welcome back, {username}!", "Login Successful",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Store user information (you can use a global variable or session)

                ' Open dashboard form
                OpenDashboard()
            Else
                ' Login failed
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                ClearPasswordField()
            End If

        Catch ex As MySqlException
            MessageBox.Show($"Database Error {ex.Number}: {ex.Message}", "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Clean up resources
            If reader IsNot Nothing Then
                reader.Close()
                reader.Dispose()
            End If
            If command IsNot Nothing Then
                command.Dispose()
            End If
            If connection IsNot Nothing Then
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                connection.Dispose()
            End If
        End Try
    End Sub

    Private Sub OpenDashboard()
        Try
            ' Create and show dashboard form
            Dim dashboardForm As New DashboardForm()

            ' Hide current form and show dashboard
            Me.Hide()
            dashboardForm.ShowDialog()

            ' Show login form again when dashboard closes
            Me.Show()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error opening dashboard: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Show()
        End Try
    End Sub

    Private Sub ClearPasswordField()
        txtPassword.Clear()
        txtPassword.Focus()
    End Sub

    Private Sub ClearFields()
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ' Confirm exit
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' Handle Enter key press for login
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True ' Prevent the beep sound
            BtnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True ' Prevent the beep sound
            txtPassword.Focus()
        End If
    End Sub

    ' Add a method to show database status
    Private Sub ShowDatabaseStatus()
        Try
            Dim result = DatabasesConfig.TestDatabaseConnection()
            MessageBox.Show(result.Message, If(result.Success, "Database Status", "Database Error"),
                           MessageBoxButtons.OK,
                           If(result.Success, MessageBoxIcon.Information, MessageBoxIcon.Error))
        Catch ex As Exception
            MessageBox.Show($"Error checking database status: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

' Alternative connection test method (you can add this to a separate module or form)
Public Module ConnectionTester
    Public Sub TestConnection()
        Dim result = DatabasesConfig.TestDatabaseConnection()
        MessageBox.Show(result.Message, If(result.Success, "Success", "Error"),
                       MessageBoxButtons.OK,
                       If(result.Success, MessageBoxIcon.Information, MessageBoxIcon.Error))
    End Sub
End Module