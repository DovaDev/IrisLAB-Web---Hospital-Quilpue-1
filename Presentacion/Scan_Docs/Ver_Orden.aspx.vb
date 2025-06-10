Imports System.Collections.Generic
Imports System.Runtime.Remoting
Imports System.Text
Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization

Public Class Ver_Orden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN
        Dim Data_Estado_Mant As New E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN_ATE(ATE_NUM)
        If (Data_Estado_Mant IsNot Nothing) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function prueba_order_med(ByVal imgbase64 As String, ByVal ID_ATENCION As Integer,
                                            ByVal ID_USUARIO As Integer,
                                            ByVal ATE_NUM As Integer) As Object

        'Dim R_HR_TN As New Resumen_Prev_Prog_Subp_Scr_3_Glob_Med
        'Dim result = R_HR_TN.GuardarImg_orden_medica(DOMAIN_URL, imgbase64, tp_order)





        Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(imgbase64, ID_ATENCION, ID_USUARIO, ATE_NUM)

        Return Data_OUT
        'Return result

    End Function

    <Services.WebMethod()>
    Public Shared Function prueba_order_med_PDF(ByVal imgbase64 As String, ByVal ID_ATENCION As Integer,
                                            ByVal ID_USUARIO As Integer,
                                            ByVal ATE_NUM As Integer, fileType As String
                                            ) As Object
        Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF(imgbase64, ID_ATENCION, ID_USUARIO, ATE_NUM, fileType)

        Return Data_OUT
        'Return result

    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Img(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(ID_ATENCION)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Img_PDF(ByVal PREI_NUM As Long, ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_PDF_ATE_PREI(PREI_NUM, ATE_NUM)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Img_Asoc(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_ASOC(DESDE, HASTA)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Img_Asoc_PDF(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)

        Data_Estado_Mant_2 = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_ASOC_PDF(DESDE, HASTA)

        If (Data_Estado_Mant_2.Count > 0) Then
            Return Data_Estado_Mant_2
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Graba_Asoc(ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Long, ByVal ATE_NUM As String, ByVal ID_PREINGRESO As Long,
                                            ByVal PREI_NUM As String, ByVal ARRAY_IMG As List(Of Long)) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As Integer = 0

        For Each IMG In ARRAY_IMG
            Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC_PREI(ID_USUARIO, ID_ATENCION, ATE_NUM, ID_PREINGRESO, PREI_NUM, IMG)
        Next

        Return Data_Estado_Mant_2

    End Function
    'Public Shared Function Graba_Asoc(ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Long, ByVal ATE_NUM As String, ByVal ARRAY_IMG As List(Of Long)) As Integer
    '    'Declaraciones del Serializador
    '    Dim str_Builder As New StringBuilder

    '    'Declaraciones internas
    '    Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    '    Dim Data_Estado_Mant_2 As Integer = 0

    '    For Each IMG In ARRAY_IMG
    '        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC(ID_USUARIO, ID_ATENCION, ATE_NUM, IMG)
    '    Next

    '    Return Data_Estado_Mant_2

    'End Function

    <Services.WebMethod()>
    Public Shared Function Elimina_Asoc(ByVal ID_FOTO_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As Integer = 0

        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE_ASOC(ID_FOTO_ATE)


        Return Data_Estado_Mant_2

    End Function
    <Services.WebMethod()>
    Public Shared Function Elimina_Img(ByVal ID_FOTO_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As Integer = 0

        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE(ID_FOTO_ATE)


        Return Data_Estado_Mant_2

    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Folio(ByVal ID_ATENCION As Integer) As String
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim Data_Estado_Mant_2 As Integer = 0

        Data_Estado_Mant_2 += NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_FOLIO_ID_ATE(ID_ATENCION)


        Return Data_Estado_Mant_2

    End Function

    <Services.WebMethod()>
    Public Shared Function ReName(ByVal ID As Long, ByVal NOMBRE_DOC As String) As Integer
        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC
        Dim Data_Estado_Mant As Integer

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC_MOBILE(ID, NOMBRE_DOC)


        If (Data_Estado_Mant > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
End Class