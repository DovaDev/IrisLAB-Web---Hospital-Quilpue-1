Imports System.Data.OleDb
Imports System.Globalization
Public Class D_Update_Observaciones_TM


    Shared Function Update_Segunda_PTGO(idAtencion As Integer) As Boolean
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_FECHA_HORA_SEGUNDA_PTGO_TOMA_MUESTRA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros

        With Cmd_command.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = idAtencion
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Dim Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        If Read_Sql > 0 Then
            Return True
        End If
        Return False
    End Function



    Shared Function Update_Segunda_Carga(idAtencion As Integer) As Boolean
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_FECHA_HORA_SEGUNDA_CARGA_PTGO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros

        With Cmd_command.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = idAtencion
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Dim Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        If Read_Sql > 0 Then
            Return True
        End If
        Return False
    End Function

End Class
