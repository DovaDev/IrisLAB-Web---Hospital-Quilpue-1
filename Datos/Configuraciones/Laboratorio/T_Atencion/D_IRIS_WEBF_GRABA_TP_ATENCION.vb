Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_TP_ATENCION
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_TP_ATENCION(ByVal TP_ATE_COD As String,
                                            ByVal TP_ATE_DES As String,
                                            ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_TP_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TP_ATE_COD", OleDbType.VarChar).Value = TP_ATE_COD
            .Add("@TP_ATE_DES", OleDbType.VarChar).Value = TP_ATE_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
