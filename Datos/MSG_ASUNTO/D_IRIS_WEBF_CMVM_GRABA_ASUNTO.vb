Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_CMVM_GRABA_ASUNTO
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_GRABA_ASUNTO(ASUNTO, ID_USER_1, ID_USER_2, FECHA) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_ASUNTO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ASUNTO", OleDbType.VarChar).Value = ASUNTO
            .Add("@ID_USER_1", OleDbType.Numeric).Value = ID_USER_1
            .Add("@ID_USER_2", OleDbType.Numeric).Value = ID_USER_2
            .Add("@FECHA", OleDbType.Date).Value = FECHA
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Dim numOut As Integer
        Read_Sql = Cmd_command.ExecuteReader
        While Read_Sql.Read
            numOut = DD_Gen.DB_NULL(Read_Sql, 0, 0)
        End While

        objconexion.Oledbconexion.Close()
        Return numOut
    End Function
    Function IRIS_WEBF_CMVM_GRABA_ASUNTO_MSG(ID_MSG_ASUNTO, ID_USER_1, TIPO, TEXT, FECHA) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_ASUNTO_TEXT"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_MSG_ASUNTO", OleDbType.Numeric).Value = ID_MSG_ASUNTO
            .Add("@ID_USER_1", OleDbType.Numeric).Value = ID_USER_1
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@MSG", OleDbType.VarChar, -1).Value = TEXT
            .Add("@FECHA", OleDbType.Date).Value = FECHA
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
