Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
    Function D_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION(ByVal ID_ANO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_FONASA As Integer, ByVal ID_ESTADO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ANO", OleDbType.Numeric).Value = ID_ANO
            .Add("@ID_ANO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_ANO", OleDbType.Numeric).Value = ID_FONASA
            .Add("@ID_ANO", OleDbType.Numeric).Value = ID_ESTADO
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
