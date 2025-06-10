
'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.EST_TM_ACTIVA = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
