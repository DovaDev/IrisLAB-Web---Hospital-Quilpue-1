'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_MEDICOS_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MEDICOS_ACTIVO"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
            Obj_Read_Dt.ID_DOCTOR = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 2, "")
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ESP_DESC = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.DOC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.DOC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_MEDICOS_ACTIVO_2() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MEDICOS_ACTIVO_2"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
            Obj_Read_Dt.ID_DOCTOR = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 2, "")
            'Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Obj_Read_Dt.ESP_DESC = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            'Obj_Read_Dt.DOC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            'Obj_Read_Dt.DOC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_MEDICO_COMPARA_SI_EXISTE(ByVal NOMBRE As String) As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones
        Dim objconexion = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista'
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_MEDICO_COMPARA_SI_EXISTE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NOMBRE", OleDbType.VarChar).Value = NOMBRE
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
            Obj_Read_Dt.ID_DOCTOR = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 2, "")
            'Agregar items a la lista
            E_Proc_List.Add(Obj_Read_Dt)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


End Class
