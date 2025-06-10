Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_UPDATE_PROCEDENCIA
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_UPDATE_PROCEDENCIA(ByVal ID_PROCEDENCIA As Integer,
                                            ByVal PROC_COD As String,
                                            ByVal PROC_DES As String,
                                            ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PROCEDENCIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@PROC_COD", OleDbType.VarChar).Value = PROC_COD
            .Add("@PROC_DES", OleDbType.VarChar).Value = PROC_DES
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


    Function IRIS_WEBF_UPDATE_PROCEDENCIA_2(ByVal ID_PROCEDENCIA As Integer,
                                            ByVal PROC_COD As String,
                                            ByVal PROC_DES As String,
                                            ByVal ID_ESTADO As Integer,
                                          ByVal COD_AVIS As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PROCEDENCIA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@PROC_COD", OleDbType.VarChar).Value = PROC_COD
            .Add("@PROC_DES", OleDbType.VarChar).Value = PROC_DES
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@COD_AVIS", OleDbType.VarChar).Value = COD_AVIS
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
