Imports System.Data.OleDb
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1
    Dim thedatatable As New DataTable

    Dim headersSet = False
    Dim header1 = ""
    Dim header2 = ""
    Dim ipColumnIndex = -1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LoadCSV.Click

        Label1.Visible = False

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

            While tfp.EndOfData = False
                Dim fields = tfp.ReadFields()
                Dim column1 = fields(0)
                Dim column2 = fields(1)

                If headersSet = False Then

                    If column1.Contains(".") Or column2.Contains(".") Then
                        header1 = "IP Address"
                        header2 = "Client Name"

                        With thedatatable
                            .Columns.Add(header1, System.Type.GetType("System.String"))
                            .Columns.Add(header2, System.Type.GetType("System.String"))
                            .Columns.Add("Status", System.Type.GetType("System.String"))
                        End With

                        Dim newrow As DataRow = thedatatable.NewRow
                        newrow(header1) = column1
                        newrow(header2) = column2
                        newrow("Status") = "--"
                        thedatatable.Rows.Add(newrow)
                    Else
                        header1 = column1
                        header2 = column2

                        With thedatatable
                            .Columns.Add(header1, System.Type.GetType("System.String"))
                            .Columns.Add(header2, System.Type.GetType("System.String"))
                            .Columns.Add("Status", System.Type.GetType("System.String"))
                        End With
                    End If

                    headersSet = True
                Else
                    Dim newrow As DataRow = thedatatable.NewRow
                    newrow(header1) = column1
                    newrow(header2) = column2
                    newrow("Status") = "--"
                    thedatatable.Rows.Add(newrow)
                End If

                If ipColumnIndex = -1 Then
                    If Regex.Matches(column1, "\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b").Count = 1 Then
                        ipColumnIndex = 0
                    ElseIf Regex.Matches(column2, "\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b").Count = 1 Then
                        ipColumnIndex = 1
                    End If
                End If

                rowIndex += 1

            End While

            grid1.DataSource = thedatatable
            Run.Enabled = True


        End If

    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Run.Click

        If ipColumnIndex = -1 Then
            MsgBox("Please check that you have valid IP addresses in either the left or right column.")
        Else
            For Each drow As DataRow In thedatatable.Rows

                Dim ipAddress As String = drow.ItemArray.ElementAt(ipColumnIndex).ToString
                ' MsgBox("Scanning ." & ipAddress & ".")

                If Regex.Matches(ipAddress, "\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b").Count = 1 Then
                    Try
                        If My.Computer.Network.Ping(ipAddress, 1000) Then
                            drow.SetField("Status", "Online")
                        Else
                            drow.SetField("Status", "Offline")
                        End If
                    Catch ex As Exception
                        drow.SetField("Status", "Offline")
                    End Try

                Else
                    drow.SetField("Status", "Invalid IP Address")
                End If

            Next
        End If

    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            MsgBox(path)
        Next
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class