Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE(ByVal FECHA As String,
                                               ByVal ATE_FECHA As String,
                                               ByVal ID_USUARIO As Long,
                                               ByVal ID_ATENCION As Long,
                                               ByVal IMG As Integer,
                                               ByVal ATE_NUM As Integer) As Integer

        Dim objconexion As New Conexion.C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        'Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = FECHA
            .Add("@ATE_FECHA", OleDbType.Date).Value = CDate(ATE_FECHA)
            .Add("@ID_USUARIO", OleDbType.BigInt).Value = ID_USUARIO
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@IMG", OleDbType.BigInt).Value = IMG
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM

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