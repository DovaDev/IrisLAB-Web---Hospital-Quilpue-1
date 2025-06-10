'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class D_Ate_Resultados
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Public Shared Function IRIS_WEB_BUSCAR_HISTORIAL_POR_PRUEBA(ID_ATENCION As Integer, ID_PACIENTE As Integer, ID_PRUEBA As Integer) As List(Of Resultados_Historicos_Por_Prueba)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATENCION", ID_ATENCION),
            New SqlParameter("@ID_PACIENTE", ID_PACIENTE),
            New SqlParameter("@ID_PRUEBA", ID_PRUEBA)
        }
        Return D_General_Functions.ExecuteReaderSP(Of Resultados_Historicos_Por_Prueba)("IRIS_WEB_BUSCAR_HISTORIAL_POR_PRUEBA", params)
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_URGENCIAS(DESDE As String, HASTA As String, ID_SEC As Integer, ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_URGENCIAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM_NEW(ByVal NUM_ATE As Long, ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.BigInt).Value = NUM_ATE
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
            .Add("@USU_ID_PROC", OleDbType.BigInt).Value = USU_ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim Response As Long
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            Response = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return Response
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                          ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES_VAL(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                     ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                     ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                     ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES_VAL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                       ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                       ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                       ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Shared Function IRIS_WEB_BUSCA_POR_FLECHA(ATE_NUM As Long, DIRECTION As Boolean, ID_PROC As Integer,
                                       ID_PREV As Integer, ID_PROG As Integer, ID_SECC As Integer,
                                       ID_EXAM As Integer, ID_SECT As Integer, ID_PACI As Long,
                                       ID_USER As Integer, USU_ID_PROC As Integer, PENDIENTE As Boolean) As Long
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        Dim DD_GEN As New D_General_Functions
        'Declaraciones 'lista'
        Dim E_Proc_Item As Long = 0

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[IRIS_WEB_BUSCA_ATENCION_VISOR_POR_FLECHA_POR_ID_USER_3]"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
            .Add("@PENDIENTE", OleDbType.Boolean).Value = PENDIENTE
        End With

        CC_ConnBD.Oledbconexion.Open()

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    'Shared Function IRIS_WEB_BUSCA_POR_FLECHA(ATE_NUM As Long, DIRECTION As Boolean, ID_PROC As Integer,
    '                                   ID_PREV As Integer, ID_PROG As Integer, ID_SECC As Integer,
    '                                   ID_EXAM As Integer, ID_SECT As Integer, ID_PACI As Long,
    '                                   ID_USER As Integer, USU_ID_PROC As Integer, PENDIENTE As Boolean) As Long
    '    'Declaraciones
    '    Dim CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand

    '    Dim DD_GEN As New D_General_Functions
    '    'Declaraciones 'lista'
    '    Dim E_Proc_Item As Long = 0

    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEB_BUSCA_ATENCION_VISOR_POR_FLECHA_POR_ID_USER_2"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '        .CommandTimeout = 999999999
    '    End With

    '    'Enviar parámetros
    '    With Cmd_SQL.Parameters
    '        .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
    '        .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
    '        .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
    '        .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
    '        .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
    '        .Add("@ID_SECC", OleDbType.Numeric).Value = ID_RLS_LS
    '        .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
    '        .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
    '        .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
    '        .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
    '        .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
    '        .Add("@PENDIENTE", OleDbType.Boolean).Value = PENDIENTE
    '    End With

    '    CC_ConnBD.Oledbconexion.Open()

    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    While Obj_Reader.Read
    '        E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
    '    End While

    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_Item
    'End Function

    Public Function IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(ByVal ID_ATE_RES As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim result As Integer = 0

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            result = E_Proc_Item.ID_ATE_RES
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return result
    End Function

    Function IRIS_WEB_RESULTADOS_BUSCA_VISOR_DETALLE(ID_ATE As Long,
                                                     ID_SECCION As Long,
                                                     ID_EXAMEN As Long,
                                                     R_DIA As Integer,
                                                     R_MES As Integer,
                                                     R_AÑO As Integer,
                                                     PENDIENTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_RESULTADOS_BUSCA_VISOR_DETALLE_NEW_4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_EXAMEN", OleDbType.Numeric).Value = ID_EXAMEN
            .Add("@R_DIA", OleDbType.Numeric).Value = R_DIA
            .Add("@R_MES", OleDbType.Numeric).Value = R_MES
            .Add("@R_AÑO", OleDbType.Numeric).Value = R_AÑO
            .Add("@PENDIENTE", OleDbType.Boolean).Value = PENDIENTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2


            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_U_MEDIDA_1 = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.PRU_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 13, "").trim()
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.CF_CORTO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 16, 0)
            E_Proc_Item.ID_U_MEDIDA_2 = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 18, 0)
            E_Proc_Item.PRU_RESU_INMEDIATO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 27, 0)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 28, 0)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 29, 0)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.REQ_RES_VAL = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.RES_HIST = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.RES_HIST_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.RES_HIST_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Date.Now)

            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 39, "")
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 40, "")
            E_Proc_Item.CANTIDAD_DE_HISTORICOS = DD_GEN.DB_NULL(Obj_Reader, 41, 0)
            E_Proc_Item.RECHAZADO = DD_GEN.DB_NULL(Obj_Reader, 42, False)
            E_Proc_Item.RECEPCIONADO = DD_GEN.DB_NULL(Obj_Reader, 43, False)
            E_Proc_Item.ATE_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 44, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 45, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 46, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function busca_numero_atencion_l_r(numeroAtencion As Integer, direccion As Boolean, idCodigoFonasa As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "busca_numero_atencion_l_r"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = numeroAtencion
            .Add("@DIRECCION", OleDbType.Boolean).Value = direccion
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = idCodigoFonasa
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
        Dim ATE_NUM = 0
        While Obj_Reader.Read
            ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return ATE_NUM
    End Function

    Function IRIS_WEBF_UPDATE_CRIT_MANUAL(ByVal ID_ATE_RES As Long) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand


        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_UPDATE_CRITICO_MANUAL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
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
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(ByVal ID_ATE As Long,
                                                                     ByVal ID_SECCION As Long,
                                                                     ByVal ID_EXAMEN As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_DETALLE_SECCION_EXAMEN"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_EXAMEN", OleDbType.Numeric).Value = ID_EXAMEN
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2

            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_U_MEDIDA_1 = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.PRU_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 13, "").trim()
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.CF_CORTO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 16, 0)
            E_Proc_Item.ID_U_MEDIDA_2 = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 18, 0)
            E_Proc_Item.PRU_RESU_INMEDIATO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 27, 0)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 28, 0)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 29, 0)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.REQ_RES_VAL = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION(ByVal ID_ATE As Long, ByVal ID_PAC As Long, ByVal ID_PRU As Long) As List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = Integer.MaxValue
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters '[dbo].[IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA]
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION

            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA_2(ByVal ID_PRU As Long, ByVal SEXO As String, ByVal ID_ATE_RES As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_RANGO_REFERENCIA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
            If (IsNothing(SEXO) = True) Then
                .Add("@SEXO", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@SEXO", OleDbType.VarChar).Value = SEXO
            End If
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA

            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RF_ANO_DESDE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.RF_MESES_DESDE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RF_DIAS_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.RF_ANO_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.RF_MESES_HASTA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.RF_DIAS_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 14, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ByVal ID_PRU As Long, ByVal SEXO As String) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_RANGO_REFERENCIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
            If (IsNothing(SEXO) = True) Then
                .Add("@SEXO", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@SEXO", OleDbType.VarChar).Value = SEXO
            End If

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA

            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RF_ANO_DESDE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.RF_MESES_DESDE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RF_DIAS_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.RF_ANO_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.RF_MESES_HASTA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.RF_DIAS_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_SECCION_POR_ID_ATENCION_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_SECCION = DD_GEN.DB_NULL(Obj_Reader, 4, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_EXAMENES_POR_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION

            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION(ByVal ID_ATE As Long, ByVal ID_RLS As Long) As List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_RLS", OleDbType.Numeric).Value = ID_RLS
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_EXAMENES_POR_ATENCION_Y_SECCION

            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 6, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ByVal ID_RES As Integer, ByVal RES As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_TEXTO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_GRABA_CONTROL_AUDITORIA(ByVal ID_USER As Integer, ByVal ACTION As String, ByVal FORM As String, ByVal ID_ATE_RES As Long)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_GRABA_CONTROL_AUDITORIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USER
            .Add("@ACCION", OleDbType.VarChar).Value = ACTION
            .Add("@FORMA", OleDbType.VarChar).Value = FORM
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ByVal ID_RES As Integer, ByVal RES As String, ByVal EVAL As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_NUMERICO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
            .Add("@ALTOBAJO", OleDbType.VarChar).Value = EVAL
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Function IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_CONTROL_AUDITORIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.AUDI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 0, New Date)
            E_Proc_Item.AUDI_ACCION = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.AUDI_FORMA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Sub IRIS_WEBF_UPDATE_VALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal AB As String, ByVal MUY_DESDE As String, ByVal MUY_HASTA As String, ByVal MUY_AB As Integer, ByVal UNIDADES As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_VALIDACION_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@DESDE", OleDbType.VarChar).Value = IIf(IsNothing(DESDE) = True, DBNull.Value, DESDE)
            .Add("@HASTA", OleDbType.VarChar).Value = IIf(IsNothing(HASTA) = True, DBNull.Value, HASTA)
            .Add("@AB", OleDbType.VarChar).Value = IIf(IsNothing(AB) = True, DBNull.Value, AB)
            .Add("@MUY_DESDE", OleDbType.VarChar).Value = IIf(IsNothing(MUY_DESDE) = True, DBNull.Value, MUY_DESDE)
            .Add("@MUY_HASTA", OleDbType.VarChar).Value = IIf(IsNothing(MUY_HASTA) = True, DBNull.Value, MUY_HASTA)
            .Add("@MUY_AB", OleDbType.Numeric).Value = IIf(IsNothing(MUY_AB) = True, DBNull.Value, MUY_AB)
            .Add("@UNIDADES", OleDbType.VarChar).Value = IIf(IsNothing(UNIDADES) = True, DBNull.Value, UNIDADES)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Sub IRIS_WEBF_UPDATE_DESVALIDA_RESULTADO(ByVal ID_ATE_RES As Integer, ByVal ID_USUARIO As Integer)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_DESVALIDACION_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Function IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS

            E_Proc_Item.ID_REL_PRU_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_RES_COD = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.RES_COD_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.RES_COD_COD = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R(ByVal ID_ATE As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                          ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                          ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                          ByVal ID_USER As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            '.Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
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
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO() As List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_TIPO_CLIENTE_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        ''Enviar parámetros
        'With Cmd_SQL.Parameters

        'End With

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO

            E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.INTEXT_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.INTEXT_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(ByVal ID_ATE As Long) As E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        E_Proc_Item.ID_PAC = 0
        E_Proc_Item.CANT_ATE = 0
        E_Proc_Item.CANT_EXA = 0

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item.ID_PAC = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CANT_ATE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.CANT_EXA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(ByVal NUM_ATE As Long, ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.BigInt).Value = NUM_ATE
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
            .Add("@USU_ID_PROC", OleDbType.BigInt).Value = USU_ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim Response As Long
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            Response = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return Response
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS(ByVal ID_ATE As Long, ByVal ID_PRU As Long, ByVal BL_ALL As Boolean) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_PRU", OleDbType.BigInt).Value = ID_PRU
            .Add("@BL_ALL", OleDbType.Boolean).Value = BL_ALL
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
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS

            obj_Item.ID_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.NN_ATE = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.ATE_R_VALUE = DD_GEN.DB_NULL(Obj_Reader, 3)
            obj_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4)
            obj_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 5)
            obj_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 6)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
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
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE

            obj_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.EXA_COUNT = DD_GEN.DB_NULL(Obj_Reader, 3)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF(ByVal ID_ATE As Long, ByVal ID_CF As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        Dim obj_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 1000 * 60 * 5
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
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
            obj_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU

            obj_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0)
            obj_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1)
            obj_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2)
            obj_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3)
            obj_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 4)
            obj_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 5)
            obj_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 6)
            obj_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 7)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return obj_List
    End Function

    Public Class EE_Check_Valida
        Private EE_ID_DET_ATE As Long
        Public Property ID_DET_ATE() As Long
            Get
                Return EE_ID_DET_ATE
            End Get
            Set(ByVal value As Long)
                EE_ID_DET_ATE = value
            End Set
        End Property
    End Class

    Function IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA(ByVal ID_ATE As Long, ByVal ID_CF As Long) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Lista de Objetos Graph
        Dim obj_List As New List(Of EE_Check_Valida)
        Dim obj_Item As EE_Check_Valida

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA_test"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 1000 * 60 * 5
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF", OleDbType.BigInt).Value = ID_CF
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
            obj_Item = New EE_Check_Valida

            obj_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0)

            obj_List.Add(obj_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()

        If obj_List.Count > 0 Then
            Return 1
        Else
            Return 0
        End If
    End Function


    Function IRIS_WEB_RESULTADOS_BUSCA_VISOR_DETALLE(ID_ATE As Long,
                                                     ID_SECCION As Long,
                                                     ID_EXAMEN As Long,
                                                     R_DIA As Integer,
                                                     R_MES As Integer,
                                                     R_AÑO As Integer,
                                                     ID_AREA As Integer,
                                                     ID_RLS_LS As Integer) As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_RESULTADOS_BUSCA_VISOR_DETALLE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_EXAMEN", OleDbType.Numeric).Value = ID_EXAMEN
            .Add("@R_DIA", OleDbType.Numeric).Value = R_DIA
            .Add("@R_MES", OleDbType.Numeric).Value = R_MES
            .Add("@R_AÑO", OleDbType.Numeric).Value = R_AÑO
            .Add("@ID_AREA", OleDbType.Numeric).Value = ID_AREA
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
        End With

        CC_ConnBD.Oledbconexion.Open()

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2

            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_U_MEDIDA_1 = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.PRU_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 13, "").trim()
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.CF_CORTO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 16, 0)
            E_Proc_Item.ID_U_MEDIDA_2 = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 18, 0)
            E_Proc_Item.PRU_RESU_INMEDIATO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.EST_COD = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 27, 0)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 28, 0)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 29, 0)
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.PRU_VECTOR_CALCULO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.REQ_RES_VAL = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.RES_HIST = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.RES_HIST_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.RES_HIST_FECHA = DD_GEN.DB_NULL(Obj_Reader, 35, Date.Now)

            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 37, "")
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 39, "")
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 40, "")
            'E_Proc_Item.RECEPCIONADO = DD_GEN.DB_NULL(Obj_Reader, 42, False)
            'E_Proc_Item.RECEPCIONADO_SEC = DD_GEN.DB_NULL(Obj_Reader, 43, False)
            'E_Proc_Item.CRITICO_NOTIFICADO = DD_GEN.DB_NULL(Obj_Reader, 44, False)
            'E_Proc_Item.ID_AREA = DD_GEN.DB_NULL(Obj_Reader, 45, 0)
            'E_Proc_Item.ID_SECCION = DD_GEN.DB_NULL(Obj_Reader, 46, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Shared Function IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO_CON_LOG(ByVal ID_RES As Integer, ByVal RES As String, ID_USER As Integer) As String
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_TEXTO_CON_LOG"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USER
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        Dim resultadoViejo = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return resultadoViejo
    End Function

    Public Shared Function IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO_CON_LOG(ID_RES As Integer, RES As String, ID_USUARIO As Integer) As String
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_UPDATE_EXAMEN_NUMERICO_CON_LOG_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_RES
            .Add("@RESULTADO", OleDbType.VarChar).Value = RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        Dim Obj_Reader = Cmd_SQL.ExecuteNonQuery()
        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Public Shared Sub IRIS_WEBF_UPDATE_REVISION_DET_ATENCIONES(obj_Rev As Obj_Rev)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REVISION_DET_ATENCIONES_"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim userID As Integer = 0
        If Cookie_ID IsNot Nothing AndAlso Integer.TryParse(Cookie_ID.Value, Nothing) AndAlso Integer.Parse(Cookie_ID.Value) > 0 Then
            userID = Integer.Parse(Cookie_ID.Value)
        Else
            Return
        End If
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_COM", OleDbType.Numeric).Value = obj_Rev.ID_DET_ATE
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = 1
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = userID
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Shared Sub IRIS_WEBF_UPDATE_REVISION_RESULTADO_ATENCIONES(obj_Rev As Obj_Rev)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REVISION_DET_RESULTADO_EN_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim userID As Integer = 0
        If Cookie_ID IsNot Nothing AndAlso Integer.TryParse(Cookie_ID.Value, Nothing) AndAlso Integer.Parse(Cookie_ID.Value) > 0 Then
            userID = Integer.Parse(Cookie_ID.Value)
        Else
            Return
        End If
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = obj_Rev.ID_ATE_RES
            .Add("@ID_DET_ATE", OleDbType.Numeric).Value = obj_Rev.ID_DET_ATE
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = 1
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = userID
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub
    Public Shared Sub IRIS_WEBF_UPDATE_REVISION_DET_RESULTADO_EN_ATENCION_QUITA_ESTADO(obj_Rev As Obj_Rev)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REVISION_DET_RESULTADO_EN_ATENCION_QUITA_ESTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim userID As Integer = 0
        If Cookie_ID IsNot Nothing AndAlso Integer.TryParse(Cookie_ID.Value, Nothing) AndAlso Integer.Parse(Cookie_ID.Value) > 0 Then
            userID = Integer.Parse(Cookie_ID.Value)
        Else
            Return
        End If
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = obj_Rev.ID_ATE_RES
            .Add("@ID_DET_ATE", OleDbType.Numeric).Value = obj_Rev.ID_DET_ATE
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = 1
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = userID
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub

    Public Shared Sub IRIS_WEB_RESULTADOS_UPDATE_VALIDACION_RESULTADO_CON_LOG(obj_valid As Obj_Valida)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_RESULTADOS_UPDATE_VALIDACION_RESULTADO_CON_LOG"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim userID As Integer = 0
        If Cookie_ID IsNot Nothing AndAlso Integer.TryParse(Cookie_ID.Value, Nothing) AndAlso Integer.Parse(Cookie_ID.Value) > 0 Then
            userID = Integer.Parse(Cookie_ID.Value)
        Else
            Return
        End If
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = obj_valid.ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = userID
            .Add("@DESDE", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.DESDE) = True, DBNull.Value, obj_valid.DESDE)
            .Add("@HASTA", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.HASTA) = True, DBNull.Value, obj_valid.HASTA)
            .Add("@AB", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.AB) = True, DBNull.Value, obj_valid.AB)
            .Add("@MUY_DESDE", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.MUY_DESDE) = True, DBNull.Value, obj_valid.MUY_DESDE)
            .Add("@MUY_HASTA", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.MUY_HASTA) = True, DBNull.Value, obj_valid.MUY_HASTA)
            .Add("@MUY_AB", OleDbType.Numeric).Value = IIf(IsNothing(obj_valid.MUY_AB) = True, DBNull.Value, obj_valid.MUY_AB)
            .Add("@UNIDADES", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.UNIDADES) = True, DBNull.Value, obj_valid.UNIDADES)
            .Add("@RESULTADO", OleDbType.VarChar).Value = IIf(IsNothing(obj_valid.UNIDADES) = True, DBNull.Value, obj_valid.VALUE)
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub


    Public Shared Sub IRIS_WEB_RESULTADOS_UPDATE_DESVALIDACION_RESULTADO_CON_LOG(ID_ATE_RES As Integer, ID_USUARIO As Integer, RESULTADO As String)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_RESULTADOS_UPDATE_DESVALIDACION_RESULTADO_CON_LOG"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@RESULTADO", OleDbType.VarChar).Value = RESULTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Cmd_SQL.ExecuteNonQuery()
    End Sub


    Function IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2_AREA(ATE_NUM As Long, DIRECTION As Boolean, ID_PROC As Integer,
                                                 ID_PREV As Integer, ID_PROG As Integer, ID_SECC As Integer,
                                                 ID_EXAM As Integer, ID_SECT As Integer, ID_PACI As Long,
                                                 ID_USER As Integer, USU_ID_PROC As Integer, ID_AREA As Integer,
                                                 PENDIENTE As Boolean, ID_RLS_LS As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Long = 0

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_AREA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIRECTION", OleDbType.Boolean).Value = DIRECTION
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_EXAM", OleDbType.Numeric).Value = ID_EXAM
            .Add("@ID_SECT", OleDbType.Numeric).Value = ID_SECT
            .Add("@ID_PACI", OleDbType.Numeric).Value = ID_PACI
            .Add("@USU_ID_PROC", OleDbType.Numeric).Value = USU_ID_PROC
            .Add("@ID_AREA", OleDbType.Numeric).Value = ID_AREA
            .Add("@PENDIENTE", OleDbType.Boolean).Value = PENDIENTE
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
        End With

        CC_ConnBD.Oledbconexion.Open()

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function


    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM_ID_PROC_USU(ByVal NUM_ATE As Long, ByVal ID_USER As Integer, ByVal USU_ID_PROC As Integer) As Long
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.BigInt).Value = NUM_ATE
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
            .Add("@USU_ID_PROC", OleDbType.BigInt).Value = USU_ID_PROC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim Response As Long
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            Response = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return Response
    End Function

    Function IRIS_WEB_UPDATE_CRITICO_MANUAL(ID_ATE_RES As Integer, ID_USUARIO As Integer) As Integer
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATE_RES", ID_ATE_RES),
            New SqlParameter("@ID_USUARIO", ID_USUARIO)
        }
        Return D_General_Functions.ExecuteNonQuerySP("IRIS_WEB_UPDATE_CRITICO_MANUAL", params)
    End Function

    Function IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_BACTERIOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA(DESDE As String, HASTA As String, ID_SEC As Integer, ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_AREA(DESDE As String, HASTA As String, ID_AREA As Integer, ID_SEC As Integer, ID_PROC As Integer, ID_RLS_LS As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        Dim params As New List(Of SqlParameter) From {
                New SqlParameter("@DESDE", CDate(DESDE)),
                New SqlParameter("@HASTA", CDate(HASTA)),
                New SqlParameter("@ID_AREA", ID_AREA),
                New SqlParameter("@ID_SECCION", ID_SEC),
                New SqlParameter("@ID_PROCEDENCIA", ID_PROC),
                New SqlParameter("@ID_RLS_LS", ID_RLS_LS)
            }
        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)("IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_AREA", params)
    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_1(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_SEC As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim DD_GEN As New D_General_Functions
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_1"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_2(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_SEC As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim DD_GEN As New D_General_Functions

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_SEC As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim DD_GEN As New D_General_Functions
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_2_AREA(DESDE As String, HASTA As String, ID_AREA As Integer, ID_SEC As Integer, ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)("IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_2_AREA",
                                                                                                                New List(Of SqlParameter) From {
                                                                                                                    New SqlParameter("@DESDE", CDate(DESDE)),
                                                                                                                    New SqlParameter("@HASTA", CDate(HASTA)),
                                                                                                                    New SqlParameter("@ID_AREA", ID_AREA),
                                                                                                                    New SqlParameter("@ID_SECCION", ID_SEC),
                                                                                                                    New SqlParameter("@ID_PROCEDENCIA", ID_PROC)
                                                                                                                })

    End Function
    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_1_AREA(DESDE As String, HASTA As String, ID_AREA As Integer, ID_SEC As Integer, ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)("IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_1_AREA",
                                                                                                                New List(Of SqlParameter) From {
                                                                                                                    New SqlParameter("@DESDE", CDate(DESDE)),
                                                                                                                    New SqlParameter("@HASTA", CDate(HASTA)),
                                                                                                                    New SqlParameter("@ID_AREA", ID_AREA),
                                                                                                                    New SqlParameter("@ID_SECCION", ID_SEC),
                                                                                                                    New SqlParameter("@ID_PROCEDENCIA", ID_PROC)
                                                                                                                })

    End Function
    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_AREA(DESDE As String,
                                                                                     HASTA As String,
                                                                                     ID_AREA As Integer,
                                                                                     ID_SEC As Integer,
                                                                                     ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)("IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_AREA",
                                                                                                                New List(Of SqlParameter) From {
                                                                                                                    New SqlParameter("@DESDE", CDate(DESDE)),
                                                                                                                    New SqlParameter("@HASTA", CDate(HASTA)),
                                                                                                                    New SqlParameter("@ID_AREA", ID_AREA),
                                                                                                                    New SqlParameter("@ID_SECCION", ID_SEC),
                                                                                                                    New SqlParameter("@ID_PROCEDENCIA", ID_PROC)
                                                                                                                })

    End Function

    Shared Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_PENDIENTES_AREA_SECCION(DESDE As String,
                                                                                     HASTA As String,
                                                                                     ID_AREA As Integer,
                                                                                     ID_SEC As Integer,
                                                                                     ID_PROC As Integer,
                                                                                     ID_CODIGO_FONASA As Integer,
                                                                                     ID_RLS_LS As Integer) As List(Of E_Examen_Pendiente_Ate_Resultado)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@DESDE", CDate(DESDE)),
            New SqlParameter("@HASTA", CDate(HASTA)),
            New SqlParameter("@ID_AREA", ID_AREA),
            New SqlParameter("@ID_SECCION", ID_SEC),
            New SqlParameter("@ID_PROCEDENCIA", ID_PROC),
            New SqlParameter("@ID_CODIGO_FONASA", ID_CODIGO_FONASA),
            New SqlParameter("@ID_RLS_LS", ID_RLS_LS)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_Examen_Pendiente_Ate_Resultado)("IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_PENDIENTES_AREA_SECCION", params)

    End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_PENDIENTES(DESDE As String, HASTA As String, ID_SEC As Integer, ID_PROC As Integer,
                                                                 ID_CODIGO_FONASA As Integer) As List(Of E_Examen_Pendiente_Ate_Resultado)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_List As New List(Of E_Examen_Pendiente_Ate_Resultado)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_PENDIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_SEC", OleDbType.Numeric).Value = ID_SEC
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
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
            Dim E_Proc_Item = New E_Examen_Pendiente_Ate_Resultado

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_COD_FONASA", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ANTIBIOGRAMAS_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_COD_FONASA", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS

            E_Proc_Item.ID_REL_CF_ANTIB = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_CF_ANTIBIOGRAMA = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CF_DESC_CULT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_BY_ID(ByVal ID_PREVE As Integer, ByVal ANO As String, ByVal ID_CF As Integer) As E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        'Declaraciones

        Dim Obj_Reader As OleDbDataReader
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCION_CODIGO_FONASA_BY_ID"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ANO", OleDbType.VarChar).Value = ANO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CF_PRECIO_HOS = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.AÑO_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DIAS = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_CF_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista

        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
    Function IRIS_WEBF_CMVM_GRABA_REL_PANEL_ANTIB(ByVal ID_ATE As Long, ByVal ID_CF_CULT As Integer, ByVal ID_PANEL As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_GRABA_REL_PANEL_ANTIB_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE '127475
            .Add("@ID_CF_CULT", OleDbType.Numeric).Value = ID_CF_CULT '1170
            .Add("@ID_PANEL", OleDbType.Numeric).Value = ID_PANEL '1093

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_QUITA_PANEL_ANTIB(ByVal ID_ATE As Long, ByVal ID_CF_CULT As Integer, ByVal ID_PANEL As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_QUITA_PANEL_ANTIB_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 99999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
            .Add("@ID_CF_CULT", OleDbType.Numeric).Value = ID_CF_CULT
            .Add("@ID_PANEL", OleDbType.Numeric).Value = ID_PANEL
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function


    Public Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M(ByVal ID_ATENCION As Integer, ByVal ID_PER As Integer, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim result As Integer = 0

        'Declaraciones 'lista'
        'Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery


        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Shared Function IRIS_WEB_QUITA_ESTADO_PERFIL_VISOR(ID_ATENCION As Integer, ID_CODIGO_FONASA As Integer, ID_USUARIO As Integer) As Integer
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATENCION", ID_ATENCION),
            New SqlParameter("@CODIGO_FONASA", ID_CODIGO_FONASA),
            New SqlParameter("@ID_USUARIO", ID_USUARIO)
        }
        Return D_General_Functions.ExecuteNonQuerySP("IRIS_WEB_QUITA_ESTADO_PERFIL_VISOR", params)
    End Function
    Shared Function IRIS_WEB_GUARDA_OBS_CRITICO_EN_EXAMEN(ID_ATENCION As Integer, ID_CODIGO_FONASA As Integer, ID_PERFIL As Integer, TEXTO_OBS As String, ID_ATE_RES_ARRAY As String) As Integer
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATENCION", ID_ATENCION),
            New SqlParameter("@ID_CODIGO_FONASA", ID_CODIGO_FONASA),
            New SqlParameter("@ID_PERFIL", ID_PERFIL),
            New SqlParameter("@TEXTO_OBS", TEXTO_OBS),
            New SqlParameter("@ID_ATE_RES_ARRAY", ID_ATE_RES_ARRAY)
        }
        Return D_General_Functions.ExecuteNonQuerySP("IRIS_WEB_GUARDA_OBS_CRITICO_EN_EXAMEN", params)
    End Function

    Public Function IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M(ByVal ATE_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim result As Integer = 0

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 8, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Public Function IRIS_WEBF_BUSCA_PRUEBAS_ACTIVAS_ATENCION(ByVal ID_ATENCION As Integer, ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim result As Integer = 0

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PRUEBAS_ACTIVAS_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 1, 0)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Public Function IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS(ByVal ID_ATENCION As Integer, ByVal ID_PER As Integer, ByVal SOLICITADA As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim result As Integer = 0

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@SOL", OleDbType.Numeric).Value = SOLICITADA
            .Add("@ID_EST", OleDbType.Numeric).Value = ID_ESTADO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA

            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PRU_SOLICITADO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class