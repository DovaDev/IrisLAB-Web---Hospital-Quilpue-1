'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_DET_ATE_USU
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@E_DESDE", OleDbType.Numeric).Value = E_DESDE
            .Add("@E_HASTA", OleDbType.Numeric).Value = E_HASTA
            .Add("@USU", OleDbType.Numeric).Value = USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@E_DESDE", OleDbType.Numeric).Value = E_DESDE
            .Add("@E_HASTA", OleDbType.Numeric).Value = E_HASTA
            .Add("@USU", OleDbType.Numeric).Value = USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION_PREVE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@USU", OleDbType.Numeric).Value = USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_FP As Long, ByVal ID_PREV As Long, ByVal E_DESDE As Long, ByVal E_HASTA As Long, ByVal USU As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR46_RENDICION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@USU", OleDbType.Numeric).Value = USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6_RENDICION_PREVE
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.USUARIO_DET = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

End Class
