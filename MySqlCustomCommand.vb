Imports MySql.Data.MySqlClient

Friend Class MySqlCustomCommand
    Friend Sub Dispose()
        Throw New NotImplementedException()
    End Sub

    Friend Function Parameters() As Object
        Throw New NotImplementedException()
    End Function

    Friend Function ExecuteReader() As MySqlDataReader
        Throw New NotImplementedException()
    End Function

    Public Shared Widening Operator CType(v As MySqlCommand) As MySqlCustomCommand
        Throw New NotImplementedException()
    End Operator
End Class
