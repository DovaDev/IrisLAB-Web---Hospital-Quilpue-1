﻿Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ANA", OleDbType.VarChar).Value = ID_ANA
            .Add("@ID_LOTE", OleDbType.VarChar).Value = ID_LOTE
            .Add("@ID_DET", OleDbType.Numeric).Value = ID_DET
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
