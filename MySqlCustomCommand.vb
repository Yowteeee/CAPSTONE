Imports MySql.Data.MySqlClient
Imports System.Data

Friend Class MySqlCustomCommand
    Private _command As MySqlCommand

    Public Sub New(command As MySqlCommand)
        _command = command
    End Sub

    Friend Sub Dispose()
        If _command IsNot Nothing Then
            _command.Dispose()
        End If
    End Sub

    Friend Function Parameters() As MySqlParameterCollection
        Return _command.Parameters
    End Function

    Friend Function ExecuteReader() As MySqlDataReader
        Return _command.ExecuteReader()
    End Function

    Public Shared Widening Operator CType(v As MySqlCommand) As MySqlCustomCommand
        Return New MySqlCustomCommand(v)
    End Operator
End Class
