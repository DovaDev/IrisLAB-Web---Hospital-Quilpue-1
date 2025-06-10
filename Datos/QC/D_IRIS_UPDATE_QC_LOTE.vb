Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_UPDATE_QC_LOTE
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_UPDATE_QC_LOTE(ByVal ID_LOTE As Long,
                                 ByVal LOTE_COD As String,
                                 ByVal LOTE_DES As String,
                                 ByVal ID_ESTADO As Integer,
                                 ByVal ID_ANA As Integer,
                                 ByVal ID_FECHA As String,
                                 ByVal CONTROL_ANA As String,
                                 ByVal NIVEL As Long) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_QC_LOTE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_LOTE", OleDbType.Numeric).Value = ID_LOTE
            .Add("@LOTE_COD", OleDbType.VarChar).Value = LOTE_COD
            .Add("@AREA_DES", OleDbType.VarChar).Value = LOTE_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_ANA", OleDbType.Numeric).Value = ID_ANA
            .Add("@ID_FECHA", OleDbType.Date).Value = CDate(ID_FECHA)
            .Add("@CONTROL_ANA", OleDbType.Numeric).Value = CONTROL_ANA
            .Add("@NIVEL", OleDbType.Numeric).Value = NIVEL
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
