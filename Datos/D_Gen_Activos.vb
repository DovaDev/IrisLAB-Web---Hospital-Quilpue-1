'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class D_Gen_Activos
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_BUSCA_ID_ATE_BY_ATE_NUM(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ID_ATE_BY_ATE_NUM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            E_Exam_Item.ID_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 0, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            E_Exam_Item.ID_PER = DD_Gen.DB_NULL(Obj_Reader, 0, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS2(ID_ATE As Integer, ID_RLS_LS As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS"
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ID_ATENCION"
            '.CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ID_ATENCION_ID_RLS_LS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            E_Exam_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Exam_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Exam_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Exam_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Exam_Item.ID_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 4, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function

    Public Function Request_Ciudad_By_ID_USER(ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)
        'Declaraciones
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim objItem As E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER
        Dim objList As New List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER

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
            objItem = New E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER

            objItem.ID_CIUDAD = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            objItem.CIU_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            objItem.CIU_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")

            'Agregar elementos a la Lista
            objList.Add(objItem)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return objList
    End Function

    Public Function Data_Sel_Comuna(ByVal ID_CIU As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        'Declaraciones
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim objItem As E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER
        Dim objList As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER"
            '.CommandText = "IRIS_BUSCA_RELACION_CIU_COMUNA"
            .CommandText = "IRIS_BUSCA_RELACION_CIU_COMUNA_ID_CIU_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CIU", OleDbType.BigInt).Value = ID_CIU

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
            objItem = New E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER

            objItem.ID_COMUNA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            objItem.COM_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            objItem.COM_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            objItem.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            objItem.ID_CIUDAD = DD_Gen.DB_NULL(Obj_Reader, 4, "")
            objItem.ID_REL_CIU_COM = DD_Gen.DB_NULL(Obj_Reader, 5, "")

            'Agregar elementos a la Lista
            objList.Add(objItem)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return objList
    End Function


    Public Function Request_Comuna_By_ID_USER(ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        'Declaraciones
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim objItem As E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER
        Dim objList As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER

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
            objItem = New E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER

            objItem.ID_COMUNA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            objItem.COM_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            objItem.COM_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")

            'Agregar elementos a la Lista
            objList.Add(objItem)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return objList
    End Function


    Shared Function IRIS_WEB_BUSCA_RELACION_AREA_SECCION_ID_ATE(ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATENCION", ID_ATENCION)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)("IRIS_WEB_BUSCA_RELACION_AREA_SECCION_ID_ATE", params)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_AND_PART_WEB() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_AND_PART_WEB"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
            E_Prev_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.PREVE_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Prev_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Prev_Item.PREVE_PART_WEB = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            'Agregar items a la lista de items
            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_T_Pago_Item As E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE
        Dim E_T_Pago_List As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_T_Pago_Item = New E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE
            E_T_Pago_Item.ID_TP_PAGO = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_T_Pago_Item.TP_PAGO_DESC = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_T_Pago_Item.TP_PAGO_ING = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_T_Pago_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            'Agregar elementos a la Lista
            E_T_Pago_List.Add(E_T_Pago_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_T_Pago_List
    End Function

    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Parametros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
            E_Proc_Item.ID_PROGRA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.PROGRA_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PROGRA_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
            E_Proc_Item.ID_PROCEDENCIA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.PROC_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            'Agregar elementos a la Lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ByVal ID_PROC As Long) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
            E_Prev_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.PREVE_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")

            'Agregar items a la lista de items
            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ByVal ID_PREV As Integer, ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.Integer).Value = ID_PREV
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
            E_Proc_Item.ID_PROCEDENCIA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.PROC_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            'Agregar elementos a la Lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ByVal ID_PROC As Long, ByVal ID_USER As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE_3"
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_BY_ID_PROC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_USER", OleDbType.Numeric).Value = ID_USER
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
            E_Prev_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.PREVE_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")

            'Agregar items a la lista de items
            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function
    Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PREVISION_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
            E_Prev_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.PREVE_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Prev_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            'Agregar items a la lista de items
            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function
    Function IRIS_WEBF_BUSCA_MEDICOS_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Med_Item As E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim E_Med_List As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_MEDICOS_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Med_Item = New E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
            E_Med_Item.ID_DOCTOR = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Med_Item.DOC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Med_Item.DOC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Med_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Med_Item.ESP_DESC = DD_Gen.DB_NULL(Obj_Reader, 4, "")
            E_Med_Item.DOC_FONO1 = DD_Gen.DB_NULL(Obj_Reader, 5, "")
            E_Med_Item.DOC_MOVIL1 = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            'Agregar items a la lista de items
            E_Med_List.Add(E_Med_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Med_List
    End Function
    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
            E_Proc_Item.ID_PROGRA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.PROGRA_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PROGRA_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
            E_Proc_Item.ID_TP_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.TP_ATE_COD = DD_Gen.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TP_ATE_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            E_Exam_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Exam_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Exam_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function
    Function IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
            E_Exam_Item.ID_ORDEN = DD_Gen.DB_NULL(Obj_Reader, 0, "")
            E_Exam_Item.ORD_COD = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Exam_Item.ORD_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Exam_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function
    Function IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_T_Pago_Item As E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE
        Dim E_T_Pago_List As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_T_Pago_Item = New E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE
            E_T_Pago_Item.ID_TP_PAGO = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_T_Pago_Item.TP_PAGO_DESC = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_T_Pago_Item.TP_PAGO_ING = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_T_Pago_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            'Agregar elementos a la Lista
            E_T_Pago_List.Add(E_T_Pago_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_T_Pago_List
    End Function
    Function IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_T_Pago_Item As E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG
        Dim E_T_Pago_List As New List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.Integer).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Integer).Value = ID_PROG
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
            E_T_Pago_Item = New E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG
            E_T_Pago_Item.ID_PROGRA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_T_Pago_Item.ID_SUBP = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_T_Pago_Item.SUBP_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_T_Pago_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_T_Pago_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            'Agregar elementos a la Lista
            E_T_Pago_List.Add(E_T_Pago_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_T_Pago_List
    End Function
    Function IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ByVal ID_PR As Long) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PR", OleDbType.Numeric).Value = ID_PR
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO
            E_Proc_Item.ID_PROGRA = DD_Gen.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_Gen.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ESTADO = DD_Gen.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_AÑO_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_AÑO_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_AÑO_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_AÑO_ACTIVO
            E_Proc_Item.ID_AÑO = DD_Gen.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.AÑO_COD = DD_Gen.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.AÑO_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Med_Item As E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS
        Dim E_Med_List As New List(Of E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Med_Item = New E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS
            E_Med_Item.USU_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 0, "")
            E_Med_Item.USU_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Med_Item.ID_USUARIO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Med_Item.PROFE_DESC = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Med_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Med_Item.ID_PROFESION = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            'Agregar items a la lista de items
            E_Med_List.Add(E_Med_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Med_List
    End Function
    Function IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO() As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Med_Item As E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        Dim E_Med_List As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Med_Item = New E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
            E_Med_Item.ID_RLS_LS = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Med_Item.ID_LABO = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Med_Item.ID_SECCION = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Med_Item.RLS_LS_DESC = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Med_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 4, 0)

            'Agregar items a la lista de items
            E_Med_List.Add(E_Med_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Med_List
    End Function

    Function IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA() As List(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Med_Item As E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA
        Dim E_Med_List As New List(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Med_Item = New E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA
            E_Med_Item.ID_AREA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Med_Item.AREA_COD = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Med_Item.AREA_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, "")
            E_Med_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)

            'Agregar items a la lista de items
            E_Med_List.Add(E_Med_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Med_List
    End Function
    Function IRIS_WEBF_BUSCA_SECCIONES_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_SECCIONES_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
            E_Proc_Item.ID_SECCION = DD_Gen.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.SECC_COD = DD_Gen.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.SECC_DESC = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_USUARIO2() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_USUARIO2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_USUARIO2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_USUARIO2
            E_Proc_Item.ID_USUARIO = DD_Gen.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.USU_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.USU_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PER_USU_DESC = DD_Gen.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.USU_NIC = DD_Gen.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ASOCIADO_PREVISION() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Exam_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim E_Exam_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ASOCIADO_PREVISION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Exam_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            E_Exam_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Exam_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_Exam_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)

            'Agreggar items a la lista
            E_Exam_List.Add(E_Exam_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Exam_List
    End Function

    Public Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        'Declaraciones
        Dim CC_ConnBD As New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones "lista"
        Dim E_T_Pago_Item As E_Async_SubP
        Dim E_T_Pago_List As New List(Of E_Async_SubP)

        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_PREVE_PROG_SUBPROG_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.Integer).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Integer).Value = ID_PROG

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
            E_T_Pago_Item = New E_Async_SubP

            E_T_Pago_Item.SubP_ID = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_T_Pago_Item.SubP_Cod = DD_Gen.DB_NULL(Obj_Reader, 1, "")
            E_T_Pago_Item.SubP_Desc = DD_Gen.DB_NULL(Obj_Reader, 2, "")

            'Agregar elementos a la Lista
            E_T_Pago_List.Add(E_T_Pago_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_T_Pago_List
    End Function
    Shared Function IRIS_WEB_BUSCA_AREA_TRABAJO_ACTIVA_CON_RELACION(ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_ATENCION", ID_ATENCION)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA)("IRIS_WEB_BUSCA_AREA_TRABAJO_ACTIVA_CON_RELACION_ID_ATE", params)
    End Function
End Class
