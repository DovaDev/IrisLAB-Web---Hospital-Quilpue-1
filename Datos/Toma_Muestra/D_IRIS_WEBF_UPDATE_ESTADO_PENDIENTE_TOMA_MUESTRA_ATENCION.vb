Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
    Function IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer, ByVal ID_USER As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION"
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
    Function IRIS_WEBF_GUARDAR_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer,
                                                                  ByVal ATE_NUM As Integer,
                                                                  ByVal DIP_CUP As Integer,
                                                                  ByVal DIP_CVC As Integer,
                                                                  ByVal DIP_PICCLINE As Integer,
                                                                  ByVal DIP_TET As Integer,
                                                                  ByVal DIP_TQT As Integer,
                                                                  ByVal DIP_AREpi As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_GUARDAR_OBSERVACIONES_TOMA_MUESTRA_ATENCION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@DIP_CUP", OleDbType.Numeric).Value = DIP_CUP
            .Add("@DIP_CVC", OleDbType.Numeric).Value = DIP_CVC
            .Add("@DIP_PICCLINE", OleDbType.Numeric).Value = DIP_PICCLINE
            .Add("@DIP_TET", OleDbType.Numeric).Value = DIP_TET
            .Add("@DIP_TQT", OleDbType.Numeric).Value = DIP_TQT
            .Add("@DIP_AREpi", OleDbType.Numeric).Value = DIP_AREpi
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
