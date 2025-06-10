Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_GRABA_HIST_FIJA_VARIABLES(ByVal ID_ANA As Long,
                                                ByVal ID_LOTE As Long,
                                                ByVal ID_DET As Long,
                                                ByVal F_LI As String,
                                                ByVal F_LS As String,
                                                ByVal F_ME As String,
                                                ByVal F_DE As String,
                                                ByVal F_CV As String,
                                                ByVal F_N As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_QC_HIST_FIJA_VARIABLES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@ID_LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@ID_DET", OleDbType.BigInt).Value = ID_DET
            .Add("@LI", OleDbType.VarChar).Value = F_LI
            .Add("@LS", OleDbType.VarChar).Value = F_LS
            .Add("@ME", OleDbType.VarChar).Value = F_ME
            .Add("@DE", OleDbType.VarChar).Value = F_DE
            .Add("@CV", OleDbType.VarChar).Value = F_CV
            .Add("@N", OleDbType.VarChar).Value = F_N
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_QC_UPDATE_FIJA_VARIABLES(ByVal ID_ANA As Long,
                                                ByVal ID_LOTE As Long,
                                                ByVal ID_DET As Long,
                                                ByVal V_LI As String,
                                                ByVal V_LS As String,
                                                ByVal V_ME As String,
                                                ByVal V_DE As String,
                                                ByVal V_CV As String,
                                                ByVal V_N As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_QC_FIJA_VARIABLES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@ID_LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@ID_DET", OleDbType.BigInt).Value = ID_DET
            .Add("@LI", OleDbType.VarChar).Value = V_LI
            .Add("@LS", OleDbType.VarChar).Value = V_LS
            .Add("@ME", OleDbType.VarChar).Value = V_ME
            .Add("@DE", OleDbType.VarChar).Value = V_DE
            .Add("@CV", OleDbType.VarChar).Value = V_CV
            .Add("@N", OleDbType.VarChar).Value = V_N
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class
