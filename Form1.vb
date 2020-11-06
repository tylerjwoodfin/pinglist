Imports System.Data.OleDb
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data
Imports System.Text.RegularExpressions

Public Class Form1
    Dim thedatatable As New DataTable

    Dim headersSet = False
    Dim header1 = ""
    Dim header2 = ""
    Dim ipColumnIndex = -1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LoadCSV.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = ""

        fd.Title = "Load CSV"
        fd.InitialDirectory = Directory.GetCurrentDirectory
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        If strFileName <> "" Then
            parseCSV(strFileName)
        End If

    End Sub

    Private Sub parseCSV(fileName As String)
        ClickHereLabel.Visible = False
        grid1.Visible = True
        Export.Enabled = True
        Clear.Enabled = True

        Dim rowIndex As Integer
        Dim tfp As New TextFieldParser(fileName)
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
                Else
                    ipColumnIndex = 0
                End If
            End If

            rowIndex += 1

        End While

        grid1.DataSource = thedatatable
        Run.Enabled = True

    End Sub



    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Run.Click

        Dim currentRow = 0
        Dim onlineCount = 0
        Dim hostsOrHosts = "hosts"

        ProgressBar.Visible = True
        ProgressBar.Maximum = grid1.Rows.Count

        If ipColumnIndex = -1 Then
            MsgBox("Please check that you have valid IP addresses in either the left or right column.")
        Else
            For Each drow As DataGridViewRow In grid1.Rows

                If Not IsDBNull(grid1.Rows(currentRow).Cells(ipColumnIndex).Value) And currentRow < grid1.Rows.Count - 1 Then
                    Dim ipAddress As String = grid1.Rows(currentRow).Cells(ipColumnIndex).Value

                    Try
                        If My.Computer.Network.Ping(ipAddress, 1000) Then
                            grid1.Rows(currentRow).Cells(2).Value = "Online"
                            onlineCount += 1
                        Else
                            grid1.Rows(currentRow).Cells(2).Value = "Offline"
                        End If
                    Catch ex As Exception
                        grid1.Rows(currentRow).Cells(2).Value = "Offline"
                    End Try

                    currentRow += 1

                    ProgressBar.Value = currentRow
                End If

            Next

            If onlineCount = 1 Then
                hostsOrHosts = "host"
            End If

            ColorRows()

            MessageBox.Show(onlineCount & " " & hostsOrHosts & " online", "Scan Complete")

        End If

        ProgressBar.Visible = False

    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            parseCSV(path)
        Next
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles ClickHereLabel.Click
        LoadCSV.PerformClick()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Clear.Click
        thedatatable.Clear()
        ClickHereLabel.Visible = True
        grid1.Visible = False
        Export.Enabled = False
        Clear.Enabled = False
        Run.Enabled = False
    End Sub

    Private Sub ExportAsCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Export.Click

        Dim fd As SaveFileDialog = New SaveFileDialog()

        fd.Title = "Save Results"
        fd.InitialDirectory = Directory.GetCurrentDirectory
        fd.Filter = "All files (*.*)|*.*|CSV File|*.csv*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        fd.DefaultExt = "csv"

        If fd.ShowDialog() = DialogResult.OK Then
            'Build the CSV file data as a Comma separated string.
            Dim csv As String = String.Empty

            'Add the Header row for CSV file.
            csv += header1 & "," & header2 & ",Status"

            'Add new line.
            csv += vbCr & vbLf

            'Adding the Rows
            Dim currentRow = 0
            For Each drow As DataGridViewRow In grid1.Rows
                If currentRow < grid1.Rows.Count - 1 Then
                    csv += grid1.Rows(currentRow).Cells(0).Value & "," & grid1.Rows(currentRow).Cells(1).Value & "," & grid1.Rows(currentRow).Cells(2).Value

                    'Add new line.
                    csv += vbCr & vbLf

                    currentRow += 1
                End If
            Next

            'Save to CSV
            File.WriteAllText(fd.FileName, csv)
        End If

    End Sub

    Private Sub ColorRows()
        Dim currentRow = 0

        For Each drow As DataGridViewRow In grid1.Rows
            If Not IsDBNull(grid1.Rows(currentRow).Cells(2).Value) Then
                If grid1.Rows(currentRow).Cells(2).Value = "Online" Then
                    grid1.Rows(currentRow).DefaultCellStyle.BackColor = Color.GreenYellow
                ElseIf grid1.Rows(currentRow).Cells(2).Value = "Offline" Then
                    grid1.Rows(currentRow).DefaultCellStyle.BackColor = Color.DarkGray
                End If
            End If

            currentRow += 1
        Next
    End Sub

    Private Sub grid1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grid1.ColumnHeaderMouseClick
        ColorRows()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCSV.Click
        ClickHereLabel.Visible = False
        grid1.Visible = True
        Export.Enabled = True
        Clear.Enabled = True

        thedatatable.Clear()
        thedatatable.Columns.Clear()

        With thedatatable
            .Columns.Add("IP Address", System.Type.GetType("System.String"))
            .Columns.Add("Client Name", System.Type.GetType("System.String"))
            .Columns.Add("Status", System.Type.GetType("System.String"))
        End With

        ipColumnIndex = 0
        grid1.DataSource = thedatatable
        Run.Enabled = True

    End Sub

    Private Sub About_Click(sender As Object, e As EventArgs) Handles About.Click
        MsgBox("A tool to ping multiple IP addresses from a CSV and export the results" +
               vbLf & vbLf & vbLf +
               "© 2020 Tyler Woodfin / www.tyler.cloud" +
               vbLf & "Donations Appreciated - Venmo: tylerjwoodfin")
    End Sub
End Class