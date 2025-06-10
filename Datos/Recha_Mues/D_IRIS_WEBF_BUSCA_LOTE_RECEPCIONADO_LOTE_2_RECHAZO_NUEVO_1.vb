'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Shared Function IRIS_WEB_BUSCA_LISTADO_RECHAZOS_POR_EXAMEN(DESDE As Date, HASTA As Date, ID_PROC As Integer, ID_RLS_LS As Integer, ID_EXAMEN As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim S_Id_User As Integer = 0

        Try
            S_Id_User = CInt(Galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Dim DD_GEN As New D_General_Functions
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim objSession As HttpSessionState = HttpContext.Current.Session

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_BUSCA_LISTADO_RECHAZOS_POR_EXAMEN_AREA_SECCION_REL_PROCE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@IDPRO", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
            .Add("@ID_RLS_LS", OleDbType.Integer).Value = ID_RLS_LS
            .Add("@ID_EXAMEN", OleDbType.Integer).Value = ID_EXAMEN
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
            Dim col = 0
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.RECEP_ETI_NUM_ATE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.RECEP_ETI_FECHA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.RECEP_ETI_RECHAZO_OBS = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1
            E_Proc_Item.TP_RECHA_DESC = DD_GEN.DB_NULL(Obj_Reader, col, "") : col += 1

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1_2(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim S_Id_User As Integer = CType(Galleta("ID_USER"), Integer)

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim objSession As HttpSessionState = HttpContext.Current.Session

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
            '.Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
            '.Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA

            .Add("@IDPRO", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

            E_Proc_Item.LOTE_RECHAZO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.RECEP_ETI_CURVA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.RECEP_ETI_NUM_ATE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.RECEP_ETI_FECHA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_LOTE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.RECEP_ETI_RECHAZO_OBS = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.TP_RECHA_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim S_Id_User As Integer = CType(Galleta("ID_USER"), Integer)

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim objSession As HttpSessionState = HttpContext.Current.Session

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
            '.Add("@ID_PROC", OleDbType.BigInt).Value = ID_PROC
            '.Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA

            .Add("@IDPRO", OleDbType.Integer).Value = CType(objSession("USU_ID_PROC"), Integer)
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

            E_Proc_Item.LOTE_RECHAZO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.RECEP_ETI_CURVA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.RECEP_ETI_NUM_ATE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.RECEP_ETI_FECHA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_LOTE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.RECEP_ETI_RECHAZO_OBS = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.TP_RECHA_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim objSession As HttpSessionState = HttpContext.Current.Session

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUMLOTE", OleDbType.Numeric).Value = NUMLOTE
            .Add("@USU_TM", OleDbType.BigInt).Value = ID_PROC
            '.Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA

            '.Add("@IDPRO", OleDbType.Integer).Value = CType(objSession("USU_TM"), Integer)
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

            E_Proc_Item.LOTE_RECHAZO_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.RECEP_ETI_CURVA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.RECEP_ETI_NUM_ATE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.RECEP_ETI_FECHA_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_LOTE_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.RECEP_ETI_RECHAZO_OBS = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.TP_RECHA_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
