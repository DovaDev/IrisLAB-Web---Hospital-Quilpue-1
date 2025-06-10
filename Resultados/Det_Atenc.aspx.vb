Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Det_Atenc
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim ID_ATE As HttpCookie = Request.Cookies("ID_ATE")

        If (IsNothing(ID_ATE) = True) Then
            Response.Redirect("index.aspx")
        End If
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_Datos(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_AtencionDet As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
        Dim DataAtencionDet As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        Dim DCrypt As New N_Encrypt

        DataAtencionDet = NN_AtencionDet.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(DCrypt.Decode(ID_ATE.Replace(" ", "+")))
        If (DataAtencionDet.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataAtencionDet, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_ExamenDet As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim DataExamenDet As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        Dim DCrypt As New N_Encrypt



        'DataExamenDet = NN_ExamenDet.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR(DCrypt.Decode(ID_ATE.Replace(" ", "+")))
        DataExamenDet = NN_ExamenDet.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_ATE_ACT_WEB(DCrypt.Decode(ID_ATE.Replace(" ", "+")))
        If (DataExamenDet.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataExamenDet, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
End Class