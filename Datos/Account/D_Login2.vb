'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Login2
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function Login2(ByVal USER As String, ByVal PASS As String) As E_Login2
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_Login2

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_00_ASPX_LOGIN_prueba_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@USER", OleDbType.VarChar).Value = USER
            .Add("@PASS", OleDbType.VarChar).Value = PASS
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
            E_Proc_Item.LOGGED = True
            E_Proc_Item.ID_USER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.NICKNAME = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.P_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.RUT = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.NAME = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.SURNAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'E_Proc_Item.USU_TM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)

        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_00_ASPX_LOGIN_PACIENTES(ByVal RUT As String, ByVal N_ATE As Long, ByVal FECHA As Date) As List(Of E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_08_05_18_00_ASPX_LOGIN_PACIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
            .Add("@N_ATE", OleDbType.Numeric).Value = N_ATE
            .Add("@FECHA", OleDbType.Date).Value = FECHA
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
            E_Proc_Item = New E_IRIS_WEBF_00_ASPX_LOGIN_PACIENTES

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED(ByVal USER As String, ByVal PASS As String) As E_Login2
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_Login2

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_00_ASPX_LOGIN_NEW_IMED"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@USER", OleDbType.VarChar).Value = USER
            .Add("@PASS", OleDbType.VarChar).Value = PASS
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
            E_Proc_Item.LOGGED = True
            E_Proc_Item.ID_USER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.NICKNAME = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.P_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.RUT = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.NAME = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.SURNAME = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.USU_ID_PROC = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.USU_PREV = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_PROF = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.USU_RUT_IMED = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.USU_PASS_IMED = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
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
            E_Proc_Item.ID_CIUDAD = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_COMUNA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
        End While

        CC_ConnBD.Oledbconexion.Close()

        Return E_Proc_Item
    End Function

End Class
