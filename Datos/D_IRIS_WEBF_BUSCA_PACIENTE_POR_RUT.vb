'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(ByVal RUT_PAC As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        'Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PACIENTE_POR_RUT"
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PACIENTE_POR_RUT_v4"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@RUT_PAC", OleDbType.VarChar).Value = RUT_PAC '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_SEXO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.PAC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ID_NACIONALIDAD = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ID_REL_CIU_COM = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PAC_FONO2 = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.PAC_MOVIL2 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.PAC_OBS_PER = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.ID_CIUDAD = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.ID_COMUNA = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.PAC_NOM_SOCIAL = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.ID_GENERO = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.IS_NEO = DD_GEN.DB_NULL(Reader_Comm, 22, 0)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_PACIENTE_POR_DNI(ByVal RUT_PAC As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PACIENTE_POR_DNI_NOM_SOC_GENERO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DNI", OleDbType.VarChar).Value = RUT_PAC '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT With {
                .ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing),
                .PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing),
                .PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing),
                .PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing),
                .ID_SEXO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing),
                .PAC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing),
                .ID_NACIONALIDAD = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing),
                .PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing),
                .ID_REL_CIU_COM = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing),
                .PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing),
                .PAC_FONO2 = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing),
                .PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing),
                .PAC_MOVIL2 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing),
                .PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing),
                .PAC_OBS_PER = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing),
                .ID_DIAGNOSTICO = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing),
                .ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing),
                .ID_CIUDAD = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing),
                .PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing),
                .ID_COMUNA = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing),
                .PAC_NOM_SOCIAL = DD_GEN.DB_NULL(Reader_Comm, 20, ""),
                .ID_GENERO = DD_GEN.DB_NULL(Reader_Comm, 21, 0)
            }
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

End Class
