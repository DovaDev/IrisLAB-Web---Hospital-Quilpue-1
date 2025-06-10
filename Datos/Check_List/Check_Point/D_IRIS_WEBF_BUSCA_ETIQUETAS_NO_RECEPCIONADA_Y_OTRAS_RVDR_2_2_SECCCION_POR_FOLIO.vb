'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO(ByVal TIPO As Integer,
                                                                                           ByVal DESDE As Date,
                                                                                           ByVal HASTA As Date,
                                                                                           ByVal ID_PRE As Integer,
                                                                                           ByVal ID_CF As Integer,
                                                                                           ByVal ID_VAL As Integer,
                                                                                           ByVal ID_NMUE As Integer,
                                                                                           ByVal ID_SECCION As Integer,
                                                                                           ByVal ATENUM As Integer,
                                                                                           ByVal ID_ENVIO As Integer,
                                                                                           ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            .Add("@ID_NMUE", OleDbType.Numeric).Value = ID_NMUE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ATENUM", OleDbType.Numeric).Value = ATENUM
            .Add("@ID_ENVIO", OleDbType.Numeric).Value = ID_ENVIO
            .Add("@ID_DERIVADO", OleDbType.Numeric).Value = ID_DERIVADO

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 19, )
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.Expr2 = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.Expr3 = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS(ByVal TIPO As Integer,
                                                                                       ByVal DESDE As Date,
                                                                                       ByVal HASTA As Date,
                                                                                       ByVal ID_PRE As Integer,
                                                                                       ByVal ID_CF As Integer,
                                                                                       ByVal ID_VAL As Integer,
                                                                                       ByVal ID_NMUE As Integer,
                                                                                       ByVal ID_SECCION As Integer,
                                                                                       ByVal ID_ENVIO As Integer,
                                                                                       ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            .Add("@ID_NMUE", OleDbType.Numeric).Value = ID_NMUE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_ENVIO", OleDbType.Numeric).Value = ID_ENVIO
            .Add("@ID_DERIVADO", OleDbType.Numeric).Value = ID_DERIVADO

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 19, )
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.Expr2 = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.Expr3 = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB(ByVal TIPO As Integer,
                                                                                   ByVal DESDE As Date,
                                                                                   ByVal HASTA As Date,
                                                                                   ByVal ID_ENVIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            '.Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            '.Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            '.Add("@ID_NMUE", OleDbType.Numeric).Value = ID_NMUE
            '.Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_ENVIO", OleDbType.Numeric).Value = ID_ENVIO
            '.Add("@ID_DERIVADO", OleDbType.Numeric).Value = ID_DERIVADO

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.Expr3 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS(ByVal TIPO As Integer,
                                                                                        ByVal DESDE As Date,
                                                                                        ByVal HASTA As Date,
                                                                                        ByVal ID_PRE As Integer,
                                                                                        ByVal ID_CF As Integer,
                                                                                        ByVal ID_VAL As Integer,
                                                                                        ByVal ID_NMUE As Integer,
                                                                                        ByVal ID_SECCION As Integer,
                                                                                        ByVal ATENUM As Integer,
                                                                                        ByVal ID_ENVIO As Integer,
                                                                                        ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            .Add("@ID_NMUE", OleDbType.Numeric).Value = ID_NMUE
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ATENUM", OleDbType.Numeric).Value = ATENUM
            .Add("@ID_ENVIO", OleDbType.Numeric).Value = ID_ENVIO
            .Add("@ID_DERIVADO", OleDbType.Numeric).Value = ID_DERIVADO

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 19, )
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.Expr2 = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.Expr3 = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function





    'traza 2 -----------------------------------------------------------------------------------------------------------------------
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB2(ByVal TIPO As Integer,
                                                                                   ByVal DESDE As Date,
                                                                                   ByVal HASTA As Date,
                                                                                   ByVal ID_ENVIO As Integer, ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_PROCED_CTE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            '.Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            '.Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            '.Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            '.Add("@ID_NMUE", OleDbType.Numeric).Value = ID_NMUE
            '.Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
            .Add("@ID_ENVIO", OleDbType.Numeric).Value = ID_ENVIO
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            '.Add("@ID_DERIVADO", OleDbType.Numeric).Value = ID_DERIVADO

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO With {
                .ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing),
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing),
                .T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing),
                .CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing),
                .IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing),
                .ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing),
                .GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing),
                .ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing),
                .ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing),
                .EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing),
                .CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing),
                .PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing),
                .ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing),
                .PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing),
                .PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, ""),
                .PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing),
                .ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing),
                .ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing),
                .ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing),
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing),
                .ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing),
                .ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing),
                .Expr1 = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing),
                .ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing),
                .Expr3 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing),
                .ATE_EST_RECEP_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing),
                .ATE_EST_ENVIO_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing),
                .ATE_USU_RECEP = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing),
                .UENVIO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing),
                .ID_USUARIO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing),
                .ID_ESTADO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing),
                .USUARIO_ENV_RECEP = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing),
                .ATE_FEC_RECEP = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing),
                .ATE_FEC_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing),
                .ENVIO_FECHA_RECEP = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            }
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    'traza 2-----------------------------------------------------------------------------------------------------------------------

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(
                                                                                   DESDE As Date,
                                                                                   HASTA As Date,
                                                                                   ID_ATENCION As Integer,
                                                                                   ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_BUSCA_TRAZABILIDAD_POR_FECHA_O_ID_ATENCION3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO With {
                .ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing),
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing),
                .T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing),
                .CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing),
                .IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing),
                .ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing),
                .GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing),
                .ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing),
                .ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing),
                .EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing),
                .CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing),
                .PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing),
                .ID_PER = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing),
                .PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing),
                .PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, ""),
                .PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing),
                .ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing),
                .ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing),
                .ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing),
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing),
                .ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing),
                .ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing),
                .Expr1 = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing),
                .ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing),
                .Expr3 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing),
                .ATE_EST_RECEP_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing),
                .ATE_EST_ENVIO_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing),
                .ATE_USU_RECEP = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing),
                .UENVIO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing),
                .ID_USUARIO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing),
                .ID_ESTADO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing),
                .USUARIO_ENV_RECEP = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing),
                .ATE_FEC_RECEP = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing),
                .ATE_FEC_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing),
                .ENVIO_FECHA_RECEP = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing),
                .ATE_FEC_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing),
                .ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing),
                .ATE_EST_VALIDA_DESC = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing),
                .ATE_USU_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing),
                .ATE_FEC_TM = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing),
                .ATE_EST_TM = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing),
                .ATE_EST_TM_DESC = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing),
                .ATE_USU_TM = DD_GEN.DB_NULL(Obj_Reader, 42, Nothing),
                .USUARIO_DERI = DD_GEN.DB_NULL(Obj_Reader, 44, Nothing),
                .ATE_FEC_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 45, Nothing),
                .USUARIO_RECH = DD_GEN.DB_NULL(Obj_Reader, 46, Nothing),
                .ATE_FEC_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 47, Nothing),
                .HISTO_ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 48, Nothing),
                .TP_HIS_ATE_DESC = DD_GEN.DB_NULL(Obj_Reader, 49, Nothing),
                .USUARIO_EX = DD_GEN.DB_NULL(Obj_Reader, 50, Nothing),
                .ESTADO_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 51, Nothing),
                .ID_TP_HIS_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 52, Nothing),
                .ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 53, Nothing),
                .ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 54, Nothing),
                .ATE_EST_DERIVA_DESC = DD_GEN.DB_NULL(Obj_Reader, 55, Nothing),
                .ATE_EST_RECHAZO_DESC = DD_GEN.DB_NULL(Obj_Reader, 56, Nothing)
            }
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

End Class
