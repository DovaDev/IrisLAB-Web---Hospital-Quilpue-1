'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_SECC As Integer, ByVal ID_PRE As Integer, ByVal ID_TUBO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 0
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_SECC", OleDbType.Numeric).Value = ID_SECC
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_TUBO", OleDbType.Numeric).Value = ID_TUBO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS

            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_RECEP_ETI = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_RECEP_ETI_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_RECEP_ETI_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_2(ByVal DESDE As Date,
                                                                              ByVal HASTA As Date,
                                                                              ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 0
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(ByVal DESDE As Date,
                                                                          ByVal HASTA As Date,
                                                                          ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 8, "0")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
