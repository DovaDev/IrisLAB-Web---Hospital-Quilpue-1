Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class D_IRIS_WEBF_BUSCA_PACK
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_PACK() As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        'Declaraciones

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PACK_CF
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PACK"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PACK_CF
            Obj_Read_Dt.ID_PACK = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PACK_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PACK_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS(ByVal ID_PACK As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PACK", OleDbType.Numeric).Value = ID_PACK
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List

    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL(ByVal ID_PACK As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_REL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PACK", OleDbType.Numeric).Value = ID_PACK
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            'E_Proc_Item.ID_CIUDAD = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IRIS_REL_PACK_CF = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION(ByVal ARRAY_COD_FONASA As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters

            .Add("@IRIS_REL_PACK_CF", OleDbType.Integer).Value = ARRAY_COD_FONASA

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_GRABA_RELACION_PACK_CF(ByVal ID_PACK As Integer, ByVal ARRAY_COD_FONASA As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_RELACION_PACK_CF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PACK", OleDbType.Integer).Value = ID_PACK
            .Add("@ID_CODIGO_FONASA", OleDbType.Integer).Value = ARRAY_COD_FONASA

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql

    End Function

    Function IRIS_WEBF_BUSCA_PACK_2023() As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PACK_CF
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PACK_NOW"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PACK_CF
            Obj_Read_Dt.ID_PACK = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PACK_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PACK_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_GRABA_PACK(ByVal PACK_COD As String, ByVal PACK_DES As String, ByVal ID_ESTADO As String) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_PACK"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@PACK_COD", OleDbType.VarChar).Value = PACK_COD
            .Add("@PACK_DES ", OleDbType.VarChar).Value = PACK_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_CMVM_UPDATE_PACK(ByVal ID_PACK As Integer,
                                            ByVal PACK_COD As String,
                                            ByVal PACK_DES As String,
                                            ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_PACK"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PACK", OleDbType.Numeric).Value = ID_PACK
            .Add("@PACK_COD", OleDbType.VarChar).Value = PACK_COD
            .Add("@PACK_DES ", OleDbType.VarChar).Value = PACK_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

End Class
