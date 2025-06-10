Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Cupo_Tot_ate_2
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
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal fecha2 As String, ByVal id As String) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        'Declaraciones internas
        Dim data_procedencia As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        Dim data_dia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_dia As New N_PROCEDENCIAS_Y_CANT_MAX
        data_procedencia = NN_Procedencia.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO(id, fecha, fecha2)

        'fecha a string para buscar los totales por cada atención

        For Each dat In data_procedencia
            Dim fechita As String
            fechita = dat.PREI_FECHA_PRE.ToString("dd/MM/yyyy")
            fechita = fechita.Replace("-", "/")

            data_dia = NN_dia.examens2(id, fechita)

            If (data_dia.Count > 0) Then
                dat.TOTAL_CUPO_NORMAL = data_dia(0).AGEND_CUPO_NORMAL
                dat.TOTAL_ESPONTANEO = data_dia(0).AGEND_ESPONTANEO
                dat.TOTAL_PRIORITARIO = data_dia(0).AGEND_PRIORITARIO
            End If

        Next

        If data_procedencia.Count > 0 Then
            Return data_procedencia
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal PROC As Long, ByVal FECHA1 As String, ByVal FECHA2 As String) As String
        Dim NN_Prev As New N_Prevision_Sum
        Return NN_Prev.Gen_Excel_DET(DOMAIN_URL, PROC, FECHA1, FECHA2)
    End Function
    Private Sub Prevision_Sum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class