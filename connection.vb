Imports System

Module TestConnection
    Public Property DatabasesConfig As Object

    Public Sub TestConnection()
        ' Test the database connection
        Dim result = DatabasesConfig.TestDatabaseConnection()

        If result.Success Then
            Console.WriteLine("✓ " & result.Message)

            ' Test DatabaseHelper
            Dim dbHelper As New DatabaseHelper(DatabasesConfig.GetConnectionString())

            If dbHelper.TestConnection() Then
                Console.WriteLine("✓ DatabaseHelper connection test passed")

                ' Example query (replace with your actual table)
                Try
                    Dim data As DataTable = dbHelper.ExecuteQuery("SHOW TABLES")
                    Console.WriteLine($"✓ Found {data.Rows.Count} tables in database")

                    For Each row As DataRow In data.Rows
                        Console.WriteLine($"  - Table: {row(0)}")
                    Next
                Catch ex As Exception
                    Console.WriteLine($"✗ Query test failed: {ex.Message}")
                End Try
            Else
                Console.WriteLine("✗ DatabaseHelper connection test failed")
            End If
        Else
            Console.WriteLine("✗ " & result.Message)
        End If

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module