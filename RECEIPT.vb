Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class RECEIPT
    Public Property user_Role As String
    Public Property user_id As String
    Public Property user_fullname As String
    Private paymentAmount As Integer
    Private changeAmount As Integer

    Private Sub RECEIPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub LoadReport(pAmount As Decimal, cAmount As Decimal)
        paymentAmount = pAmount
        changeAmount = cAmount
        ' Load cashier name first from database
        LoadFullNameFromDatabase()

        Dim rpt As New CrystalReport1()

        ' Set all report parameters
        With rpt
            .SetParameterValue("PaymentAmount", paymentAmount)
            .SetParameterValue("ChangeAmount", changeAmount)
            .SetParameterValue("CashierName", user_fullname)
            .SetParameterValue("CashierID", user_id)
        End With

        CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub LoadFullNameFromDatabase()
        Try
            ' Open your connection (adjust if you have your own connection function)
            If con.State = ConnectionState.Closed Then con.Open()

            Dim query As String = "SELECT firstname, lastname FROM login WHERE user_id = @userId"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@userId", user_id)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim firstname As String = reader("firstname").ToString()
                        Dim lastname As String = reader("lastname").ToString()
                        user_fullname = firstname & " " & lastname
                    Else
                        user_fullname = "Unknown User"
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading cashier name: " & ex.Message)
            user_fullname = "Unknown User"
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
End Class