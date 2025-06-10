'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_4"
            '.CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 17, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_vih(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_4_vih"
            '.CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.RATE_OBS_VIH = DD_GEN.DB_NULL(Obj_Reader, 18, "-")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 19, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP"
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.RECEP_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_vih(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP"
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_2_vih"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.RECEP_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.RATE_OBS_VIH = DD_GEN.DB_NULL(Obj_Reader, 19, "-")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_4_COPY(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_4_COPY"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            'E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            'E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            'E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            'E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            'E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            'E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            'E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            'E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            'E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            'E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.RECEP_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 18, New Date)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_2_vih_TEST(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP"
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2_3_POR_FECHA_RECEP_2_vih_TEST"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_2

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            'E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.RECEP_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.RATE_OBS_VIH = DD_GEN.DB_NULL(Obj_Reader, 18, "-")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
