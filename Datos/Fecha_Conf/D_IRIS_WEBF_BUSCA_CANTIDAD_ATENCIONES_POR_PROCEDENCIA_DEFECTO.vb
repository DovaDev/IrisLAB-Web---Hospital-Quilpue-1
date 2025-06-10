Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
    Function D_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO(ByVal ID_PRO As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRO", OleDbType.Integer).Value = Convert.ToInt32(ID_PRO)
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_CANTIDAD_ATENCIONES_POR_PROCEDENCIA_DEFECTO
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PROC_CANT_EXA = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

End Class
