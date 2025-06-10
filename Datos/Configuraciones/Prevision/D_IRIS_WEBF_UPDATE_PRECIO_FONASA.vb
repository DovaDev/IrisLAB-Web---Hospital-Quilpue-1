Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_UPDATE_PRECIO_FONASA
    Dim DD_GEN As New D_General_Functions
    Function D_IRIS_WEBF_UPDATE_PRECIO_FONASA(ByVal ID_PRECIO As Integer, ByVal AMB As Integer, ByVal ID_USUARIO As Integer, ByVal FECHA As DateTime, ByVal ID_ESTADO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_PRECIO_FONASA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRECIO", OleDbType.Integer).Value = ID_PRECIO
            .Add("@AMB", OleDbType.Integer).Value = AMB
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO

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
    Function IRIS_WEBF_CMVM_UPDATE_PRECIO_FONASA_BONIFICACION_Y_PARTICULAR(ByVal ID_PRECIO As Integer, ByVal AMB As Integer, ByVal ID_USUARIO As Integer, ByVal FECHA As DateTime, ByVal ID_ESTADO As Integer, ByVal BONIFICACION As Integer, ByVal PARTICULAR As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_UPDATE_PRECIO_FONASA_BONIFICACION_Y_PARTICULAR"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRECIO", OleDbType.Integer).Value = ID_PRECIO
            .Add("@AMB", OleDbType.Integer).Value = AMB
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
            .Add("@BONIFICACION", OleDbType.Integer).Value = BONIFICACION
            .Add("@PARTICULAR", OleDbType.Integer).Value = PARTICULAR

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
