Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO
    Function IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO(ByVal ID_REL_N_U As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_REL_N_U", OleDbType.Integer).Value = ID_REL_N_U
            .Add("@FECHA", OleDbType.Date).Value = DateTime.Now
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class
