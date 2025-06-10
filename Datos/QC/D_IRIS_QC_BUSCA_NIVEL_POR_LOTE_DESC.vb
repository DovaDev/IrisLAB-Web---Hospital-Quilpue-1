Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC(ByVal LOTE_DESC As String) As Integer
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Reader_Comm As OleDbDataReader
        Dim Res As Integer
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@LOTE_DESC", OleDbType.VarChar).Value = LOTE_DESC
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Res = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        objconexion.Oledbconexion.Close()
        Return Res
    End Function
End Class
