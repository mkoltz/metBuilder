Public Class metBuilder

    Dim inputFilename_string = ""
    Dim alertConfigFilename_string = ""
    Dim outputFilename_string = ""
    Dim eventDate As String = ""
    Dim raw_metData(0) As String

    Private Sub metBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog_inputFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog_AlertConfig.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        SaveFileDialog_outputFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
    End Sub

    Private Sub Button_inputFile_Click(sender As Object, e As EventArgs) Handles Button_inputFile.Click
        OpenFileDialog_inputFile.ShowDialog()
        inputFilename_string = OpenFileDialog_inputFile.FileName
        TextBox_inputFile.Text = inputFilename_string
    End Sub

    Private Sub Button_AlertConfig_Click(sender As Object, e As EventArgs) Handles Button_AlertConfig.Click
        OpenFileDialog_AlertConfig.ShowDialog()
        alertConfigFilename_string = OpenFileDialog_AlertConfig.FileName
        TextBox_alertConfig.Text = alertConfigFilename_string
    End Sub

    Private Sub Button_outputFile_Click(sender As Object, e As EventArgs) Handles Button_outputFile.Click
        SaveFileDialog_outputFile.ShowDialog()
        outputFilename_string = SaveFileDialog_outputFile.FileName
        TextBox_outputFile.Text = outputFilename_string
    End Sub

    Private Sub Button_Run_Click(sender As Object, e As EventArgs) Handles Button_Run.Click
        analyze_inputFile(TextBox_inputFile.Text)
    End Sub

    Public Sub analyze_inputFile(ByRef inputFilename As String)
        Dim date_found As Boolean = False
        Dim met_data_found As Boolean = False

        Using FileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(inputFilename)
            FileReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.SetDelimiters("#")

            Dim currentRow As String()
            While Not FileReader.EndOfData
                Try
                    currentRow = FileReader.ReadFields()

                    If date_found Then
                        eventDate = currentRow(0)
                        date_found = False
                    End If

                    If met_data_found Then
                        If (currentRow(0) <> "END") Then
                            raw_metData(raw_metData.Length - 1) = currentRow(0)
                            ReDim Preserve raw_metData(raw_metData.Length)
                        End If
                    End If

                    If currentRow(1) = "Date" Then
                        date_found = True
                    End If

                    If currentRow(1).Contains("HML(m)") Then
                        met_data_found = True
                    End If


                Catch ex As Exception

                End Try
            End While
        End Using

        ReDim Preserve raw_metData(raw_metData.Length - 2)





    End Sub



   
End Class
