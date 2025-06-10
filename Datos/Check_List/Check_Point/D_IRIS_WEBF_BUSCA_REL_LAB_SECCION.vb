Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_REL_LAB_SECCION
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_REL_LAB_SECCION() As List(Of E_IRIS_WEBF_BUSCA_REL_LAB_SECCION)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_REL_LAB_SECCION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_REL_LAB_SECCION)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_REL_LAB_SECCION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_REL_LAB_SECCION
            Obj_Read_Dt.ID_RLS_LS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.RLS_LS_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
