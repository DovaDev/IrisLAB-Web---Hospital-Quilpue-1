'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_MEDICO
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_MEDICO() As List(Of E_IRIS_WEBF_BUSCA_MEDICO)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MEDICO
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MEDICO)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MEDICOS"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MEDICO
            Obj_Read_Dt.ID_DOCTOR = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.DOC_RUT = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_SEXO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.DOC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ID_NACIONALIDAD = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.DOC_DIR = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ID_REL_CIU_COM = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.DOC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.DOC_FONO2 = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.DOC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.DOC_MOVIL2 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.DOC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ID_ESPECIALIDAD = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.ESP_DESC = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
