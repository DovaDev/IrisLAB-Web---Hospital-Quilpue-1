'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            'E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.TOTAL_PARAMETROS = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            'E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.AREA_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            'E_Proc_Item.ID_AREA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.SECC_ALT_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.SECC_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.PER_COD = DD_GEN.DB_NULL(Obj_Reader, 11, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            'E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.TOTAL_PARAMETROS = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            'E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.AREA_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            'E_Proc_Item.ID_AREA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.SECC_ALT_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.SECC_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.PER_COD = DD_GEN.DB_NULL(Obj_Reader, 11, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE(ByVal DESDE As Date,
                                                                                                                ByVal HASTA As Date,
                                                                                                                ByVal ID_PROCEDENCIA As Integer,
                                                                                                                ByVal ID_CODIGO_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            'E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.TOTAL_PARAMETROS = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            'E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            'E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            'E_Proc_Item.AREA_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            'E_Proc_Item.ID_AREA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'E_Proc_Item.PER_COD = DD_GEN.DB_NULL(Obj_Reader, 11, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMS_REM() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMS_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ORDEN = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.SECC_ALT_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_SECC_ALT = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.SECC_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 5, 0)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(ByVal CF_COD As String, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@CF_COD", OleDbType.VarChar).Value = CF_COD
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            'E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            'E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            'E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            'E_Proc_Item.SECC_ALT_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            'E_Proc_Item.SECC_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 5, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(ByVal DESDE As Date,
                                                                                                              ByVal HASTA As Date,
                                                                                                              ByVal ID_PROCEDENCIA As Integer,
                                                                                                              ByVal CF_COD As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@CF_COD", OleDbType.VarChar).Value = CF_COD
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class