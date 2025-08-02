Imports MySql.Data.MySqlClient
Imports System.Data

Public Class DatabaseResult
    Public Property Success As Boolean
    Public Property Message As String

    Public Sub New(success As Boolean, message As String)
        Me.Success = success
        Me.Message = message
    End Sub
End Class

Public Class DatabasesConfig
    ' Database connection settings
    Private Shared ReadOnly connectionString As String = "Server=127.0.0.1;Port=3306;Database=cap_101;Uid=root;Pwd=johnarbenanguring;SslMode=none;"

    ' Get connection string
    Public Shared Function GetConnectionString() As String
        Return connectionString
    End Function

    ' Test database connection
    Public Shared Function TestDatabaseConnection() As DatabaseResult
        Try
            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                If connection.State = ConnectionState.Open Then
                    Return New DatabaseResult(True, "Database connection successful!")
                Else
                    Return New DatabaseResult(False, "Failed to open database connection.")
                End If
            End Using
        Catch ex As MySqlException
            Return New DatabaseResult(False, $"MySQL Error {ex.Number}: {ex.Message}")
        Catch ex As Exception
            Return New DatabaseResult(False, $"Connection Error: {ex.Message}")
        End Try
    End Function

    ' Check database connection only (no table creation)
    Public Shared Function CreateDatabaseIfNotExists() As DatabaseResult
        Try
            Using dbConnection As New MySqlConnection(GetConnectionString())
                dbConnection.Open()
                If dbConnection.State = ConnectionState.Open Then
                    Return New DatabaseResult(True, "Database connection successful!")
                Else
                    Return New DatabaseResult(False, "Failed to open database connection.")
                End If
            End Using
        Catch ex As MySqlException
            Return New DatabaseResult(False, $"MySQL Error {ex.Number}: {ex.Message}")
        Catch ex As Exception
            Return New DatabaseResult(False, $"Database Connection Error: {ex.Message}")
        End Try
    End Function
End Class