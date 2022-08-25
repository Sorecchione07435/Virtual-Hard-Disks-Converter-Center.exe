Imports System.ComponentModel

Public Class Form1
    Dim BeforeConversionDiskPath As String = Nothing
    Dim AfterConversionDiskPath As String = Nothing
    Dim DeleteDiskAfterConversion As Boolean = False
    Dim ConversionInProgress As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
        DeleteDiskAfterConversion = False
        ConversionInProgress = False
    End Sub

    Function CommandPrompt(ByVal Arguments As String) As String
        Try

            Dim My_Process As New Process()
            Dim My_Process_Info As New ProcessStartInfo()

            My_Process_Info.FileName = "powershell.exe" ' Process filename
            My_Process_Info.Arguments = Arguments ' Process arguments

            My_Process_Info.CreateNoWindow = True  ' Show or hide the process Window
            My_Process_Info.UseShellExecute = False ' Don't use system shell to execute the process
            My_Process_Info.RedirectStandardOutput = True  '  Redirect (1) Output
            My_Process_Info.RedirectStandardError = True  ' Redirect non (1) Output

            My_Process.EnableRaisingEvents = True ' Raise events

            My_Process.StartInfo = My_Process_Info
            My_Process.Start() ' Run the process NOW

            Dim Process_ErrorOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Error Output (If any)
            Dim Process_StandardOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Standard Output (If any)

            ' Return output by priority
            If Process_ErrorOutput IsNot Nothing Then Return Process_ErrorOutput ' Returns the ErrorOutput (if any)
            If Process_StandardOutput IsNot Nothing Then Return Process_StandardOutput ' Returns the StandardOutput (if any)

        Catch ex As Exception
            Return ex.Message
        End Try

        Return "OK"

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim open As New OpenFileDialog
        open.Filter = "VirtualBox Disk Image|*.vdi|Virtual Hard Disk|*.vhd|Virtual Machine Disk|*.vmdk|Parallels Hard Disk|*.hdd|QEMU Copy-On-Write|*.qcow|QED Enhance Disk|*.qed|Hyper-V Virtual Hard Disk|*.vhdx"

        If open.ShowDialog = DialogResult.OK Then
            DiskBeforeConvertingPathText.Text = open.FileName
            BeforeConversionDiskPath = open.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim save As New SaveFileDialog
        save.Filter = "VirtualBox Disk Image|*.vdi|Virtual Hard Disk|*.vhd|Virtual Machine Disk|*.vmdk|Parallels Hard Disk|*.hdd|QEMU Copy-On-Write|*.qcow|QED Enhance Disk|*.qed"

        If save.ShowDialog = DialogResult.OK Then
            DiskAfterConvertingPathText.Text = save.FileName
            AfterConversionDiskPath = save.FileName
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DeleteDiskAfterConversion = True
        Else
            DeleteDiskAfterConversion = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DiskBeforeConvertingPathText.Text = Nothing And BeforeConversionDiskPath = Nothing Then
            MsgBox("Specificare il disco virtuale da convertire cliccando su ""Sfoglia""", MsgBoxStyle.Exclamation, "Attenzione") : Exit Sub
        ElseIf ComboBox2.Text = Nothing Then
            MsgBox("Specificare il formato del disco da convertire", MsgBoxStyle.Exclamation, "Attenzione") : Exit Sub
        ElseIf DiskAfterConvertingPathText.Text = Nothing And AfterConversionDiskPath = Nothing Then
            MsgBox("Specificare il disco virtuale da salvare cliccando su ""Sfoglia""", MsgBoxStyle.Exclamation, "Attenzione") : Exit Sub
        ElseIf ComboBox3.Text = Nothing Then
            MsgBox("Specificare il formato del disco da salvare", MsgBoxStyle.Exclamation, "Attenzione") : Exit Sub
        ElseIf ComboBox2.Text = ComboBox3.Text Then
            MsgBox("I formati del disco da convertire sono uguali, perfavore scegline uno differente!", MsgBoxStyle.Exclamation, "Attenzione") : Exit Sub
        End If

        If MsgBox("Vuoi iniziare la conversione? ciò richiederà del tempo", vbYesNo + MsgBoxStyle.Exclamation, "Attenzione") = MsgBoxResult.Yes Then
            ProgressBar1.Value = 0
            Button1.Enabled = False
            ComboBox2.Enabled = False
            Button2.Enabled = False
            ComboBox3.Enabled = False
            CheckBox1.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            ConversionInProgress = True

            BackgroundWorker1.RunWorkerAsync()
            Timer1.Start()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Select Case ComboBox3.Text
            Case "VDI"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format VDI", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format VDI", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format VDI", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format VDI", BeforeConversionDiskPath, AfterConversionDiskPath))


                End If

            Case "VHD"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format VHD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format VHD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format VHD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format VHD", BeforeConversionDiskPath, AfterConversionDiskPath))


                End If
            Case "VMDK"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format VMDK", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format VMDK", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format VMDK", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format VMDK", BeforeConversionDiskPath, AfterConversionDiskPath))


                End If
            Case "HDD"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format HDD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format HDD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format HDD", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then
                    '  Try
                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format HDD", BeforeConversionDiskPath, AfterConversionDiskPath))
                    '  Catch ex As Exception
                    'BackgroundWorker1.CancelAsync()
                    'MsgBox("Si è verificato un errore imprevisto durante la conversione del disco" & vbNewLine & vbNewLine & "Maggiori Informazioni Sull'Errore:" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Conversione Fallita")
                    'TxtLog.ForeColor = Color.Red
                    '  End Try

                End If
            Case "QCOW"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format QCOW", BeforeConversionDiskPath, AfterConversionDiskPath))

                ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format QCOW", BeforeConversionDiskPath, AfterConversionDiskPath))

                ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format QCOW", BeforeConversionDiskPath, AfterConversionDiskPath))

                ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format QCOW", BeforeConversionDiskPath, AfterConversionDiskPath))


                End If
            Case "QED"
                If BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" {1} --format QED", BeforeConversionDiskPath, AfterConversionDiskPath))

                        ElseIf BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium ""{0}"" ""{1}"" --format QED", BeforeConversionDiskPath, AfterConversionDiskPath))

                ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} ""{1}"" --format QED", BeforeConversionDiskPath, AfterConversionDiskPath))

                ElseIf Not BeforeConversionDiskPath.Contains(" ") = True And Not AfterConversionDiskPath.Contains(" ") = True Then

                    TxtLog.Text = CommandPrompt(String.Format("VBoxManage.exe clonemedium {0} {1} --format QED", BeforeConversionDiskPath, AfterConversionDiskPath))


                End If
        End Select


    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If TxtLog.Text.Contains("0%") = True Then
            ProgressBar1.Value = 0
            Label5.Text = "Avanzamento Percentuale : 0%"
        ElseIf TxtLog.Text.Contains("10%") = True Then
            ProgressBar1.Value = 10
            Label5.Text = "Avanzamento Percentuale : 10%"
        ElseIf TxtLog.Text.Contains("20%") = True Then
            ProgressBar1.Value = 20
            Label5.Text = "Avanzamento Percentuale : 20%"
        ElseIf TxtLog.Text.Contains("30%") = True Then
            ProgressBar1.Value = 30
            Label5.Text = "Avanzamento Percentuale : 30%"
        ElseIf TxtLog.Text.Contains("40%") = True Then
            ProgressBar1.Value = 40
            Label5.Text = "Avanzamento Percentuale : 40%"
        ElseIf TxtLog.Text.Contains("50%") = True Then
            ProgressBar1.Value = 50
            Label5.Text = "Avanzamento Percentuale : 50%"
        ElseIf TxtLog.Text.Contains("60%") = True Then
            ProgressBar1.Value = 60
            Label5.Text = "Avanzamento Percentuale : 60%"
        ElseIf TxtLog.Text.Contains("70%") = True Then
            ProgressBar1.Value = 70
            Label5.Text = "Avanzamento Percentuale : 70%"
        ElseIf TxtLog.Text.Contains("80%") = True Then
            ProgressBar1.Value = 80
            Label5.Text = "Avanzamento Percentuale : 80%"
        ElseIf TxtLog.Text.Contains("90%") = True Then
            ProgressBar1.Value = 90
            Label5.Text = "Avanzamento Percentuale : 90%"
        ElseIf TxtLog.Text.Contains("100%") = True Then
            ProgressBar1.Value = 100
            Label5.Text = "Avanzamento Percentuale : 100%"
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If TxtLog.Text.Contains("Clone medium created in format") = True Then
            TxtLog.ForeColor = Color.Green
            MsgBox("Conversione Disco Virtuale Completata" & vbNewLine & vbNewLine & "Il disco convertito è disponibile in " & AfterConversionDiskPath, MsgBoxStyle.Information, "Conversione Riuscita")
            If DeleteDiskAfterConversion = True Then
                My.Computer.FileSystem.DeleteFile(BeforeConversionDiskPath)
            End If

            Button1.Enabled = True
            Button2.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
            CheckBox1.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = False
            ProgressBar1.Value = ProgressBar1.Maximum
            ConversionInProgress = False
            Timer1.Stop()
        End If

        If TxtLog.Text.Contains("error") = True Then
            MsgBox("Si è verificato un errore imprevisto durante la conversione del disco", MsgBoxStyle.Critical, "Conversione Fallita")
            TxtLog.ForeColor = Color.Red
            ConversionInProgress = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label5.Text = String.Format("Avanzamento Percentuale : {0}%", ProgressBar1.Value)
    End Sub

    Private Sub InformazioniSuVHDConverterCenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformazioniSuVHDConverterCenterToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ConversionInProgress = True Then
            MsgBox("La conversione di un disco virtuale è in corso, impossibile uscire", MsgBoxStyle.Exclamation, "Attenzione")
            e.Cancel = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        BackgroundWorker1.CancelAsync()
        Button1.Enabled = True
        Button2.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        CheckBox1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        MsgBox("Conversione Disco Virtuale Annullata", MsgBoxStyle.Information)
        TxtLog.Clear()
        ProgressBar1.Value = 0
    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs)

    'TextBox1.Text = CommandPrompt("vboxmanage createhd --filename C:\prova.vdi --size 90000 --format VDI")
    ' End Sub


End Class
