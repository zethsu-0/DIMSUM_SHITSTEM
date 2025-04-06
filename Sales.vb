Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Sales
    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SHITSTEMDataSet.DailySales' table. You can move, or remove it, as needed.
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        'TODO: This line of code loads data into the 'SHITSTEMDataSet.MonthlySales' table. You can move, or remove it, as needed.
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)

        Opencon()
        Dim cmd As New SqlCommand("SELECT Month, Earned FROM MonthlySales", con)
        Dim reader As SqlDataReader

        Chart1.Series.Clear()
        Dim series As New Series("Earned")
        series.ChartType = SeriesChartType.Column
        series.BorderWidth = 2
        series.IsValueShownAsLabel = True



        ' Define alternating colors
        Dim color1 As Color = Color.DarkOrange
        Dim color2 As Color = Color.Gray

        With Chart1.ChartAreas(0).AxisX
            .Interval = 1
            .LabelStyle.Angle = -45
            .LabelStyle.IsStaggered = True
        End With

        Try
            reader = cmd.ExecuteReader()
            Dim index As Integer = 0 ' Track index for alternating colors
            While reader.Read()
                Dim point As DataPoint = New DataPoint()
                point.SetValueXY(reader("Month").ToString(), Convert.ToDouble(reader("Earned")))

                ' Alternate colors
                If index Mod 2 = 0 Then
                    point.Color = color1 ' Even index -> DarkBlue
                Else
                    point.Color = color2 ' Odd index -> Red
                End If

                series.Points.Add(point)
                index += 1
            End While
            Chart1.Series.Add(series)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

        Opencon()
        Dim cmd2 As New SqlCommand("SELECT Day, Earned FROM WeeklySales", con)
        Dim reader2 As SqlDataReader

        Chart2.Series.Clear()
        Dim series2 As New Series("Daily Sales")
        series2.ChartType = SeriesChartType.Column ' Example: Line chart for daily sales
        series2.BorderWidth = 2
        series2.IsValueShownAsLabel = True

        ' Customize Chart2 if needed
        With Chart2.ChartAreas(0).AxisX
            .Interval = 1
            .LabelStyle.Angle = -45
            .LabelStyle.IsStaggered = True
        End With

        Dim color3 As Color = Color.DarkOrange
        Dim color4 As Color = Color.Gray

        With Chart2.ChartAreas(0).AxisX
            .Interval = 1
            .LabelStyle.Angle = -45
            .LabelStyle.IsStaggered = True
        End With



        Try
            reader2 = cmd2.ExecuteReader()
            Dim index As Integer = 0
            While reader2.Read()
                Dim point As DataPoint = New DataPoint()
                point.SetValueXY(reader2("Day").ToString(), Convert.ToDouble(reader2("Earned")))

                If Index Mod 2 = 0 Then
                    point.Color = color3 ' Even index -> DarkBlue
                Else
                    point.Color = color4 ' Odd index -> Red
                End If


                series2.Points.Add(point)
                Index += 1

            End While
            Chart2.Series.Add(series2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try


        Label2.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim confirm = MessageBox.Show("are you sure you want to Exit?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If confirm = MsgBoxResult.Ok Then
            Me.Close()
        Else
            Return
        End If
    End Sub

End Class