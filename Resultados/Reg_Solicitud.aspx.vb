Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Reg_Solicitud
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_REG_SOLICITUD(ByVal RUT As String,
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

        'Declaraciones internas
        Dim NN_Graba As New N_IRIS_WEBF_GRABA_REG_SOLICITUD
        Dim Data_Graba As Integer = 0
        Data_Graba = NN_Graba.IRIS_WEBF_GRABA_REG_SOLICITUD(RUT, NOMBRE, APELLIDO, NACIONALIDAD, FECHA_NAC, SEXO, MOVIL, MOVIL2, EMAIL, LUGARTM, MOTIVO, FECHA_EVENTO, MENSAJE, PAIS)

        Data_Graba = NN_Graba.Send_Email(RUT, NOMBRE, APELLIDO, NACIONALIDAD, FECHA_NAC, SEXO, MOVIL, MOVIL2, EMAIL, LUGARTM, MOTIVO, FECHA_EVENTO, MENSAJE, PAIS)
        If (Data_Graba > 0) Then
            Return Data_Graba
        Else
            Return Nothing
        End If
    End Function


End Class