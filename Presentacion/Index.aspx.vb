Imports Datos
Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Test
    Inherits System.Web.UI.Page


    <Services.WebMethod()>
    Public Shared Function buscarEtnias() As Object
        Return N_Etnias.IRIS_WEBF_BUSCA_ETNIAS_ACTIVAS()
    End Function
    <Services.WebMethod()>
    Public Shared Function buscarUsuariosPorProcedenciaFlebo(idProcedencia As Integer) As Object
        Return D_Conf_User.IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA_FLEBO2(idProcedencia)
    End Function
    <Services.WebMethod()>
    Public Shared Function buscarProcedenciasActivas() As Object
        Return (New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO).IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarExamenesFiltro(idPrevision As Integer, idArea As Integer, idSeccion As Integer, idRlsLs As Integer) As Object
        Return (New D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS).IRIS_WEB_BUSCA_EXAMENES(idPrevision, idArea, idSeccion, idRlsLs)
    End Function

    <Services.WebMethod()>
    Public Shared Function Bus_Cant() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_CANT As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
        Dim Data_CANT As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA)
        Data_CANT = NN_CANT.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA()
        If (Data_CANT.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_CANT, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
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
    Public Shared Function Bus_Exa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_EXA As New N_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
        Dim Data_EXA As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS)
        Data_EXA = NN_EXA.IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS()
        If (Data_EXA.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_EXA, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Bus_Notif() As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)


        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO(S_Id_User)
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Upd_Notif(ByVal ID_REL_N_U As Integer) As Integer

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO(ID_REL_N_U)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Dlt_Notif(ByVal ID_NOTIF As Integer) As Integer

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_DELETE_NOTIFICACION_USUARIO
        Dim Data_OUT As Integer
        Data_OUT = NN_Search.IRIS_WEBF_CMVM_DELETE_NOTIFICACION_USUARIO(ID_NOTIF)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarSeccionArea2(idAtencion As Integer) As Object
        Return D_Gen_Activos.IRIS_WEB_BUSCA_RELACION_AREA_SECCION_ID_ATE(idAtencion)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarPrevisionesActivas() As Object
        Return (New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO).IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
    End Function

    Public Shared Function buscarExamenesActivos() As Object
        Return (New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS).IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
    End Function
    <Services.WebMethod()>
    Public Shared Function buscarExamenesActivosPorSeccion(idSeccion As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEBF_BUSCA_EXAMENES_POR_SECCION(idSeccion)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarExamenesActivosPorSeccionArea(idSeccion As Integer, idArea As Integer, idAtencion As Integer, idRlsLs As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE(idSeccion, idArea, idAtencion, idRlsLs)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarExamenesActivosPorSeccionAreaPrev(idRlsLs As Integer, idArea As Integer, idSeccion As Integer, idPreve As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE(idRlsLs, idArea, idSeccion, idPreve)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscaExamenesActivosPorSeccionAreaPrev(idRlsLs As Integer, idArea As Integer, idSeccion As Integer, idPreve As Integer, idAtencion As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE_NEW(idRlsLs, idArea, idSeccion, idPreve, idAtencion)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarSeccionArea() As Object
        Return (New N_Gen_Activos).IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarTiposAtencionActivo() As Object
        Return (New N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO).IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarTiposCritico() As Object
        Return (New D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS).IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS()
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarAreasTrabajoActivas(idAtencion As Integer) As Object
        Return D_Gen_Activos.IRIS_WEB_BUSCA_AREA_TRABAJO_ACTIVA_CON_RELACION(idAtencion)
    End Function


    <Services.WebMethod()>
    Public Shared Function buscarSeccionesActivas() As Object
        Return (New D_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO).IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
    End Function


    <Services.WebMethod()>
    Public Shared Function buscarExamenesActivosPorSeccionArea2(idSeccion As Integer, idArea As Integer, idAtencion As Integer) As Object
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE_SIN_ID_RLS(idSeccion, idArea, idAtencion)
    End Function

    <Services.WebMethod()>
    Public Shared Function buscarGrupoPesquisa()
        Return (New N_GrupoPesquisa).IRIS_WEBF_BUSCA_GRUPOS_PESQUISA_ACTIVOS()
    End Function
End Class