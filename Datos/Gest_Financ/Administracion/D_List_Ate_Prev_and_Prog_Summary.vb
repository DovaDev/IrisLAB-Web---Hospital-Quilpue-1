'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_List_Ate_Prev_and_Prog_Summary
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA(ByVal ID_PRE2 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE2", OleDbType.Numeric).Value = ID_PRE2
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.TOT_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA(ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE2", OleDbType.numeric).Value = ID_PRE2
            .Add("@ID_PRE3", OleDbType.numeric).Value = ID_PRE3
            .Add("@DESDE", OleDbType.date).Value = DESDE
            .Add("@HASTA", OleDbType.date).Value = HASTA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.TOT_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID(ByVal ID_PREVE As Long, ByVal ANO As String, ByVal CF As Long) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVE", OleDbType.numeric).Value = ID_PREVE
            .Add("@ANO", OleDbType.varchar).Value = ANO
            .Add("@CF", OleDbType.numeric).Value = CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.CF_SEL_PRUE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.CF_NO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_PRECIO_HOS = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.AÑO_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CF_DIAS = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.ID_CF_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV(ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.numeric).Value = ID_PREV
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR(ByVal SQL_Transact As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = SQL_Transact
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.TOT_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA(ByVal SQL_Transact As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = SQL_Transact
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.TOT_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function Lista_Exa_Cod_Fonasa(ByVal PA_SQL As String) As List(Of E_Lista_Exa_Cod_Fonasa)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_Lista_Exa_Cod_Fonasa
        Dim E_Proc_List As New List(Of E_Lista_Exa_Cod_Fonasa)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = PA_SQL
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
            E_Proc_Item = New E_Lista_Exa_Cod_Fonasa
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class