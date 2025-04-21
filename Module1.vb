Imports System.Data.SqlClient
Module Module1

    Public con As New SqlConnection
    Public cmd As New SqlCommand

    Sub Opencon()
        con.ConnectionString = "Data Source=KUPAL\SQLEXPRESS;Initial Catalog=SHITSTEM;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True"
        con.Open()
    End Sub

End Module
