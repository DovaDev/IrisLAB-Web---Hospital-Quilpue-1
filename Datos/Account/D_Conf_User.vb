'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Conf_User
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Shared Function IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA_FLEBO2(ID_PROCEDENCIA As Integer) As List(Of E_Usuario_Para_Tomar_Muestra)
        'Declaraciones
        Dim CC_ConnBD = New C_ConnBD
        Dim DD_GEN As New D_General_Functions
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDbCommand

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA_FLEBO2"
            .CommandText = "IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA_FLEBO_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
        End With
        CC_ConnBD.Oledbconexion.Open()
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        Dim E_Proc_List As New List(Of E_Usuario_Para_Tomar_Muestra)
        While Obj_Reader.Read
            E_Proc_List.Add(New E_Usuario_Para_Tomar_Muestra With {
                .ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 0, 0),
                .USU_FULL_NAME = DD_GEN.DB_NULL(Obj_Reader, 1, ""),
                .USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            })
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO() As List(Of E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO

            E_Proc_Item.USU_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ADMIN_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2() As List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2

            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.USU_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.USU_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ADMIN_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE"
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
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.USU_PASS = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PER_USU = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.USU_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.USU_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.ID_PROFESION = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.USU_RUT = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.USU_DIR = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ID_CIUDAD = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.ID_COMUNA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.USU_FONO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.USU_MOVIL = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.USU_EMAIL = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_CARGO = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.USU_FNAC = DD_GEN.DB_NULL(Obj_Reader, 16, New Date)
            E_Proc_Item.USU_TM = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.USU_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 18, 0)
            E_Proc_Item.USU_ENTER_LINK = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            'E_Proc_Item.USU_MOBILE = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.USU_ID_PROC = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.USU_ID_PREV = DD_GEN.DB_NULL(Obj_Reader, 21, 0)
            'E_Proc_Item.USU_FIRMA = DD_GEN.DB_NULL(Obj_Reader, 21, 0)
            'E_Proc_Item.USU_FIRMA2 = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_CMVM_USER_INSERT(ByVal USU_NICK As String,
                                        ByVal ID_ROLE As Integer,
                                        ByVal USU_PASS As String,
                                        ByVal USU_FNAC As Date,
                                        ByVal USU_RUT As String,
                                        ByVal ID_PROC As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal USU_NOMBRE As String,
                                        ByVal USU_APELLIDO As String,
                                        ByVal USU_DIR As String,
                                        ByVal USU_EMAIL As String,
                                        ByVal USU_FONO As String,
                                        ByVal USU_MOVIL As String,
                                        ByVal ID_CIUDAD As Integer,
                                        ByVal ID_COMUNA As Integer,
                                        ByVal ID_PROFESION As Integer,
                                        ByVal ID_CARGO As Integer,
                                        ByVal ID_ESTADO As Integer) As Boolean
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_USER_INSERT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@USU_NICK", OleDbType.VarChar).Value = USU_NICK
            .Add("@ID_ROLE", OleDbType.Integer).Value = ID_ROLE
            .Add("@USU_PASS", OleDbType.VarChar).Value = USU_PASS
            .Add("@USU_FNAC", OleDbType.Date).Value = USU_FNAC
            .Add("@USU_RUT", OleDbType.VarChar).Value = USU_RUT
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Integer).Value = ID_PREV
            .Add("@USU_NOMBRE", OleDbType.VarChar).Value = USU_NOMBRE
            .Add("@USU_APELLIDO", OleDbType.VarChar).Value = USU_APELLIDO
            .Add("@USU_DIR", OleDbType.VarChar).Value = USU_DIR
            .Add("@USU_EMAIL", OleDbType.VarChar).Value = USU_EMAIL
            .Add("@USU_FONO", OleDbType.VarChar).Value = USU_FONO
            .Add("@USU_MOVIL", OleDbType.VarChar).Value = USU_MOVIL
            .Add("@ID_CIUDAD", OleDbType.Integer).Value = ID_CIUDAD
            .Add("@ID_COMUNA", OleDbType.Integer).Value = ID_COMUNA
            .Add("@ID_PROFESION", OleDbType.Integer).Value = ID_PROFESION
            .Add("@ID_CARGO", OleDbType.Integer).Value = ID_CARGO
            .Add("@ID_ESTADO", OleDbType.TinyInt).Value = ID_ESTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim SQL_num As Integer = Cmd_SQL.ExecuteNonQuery()
        CC_ConnBD.Oledbconexion.Close()

        If (SQL_num > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IRIS_WEBF_CMVM_USER_UPDATE(ByVal ID_USER As Integer,
                                        ByVal USU_NICK As String,
                                        ByVal ID_ROLE As Integer,
                                        ByVal USU_PASS As String,
                                        ByVal USU_FNAC As Date,
                                        ByVal USU_RUT As String,
                                        ByVal ID_PROC As Integer,
                                        ByVal ID_PREV As Integer,
                                        ByVal USU_NOMBRE As String,
                                        ByVal USU_APELLIDO As String,
                                        ByVal USU_DIR As String,
                                        ByVal USU_EMAIL As String,
                                        ByVal USU_FONO As String,
                                        ByVal USU_MOVIL As String,
                                        ByVal ID_CIUDAD As Integer,
                                        ByVal ID_COMUNA As Integer,
                                        ByVal ID_PROFESION As Integer,
                                        ByVal ID_CARGO As Integer,
                                        ByVal ID_ESTADO As Integer) As Boolean
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As New E_IRIS_WEBF_CMVM_BUSCA_USUARIO_DETALLE

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_USER_UPDATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
            .Add("@USU_NICK", OleDbType.VarChar).Value = USU_NICK
            .Add("@ID_ROLE", OleDbType.Integer).Value = ID_ROLE
            .Add("@USU_PASS", OleDbType.VarChar).Value = USU_PASS
            .Add("@USU_FNAC", OleDbType.Date).Value = USU_FNAC
            .Add("@USU_RUT", OleDbType.VarChar).Value = USU_RUT
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Integer).Value = ID_PREV
            .Add("@USU_NOMBRE", OleDbType.VarChar).Value = USU_NOMBRE
            .Add("@USU_APELLIDO", OleDbType.VarChar).Value = USU_APELLIDO
            .Add("@USU_DIR", OleDbType.VarChar).Value = USU_DIR
            .Add("@USU_EMAIL", OleDbType.VarChar).Value = USU_EMAIL
            .Add("@USU_FONO", OleDbType.VarChar).Value = USU_FONO
            .Add("@USU_MOVIL", OleDbType.VarChar).Value = USU_MOVIL
            .Add("@ID_CIUDAD", OleDbType.Integer).Value = ID_CIUDAD
            .Add("@ID_COMUNA", OleDbType.Integer).Value = ID_COMUNA
            .Add("@ID_PROFESION", OleDbType.Integer).Value = ID_PROFESION
            .Add("@ID_CARGO", OleDbType.Integer).Value = ID_CARGO
            .Add("@ID_ESTADO", OleDbType.TinyInt).Value = ID_ESTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim SQL_num As Integer = Cmd_SQL.ExecuteNonQuery()
        CC_ConnBD.Oledbconexion.Close()

        If (SQL_num > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IRIS_WEBF_CMVM_USER_UPDATE_STATUS(ByVal ID_USER As Long, ByVal ID_ESTADO As Integer) As Boolean
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_USER_UPDATE_STATUS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USER", OleDbType.BigInt).Value = ID_USER
            .Add("@ID_ESTADO", OleDbType.TinyInt).Value = ID_ESTADO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Dim SQL_num As Integer = Cmd_SQL.ExecuteNonQuery()
        CC_ConnBD.Oledbconexion.Close()

        If (SQL_num > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class