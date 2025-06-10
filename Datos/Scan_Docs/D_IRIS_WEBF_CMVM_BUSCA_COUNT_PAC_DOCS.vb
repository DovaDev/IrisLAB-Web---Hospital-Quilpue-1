Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration
Public Class D_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS

    Function IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS(ByVal ID_ATENCION As Long) As Integer
        Dim objconexion As New Conexion.C_ConnBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
        End With

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If

        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read

            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
        End While
        objconexion.Oledbconexion.Close()

        Return Obj_Read_Dt


    End Function
End Class