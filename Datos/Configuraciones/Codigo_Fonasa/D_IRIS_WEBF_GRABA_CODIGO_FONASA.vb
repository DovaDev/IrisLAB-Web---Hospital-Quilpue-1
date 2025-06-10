Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_CODIGO_FONASA
    Dim DD_GEN As New D_General_Functions
    Function D_IRIS_WEBF_GRABA_CODIGO_FONASA(ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_GRABA_CODIGO_FONASA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@COD_CF", OleDbType.VarChar).Value = COD_CF
            .Add("@DESC_CF", OleDbType.VarChar).Value = DESC_CF
            .Add("@CORTO_CF", OleDbType.VarChar).Value = CORTO_CF
            .Add("@DIAS_CF", OleDbType.Integer).Value = DIAS_CF
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
            .Add("@1_SOLA_CF", OleDbType.VarChar).Value = SOLA_CF
            .Add("@IMP_NOM_CF", OleDbType.VarChar).Value = IMP_NOM_CF
            .Add("@IMP_SEL_CF", OleDbType.VarChar).Value = IMP_SEL_CF
            .Add("@IMP_PAR_CF", OleDbType.VarChar).Value = IMP_PAR_CF
            .Add("@HOST_CF", OleDbType.VarChar).Value = HOST_CF
            .Add("@ID_MUESTRA", OleDbType.Integer).Value = ID_MUESTRA
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
