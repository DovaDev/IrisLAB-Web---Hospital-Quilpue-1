'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP(ByVal NUMLOTE As Integer, ByVal ID_USER As Integer) As Integer

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USER
            .Add("@FECHA", OleDbType.Date).Value = Date.Now
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

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_SIMPLE(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_SIMPLE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración generalS
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ENVIO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Declaraciones


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        'Configuración generalS
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            E_Proc_Item.ENVIO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CANTIDAD_TUBO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
