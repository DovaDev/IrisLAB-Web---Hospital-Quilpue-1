'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    Dim objconexion As New Conexion.ConexionBD
    Dim Cmd_command As New OleDb.OleDbCommand
    Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
    Dim DD_GEN As New D_General_Functions
    Dim Reader_Comm As OleDbDataReader
    Function IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO(ByVal ID_AÑO As String, ByVal ID_PREVI As String) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_AÑO", OleDbType.Integer).Value = Convert.ToInt32(ID_AÑO)
            .Add("@ID_PREVI", OleDbType.Integer).Value = Convert.ToInt32(ID_PREVI)
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
            Obj_Read_Dt.AÑO_DESC = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_PREVE = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.CF_PRECIO_AMB = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.CF_PRECIO_HOS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ID_AÑO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ID_CF_PRECIO = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION_Y_PARTICULAR(ByVal ID_AÑO As String, ByVal ID_PREVI As String) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION_Y_PARTICULAR"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_AÑO", OleDbType.Integer).Value = Convert.ToInt32(ID_AÑO)
            .Add("@ID_PREVI", OleDbType.Integer).Value = Convert.ToInt32(ID_PREVI)
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
            Obj_Read_Dt.AÑO_DESC = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ID_PREVE = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.CF_PRECIO_AMB = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.CF_PRECIO_HOS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ID_AÑO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ID_CF_PRECIO = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.CF_BONIFICACION = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.CF_PRECIO_PARTICULAR = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
