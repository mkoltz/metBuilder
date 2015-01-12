<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class metBuilder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox_inputFile = New System.Windows.Forms.TextBox()
        Me.Label_inputFile = New System.Windows.Forms.Label()
        Me.Button_inputFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog_inputFile = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox_ExerciseName = New System.Windows.Forms.TextBox()
        Me.Label_ExerciseName = New System.Windows.Forms.Label()
        Me.Label_ForecastSite = New System.Windows.Forms.Label()
        Me.ComboBox_ForecastSite = New System.Windows.Forms.ComboBox()
        Me.Label_timezone = New System.Windows.Forms.Label()
        Me.ComboBox_Timezone = New System.Windows.Forms.ComboBox()
        Me.Label_sunrise = New System.Windows.Forms.Label()
        Me.Label_sunset = New System.Windows.Forms.Label()
        Me.DateTimePicker_Sunrise = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker_Sunset = New System.Windows.Forms.DateTimePicker()
        Me.OpenFileDialog_AlertConfig = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog_outputFile = New System.Windows.Forms.SaveFileDialog()
        Me.TextBox_outputFile = New System.Windows.Forms.TextBox()
        Me.Button_outputFile = New System.Windows.Forms.Button()
        Me.Label_outputFile = New System.Windows.Forms.Label()
        Me.Button_Run = New System.Windows.Forms.Button()
        Me.NumericUpDown_DaysBefore = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_DaysAfter = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_VariabilityTemp = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_VariabilityWindSpeed = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_VariabilityWindDirection = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown_DaysBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_DaysAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_VariabilityTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_VariabilityWindSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_VariabilityWindDirection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox_inputFile
        '
        Me.TextBox_inputFile.Location = New System.Drawing.Point(48, 31)
        Me.TextBox_inputFile.Name = "TextBox_inputFile"
        Me.TextBox_inputFile.Size = New System.Drawing.Size(439, 20)
        Me.TextBox_inputFile.TabIndex = 1
        '
        'Label_inputFile
        '
        Me.Label_inputFile.AutoSize = True
        Me.Label_inputFile.Location = New System.Drawing.Point(45, 9)
        Me.Label_inputFile.Name = "Label_inputFile"
        Me.Label_inputFile.Size = New System.Drawing.Size(364, 13)
        Me.Label_inputFile.TabIndex = 1
        Me.Label_inputFile.Text = "Input Filename (same *.txt used by CHPConvert to create WebPuff met files)"
        '
        'Button_inputFile
        '
        Me.Button_inputFile.Location = New System.Drawing.Point(493, 30)
        Me.Button_inputFile.Name = "Button_inputFile"
        Me.Button_inputFile.Size = New System.Drawing.Size(75, 23)
        Me.Button_inputFile.TabIndex = 2
        Me.Button_inputFile.Text = "Browse"
        Me.Button_inputFile.UseVisualStyleBackColor = True
        '
        'TextBox_ExerciseName
        '
        Me.TextBox_ExerciseName.Location = New System.Drawing.Point(48, 80)
        Me.TextBox_ExerciseName.Name = "TextBox_ExerciseName"
        Me.TextBox_ExerciseName.Size = New System.Drawing.Size(520, 20)
        Me.TextBox_ExerciseName.TabIndex = 3
        '
        'Label_ExerciseName
        '
        Me.Label_ExerciseName.AutoSize = True
        Me.Label_ExerciseName.Location = New System.Drawing.Point(45, 64)
        Me.Label_ExerciseName.Name = "Label_ExerciseName"
        Me.Label_ExerciseName.Size = New System.Drawing.Size(292, 13)
        Me.Label_ExerciseName.TabIndex = 4
        Me.Label_ExerciseName.Text = "Exercise Title and Date (e.g., ""BGCA Nov 21, 2014 CAIRA"")"
        '
        'Label_ForecastSite
        '
        Me.Label_ForecastSite.AutoSize = True
        Me.Label_ForecastSite.Location = New System.Drawing.Point(28, 126)
        Me.Label_ForecastSite.Name = "Label_ForecastSite"
        Me.Label_ForecastSite.Size = New System.Drawing.Size(69, 13)
        Me.Label_ForecastSite.TabIndex = 6
        Me.Label_ForecastSite.Text = "Forecast Site"
        '
        'ComboBox_ForecastSite
        '
        Me.ComboBox_ForecastSite.FormattingEnabled = True
        Me.ComboBox_ForecastSite.Items.AddRange(New Object() {"Richmond, KY", "Pueblo, CO"})
        Me.ComboBox_ForecastSite.Location = New System.Drawing.Point(106, 122)
        Me.ComboBox_ForecastSite.Name = "ComboBox_ForecastSite"
        Me.ComboBox_ForecastSite.Size = New System.Drawing.Size(464, 21)
        Me.ComboBox_ForecastSite.TabIndex = 4
        Me.ComboBox_ForecastSite.Text = "Richmond, KY"
        '
        'Label_timezone
        '
        Me.Label_timezone.AutoSize = True
        Me.Label_timezone.Location = New System.Drawing.Point(44, 166)
        Me.Label_timezone.Name = "Label_timezone"
        Me.Label_timezone.Size = New System.Drawing.Size(53, 13)
        Me.Label_timezone.TabIndex = 8
        Me.Label_timezone.Text = "Timezone"
        '
        'ComboBox_Timezone
        '
        Me.ComboBox_Timezone.FormattingEnabled = True
        Me.ComboBox_Timezone.Items.AddRange(New Object() {"EST", "CST", "MST", "PST", "EDT", "CDT", "MDT", "PDT"})
        Me.ComboBox_Timezone.Location = New System.Drawing.Point(106, 163)
        Me.ComboBox_Timezone.Name = "ComboBox_Timezone"
        Me.ComboBox_Timezone.Size = New System.Drawing.Size(464, 21)
        Me.ComboBox_Timezone.TabIndex = 5
        Me.ComboBox_Timezone.Text = "EST"
        '
        'Label_sunrise
        '
        Me.Label_sunrise.AutoSize = True
        Me.Label_sunrise.Location = New System.Drawing.Point(55, 213)
        Me.Label_sunrise.Name = "Label_sunrise"
        Me.Label_sunrise.Size = New System.Drawing.Size(46, 13)
        Me.Label_sunrise.TabIndex = 10
        Me.Label_sunrise.Text = "Sunrise*"
        '
        'Label_sunset
        '
        Me.Label_sunset.AutoSize = True
        Me.Label_sunset.Location = New System.Drawing.Point(57, 242)
        Me.Label_sunset.Name = "Label_sunset"
        Me.Label_sunset.Size = New System.Drawing.Size(44, 13)
        Me.Label_sunset.TabIndex = 11
        Me.Label_sunset.Text = "Sunset*"
        '
        'DateTimePicker_Sunrise
        '
        Me.DateTimePicker_Sunrise.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker_Sunrise.Location = New System.Drawing.Point(106, 211)
        Me.DateTimePicker_Sunrise.Name = "DateTimePicker_Sunrise"
        Me.DateTimePicker_Sunrise.ShowUpDown = True
        Me.DateTimePicker_Sunrise.Size = New System.Drawing.Size(63, 20)
        Me.DateTimePicker_Sunrise.TabIndex = 6
        Me.DateTimePicker_Sunrise.Value = New Date(2015, 1, 12, 7, 0, 0, 0)
        '
        'DateTimePicker_Sunset
        '
        Me.DateTimePicker_Sunset.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker_Sunset.Location = New System.Drawing.Point(106, 238)
        Me.DateTimePicker_Sunset.Name = "DateTimePicker_Sunset"
        Me.DateTimePicker_Sunset.ShowUpDown = True
        Me.DateTimePicker_Sunset.Size = New System.Drawing.Size(63, 20)
        Me.DateTimePicker_Sunset.TabIndex = 7
        Me.DateTimePicker_Sunset.Value = New Date(2015, 1, 12, 18, 30, 0, 0)
        '
        'TextBox_outputFile
        '
        Me.TextBox_outputFile.Location = New System.Drawing.Point(106, 441)
        Me.TextBox_outputFile.Name = "TextBox_outputFile"
        Me.TextBox_outputFile.Size = New System.Drawing.Size(383, 20)
        Me.TextBox_outputFile.TabIndex = 13
        '
        'Button_outputFile
        '
        Me.Button_outputFile.Location = New System.Drawing.Point(495, 441)
        Me.Button_outputFile.Name = "Button_outputFile"
        Me.Button_outputFile.Size = New System.Drawing.Size(75, 23)
        Me.Button_outputFile.TabIndex = 14
        Me.Button_outputFile.Text = "Browse"
        Me.Button_outputFile.UseVisualStyleBackColor = True
        '
        'Label_outputFile
        '
        Me.Label_outputFile.AutoSize = True
        Me.Label_outputFile.Location = New System.Drawing.Point(39, 444)
        Me.Label_outputFile.Name = "Label_outputFile"
        Me.Label_outputFile.Size = New System.Drawing.Size(58, 13)
        Me.Label_outputFile.TabIndex = 19
        Me.Label_outputFile.Text = "Output File"
        '
        'Button_Run
        '
        Me.Button_Run.Location = New System.Drawing.Point(266, 485)
        Me.Button_Run.Name = "Button_Run"
        Me.Button_Run.Size = New System.Drawing.Size(75, 23)
        Me.Button_Run.TabIndex = 15
        Me.Button_Run.Text = "Run"
        Me.Button_Run.UseVisualStyleBackColor = True
        '
        'NumericUpDown_DaysBefore
        '
        Me.NumericUpDown_DaysBefore.Location = New System.Drawing.Point(106, 301)
        Me.NumericUpDown_DaysBefore.Name = "NumericUpDown_DaysBefore"
        Me.NumericUpDown_DaysBefore.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown_DaysBefore.TabIndex = 8
        Me.NumericUpDown_DaysBefore.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NumericUpDown_DaysAfter
        '
        Me.NumericUpDown_DaysAfter.Location = New System.Drawing.Point(106, 344)
        Me.NumericUpDown_DaysAfter.Name = "NumericUpDown_DaysAfter"
        Me.NumericUpDown_DaysAfter.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown_DaysAfter.TabIndex = 9
        Me.NumericUpDown_DaysAfter.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NumericUpDown_VariabilityTemp
        '
        Me.NumericUpDown_VariabilityTemp.Location = New System.Drawing.Point(106, 399)
        Me.NumericUpDown_VariabilityTemp.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NumericUpDown_VariabilityTemp.Name = "NumericUpDown_VariabilityTemp"
        Me.NumericUpDown_VariabilityTemp.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown_VariabilityTemp.TabIndex = 10
        Me.NumericUpDown_VariabilityTemp.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NumericUpDown_VariabilityWindSpeed
        '
        Me.NumericUpDown_VariabilityWindSpeed.Location = New System.Drawing.Point(236, 399)
        Me.NumericUpDown_VariabilityWindSpeed.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NumericUpDown_VariabilityWindSpeed.Name = "NumericUpDown_VariabilityWindSpeed"
        Me.NumericUpDown_VariabilityWindSpeed.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown_VariabilityWindSpeed.TabIndex = 11
        Me.NumericUpDown_VariabilityWindSpeed.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NumericUpDown_VariabilityWindDirection
        '
        Me.NumericUpDown_VariabilityWindDirection.Location = New System.Drawing.Point(367, 399)
        Me.NumericUpDown_VariabilityWindDirection.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NumericUpDown_VariabilityWindDirection.Name = "NumericUpDown_VariabilityWindDirection"
        Me.NumericUpDown_VariabilityWindDirection.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown_VariabilityWindDirection.TabIndex = 12
        Me.NumericUpDown_VariabilityWindDirection.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Days of Simulated met Before Event"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 328)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Days of Simulated met After Event"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 402)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Variability (+/-)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 383)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Temperature (F)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(249, 383)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Wind Speed (MPH)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(374, 383)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Wind Direction (Deg)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(185, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "*Uses 24 Hour Local Time"
        '
        'metBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 523)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown_VariabilityWindDirection)
        Me.Controls.Add(Me.NumericUpDown_VariabilityWindSpeed)
        Me.Controls.Add(Me.NumericUpDown_VariabilityTemp)
        Me.Controls.Add(Me.NumericUpDown_DaysAfter)
        Me.Controls.Add(Me.NumericUpDown_DaysBefore)
        Me.Controls.Add(Me.Button_Run)
        Me.Controls.Add(Me.Label_outputFile)
        Me.Controls.Add(Me.Button_outputFile)
        Me.Controls.Add(Me.TextBox_outputFile)
        Me.Controls.Add(Me.DateTimePicker_Sunset)
        Me.Controls.Add(Me.DateTimePicker_Sunrise)
        Me.Controls.Add(Me.Label_sunset)
        Me.Controls.Add(Me.Label_sunrise)
        Me.Controls.Add(Me.ComboBox_Timezone)
        Me.Controls.Add(Me.Label_timezone)
        Me.Controls.Add(Me.ComboBox_ForecastSite)
        Me.Controls.Add(Me.Label_ForecastSite)
        Me.Controls.Add(Me.Label_ExerciseName)
        Me.Controls.Add(Me.TextBox_ExerciseName)
        Me.Controls.Add(Me.Button_inputFile)
        Me.Controls.Add(Me.Label_inputFile)
        Me.Controls.Add(Me.TextBox_inputFile)
        Me.Name = "metBuilder"
        Me.Text = "metBuilder"
        CType(Me.NumericUpDown_DaysBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_DaysAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_VariabilityTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_VariabilityWindSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_VariabilityWindDirection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_inputFile As System.Windows.Forms.TextBox
    Friend WithEvents Label_inputFile As System.Windows.Forms.Label
    Friend WithEvents Button_inputFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog_inputFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox_ExerciseName As System.Windows.Forms.TextBox
    Friend WithEvents Label_ExerciseName As System.Windows.Forms.Label
    Friend WithEvents Label_ForecastSite As System.Windows.Forms.Label
    Friend WithEvents ComboBox_ForecastSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label_timezone As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Timezone As System.Windows.Forms.ComboBox
    Friend WithEvents Label_sunrise As System.Windows.Forms.Label
    Friend WithEvents Label_sunset As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_Sunrise As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker_Sunset As System.Windows.Forms.DateTimePicker
    Friend WithEvents OpenFileDialog_AlertConfig As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog_outputFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TextBox_outputFile As System.Windows.Forms.TextBox
    Friend WithEvents Button_outputFile As System.Windows.Forms.Button
    Friend WithEvents Label_outputFile As System.Windows.Forms.Label
    Friend WithEvents Button_Run As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown_DaysBefore As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown_DaysAfter As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown_VariabilityTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown_VariabilityWindSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown_VariabilityWindDirection As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
