Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_UPDATE_USUARIOS
    Function IRIS_WEBF_UPDATE_USUARIOS(ByVal ID_USU As Integer,
                                                                     ByVal RUT_USU As String,
                                                                     ByVal NOMBRE_USU As String,
                                                                     ByVal APE_USU As String,
                                                                     ByVal FNAC_USU As Date,
                                                                     ByVal DIR_USU As String,
                                                                     ByVal EMAIL_USU As String,
                                                                     ByVal ID_EST_USU As Integer,
                                                                     ByVal ID_REL_CIU As Integer,
                                                                     ByVal ID_PRO_USU As Integer,
                                                                     ByVal ID_CAR_USU As Integer,
                                                                     ByVal USUARIO As String,
                                                                     ByVal PASS As String,
                                                                     ByVal ID_PER_USU As Integer,
                                                                     ByVal FONO As String,
                                                                     ByVal MOVIL As String,
                                                                    ByVal USU_ADMIN As Integer,
                                                                    ByVal USU_TM As Integer,
                                                                    ByVal USU_FIRMA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_USUARIOS_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'B64 a Binary
        Dim base64 As String = USU_FIRMA
        Dim bitmapData As Byte()
        Dim B64_Clear As String = FixBase64ForImage(base64)
        bitmapData = Convert.FromBase64String(B64_Clear)


        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
            .Add("@RUT_USU", OleDbType.VarChar).Value = RUT_USU
            .Add("@NOMBRE_USU", OleDbType.VarChar).Value = NOMBRE_USU
            .Add("@APE_USU", OleDbType.VarChar).Value = APE_USU
            .Add("@FNAC_USU as", OleDbType.Date).Value = FNAC_USU
            .Add("@DIR_USU", OleDbType.VarChar).Value = DIR_USU
            .Add("@EMAIL_USU", OleDbType.VarChar).Value = EMAIL_USU
            .Add("@ID_EST_USU", OleDbType.Numeric).Value = ID_EST_USU
            .Add("@ID_REL_CIU", OleDbType.Numeric).Value = ID_REL_CIU
            .Add("@ID_PRO_USU", OleDbType.Numeric).Value = ID_PRO_USU
            .Add("@ID_CAR_USU", OleDbType.Numeric).Value = ID_CAR_USU
            .Add("@USUARIO", OleDbType.VarChar).Value = USUARIO
            .Add("@PASS", OleDbType.VarChar).Value = PASS
            .Add("@ID_PER_USU", OleDbType.Numeric).Value = ID_PER_USU
            .Add("@FONO", OleDbType.VarChar).Value = FONO
            .Add("@MOVIL", OleDbType.VarChar).Value = MOVIL
            .Add("@USU_ADMIN", OleDbType.Numeric).Value = USU_ADMIN
            .Add("@USU_TM", OleDbType.Numeric).Value = USU_TM
            If (base64 <> "vacio") Then
                .Add("@USU_FIRMA", OleDbType.Binary).Value = bitmapData
            Else
                .Add("@USU_FIRMA", OleDbType.Binary).Value = Nothing
            End If

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


    Function FixBase64ForImage(ByVal image As String)
        Dim sbText As New StringBuilder(image, image.Length)
        sbText.Replace("data:image/jpeg;base64,", String.Empty)
        sbText.Replace("data:image/png;base64,", String.Empty)
        sbText.Replace("data:image/bmp;base64,", String.Empty)
        sbText.Replace("\r\n", String.Empty)
        sbText.Replace(" ", String.Empty)
        Return sbText.ToString()
    End Function
End Class
