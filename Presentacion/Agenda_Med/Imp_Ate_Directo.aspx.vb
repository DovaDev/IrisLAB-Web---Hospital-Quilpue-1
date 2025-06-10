Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Imp_Ate_Directo
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

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
    Public Shared Function Llenar_PAC(ByVal ID As String, ByVal fecha As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO(ID, CDate(fecha))
        Return data_pac
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As REEE2
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EXAMEN)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION


        data_pac = NN_pac.IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR(ID)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_EXAMEN(ID)


        Dim reeeeeee As New REEE2
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        'Declaraciones internas
        Return reeeeeee
    End Function
    Public Class REEE2
        Dim arr1 As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR)
        Dim arr2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EXAMEN)


        Public Property proparra1 As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR)
            Get
                Return arr1
            End Get
            Set(ByVal value As List(Of E_IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR))
                arr1 = value
            End Set
        End Property
        Public Property proparra2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EXAMEN)
            Get
                Return arr2
            End Get
            Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EXAMEN))
                arr2 = value
            End Set
        End Property
    End Class
End Class