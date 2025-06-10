'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA
    Function IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA(ByVal ID_PROCEDENCIA As Long) As List(Of E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA)
        'Declaraciones Generales
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA
        Dim List_Reader As New List(Of E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        'Cmd_command.CommandText = "IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA"
        Cmd_command.CommandText = "IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA_3"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PROCEDENCIA", OleDbType.Integer).Value = ID_PROCEDENCIA
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
            Obj_Read_Dt = New E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA
            Obj_Read_Dt.ID_USUARIO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.USU_FULL_NAME = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.USU_NIC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
