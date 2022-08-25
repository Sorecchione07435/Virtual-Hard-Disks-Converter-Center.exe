Public Class AboutBox
    Private Sub AboutBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblProductName.Text = My.Application.Info.AssemblyName
        LblVersion.Text = String.Format("Ver. {0}", My.Application.Info.Version.ToString)
        LblCompany.Text = My.Application.Info.CompanyName
        LblCopyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class