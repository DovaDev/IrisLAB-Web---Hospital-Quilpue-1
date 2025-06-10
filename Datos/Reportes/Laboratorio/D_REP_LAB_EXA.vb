'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_REP_LAB_EXA
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@PROCEDENCIA", OleDbType.Integer).Value = PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 17, "")

            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID(ByVal DESDE As Date, ByVal HASTA As Date, ID_CF As Long, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@PROCEDENCIA", OleDbType.Numeric).Value = PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 16, "")


            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@PROCEDENCIA", OleDbType.Integer).Value = PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 17, "")

            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 27, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3(ByVal DESDE As Date, ByVal HASTA As Date, ID_CF As Long, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_2_2_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@PROCEDENCIA", OleDbType.Numeric).Value = PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 16, "")


            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 27, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4(ByVal DESDE As Date, ByVal HASTA As Date, ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS_2_2_2_3_4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@PROCEDENCIA", OleDbType.Integer).Value = PROCEDENCIA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 17, "")

            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 27, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

End Class
