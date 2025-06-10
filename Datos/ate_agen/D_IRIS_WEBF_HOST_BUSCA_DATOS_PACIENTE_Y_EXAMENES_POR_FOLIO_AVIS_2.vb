'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.IdSolicitudCorrelativo = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.IRIS_H_FECHA = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.IRIS_H_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.IRIS_H_ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.HO_COD_PREVE = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.HO_COD_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 42, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 43, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 44, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUSCA_PACIENTES_SIN_RUT_AVIS() As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_PACIENTES_SIN_RUT_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.IRIS_H_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_GLOBAL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.IdSolicitudCorrelativo = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.IRIS_H_FECHA = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.IRIS_H_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.IRIS_H_ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.HO_COD_PREVE = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.HO_COD_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 42, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 43, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 44, Nothing)
            E_Proc_Item.IRIS_H_ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 45, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_GLOBAL(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2_GLOBAL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.IRIS_H_ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 39, 0)
            E_Proc_Item.IRIS_H_ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 40, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



    Function IRIS_WEBF_BUSCA_ID_PROC_X_COD(ByVal cod_proc_avis As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ID_PROC_X_COD"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@cod_proc_avis", OleDbType.VarChar).Value = cod_proc_avis
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global_2(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_GLOBAL_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.IdSolicitudCorrelativo = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.IRIS_H_FECHA = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.IRIS_H_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.IRIS_H_ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.HO_COD_PREVE = DD_GEN.DB_NULL(Obj_Reader, 40, Nothing)
            E_Proc_Item.HO_COD_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 41, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 42, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 43, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 44, Nothing)
            E_Proc_Item.IRIS_H_ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 45, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP

            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2_GLOBAL_POR_NOMBRE(ByVal NOMBRE As String, ByVal APELLIDO As String, ByVal APELLIDO_MAT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2_GLOBAL_POR_NOMBRE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NOMBRE", OleDbType.VarChar).Value = NOMBRE
            .Add("@APELLIDO", OleDbType.VarChar).Value = APELLIDO
            .Add("@APELLIDO_MAT", OleDbType.VarChar).Value = APELLIDO_MAT

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
            E_Proc_Item.HO_ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.HO_CP = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.HO_CC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.HO_FechaAtencion = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.HO_RutPaciente = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.HO_DvPaciente = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.HO_Nombres = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.HO_ApellidoPaterno = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.HO_ApellidoMaterno = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.HO_Sexo = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.HO_FechaNacimiento = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.HO_TelefonoPaciente = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.HO_EmailPaciente = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.HO_RutMedico = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.HO_DvMedico = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.HO_NombreMedico = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.HO_TipoAtencion = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.HO_ServicioCodigo = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HO_ServicioDescripcion = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.HO_ProcedenciaCodigo = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.HO_ProcedenciaDescripcion = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.HO_ExamenCodigo = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.HO_ExamenDescripcion = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.HO_FechaRegistro = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.HO_EstadoProceso = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.HO_EstadoFecha = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.HO_Iris_EstadoCarga = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.HO_Iris_FechaCarga = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.HO_Iris_Ruta = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.HO_Iris_PDF = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.HO_Iris_Recepcion = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.HO_Iris_FechaRecep = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.HO_IdExamenIris = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HO_Fecha_D = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)
            E_Proc_Item.ID_DIAGNOSTICO = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.HO_COD_DIAG = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.NumCorrelativoCero = DD_GEN.DB_NULL(Obj_Reader, 38, Nothing)
            E_Proc_Item.IRIS_H_ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 39, 0)
            E_Proc_Item.IRIS_H_ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 40, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
