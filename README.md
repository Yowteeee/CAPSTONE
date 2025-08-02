# CAP101 - User Login System

A VB.NET Windows Forms application with a complete user login system and dashboard.

## Features

- **User Authentication**: Secure login with username and password
- **Database Integration**: MySQL database with automatic table creation
- **Modern UI**: Clean and professional login interface
- **Dashboard**: Post-login dashboard with menu options
- **Error Handling**: Comprehensive error handling and user feedback
- **Security**: Password masking and SQL injection prevention

## Prerequisites

1. **MySQL Server**: Make sure MySQL Server is installed and running
2. **.NET 9.0**: The application targets .NET 9.0
3. **Visual Studio**: For development and building

## Database Setup

The application will automatically create the required database and tables on first run. However, you may need to configure the database connection settings in `DatabasesConfig.vb`:

```vb
Private Shared ReadOnly Server As String = "localhost"
Private Shared ReadOnly Database As String = "cap101_db"
Private Shared ReadOnly Username As String = "root"
Private Shared ReadOnly Password As String = ""
Private Shared ReadOnly Port As String = "3306"
```

## Default Login Credentials

The system creates a default admin user on first run:
- **Username**: `admin`
- **Password**: `admin123`

## How to Run

1. Open the solution in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

## Project Structure

- `Form1.vb` - Main login form
- `Form1.Designer.vb` - Login form UI design
- `DashboardForm.vb` - Dashboard form after successful login
- `DatabasesConfig.vb` - Database configuration and connection management
- `MySqlConnection.vb` - Database helper class
- `connection.vb` - Connection testing module

## Features in Detail

### Login Form
- Username and password validation
- Enter key support for quick navigation
- Visual feedback during login process
- Error messages for invalid credentials

### Dashboard
- Welcome message
- Main menu with placeholder features
- Database status checker
- Logout functionality

### Database Features
- Automatic database and table creation
- SQL injection prevention using parameterized queries
- Connection testing and error reporting
- User session management

## Security Features

- Password masking with bullet characters
- SQL injection prevention
- Input validation
- Secure connection string handling

## Customization

### Adding New Users
You can add new users directly to the database:

```sql
INSERT INTO log_in (username, password, email) 
VALUES ('newuser', 'password123', 'user@example.com');
```

### Modifying the UI
The forms use Windows Forms designer, so you can easily modify the UI by:
1. Opening the `.Designer.vb` files
2. Using the Visual Studio Forms Designer
3. Modifying colors, fonts, and layouts

### Adding New Features
The dashboard is designed to be easily extensible. You can add new menu items and functionality by:
1. Adding new buttons to the `CreateMainMenu()` method
2. Creating corresponding event handlers
3. Implementing the feature logic

## Troubleshooting

### Database Connection Issues
1. Ensure MySQL Server is running
2. Check the connection string in `DatabasesConfig.vb`
3. Verify MySQL credentials
4. Check if the port is correct (default: 3306)

### Build Issues
1. Ensure .NET 9.0 SDK is installed
2. Restore NuGet packages
3. Clean and rebuild the solution

## License

This project is provided as-is for educational and development purposes.

## Support

For issues or questions, please check the error messages in the application or review the database connection settings. 