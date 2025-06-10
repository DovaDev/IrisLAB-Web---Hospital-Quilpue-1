Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_PROCEDENCIA
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_PROCEDENCIA() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PROCEDENCIA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PROCEDENCIA"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PROCEDENCIA
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PROC_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function





    Function IRIS_WEBF_BUSCA_PROCEDENCIA_2() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PROCEDENCIA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PROCEDENCIA_2"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PROCEDENCIA
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PROC_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PROC_DESC_AVIS = DD_GEN.DB_NULL(Reader_Comm, 4, "-")
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
