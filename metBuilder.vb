﻿Imports System.IO

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
        DateTimePicker_Sunrise.CustomFormat = dateTimeFormat
        DateTimePicker_Sunset.CustomFormat = dateTimeFormat
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
        createMetArray()
        'Take the input array and build an output array
        writeOutputFile()

    End Sub

    Public Sub writeOutputFile()

        Dim sunrise_time_string As String = getTimeString(DateTimePicker_sunrise)
        Dim sunset_time_string As String = getTimeString(DateTimePicker_sunset)


        Using fileWriter As New StreamWriter(TextBox_outputFile.Text)

            fileWriter.WriteLine("#Version number of this files format" & vbCrLf & "1" & vbCrLf)
            fileWriter.WriteLine("#Exercise Name" & vbCrLf & """" + TextBox_ExerciseName.Text + """" + vbCrLf)
            fileWriter.WriteLine("#Forecast Site" & vbCrLf & """" + ComboBox_ForecastSite.Text + """" + vbCrLf)
            fileWriter.WriteLine("#Time zone" & vbCrLf & """" + ComboBox_Timezone.Text + """" + vbCrLf)
            fileWriter.WriteLine("#Sunset and Sunrise Time" & vbCrLf & """" & sunrise_time_string & """")
            fileWriter.WriteLine("""" & sunset_time_string & """" & vbCrLf)
            fileWriter.WriteLine("#Alert Configuration" & vbCrLf)

            For Each alert As Array In alert_config

                fileWriter.WriteLine("""" & alert(0) & """" & vbCrLf & """" & alert(1) & """" & vbCrLf & """" & alert(2) & """" & vbCrLf & vbCrLf)

            Next

            fileWriter.WriteLine("END # End of the alerts list")



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


    Public Sub createMetArray()
        'loop through all of the days and do different actions on the event day than on the preceeding and following days.

        Dim startTime As Byte = 6
        Dim timeString As String = "6:00am"

        For c As Integer = (NumericUpDown_DaysBefore.Value * -1) To (NumericUpDown_DaysAfter.Value)

            If c = 0 Then
                'build excercise day met
                Console.WriteLine("It's the event Data: " & eventDate)
            Else
                'build before and after excercise day met
                Console.WriteLine("The Date is:" & DateAdd(DateInterval.Day, c, CDate(eventDate)))

                For x = 0 To 24
                    Console.WriteLine("The time is: " & timeString)
                    startTime = addHours(startTime, 3, timeString)
                Next


            End If

        Next

    End Sub

    Public Function addHours(ByRef startHour As Byte, ByRef increment As Byte, ByRef timeString As String) As Byte
        Dim outputHour As Byte = 0
        Dim hourClassifier As String = "am"
        outputHour = startHour + increment
        Dim stringHour As String

        If (outputHour >= 24) Then
            outputHour = outputHour - 24
        End If

        If (outputHour >= 12) Then
            hourClassifier = "pm"
        End If

        If (outputHour > 12) Then
            stringHour = CStr(outputHour - 12)
        ElseIf (outputHour = 0) Then
            stringHour = 12
        Else
            stringHour = CStr(outputHour)
        End If


        timeString = stringHour & ":00" & hourClassifier

        Return outputHour
    End Function

End Class
