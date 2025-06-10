'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_DET_POR_MAKINA
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_DET_POR_MAKINA(ByVal IRIS_LNK_MAQ_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAKINA)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DET_POR_MAKINA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAKINA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DET_POR_MAKINA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@IRIS_LNK_MAQ_ID", OleDbType.Numeric).Value = IRIS_LNK_MAQ_ID
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DET_POR_MAKINA
            Obj_Read_Dt.IRIS_LNK_DET_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_PRUEBA = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_DET_POR_MAKINA_MM(ByVal IRIS_LNK_MAQ_ID As Long, ByVal IRIS_LNK_I_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_CANAL_MAQ)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_CANAL_MAQ
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_CANAL_MAQ)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANAL_MAQ"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@IRIS_LNK_MAQ_ID", OleDbType.Numeric).Value = IRIS_LNK_MAQ_ID
            .Add("@IRIS_LNK_I_ID", OleDbType.Numeric).Value = IRIS_LNK_I_ID
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_CANAL_MAQ
            Obj_Read_Dt.REL_CM_CANAL_DESC = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.REL_CM_DETER_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
