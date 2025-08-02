Imports MySql.Data.MySqlClient
Imports System.Data

Public Class TestDatabase
    Public Shared Sub TestConnection()
        Try
            Console.WriteLine("Testing database connection...")
            
            Dim connectionString As String = "Server=127.0.0.1;Port=3306;Database=cap_101;Uid=root;Pwd=johnarbenanguring;SslMode=none;"
            
            Using connection As New MySqlConnection(connectionString)
                Console.WriteLine("Attempting to open connection...")
                connection.Open()
                
                If connection.State = ConnectionState.Open Then
                    Console.WriteLine("✓ Database connection successful!")
                    
                    ' Test if the log_in table exists
                    Try
                        Using command As New MySqlCommand("SELECT COUNT(*) FROM log_in", connection)
                            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                            Console.WriteLine($"✓ Found {count} records in log_in table")
                        End Using
                    Catch tableEx As Exception
                        Console.WriteLine($"✗ Error accessing log_in table: {tableEx.Message}")
                        Console.WriteLine("The log_in table might not exist. Creating it...")
                        
                        ' Create the log_in table if it doesn't exist
                        Try
                            Dim createTableQuery As String = "
                                CREATE TABLE IF NOT EXISTS log_in (
                                    id INT AUTO_INCREMENT PRIMARY KEY,
                                    username VARCHAR(50) NOT NULL UNIQUE,
                                    password VARCHAR(100) NOT NULL,
                                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                )"
                            
                            Using command As New MySqlCommand(createTableQuery, connection)
                                command.ExecuteNonQuery()
                                Console.WriteLine("✓ log_in table created successfully")
                            End Using
                            
                            ' Insert a test user
                            Try
                                Dim insertQuery As String = "INSERT INTO log_in (username, password) VALUES (@username, @password)"
                                Using command As New MySqlCommand(insertQuery, connection)
                                    command.Parameters.AddWithValue("@username", "admin")
                                    command.Parameters.AddWithValue("@password", "admin123")
                                    command.ExecuteNonQuery()
                                    Console.WriteLine("✓ Test user 'admin' created with password 'admin123'")
                                End Using
                            Catch insertEx As MySqlException
                                If insertEx.Number = 1062 Then ' Duplicate entry
                                    Console.WriteLine("✓ Test user already exists")
                                Else
                                    Console.WriteLine($"✗ Error creating test user: {insertEx.Message}")
                                End If
                            End Try
                            
                        Catch createEx As Exception
                            Console.WriteLine($"✗ Error creating log_in table: {createEx.Message}")
                        End Try
                    End Try
                Else
                    Console.WriteLine("✗ Failed to open database connection")
                End If
            End Using
            
        Catch mysqlEx As MySqlException
            Console.WriteLine($"✗ MySQL Error {mysqlEx.Number}: {mysqlEx.Message}")
        Catch generalEx As Exception
            Console.WriteLine($"✗ Connection Error: {generalEx.Message}")
        End Try
        
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub
End Class 