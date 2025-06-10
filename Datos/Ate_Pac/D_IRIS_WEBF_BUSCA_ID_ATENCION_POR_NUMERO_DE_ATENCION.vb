'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@NUM_ATE", OleDbType.VarChar).Value = NUM_ATE
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@NUM_ATE", OleDbType.VarChar).Value = NUM_ATE
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        Return List_Reader
    End Function


    Function IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA_ID(ByVal NUM_ATE As String) As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_ID_PREINGRESO_POR_NUMERO_DE_AGENDA_ID"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@NUM_ATE", OleDbType.VarChar).Value = NUM_ATE
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        Return List_Reader
    End Function
End Class
