Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
    Function D_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2(ByVal ID_PRO As Integer, ByVal FECHA As String) As List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = FECHA
            .Add("@ID_PRO", OleDbType.Integer).Value = ID_PRO
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
            Obj_Read_Dt.PROC_CANT_EXA = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            Obj_Read_Dt.CONF_DIAS_FECHA = DD_GEN.DB_NULL(Reader_Comm, 1, "")
            Obj_Read_Dt.CONF_DIAS_EXA = DD_GEN.DB_NULL(Reader_Comm, 2, "")
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, "")
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 4, "")
            Obj_Read_Dt.ID_CONF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, "")
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2_NEW(ByVal ID_PRO As Integer, ByVal FECHA As String) As List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2_NEW_COMENT"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = FECHA
            .Add("@ID_PRO", OleDbType.Integer).Value = ID_PRO
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
            Obj_Read_Dt.PROC_CANT_EXA = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            Obj_Read_Dt.CONF_DIAS_FECHA = DD_GEN.DB_NULL(Reader_Comm, 1, "")
            Obj_Read_Dt.CONF_DIAS_EXA = DD_GEN.DB_NULL(Reader_Comm, 2, "")
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, "")
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 4, "")
            Obj_Read_Dt.ID_CONF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, "")
            Obj_Read_Dt.AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 6, 0)
            Obj_Read_Dt.AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 7, 0)
            Obj_Read_Dt.AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 8, 0)
            Obj_Read_Dt.AGEND_COMENTARIO = DD_GEN.DB_NULL(Reader_Comm, 9, "")
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
