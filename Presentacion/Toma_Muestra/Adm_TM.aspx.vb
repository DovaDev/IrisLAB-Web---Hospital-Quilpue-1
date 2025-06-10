Imports Datos
Imports Entidades
Imports Negocio
Public Class Adm_TM
    Inherits System.Web.UI.Page


    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Estados() As List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            Return Data_LugarTM
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_ordenATE() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO

        data_paciente = NN.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Actualiza_Obs_Normal(ATE_NUM As String,
                                                PESO As String,
                                                TALLA As String,
                                                HGT As String,
                                                FECHA_HORA_ULTIMA_DOSIS As String,
                                                OBSERVACION_TM As String,
                                                ATE_OBS_FICHA As String,
                                                OBSERVACION_PER As String,
                                                DIURESIS As String,
                                                GRAMAJE As String, ID_PAC As Integer,
                                                ZONA_TM As String) As Integer
        'OBS As String,
        'CONCENTRACION_MEDICAMENTO As String,
        'PERSONA As String) 
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_OBS_ATENCION_NORMAL(ATE_NUM,
                                                                  PESO,
                                                                  TALLA,
                                                                  HGT,
                                                                  FECHA_HORA_ULTIMA_DOSIS,
                                                                  OBSERVACION_TM,
                                                                  ATE_OBS_FICHA,
                                                                  OBSERVACION_PER,
                                                                  DIURESIS,
                                                                  GRAMAJE, ID_PAC, ZONA_TM)
        'OBS,
        'CONCENTRACION_MEDICAMENTO,
        '                                                          PERSONA)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Anato(ID_ATE_RES As Integer, SITIO_ANATO As String, ID_CODIGO_FONASA As Integer) As Object

        Return N_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS.Udpdate_Anatomico(SITIO_ANATO, ID_ATE_RES, ID_CODIGO_FONASA)

    End Function
    <Services.WebMethod()>
    Public Shared Function Detalle_De_Atencion(ID_ATENCION As Integer) As Object
        Return N_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS.Detalle_Atencion_Toma_De_Muestra(ID_ATENCION)
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Estado_Examen(ID_ATENCION As Integer, ID_ESTADO As Integer, ID_USUARIO As Integer, perfiles As List(Of Integer), codigosBarra As List(Of String)) As Object
        Return N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION.Update_Estado_Examen(ID_ATENCION, ID_ESTADO, ID_USUARIO, perfiles, codigosBarra)
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORD As Integer, ByVal ID_PROC As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)

        Data_OUT = NN_Search.IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS(DESDE, HASTA, ID_ORD, ID_PROC, ID_ESTADO)
        If (Data_OUT.Count > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Estado_Atendido(ByVal ID_ATE As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_Estado_Atendido_TM(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USUARIO)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Update_Estado_Pendiente(ByVal ID_ATE As Integer, ByVal ID_USER As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        'Dim ID_USER As Integer
        Data_OUT = NN_Search.IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Guardar_Observaciones(ByVal ID_ATE As Integer,
                                                 ByVal ATE_NUM As Integer,
                                                 ByVal DIP_CUP As Integer,
                                                 ByVal DIP_CVC As Integer,
                                                 ByVal DIP_PICCLINE As Integer,
                                                 ByVal DIP_TET As Integer,
                                                 ByVal DIP_TQT As Integer,
                                                 ByVal DIP_AREpi As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As Integer
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Data_OUT = NN_Search.IRIS_WEBF_GUARDAR_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ID_ATE, ATE_NUM, DIP_CUP, DIP_CVC, DIP_PICCLINE, DIP_TET, DIP_TQT, DIP_AREpi)
        If (Data_OUT > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Observaciones(ByVal ID_ATE As Integer) As List(Of E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION)
        Data_OUT = NN_Search.IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ID_ATE)
        If (Data_OUT.Count > 0) Then
            Return Data_OUT
        Else
            Return Nothing
        End If
    End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA(ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA)
        Dim NN As N_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA = New N_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA
        data_paciente = NN.IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA(ID_PROCEDENCIA)

        Return data_paciente
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As Integer = CType(objSession("P_ADMIN"), Integer)
        'If C_P_ADMIN = 0 Then
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub

    <Services.WebMethod()>
    Public Shared Function Update_Segunda_PTGO(idAtencion As Integer) As Boolean
        Return D_Update_Observaciones_TM.Update_Segunda_PTGO(idAtencion)
    End Function


    <Services.WebMethod()>
    Public Shared Function Update_Segunda_Carga(idAtencion As Integer) As Boolean
        Return D_Update_Observaciones_TM.Update_Segunda_Carga(idAtencion)
    End Function

End Class