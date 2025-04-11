Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form2


    Public Property user_id As String
    Private lastOpenedForm As Form = Nothing

    Private PRODUCTS_TAB As New PRODUCTS_TAB()
    Private EMPLOYEE_TAB As New EMPLOYEE_TAB()
    Private SALES_TAB As New SALES_TAB()

    Private Sub OpenNewForm(newForm As Form)
        If lastOpenedForm IsNot Nothing AndAlso Not lastOpenedForm.IsDisposed Then
            lastOpenedForm.Close()
        End If

        lastOpenedForm = newForm
        newForm.Show()
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        Form1.Show()
    End Sub



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        If Not String.IsNullOrEmpty(user_id) Then
            GetUserFullName()
            con.Close()
        Else
            Label3.Text = "Invalid User ID"
            con.Close()
        End If

        Timer1.Interval = 1000
        Timer1.Start()
    End Sub

    Private Sub Form2_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub

    Private Sub GetUserFullName()
        Try

            Dim query As String = "SELECT firstname, lastname FROM login WHERE user_id = @user_id"

            Using command As New SqlCommand(query, con)

                command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.Read() Then
                    Dim firstName As String = reader("firstname").ToString()
                    Dim lastName As String = reader("lastname").ToString()

                    Label3.Text = firstName & " " & lastName
                    con.Close()
                Else
                    Label3.Text = "User not found"
                    con.Close()
                End If

                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving user data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            con.Close()
        End Try

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub productbtn_Click(sender As Object, e As EventArgs) Handles productbtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(PRODUCTS_TAB)
        PRODUCTS_TAB.Dock = DockStyle.Fill
    End Sub

    Private Sub salesbtn_Click(sender As Object, e As EventArgs) Handles salesbtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(SALES_TAB)
        EMPLOYEE_TAB.Dock = DockStyle.Fill
    End Sub

    Private Sub employeebtn_Click(sender As Object, e As EventArgs) Handles employeebtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(EMPLOYEE_TAB)
        EMPLOYEE_TAB.Dock = DockStyle.Fill
    End Sub

    Private Sub cashierbtn_Click(sender As Object, e As EventArgs) Handles cashierbtn.Click
        CASHIER.Show()
    End Sub

    Private Sub logoutbtn_Click(sender As Object, e As EventArgs) Handles logoutbtn.Click
        Dim sure As DialogResult = MessageBox.Show(Me, "Are you sure you want to Logout?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If sure = DialogResult.OK Then
            Dim form1 As New Form1()
            form1.Owner = Me
            OpenNewForm(form1)
            Me.Hide()
        End If
    End Sub
End Class