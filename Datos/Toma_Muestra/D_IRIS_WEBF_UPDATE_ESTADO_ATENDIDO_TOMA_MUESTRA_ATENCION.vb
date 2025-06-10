Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION

    Shared Function Update_Estado_Examen(ID_ATENCION As Integer, ID_ESTADO As Integer, ID_USUARIO As Integer, perfiles As List(Of Integer), codigosBarra As List(Of String)) As Integer
        Dim Read_Sql = 0
        For i = 0 To perfiles.Count - 1
            Dim objconexion As New Conexion.ConexionBD
            Dim Cmd_command As New OleDb.OleDbCommand

            'definiendo tipo de consulta a la BD
            Cmd_command.CommandType = CommandType.StoredProcedure
            Cmd_command.CommandText = "IRIS_WEB_UPDATE_ESTADO_EXAMEN_TOMA_MUESTRA"
            Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
            'Enviar parámetros
            With Cmd_command.Parameters
                .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
                .Add("@ID_PER", OleDbType.Numeric).Value = perfiles(i)
                .Add("@CB_DESC", OleDbType.VarChar).Value = codigosBarra(i)
                .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
                .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            End With
            'establece conexion con la base de datos
            If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
                objconexion.Oledbconexion.Close()
            Else
                objconexion.Oledbconexion.Open()
            End If
            'Leer Datos entregados por la BD
            Read_Sql += Cmd_command.ExecuteNonQuery
            objconexion.Oledbconexion.Close()
        Next


        Return Read_Sql
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer, ByVal ID_USER As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.VarChar).Value = ID_USER

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

    Function IRIS_WEBF_UPDATE_ESTADO_bos_vih(ByVal ID_ATE As Integer, ByVal OBS_VIH As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_OBS_VIH"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@OBS_VIH", OleDbType.VarChar).Value = OBS_VIH

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

    Function IRIS_WEBF_UPDATE_OBS_ATENCION_NORMAL(ATE_NUM As String,
                                                  PESO As String,
                                                  TALLA As String,
                                                  HGT As String,
                                                  FECHA_HORA_ULTIMA_DOSIS As String,
                                                  OBSERVACION_TM As String,
                                                  ATE_OBS_FICHA As String,
                                                  OBSERVACION_PER As String,
                                                  DIURESIS As String,
                                                  GRAMAJE As String, ID_PAC As Integer, ZONA_TM As String) As Integer
        'CONCENTRACION_MEDICAMENTO As String,
        'PERSONA As String)
        Dim objconexion As New ConexionBD
        Dim Cmd_command As New OleDbCommand
        Dim Read_Sql As Integer


        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_OBS_ATENCION_NORMAL_TM_FICHA_OBS_PER_ZONA_TM"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@PESO", OleDbType.VarChar).Value = PESO
            .Add("@TALLA", OleDbType.VarChar).Value = TALLA
            .Add("@HGT", OleDbType.VarChar).Value = HGT
            .Add("@FECHA_HORA_ULTIMA_DOSIS", OleDbType.Date).Value = If(FECHA_HORA_ULTIMA_DOSIS = "T", DBNull.Value, FECHA_HORA_ULTIMA_DOSIS)
            .Add("@OBSERVACION_TM", OleDbType.VarChar).Value = OBSERVACION_TM
            .Add("@ATE_OBS_FICHA", OleDbType.VarChar).Value = ATE_OBS_FICHA
            .Add("@OBSERVACION_PER", OleDbType.VarChar).Value = OBSERVACION_PER
            .Add("@DIURESIS", OleDbType.VarChar).Value = DIURESIS
            .Add("@GRAMAJE", OleDbType.VarChar).Value = GRAMAJE
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@ZONA_TM", OleDbType.VarChar).Value = ZONA_TM

            '.Add("@CONCENTRACION_MEDICAMENTO", OleDbType.VarChar).Value = CONCENTRACION_MEDICAMENTO
            '.Add("@PERSONA", OleDbType.VarChar).Value = PERSONA
            '.Add("@OBS", OleDbType.VarChar).Value = OBS
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
