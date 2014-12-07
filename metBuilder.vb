Imports System.IO

Public Class metBuilder

    Dim inputFilename_string = ""
    Dim alertConfigFilename_string = ""
    Dim outputFilename_string = ""
    Dim eventDate As String = ""
    Dim met_data(0) As Array
    Dim alert_config(0) As Array
    Dim dateTimeFormat As String = "HH:mm"
    Dim output_met_array(0) As Array

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
        Dim nextDay As Boolean = False
        Dim averageWindspeed(1), averageWindDirection(1), averageTemp(1) As Integer
        Dim numMetRows As Byte = 0
        Dim row As Byte = 0

        For Each raw_met_row As String() In met_data

            averageWindspeed(0) += raw_met_row(3)
            averageWindDirection(0) += raw_met_row(4)
            averageTemp(0) += raw_met_row(2)

            numMetRows += 1
        Next

        averageTemp(0) = (Math.Floor(averageTemp(0) / numMetRows)) * (9 / 5) + 32
        averageWindDirection(0) = Math.Floor(averageWindDirection(0) / numMetRows)
        averageWindspeed(0) = Math.Floor(averageWindspeed(0) / numMetRows * 2.23694)

        Console.WriteLine(averageTemp(0))
        Console.WriteLine(averageWindDirection(0))
        Console.WriteLine(averageWindspeed(0))


        For c As Integer = (NumericUpDown_DaysBefore.Value * -1) To (NumericUpDown_DaysAfter.Value)
            If c = 0 Then
                'build excercise day met
                While Not nextDay
                    Console.WriteLine(DateAdd(DateInterval.Day, c, CDate(eventDate)) & " " & timeString)
                    startTime = addHours(startTime, 1, timeString, nextDay)
                End While
                nextDay = False

            Else
                'build before and after excercise day met
                While Not nextDay

                    averageTemp(1) = averageTemp(0) - NumericUpDown_VariabilityTemp.Value + Rnd() * (NumericUpDown_VariabilityTemp.Value * 2)
                    averageWindDirection(1) = averageWindDirection(0) - NumericUpDown_VariabilityWindDirection.Value + Rnd() * (NumericUpDown_VariabilityWindDirection.Value * 2)
                    averageWindspeed(1) = averageWindspeed(0) - NumericUpDown_VariabilityWindSpeed.Value + Rnd() * (NumericUpDown_VariabilityWindSpeed.Value * 2)
                    output_met_array(row) = {DateAdd(DateInterval.Day, c, CDate(eventDate)), timeString, "MostlyCloudy", averageTemp(1), averageWindDirection(1), averageWindspeed(1), "No Alert"}
                    ReDim Preserve output_met_array(output_met_array.Length)
                    startTime = addHours(startTime, 3, timeString, nextDay)


                    For Each value As String In output_met_array(row)
                        Console.Write(value & " ")
                    Next
                    row += 1
                    Console.WriteLine()
                End While

                nextDay = False

            End If

        Next

    End Sub

    ''' <summary>
    ''' Used to add a specified amount of hours to a byte variable and create a time string based on that hour.  Also turns on the next day switch and handles AM PM shifts
    ''' </summary>
    ''' <param name="startHour">Input start hour onto which the increment will be added</param>
    ''' <param name="increment">Number of hours to add</param>
    ''' <param name="timeString">Time String the function will modify</param>
    ''' <param name="nextDay">Boolean to switch to the next day</param>
    ''' <returns>outputHour byte</returns>
    ''' <remarks></remarks>
    Public Function addHours(ByRef startHour As Byte, ByRef increment As Byte, ByRef timeString As String, ByRef nextDay As Boolean) As Byte

        Dim outputHour As Byte = 0
        Dim hourClassifier As String = "am"
        outputHour = startHour + increment
        Dim stringHour As String

        If (outputHour >= 24) Then
            outputHour = outputHour - 24
            nextDay = True
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
