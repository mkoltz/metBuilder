Imports System.IO

Public Class metBuilder

    Dim inputFilename_string = ""
    Dim alertConfigFilename_string = ""
    Dim outputFilename_string = ""
    Dim eventDate As String = ""
    Dim met_data(0) As Array
    Dim alert_config(0) As Array
    Dim dateTimeFormat As String = "HH:mm"

    Private Sub metBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog_inputFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog_AlertConfig.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        SaveFileDialog_outputFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        DateTimePicker_sunrise.CustomFormat = dateTimeFormat
        DateTimePicker_sunset.CustomFormat = dateTimeFormat
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
        createAlertArray()
        'read alert config file and biuld an output string
        'Take the input array and build an output array
        writeOutputFile()

    End Sub

    Public Sub writeOutputFile()

        Dim sunrise_time_string As String = getTimeString(DateTimePicker_sunrise)
        Dim sunset_time_string As String = getTimeString(DateTimePicker_sunset)


        Using fileWriter As New StreamWriter(TextBox_outputFile.Text)

            fileWriter.WriteLine(+vbCrLf)

            fileWriter.WriteLine("""" + TextBox_ExerciseName.Text + """" + vbCrLf)
            'fileWriter.WriteLine(My.Resources.outputFile_String6 + vbCrLf)

            fileWriter.WriteLine("""" + ComboBox_ForecastSite.Text + """" + vbCrLf)
            '  fileWriter.WriteLine(My.Resources. + vbCrLf)

            fileWriter.WriteLine("""" + ComboBox_Timezone.Text + """" + vbCrLf)
            'fileWriter.WriteLine(My.Resources.outputFile_String4 + vbCrLf)

            fileWriter.WriteLine("""" & sunrise_time_string & """" & " #Sunrise Time")
            fileWriter.WriteLine("""" & sunset_time_string & """" & " #Sunset Time" & vbCrLf)
            'fileWriter.WriteLine(My.Resources.outputFile_String5 + vbCrLf)

            For Each alert As Array In alert_config

                fileWriter.WriteLine("#" & vbCrLf & "#" & vbCrLf & """" & alert(0) & """" & vbCrLf & """" & alert(1) & """" & vbCrLf & """" & alert(2) & """")

            Next

            'fileWriter.WriteLine(My.Resources.outputFile_String6)

        End Using

    End Sub

    Public Function getTimeString(ByRef picker As DateTimePicker)
        Dim time_string As String = ""

        Dim hour As Integer = picker.Value.Hour
        Dim minute As Integer = picker.Value.Minute
        Dim time_classifier As String


        If hour >= 12 Then
            time_classifier = "pm"
            If hour > 12 Then
                hour = hour - 12
            End If
        Else
            time_classifier = "am"
        End If

        time_string = hour & ":" & minute & time_classifier

        Return time_string
    End Function


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
                            met_data(met_data.Length - 1) = currentRow(0).Split(New String() {}, StringSplitOptions.RemoveEmptyEntries)
                            ReDim Preserve met_data(met_data.Length)
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


        ReDim Preserve met_data(met_data.Length - 2)

    End Sub

    Public Sub createAlertArray()

        Using FileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(TextBox_alertConfig.Text)

            FileReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.SetDelimiters(",")

            Dim currentRow As String()
            While Not FileReader.EndOfData
                Try
                    currentRow = FileReader.ReadFields()

                    alert_config(alert_config.Length - 1) = currentRow
                    ReDim Preserve alert_config(alert_config.Length)

                Catch ex As Exception

                End Try

            End While

        End Using


        ReDim Preserve alert_config(alert_config.Length - 2)

    End Sub

End Class
