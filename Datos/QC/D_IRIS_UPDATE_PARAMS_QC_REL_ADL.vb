Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_UPDATE_PARAMS_QC_REL_ADL
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_UPDATE_PARAMS_QC_REL_ADL(ByVal ID_REL As Long,
                                     ByVal LI As String,
                                     ByVal LS As String,
                                     ByVal MEDIA As String,
                                     ByVal DESVIACION As String,
                                     ByVal CV As String,
                                     ByVal NUM As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_QC_LOTE_MAQ_DET_ACTUALIZA_VALORES_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_REL", OleDbType.BigInt).Value = ID_REL
            .Add("@LI", OleDbType.VarChar).Value = LI
            .Add("@LS", OleDbType.VarChar).Value = LS
            .Add("@MEDIA", OleDbType.VarChar).Value = MEDIA
            .Add("@DESVIACION", OleDbType.VarChar).Value = DESVIACION
            .Add("@CV", OleDbType.VarChar).Value = CV
            .Add("@NUM", OleDbType.VarChar).Value = NUM
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
