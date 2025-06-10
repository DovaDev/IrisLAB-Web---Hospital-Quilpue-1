Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration

Public Class D_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER(ByVal ID_USUARIO As Integer, ByVal IMG As String) As Integer
        CC_ConnBD = New C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER"
        Cmd_command.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@IMG", OleDbType.VarChar, -1).Value = IMG
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

        End With
        'establece conexion con la base de datos
        If (CC_ConnBD.Oledbconexion.State = ConnectionState.Open) Then
            CC_ConnBD.Oledbconexion.Close()
        Else
            CC_ConnBD.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(ByVal IMG As String, ByVal ID_ATENCION As Integer, ByVal ID_USUARIO As Integer, ByVal ATE_NUM As Integer) As Integer
        CC_ConnBD = New C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC"
        Cmd_command.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            '.Add("@IMG", OleDbType.VarChar, -1).Value = "data:image/jpeg;base64," + IMG
            .Add("@IMG", OleDbType.VarChar, -1).Value = IMG
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@ID_USU", OleDbType.BigInt).Value = ID_USUARIO
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM
        End With
        'establece conexion con la base de datos
        If (CC_ConnBD.Oledbconexion.State = ConnectionState.Open) Then
            CC_ConnBD.Oledbconexion.Close()
        Else
            CC_ConnBD.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF(ByVal IMG As String, ByVal ID_ATENCION As Integer, ByVal ID_USUARIO As Integer, ByVal ATE_NUM As Integer, fileType As String) As Integer
        CC_ConnBD = New C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF"
        Cmd_command.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            '.Add("@IMG", OleDbType.VarChar, -1).Value = "data:image/jpeg;base64," + IMG
            .Add("@IMG", OleDbType.VarChar, -1).Value = IMG
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@ID_USU", OleDbType.BigInt).Value = ID_USUARIO
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM
            .Add("@FILE_TYPE", OleDbType.VarChar).Value = fileType
        End With
        'establece conexion con la base de datos
        If (CC_ConnBD.Oledbconexion.State = ConnectionState.Open) Then
            CC_ConnBD.Oledbconexion.Close()
        Else
            CC_ConnBD.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF_PREI(ByVal IMG As String, ByVal ID_PREINGRESO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Integer, ByVal ATE_NUM As Integer, ByVal PREI_NUM As Integer, fileType As String) As Integer
        CC_ConnBD = New C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF_PREI"
        Cmd_command.Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        'Enviar parámetros
        With Cmd_command.Parameters
            '.Add("@IMG", OleDbType.VarChar, -1).Value = "data:image/jpeg;base64," + IMG
            .Add("@IMG", OleDbType.VarChar, -1).Value = IMG
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@ID_PREINGRESO", OleDbType.BigInt).Value = ID_PREINGRESO
            .Add("@ID_USU", OleDbType.BigInt).Value = ID_USUARIO
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM
            .Add("@PREI_NUM", OleDbType.BigInt).Value = PREI_NUM
            .Add("@FILE_TYPE", OleDbType.VarChar).Value = fileType
        End With
        'establece conexion con la base de datos
        If (CC_ConnBD.Oledbconexion.State = ConnectionState.Open) Then
            CC_ConnBD.Oledbconexion.Close()
        Else
            CC_ConnBD.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

End Class
