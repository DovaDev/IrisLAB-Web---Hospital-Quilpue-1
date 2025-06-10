Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA
    Function IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA(ByVal ID_NOTIF As Long,
                                              ByVal TIPO As Integer,
                                              ByVal FECHA_D As String,
                                              ByVal FECHA_H As String,
                                              ByVal PERMA As Integer,
                                              ByVal MENSAJE As String,
                                              ByVal ESTADO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_NOTIF", OleDbType.Integer).Value = ID_NOTIF
            .Add("@TIPO", OleDbType.Integer).Value = TIPO
            .Add("@FECHA_D", OleDbType.Date).Value = FECHA_D
            .Add("@FECHA_H", OleDbType.Date).Value = FECHA_H
            .Add("@PERMA", OleDbType.Integer).Value = PERMA
            .Add("@MENSAJE", OleDbType.Varchar).Value = MENSAJE
            .Add("@ESTADO", OleDbType.Integer).Value = ESTADO

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
