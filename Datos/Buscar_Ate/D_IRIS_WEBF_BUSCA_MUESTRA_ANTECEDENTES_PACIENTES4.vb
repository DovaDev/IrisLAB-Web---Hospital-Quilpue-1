'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    'Declaraciones Generales
    Dim objconexion As New Conexion.ConexionBD
    Dim Cmd_command As New OleDb.OleDbCommand
    Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
    Dim DD_GEN As New D_General_Functions
    Dim Reader_Comm As OleDbDataReader
    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Integer).Value = ID_ATE
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ATE_FUR = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ATE_OBS_FICHA = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ATE_AÑO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_OBS_TM = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.SEXO_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PAC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.NAC_DESC = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.COM_DESC = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CIU_DESC = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.PROGRA_DESC = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.ATE_TOTAL = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ATE_AUTORIZO_RETIRO = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 28, "")
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 29, "")
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Integer).Value = ID_ATE
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ATE_FUR = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ATE_OBS_FICHA = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ATE_AÑO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_OBS_TM = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.SEXO_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PAC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.NAC_DESC = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.COM_DESC = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CIU_DESC = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.PROGRA_DESC = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.ATE_TOTAL = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ATE_AUTORIZO_RETIRO = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 28, "")
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 29, "")
            Obj_Read_Dt.ATE_AVIS = DD_GEN.DB_NULL(Reader_Comm, 30, "--")
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2_DNI(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4_2_DNI"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Integer).Value = ID_ATE
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ATE_FUR = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ATE_OBS_FICHA = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ATE_AÑO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_OBS_TM = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.SEXO_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PAC_FNAC = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.PAC_DIR = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.PAC_FONO1 = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PAC_MOVIL1 = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.PAC_EMAIL = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.PAC_OBS_PERMA = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.NAC_DESC = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.COM_DESC = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CIU_DESC = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.PROGRA_DESC = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.ATE_TOTAL = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ATE_AUTORIZO_RETIRO = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 28, "")
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 29, "")
            Obj_Read_Dt.ATE_AVIS = DD_GEN.DB_NULL(Reader_Comm, 30, "")
            Obj_Read_Dt.PAC_DNI = DD_GEN.DB_NULL(Reader_Comm, 31, "")
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
