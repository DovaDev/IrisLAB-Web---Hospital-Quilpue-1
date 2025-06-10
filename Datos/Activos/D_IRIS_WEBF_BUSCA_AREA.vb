Imports Entidades
Imports Conexion
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_AREA
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_AREA() As List(Of E_IRIS_WEBF_BUSCA_AREA)
        'Declaraciones

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_AREA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_AREA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_AREA"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_AREA
            Obj_Read_Dt.ID_AREA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.AREA_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.AREA_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function


    Function IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_NO_RELACIONADAS(ByVal ID_AREA As Integer) As List(Of E_IRIS_WEBF_BUSCA_SECCION)
        'Declaraciones
        Dim objconexion = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_SECCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_SECCION)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_SECCIONES_NO_CARGADAS"
            .Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_AREA
        End With
        'Conectar con la Base de Datos
        Select Case objconexion.Oledbconexion.State
            Case ConnectionState.Open
                objconexion.Oledbconexion.Close()
            Case Else
                objconexion.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_SECCION
            E_Proc_Item.SECC_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_SECCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.SECC_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        objconexion.Oledbconexion.Close()
        Return E_Proc_List
    End Function





    Function IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO(ByVal ID_AREA As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_AREA", OleDbType.Numeric).Value = ID_AREA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_LABO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_SECCION = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_GRABA_RELACION_AREA_SECCION(ByVal ID_AREA As Integer, ByVal ARRAY_SECCION As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_RELACION_AREA_SECCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_AREA", OleDbType.Integer).Value = ID_AREA
            .Add("@ID_SECCION ", OleDbType.Integer).Value = ARRAY_SECCION

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

    Function IRIS_WEBF_UPDATE_REL_AREA_SECCION_QUITAR_RELACION(ByVal ARRAY_SECCION As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REL_AREA_SECCION_QUITAR_RELACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetr
        With Cmd_SQL.Parameters

            .Add("@ID_RLS_LS ", OleDbType.Integer).Value = ARRAY_SECCION

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

    Function IRIS_WEBF_LLENAR_DLL_SECCION() As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Declaraciones

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_RELACION_AREA_SECCION_ESTADO"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
            Obj_Read_Dt.ID_RLS_LS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_LABO = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_SECCION = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.RLS_LS_DESC = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function



End Class
