Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
    Function D_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN(ByVal ID_CONF As Integer, ByVal CANTIDAD As String, ByVal ID_ESTADO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_CONF", OleDbType.Numeric).Value = Convert.ToInt32(ID_CONF)
            .Add("@CANTIDAD", OleDbType.VarChar).Value = CANTIDAD
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = Convert.ToInt32(ID_ESTADO)
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
    Function IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN_NEW(ByVal ID_CONF As Integer, ByVal CANTIDAD As String, ByVal ID_ESTADO As Integer, ByVal normal As String, ByVal prioritario As String, ByVal espontaneo As String, ByVal COMENTARIO As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN_NEW_2_comentario"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_CONF", OleDbType.Numeric).Value = Convert.ToInt32(ID_CONF)
            .Add("@CANTIDAD", OleDbType.VarChar).Value = CANTIDAD
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = Convert.ToInt32(ID_ESTADO)
            .Add("@normal", OleDbType.Numeric).Value = Convert.ToInt32(normal)
            .Add("@prioritario", OleDbType.Numeric).Value = Convert.ToInt32(prioritario)
            .Add("@espontaneo", OleDbType.Numeric).Value = Convert.ToInt32(espontaneo)
            .Add("@COMENTARIO", OleDbType.VarChar).Value = COMENTARIO
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
