'Importar Capas
Imports Connection
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports Conexion

Public Class D_Check_Val_Criticos
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEB_GET_NOTIFICATION_COUNTS(ID_ATE_RES As Integer) As E_IRIS_WEB_GET_NOTIFICATION_COUNTS
        ' Declaraciones
        CC_ConnBD = New ConexionBD
        Dim Cmd_SQL As New OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        Dim E_Proc_Item As New E_IRIS_WEB_GET_NOTIFICATION_COUNTS

        ' Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_GET_NOTIFICATION_COUNTS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        ' Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
        End With

        ' Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        ' Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader()
        If Obj_Reader.Read() Then
            E_Proc_Item.numLlamadas = If(IsDBNull(Obj_Reader("numLlamadas")), 0, Obj_Reader("numLlamadas"))
            E_Proc_Item.numCorreos = If(IsDBNull(Obj_Reader("numCorreos")), 0, Obj_Reader("numCorreos"))
        End If

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_FINALIZAR_PROCESO(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, NOTIFICADO As String, ID_TP_CRITICO As Integer, ESTADO_NOTIFICADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New ConexionBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_FINALIZAR_PROCESO_v2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES_SUPREME
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = S_Id_User
            .Add("@DET_CRITICO_DESC", OleDbType.VarChar).Value = NOTIFICADO
            .Add("@ID_TP_CRITICO", OleDbType.Numeric).Value = ID_TP_CRITICO
            '            .Add("@LLAMADO", OleDbType.Numeric).Value = LLAMADO
            '            .Add("@CORREO", OleDbType.Numeric).Value = CORREO
            .Add("@ESTADO_NOTIFICADO", OleDbType.Numeric).Value = ESTADO_NOTIFICADO ' Nuevo parámetro
        End With

        'Conectar con la Base de Datos
        CC_ConnBD.Oledbconexion.Open()

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader


    End Function
    Function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, DATE_str01 As String, NOTIFICADO As String, ID_TP_CRITICO As Integer, CAUSA As String, LLAMADO As Integer, CORREO As Integer, ESTADO_NOTIFICADO As Integer) As Integer
        ' Declaraciones
        CC_ConnBD = New ConexionBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDbCommand

        Dim DATE_str01EnDateTime As DateTime
        If DATE_str01 <> "" Then
            Try
                DATE_str01EnDateTime = DateTime.ParseExact(DATE_str01, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture)
            Catch formatEx As FormatException
                Return 10
            End Try
        End If

        ' Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION_O_SAPU_TEST_VALORES_ESPECIFICOS_V2_CON_PRINT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        ' Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES_SUPREME
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = S_Id_User
            .Add("@DET_CRITICO_DESC", OleDbType.VarChar).Value = NOTIFICADO
            .Add("@ID_TP_CRITICO", OleDbType.BigInt).Value = ID_TP_CRITICO
            .Add("@FECHA", OleDbType.Date).Value = DATE_str01EnDateTime
            .Add("@CAUSA", OleDbType.VarChar).Value = CAUSA
            .Add("@LLAMADO", OleDbType.Numeric).Value = LLAMADO
            .Add("@CORREO", OleDbType.Numeric).Value = CORREO
            .Add("@ESTADO_NOTIFICADO", OleDbType.Numeric).Value = ESTADO_NOTIFICADO
        End With

        ' Conectar con la Base de Datos
        CC_ConnBD.Oledbconexion.Open()

        ' Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES As Integer, ES_SAPU As Boolean) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES_O_SAPU_TEST"
            .CommandText = "IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES_O_SAPU_TEST_LLAMADA_Y_CORREO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ES_SAPU", OleDbType.Boolean).Value = ES_SAPU
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.ID_DET_CRITICO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.DET_CRITICO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.DET_CRITICO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_TP_CRITICO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.TP_CRITICO_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DET_CRITICO_FECHA_MANUAL = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.LLAMADA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.DET_CORREO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.OBS = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)





            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Shared Function IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA(DESDE As Date,
                                                                          HASTA As Date,
                                                                          ID_CF As Long,
                                                                          ID_PRE2 As Long,
                                                                          ID_EST As Long,
                                                                          ID_TP_ATENCION As Integer,
                                                                          ID_RLS_LS As Integer) As List(Of E_IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        Dim DD_GEN = New D_General_Functions

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = $"IRIS_WEB_BUSCA_RESULTADOS_{If(ID_TP_ATENCION = 5, "SAPU", "CRITICOS")}_Y_TIEMPO_RESPUESTA_SECCION"
            '.CommandText = "IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA_SECCION_TEST"
            '.CommandText = "IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA_SECCION_TEST_ESTADO_NOTIFICADO"
            '            .CommandText = "IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA_SECCION_TEST_ESTADO_NOTIFICADO_V2_test"
            '.CommandText = "IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA_SECCION_TEST_ESTADO_NOTIFICADO_V3_test"
            .CommandText = "IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA_SECCION_TEST_ESTADO_NOTIFICADO_V4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PRE2", OleDbType.BigInt).Value = ID_PRE2
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_EST
            .Add("@ID_TP_ATENCION", OleDbType.Numeric).Value = ID_TP_ATENCION
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        Dim E_Proc_List As New List(Of E_IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA)
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            Dim E_Proc_Item = New E_IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA With {
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing),
                .PAC_NOMBRE_COMPLETO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing),
                .PAC_RUT_DNI = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing),
                .FECHA_INGRESO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing),
                .HORA_INGRESO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing),
                .FECHA_NOTIFICACION = DD_GEN.DB_NULL(Obj_Reader, 5, ""),
                .HORA_NOTIFICACION = DD_GEN.DB_NULL(Obj_Reader, 6, ""),
                .FECHA_VALIDACION = DD_GEN.DB_NULL(Obj_Reader, 7, ""),
                .HORA_VALIDACION = DD_GEN.DB_NULL(Obj_Reader, 8, ""),
                .HORAS_DIFERENCIA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing),
                .MEDIO_NOTIFICACION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing),
                .QUIEN_NOTIFICA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing),
                .CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing),
                .PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing),
                .NOTIFICADO_A = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing),
                .ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing),
                .RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing),
                .ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing),
                .FECHA_RECEPCION = DD_GEN.DB_NULL(Obj_Reader, 18, ""),
                .HORA_RECEPCION = DD_GEN.DB_NULL(Obj_Reader, 19, ""),
                .PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing),
                .NOTIFICADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing),
                .ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing),
                .APRUEBA_NORMAL = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing),
                .APRUEBA_SAPU = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing),
                .ES_SAPU = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing),
                .LLAMADA = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing),
                .DET_CORREO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing),
                .ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing),
                .UM_COD = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing),
                .RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing),
                .USU_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing),
                .ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            }

            'Agregar items a la lista 
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 999999999
            .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
            .Add("@ID_PRE2", OleDbType.BigInt).Value = ID_PRE2
            .Add("@ID_EST", OleDbType.BigInt).Value = ID_EST
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim esss As String = ""
        'Configuración general
        If (ID_EST = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        Else
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS_ESTADO2"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If
        If (ID_EST = 1) Then
            esss = "B"
        Else
            esss = "A"
        End If

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRE2", OleDbType.Numeric).Value = ID_PRE2
            .Add("@ID_EST", OleDbType.VarChar).Value = esss
            .Add("@SECCION", OleDbType.Numeric).Value = CInt(SECCION)
            .Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS

            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 21, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 31, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS


            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
