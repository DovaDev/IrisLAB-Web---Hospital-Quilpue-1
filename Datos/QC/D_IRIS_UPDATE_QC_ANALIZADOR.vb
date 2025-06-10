Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_UPDATE_QC_ANALIZADOR
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_UPDATE_QC_ANALIZADOR(ByVal ID_AREA As Long,
                                      ByVal AREA_COD As String,
                                      ByVal AREA_DES As String,
                                      ByVal ID_ESTADO As Integer,
                                      ByVal ID_SECCION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_QC_ANALIZADORES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_AREA", OleDbType.VarChar).Value = ID_AREA
            .Add("@AREA_COD", OleDbType.VarChar).Value = AREA_COD
            .Add("@AREA_DES", OleDbType.VarChar).Value = AREA_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_SECCION", OleDbType.Numeric).Value = ID_SECCION
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
