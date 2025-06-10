Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ANOS_POR_ID
    Dim DD_GEN As New D_General_Functions
    Function D_IRIS_WEBF_BUSCA_ANOS_POR_ID(ByVal ANO As String) As List(Of E_IRIS_WEBF_BUSCA_ANOS_POR_ID)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ANOS_POR_ID
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ANOS_POR_ID)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_ANOS_POR_ID"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ANO", OleDbType.VarChar).Value = ANO
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ANOS_POR_ID
            Obj_Read_Dt.ID_AÑO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.AÑO_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.AÑO_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
