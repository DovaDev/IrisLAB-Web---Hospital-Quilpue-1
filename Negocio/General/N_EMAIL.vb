Imports System.Web.Mail
Public Class N_EMAIL
    Dim CORP_MAIL As String
    Dim CORP_PASS As String
    Dim PORT As String
    Dim HOST As String
    Dim MAIL_DEST As String
    Dim CC As List(Of String)
    Dim TITLE As String
    Dim ASUNTO As String
    Public Property Set_Destinat As String
        Get
            Return MAIL_DEST
        End Get
        Set(value As String)
            MAIL_DEST = value
        End Set
    End Property
    Public Property Set_Asunto As String
        Get
            Return ASUNTO
        End Get
        Set(value As String)
            ASUNTO = value
        End Set
    End Property
    Public Sub New()
        'Datos del remitente
        CORP_MAIL = "envios@irislab.cl"
        CORP_PASS = "V2BPzE5V"
        HOST = "mail.irislab.cl"
        'HOST = "mail.aclin.cl"
        PORT = "25"
        'PORT = "587"
        'Correos de Destino
        MAIL_DEST = ""
        CC = New List(Of String)
        CC.Add("fsilva.irislab@gmail.com")
        CC.Add("dpereira@irislab.cl")
        'Descripción del Mensaje
        TITLE = "IrisLAB Holanda"
        ASUNTO = "Excel de Prueba"
    End Sub
    Function Send_Email(ByVal HTML_Body As String) As String
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim ERR As String
        'CONFIGURACIÓN DEL STMP
        With _SMTP
            .Host = HOST
            .Port = PORT
            .EnableSsl = False 'True
            .Credentials = New System.Net.NetworkCredential(CORP_MAIL, CORP_PASS)
        End With
        'CONFIGURACION DEL MENSAJE
        With _Message
            .[To].Add(MAIL_DEST) 'Cuenta de Correo al que se le quiere enviar el e-mail
            'Correos con copia a...
            For y = 0 To (CC.Count - 1)
                .CC.Add(CC(y))
            Next y
            .From = New System.Net.Mail.MailAddress(CORP_MAIL, TITLE, System.Text.Encoding.UTF8) 'Quien lo envía
            .Subject = ASUNTO       'Asunto del e-Mail
            .SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion
            .Body = HTML_Body       'contenido del mail
            .BodyEncoding = System.Text.Encoding.UTF8
            .Priority = System.Net.Mail.MailPriority.Normal
            .IsBodyHtml = True
        End With
        'Enviar Correo
        Try
            _SMTP.Send(_Message)
            ERR = "ok"
        Catch ex As System.Net.Mail.SmtpException
            ERR = "error"
        End Try
        Return ERR
    End Function
End Class
