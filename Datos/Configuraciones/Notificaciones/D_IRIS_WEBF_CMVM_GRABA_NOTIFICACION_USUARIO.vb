Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO(ByVal TIPO_MENSAJE As Integer,
                                                ByVal MENSAJE As String,
                                                ByVal FECHA_D As String,
                                                ByVal FECHA_H As String,
                                                ByVal PERMANENTE As Integer) As Integer

        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        'Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@TIPO_MENSAJE", OleDbType.Integer).Value = TIPO_MENSAJE
            .Add("@MENSAJE", OleDbType.VarChar).Value = MENSAJE
            .Add("@FECHA_D", OleDbType.Date).Value = CDate(FECHA_D)
            .Add("@FECHA_H", OleDbType.Date).Value = CDate(FECHA_H)
            .Add("@PERMANENTE", OleDbType.Integer).Value = PERMANENTE
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Obj_Reader = Cmd_command.ExecuteReader
        Dim AYYYYYY As Integer = 0
        While Obj_Reader.Read
            AYYYYYY = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
        End While

        objconexion.Oledbconexion.Close()
        Return AYYYYYY
    End Function
End Class
