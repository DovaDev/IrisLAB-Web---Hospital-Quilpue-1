Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_GRABA_REG_SOLICITUD
    Dim DD_Data As D_IRIS_WEBF_GRABA_REG_SOLICITUD
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_REG_SOLICITUD
    End Sub
    Function IRIS_WEBF_GRABA_REG_SOLICITUD(ByVal RUT As String,
                 ByVal NOMBRE As String,
                 ByVal APEPELLIDO As String,
                 ByVal NACIONALIDAD As String,
                ByVal FECHA_NAC As String,
                 ByVal SEXO As String,
                 ByVal MOVIL As String,
                 ByVal MOVIL2 As String,
                 ByVal EMAIL As String,
                 ByVal LUGARTM As String,
                 ByVal MOTIVO As String,
                 ByVal FECHA_EVENTO As String,
                 ByVal MENSAJE As String,
                ByVal PAIS As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_REG_SOLICITUD(RUT, NOMBRE, APEPELLIDO, NACIONALIDAD, FECHA_NAC, SEXO, MOVIL, MOVIL2, EMAIL, LUGARTM, MOTIVO, FECHA_EVENTO, MENSAJE, PAIS)
    End Function

    Function IRIS_WEBF_BUSCA_EMAIL_REG_SOLICITUD()
        Return DD_Data.IRIS_WEBF_BUSCA_EMAIL_REG_SOLICITUD()
    End Function

    Function Send_Email(ByVal RUT As String,
                ByVal NOMBRE As String,
                ByVal APELLIDO As String,
                ByVal NACIONALIDAD As String,
               ByVal FECHA_NAC As String,
                ByVal SEXO As String,
                ByVal MOVIL As String,
                ByVal MOVIL2 As String,
                ByVal EMAIL As String,
                ByVal LUGARTM As String,
                ByVal MOTIVO As String,
                ByVal FECHA_EVENTO As String,
                ByVal MENSAJE As String,
               ByVal PAIS As String) As String

        Dim NN_Search3 As New N_Gen_Activos

        Dim TITLE As String
        Dim ASUNTO As String
        Dim CORP_MAIL As String
        Dim CORP_PASS As String
        Dim PORT As String
        Dim HOST As String
        Dim MAIL_DEST As String
        'Dim _PROC As String
        Dim _TO As List(Of String)
        'Dim _CC As List(Of String)
        Dim _T_ADM As HttpCookie = HttpContext.Current.Request.Cookies("P_ADMIN")
        Dim Lista_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Lista_Preve As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)


        Dim NN_Search As New N_IRIS_WEBF_GRABA_REG_SOLICITUD
        _TO = NN_Search.IRIS_WEBF_BUSCA_EMAIL_REG_SOLICITUD()

        Dim NN_Search2 As New N_IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY
        '_CC = NN_Search2.IRIS_WEBF_CMVM_BUSCA_SOPORTE_COPY()



        'Descripción del Mensaje
        TITLE = "IrisLab Soporte Web"
        ASUNTO = "FORMULARIO DE CONSULTAS, SUGERENCIAS Y RECLAMOS, LABORATORIO CLÍNICO CMVALPARAISO"
        'Datos del remitente
        CORP_MAIL = "envios@irislab.cl"
        CORP_PASS = "labtuxlinktux"
        HOST = "mail.irislab.cl"
        'HOST = "mail.aclin.cl"
        PORT = "25"
        'PORT = "587"

        'Correos de Destino
        MAIL_DEST = ""
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

            For y = 0 To (_TO.Count - 1)
                .[To].Add(_TO(y))
            Next y

            ''Correos con copia a...
            'For y = 0 To (_CC.Count - 1)
            '    .CC.Add(_CC(y))
            'Next y

            .From = New System.Net.Mail.MailAddress(CORP_MAIL, TITLE, System.Text.Encoding.UTF8) 'Quien lo envía
            .Subject = ASUNTO       'Asunto del e-Mail
            .SubjectEncoding = System.Text.Encoding.UTF8
            Dim Body_1 As String
            Dim Body_2 As String
            Dim Body_3 As String
            Dim Body_4 As String
            Dim Body_5 As String
            Dim Body_6 As String
            Dim Body_7 As String
            Dim Body_8 As String
            Dim Body_9 As String
            Dim Body_10 As String
            Dim Body_11 As String
            Dim Body_12 As String
            Dim Body_13 As String
            Dim Body_14 As String
            Dim Body_15 As String

            Body_1 = "<div style='background-color:white;border-bottom: 1px #00738e solid;border-right: 1px #00738e solid;border-left: 1px #00738e solid;'>"
            Body_2 = "<div style='background-color:#00738e;'><h1 style='color:#fff;text-align:center;font-size:26px;font-family:sans-serif;padding:10px 0'>" + TITLE + "</h1></div>"
            Body_3 = "<h3 style='color:#014b5d;padding:25px 35px;font-size:15px;margin:0'>Asunto: " + "FORMULARIO DE CONSULTAS, SUGERENCIAS Y RECLAMOS " + "<br>" ' ASUNTO Y FORM
            Body_4 = "Nombre: " + NOMBRE + " " + APELLIDO + "<br>Rut: " + RUT + "<br>"
            Body_5 = "Nacionalidad: " + NACIONALIDAD + "<br>País: " + PAIS + "<br>"
            Body_6 = "F. Nacimiento: " + FECHA_NAC + "<br>Sexo: " + SEXO + "<br>"
            Body_7 = "Fono: " + MOVIL + "<br>Otro Fono: " + MOVIL2 + "<br>"
            Body_8 = "Email: " + EMAIL + "<br>"
            Body_9 = "<br>"

            Body_10 = "Consultorio: " + LUGARTM + "<br>Motivo: " + MOTIVO + "<br>"
            Body_11 = "Fecha de evento: " + FECHA_EVENTO + "</h3><br>"
            Body_12 = "<div style='text-align:justify;font-size:15px;padding:0 35px;color:#002e3a'>" + MENSAJE + "</div>"
            Body_13 = "<hr style='border-color:#c2f4ff;max-width:80%;margin-top:17px'><br><h2 style='text-align:center;margin:0;color:#014b5d'>Soporte Informático IrisLab Web</h2>" ' SOPORTE
            Body_14 = "<div style='text-align:center'><img src='http://186.103.210.187:10000/Imagenes/IrisLab%20Logo%20LARGOa.png' style='max-width:430px;width:90vw'</div>" ' LOGO
            Body_15 = "<h3 style='text-align:center;margin:0;color:#014b5d;padding-bottom:25px'>Visítanos en: <a href='http://www.irislab.cl' style='color:#007b98'>www.irislab.cl</a></h3></div>" ' URL IRISLAB

            'Codificacion
            .Body = Body_1 & Body_2 & Body_3 & Body_4 & Body_5 & Body_6 & Body_7 & Body_8 & Body_9 & Body_10 & Body_11 & Body_12 & Body_13 & Body_14 & Body_15    'contenido del mail
            .BodyEncoding = System.Text.Encoding.UTF8
            .Priority = System.Net.Mail.MailPriority.Normal
            .IsBodyHtml = True
        End With

        'Enviar Correo
        Try
            _SMTP.Send(_Message)
            ERR = 1
        Catch ex As System.Net.Mail.SmtpException
            ERR = 0

        End Try

        Return ERR
    End Function
End Class