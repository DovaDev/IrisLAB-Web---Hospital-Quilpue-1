Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_FOLIO_BE
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_CMVM_BUSCA_FOLIO_BE(ByVal ID_ATENCION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As String
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BE_BUSCA_FOLIO_ID_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_List = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        Return E_Proc_List
    End Function


End Class
