'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_INDICACIONES
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_INDICACIONES() As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_INDICACIONES
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_INDICACIONES"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_INDICACIONES
            Obj_Read_Dt.ID_IND = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.IND_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.IND_DES = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function


    Function IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS(ByVal ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_INDICACIONES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_INDICACIONES)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_INDICACIONES_BY_ID_CODIGO_FONASA_NO_RELACIONADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_FONASA", OleDbType.Numeric).Value = ID_FONASA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_INDICACIONES
            E_Proc_Item.IND_DES = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_IND = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IND_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL(ByVal ID_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_RELACION_FONASA_INDICACION_ID_CODFONASA_MANTENEDOR_REL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_FONASA", OleDbType.Numeric).Value = ID_FONASA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA
            E_Proc_Item.IND_DES = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_IND = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_RLS_CF_IND = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_AGREGA_INDICACIONES_FONASA(ByVal ID_FONASA As Integer, ByVal ARRAY_COMUNAS As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_RELACION_IND_FONASA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CF", OleDbType.Integer).Value = ID_FONASA
            .Add("@ID_IND ", OleDbType.Integer).Value = ARRAY_COMUNAS

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


    Function IRIS_WEBF_UPDATE_REL_INDICACION_FONASA_QUITAR_RELACION(ByVal ARRAY_COMUNAS As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REL_INDICACIONES_FONASA_QUITAR_RELACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters

            .Add("@ID_RLS_CF_IND ", OleDbType.Integer).Value = ARRAY_COMUNAS

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
