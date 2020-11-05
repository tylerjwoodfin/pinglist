Imports System.Data.OleDb
Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Public Class Form1
    Dim thedatatable As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LoadCSV.Click

        Dim rowIndex As Integer

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = Directory.GetCurrentDirectory
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        If strFileName <> "" Then
            Dim tfp As New TextFieldParser(strFileName)
            tfp.Delimiters = New String() {","}
            tfp.TextFieldType = FieldType.Delimited


            'tfp.ReadLine() ' skip header

            Dim header1 = ""
            Dim header2 = ""

            While tfp.EndOfData = False
                Dim fields = tfp.ReadFields()
                Dim column1 = fields(0)
                Dim column2 = fields(1)

                If rowIndex = 0 Then
                    header1 = column1
                    header2 = column2

                    With thedatatable
                        .Columns.Add(header1, System.Type.GetType("System.String"))
                        .Columns.Add(header2, System.Type.GetType("System.String"))
                    End With
                Else
                    Dim newrow As DataRow = thedatatable.NewRow
                    newrow(header1) = column1
                    newrow(header2) = column2
                    thedatatable.Rows.Add(newrow)
                End If

                rowIndex += 1

            End While

            'With thedatatable
            '    .Columns.Add("customer", System.Type.GetType("System.String"))
            '    .Columns.Add("product", System.Type.GetType("System.String"))
            '    .Columns.Add("thedate", System.Type.GetType("System.DateTime"))
            '    .Columns.Add("thevalue", System.Type.GetType("System.Double"))
            'End With

            'Dim newrow As DataRow = thedatatable.NewRow
            'newrow("customer") = "Customer 1"
            'newrow("product") = "Product 1"
            'newrow("thedate") = Today
            'newrow("thevalue") = "123.45"
            'thedatatable.Rows.Add(newrow)

            'Dim newrow1 As DataRow = thedatatable.NewRow
            'newrow1("customer") = "Customer 2"
            'newrow1("product") = "Product 2"
            'newrow1("thedate") = Today.AddDays(1)
            'newrow1("thevalue") = "34.67"
            'thedatatable.Rows.Add(newrow1)

            'Dim newrow2 As DataRow = thedatatable.NewRow
            'newrow2("customer") = "Customer 3"
            'newrow2("product") = "Product 3"
            'newrow2("thedate") = Today.AddDays(2)
            'newrow2("thevalue") = "862.45"
            'thedatatable.Rows.Add(newrow2)

            ' MsgBox(thedatatable.Rows.Count)

            grid1.DataSource = thedatatable

            'For Each drow As DataRow In thedatatable.Rows
            '    MsgBox(drow(header1) & vbCrLf & drow(header2))
            'Next
        End If

    End Sub

End Class