Imports MySql.Data.MySqlClient
Imports System.Data
Imports MySql.Data.MySqlClient.MySqlCommand


Public Class DatabaseHelper
    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Function TestConnection() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Return connection.State = ConnectionState.Open
            End Using
        Catch ex As Exception
            Console.WriteLine($"Connection failed: {ex.Message}")
            Return False
        End Try
    End Function

    Public Function ExecuteQuery(query As String) As DataTable
        Dim dataTable As New DataTable()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using command As New Global.MySql.Data.MySqlClient.MySqlCommand()
                    command.Connection = connection
                    command.CommandText = query
                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Query execution failed: {ex.Message}")
        End Try

        Return dataTable
    End Function

    Public Function ExecuteNonQuery(query As String) As Integer
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using command As New Global.MySql.Data.MySqlClient.MySqlCommand()
                    command.Connection = connection
                    command.CommandText = query
                    Return command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Query execution failed: {ex.Message}")
            Return -1
        End Try
    End Function

    Public Function ExecuteScalar(query As String) As Object
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using command As New Global.MySql.Data.MySqlClient.MySqlCommand()
                    command.Connection = connection
                    command.CommandText = query
                    Return command.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Query execution failed: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' Method with parameters to prevent SQL injection
    Public Function ExecuteQueryWithParameters(query As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim dataTable As New DataTable()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using command As New Global.MySql.Data.MySqlClient.MySqlCommand()
                    command.Connection = connection
                    command.CommandText = query

                    ' Add parameters
                    For Each param In parameters
                        command.Parameters.AddWithValue(param.Key, param.Value)
                    Next

                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Query execution failed: {ex.Message}")
        End Try

        Return dataTable
    End Function

    Public Function ExecuteNonQueryWithParameters(query As String, parameters As Dictionary(Of String, Object)) As Integer
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using command As New Global.MySql.Data.MySqlClient.MySqlCommand()
                    command.Connection = connection
                    command.CommandText = query

                    ' Add parameters
                    For Each param In parameters
                        command.Parameters.AddWithValue(param.Key, param.Value)
                    Next

                    Return command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Query execution failed: {ex.Message}")
            Return -1
        End Try
    End Function
End Class