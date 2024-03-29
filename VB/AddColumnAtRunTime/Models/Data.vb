Imports System.Web
Imports System.Data.OleDb
Imports System.Data

Namespace DisplayDetailInPopupWindow.Models

    Public Class ConnectionRepository

        Public Shared Function GetDataConnection() As OleDbConnection
            Dim connection As OleDbConnection = New OleDbConnection()
            connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/data.mdb"))
            Return connection
        End Function
    End Class

    Public Module CustomerRepository

        Public Function GetCustomers() As DataTable
            Dim dataTableCustomers As DataTable = New DataTable()
            Using connection As OleDbConnection = ConnectionRepository.GetDataConnection()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(String.Empty, connection)
                adapter.SelectCommand.CommandText = "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [Country], [City] FROM [Customers]"
                adapter.Fill(dataTableCustomers)
            End Using

            Return dataTableCustomers
        End Function
    End Module
End Namespace
