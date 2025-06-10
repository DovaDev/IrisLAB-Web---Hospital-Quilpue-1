'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class D_PROCEDENCIAS_Y_CANT_MAX
    'Declaraciones Generales
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX() As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX"
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
            Obj_Read_Dt.ID_PROCEDENCIA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PROC_CANT_EXA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PRO_TIPO_I = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2(ByVal ID_PRE As String, ByVal FECHA As String) As Integer
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRE", OleDbType.VarChar).Value = ID_PRE '1
            .Add("@DESDE", OleDbType.VarChar).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.VarChar).Value = CDate(FECHA) '3
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
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        objconexion.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function

    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_TOTALES_DE_PROCEDENCIA_ATENCIONES
        Dim List_Reader As New List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        Dim Reader_Comm As OleDbDataReader


        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRE", OleDbType.VarChar).Value = ID_PRE '1
            .Add("@DESDE", OleDbType.VarChar).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.VarChar).Value = CDate(FECHA) '3
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_TOTALES_DE_PROCEDENCIA_ATENCIONES
            Obj_Read_Dt.TOTAL_AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            Obj_Read_Dt.TOTAL_AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 1, 0)
            Obj_Read_Dt.TOTAL_AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 2, 0)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO(ByVal ID_PRE As String, ByVal FECHA As Date, ByVal FECHA2 As Date) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE
        Dim List_Reader As New List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        Dim Reader_Comm As OleDbDataReader

        'FECHA.Replace("/", "-")
        'FECHA2.Replace("/", "-")
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE '1
            .Add("@DESDE", OleDbType.VarChar).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.VarChar).Value = CDate(FECHA2)
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE
            Obj_Read_Dt.TOTAL_AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            Obj_Read_Dt.TOTAL_AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 1, 0)
            Obj_Read_Dt.TOTAL_AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 2, 0)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 3, 0)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_estadistica(ByVal ID_PRE As String, ByVal FECHA As Date, ByVal FECHA2 As Date) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_TOTALES_DE_PROCEDENCIA_ATENCIONES
        Dim List_Reader As New List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        Dim Reader_Comm As OleDbDataReader

        'FECHA.Replace("/", "-")
        'FECHA2.Replace("/", "-")
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_ESTA_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE '1
            .Add("@DESDE", OleDbType.VarChar).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.VarChar).Value = CDate(FECHA2)
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_TOTALES_DE_PROCEDENCIA_ATENCIONES
            Obj_Read_Dt.TOTAL_AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            Obj_Read_Dt.TOTAL_AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 1, 0)
            Obj_Read_Dt.TOTAL_AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 2, 0)
            Obj_Read_Dt.TOTAL_AGEND_PAP = DD_GEN.DB_NULL(Reader_Comm, 3, 0)
            Obj_Read_Dt.TOTAL_SOBRE_CUPO = DD_GEN.DB_NULL(Reader_Comm, 4, 0)

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = FECHA '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PRE '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA
            Obj_Read_Dt.PROC_CANT_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CONF_DIAS_FECHA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CONF_DIAS_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_PROCEDENCIA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_CONF_DIAS_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()

        Return List_Reader
    End Function
    Function examens(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim Reader_Comm As OleDbDataReader
        Dim fechafrom = ""
        fechafrom = FECHA.Replace("-", "/")
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = fechafrom '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PRE '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
            Obj_Read_Dt.PROC_CANT_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CONF_DIAS_FECHA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CONF_DIAS_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_PROCEDENCIA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_CONF_DIAS_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function examens2(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim Reader_Comm As OleDbDataReader
        Dim fechafrom = ""
        fechafrom = FECHA.Replace("-", "/")
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = fechafrom '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PRE '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
            Obj_Read_Dt.PROC_CANT_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CONF_DIAS_FECHA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CONF_DIAS_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_PROCEDENCIA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_CONF_DIAS_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 6, 0)
            Obj_Read_Dt.AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 7, 0)
            Obj_Read_Dt.AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 8, 0)
            Obj_Read_Dt.TOTAL_COMENTARIO = DD_GEN.DB_NULL(Reader_Comm, 9, "")




            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.Date).Value = CDate(FECHA) '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = CInt(ID_PRE) '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.Date).Value = CDate(FECHA) '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = CInt(ID_PRE) '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION2(ByVal ID_PRE As String, ByVal FECHA As String, ByVal FECHA2 As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        Cmd_command.CommandTimeout = 1000 * 60 * 10
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(FECHA) '2
            .Add("@HASTA", OleDbType.Date).Value = CDate(FECHA2) '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = CInt(ID_PRE) '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_CANT_EXA(ByVal ID_PRE As String) As Integer
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_EXA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_PREINGRESO", OleDbType.VarChar).Value = ID_PRE
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
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        objconexion.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_BUSCA_CANT_EXA_ATE(ByVal ID_ATE As String) As Integer
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CANT_EXA_ATE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
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
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        objconexion.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO(ByVal ID_PRE As String, ByVal FECHA As Date) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO)
        Dim Reader_Comm As OleDbDataReader
        Dim FECHA2 As Date = FECHA

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = Format(FECHA, "dd-MM-yyyy 00:00:00") '2
            .Add("@HASTA", OleDbType.Date).Value = Format(FECHA2, "dd-MM-yyyy 23:59:59") '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = CInt(ID_PRE) '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 7, "-")
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 8, "")
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM_CON_EXAMENES(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New ConexionBD
        Dim Cmd_command As New OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LIS_PAC_TDM_CON_EXAMENES"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@ID_PREVISION", OleDbType.Numeric).Value = ID_PREVISION
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE_String = DD_GEN.DB_NULL(Reader_Comm, 8, "")
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.ATE_NUM_INT = DD_GEN.DB_NULL(Reader_Comm, 14, 0)
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            Obj_Read_Dt.PREI_HORA = DD_GEN.DB_NULL(Reader_Comm, 16, "SIN HORA")
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 17, 0)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 18, "")

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE_PTGO_disponible(ID_PRE As String, FECHA As String, ID_BLOQUE As Integer) As E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        'Declaraciones
        Dim DD_GEN As New D_General_Functions
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim Reader_Comm As OleDbDataReader
        Dim fechafrom = ""
        fechafrom = FECHA.Replace("-", "/")
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE_PTGO_disponible"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA", OleDbType.VarChar).Value = fechafrom '2
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PRE '1
            .Add("@ID_BLOQUE", OleDbType.Numeric).Value = ID_BLOQUE '1
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX With {
                .PROC_CANT_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing),
                .CONF_DIAS_FECHA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing),
                .CONF_DIAS_EXA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing),
                .ID_ESTADO_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing),
                .ID_PROCEDENCIA_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing),
                .ID_CONF_DIAS_BUSCA_DIAS = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing),
                .AGEND_CUPO_NORMAL = DD_GEN.DB_NULL(Reader_Comm, 6, 0),
                .AGEND_PRIORITARIO = DD_GEN.DB_NULL(Reader_Comm, 7, 0),
                .AGEND_ESPONTANEO = DD_GEN.DB_NULL(Reader_Comm, 8, 0),
                .TOTAL_COMENTARIO = DD_GEN.DB_NULL(Reader_Comm, 9, ""),
                .AGEND_PTGO = DD_GEN.DB_NULL(Reader_Comm, 10, 0),
                .ID_BLOQUE = DD_GEN.DB_NULL(Reader_Comm, 11, 0)
            }

        End While
        objconexion.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function



    Shared Function IRIS_WEBF_UPDATE_HORA_AGENDAMIENTO(idAgendamiento As Integer, ID_PRE As String, FECHA As String, ID_BLOQUE As Integer, SUB_GRUPO_ATE As Integer) As Integer
        'Declaraciones
        Dim DD_GEN As New D_General_Functions
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_HORA_AGENDAMIENTO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@idAgendamiento", OleDbType.Numeric).Value = idAgendamiento
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_BLOQUE", OleDbType.Numeric).Value = ID_BLOQUE
            .Add("@@SUB_GRUPO_ATE", OleDbType.Numeric).Value = SUB_GRUPO_ATE
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Dim rows = Cmd_command.ExecuteNonQuery()

        objconexion.Oledbconexion.Close()
        Return rows
    End Function

    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LIS_PAC_TDM"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@ID_PREVISION", OleDbType.Numeric).Value = ID_PREVISION
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE_String = DD_GEN.DB_NULL(Reader_Comm, 8, "")
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.ATE_NUM_INT = DD_GEN.DB_NULL(Reader_Comm, 14, 0)
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            Obj_Read_Dt.PREI_HORA = DD_GEN.DB_NULL(Reader_Comm, 16, "SIN HORA")
            Obj_Read_Dt.CANT_EXAM = DD_GEN.DB_NULL(Reader_Comm, 17, 0)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 18, "")

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function


    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String, ESTADO As Integer) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
        Dim List_Reader As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROCEDENCIA
            .Add("@ID_PREVISION", OleDbType.Numeric).Value = ID_PREVISION
            .Add("@ESTADO", OleDbType.Numeric).Value = ESTADO
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
            Obj_Read_Dt = New E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREI_FEC_FLE = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.PREI_FECHA_PRE_String = DD_GEN.DB_NULL(Reader_Comm, 8, "")
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_IID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.EST_DESCRIPCION = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 14, "-")
            Obj_Read_Dt.ATE_NUM_INT = DD_GEN.DB_NULL(Reader_Comm, 14, 0)
            Obj_Read_Dt.DNI = DD_GEN.DB_NULL(Reader_Comm, 15, "-")
            Obj_Read_Dt.PREI_HORA = DD_GEN.DB_NULL(Reader_Comm, 16, "SIN HORA")
            Obj_Read_Dt.CANT_EXAM = DD_GEN.DB_NULL(Reader_Comm, 17, 0)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 18, "")

            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEB_AUSENTISMO(id_procedencia As Integer, id_prevision As Integer, fecha As String) As List(Of E_IRIS_WEB_AUSENTISMO)
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("fecha", fecha),
            New SqlParameter("id_procedencia", id_procedencia),
            New SqlParameter("id_prevision", id_prevision)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_IRIS_WEB_AUSENTISMO)("IRIS_WEB_AUSENTISMO", params)
    End Function

End Class
Public Class E_IRIS_WEB_AUSENTISMO
    Private E_Descripcion As String
    Private E_d1 As Integer
    Private E_d2 As Integer
    Private E_d3 As Integer
    Private E_d4 As Integer
    Private E_d5 As Integer
    Private E_d6 As Integer
    Private E_d7 As Integer
    Private E_d8 As Integer
    Private E_d9 As Integer
    Private E_d10 As Integer
    Private E_d11 As Integer
    Private E_d12 As Integer
    Private E_d13 As Integer
    Private E_d14 As Integer
    Private E_d15 As Integer
    Private E_d16 As Integer
    Private E_d17 As Integer
    Private E_d18 As Integer
    Private E_d19 As Integer
    Private E_d20 As Integer
    Private E_d21 As Integer
    Private E_d22 As Integer
    Private E_d23 As Integer
    Private E_d24 As Integer
    Private E_d25 As Integer
    Private E_d26 As Integer
    Private E_d27 As Integer
    Private E_d28 As Integer
    Private E_d29 As Integer
    Private E_d30 As Integer
    Private E_d31 As Integer

    Public Property Descripcion As String
        Get
            Return E_Descripcion
        End Get
        Set(value As String)
            E_Descripcion = value
        End Set
    End Property

    Public Property d1 As Integer
        Get
            Return E_d1
        End Get
        Set(value As Integer)
            E_d1 = value
        End Set
    End Property

    Public Property d2 As Integer
        Get
            Return E_d2
        End Get
        Set(value As Integer)
            E_d2 = value
        End Set
    End Property

    Public Property d3 As Integer
        Get
            Return E_d3
        End Get
        Set(value As Integer)
            E_d3 = value
        End Set
    End Property

    Public Property d4 As Integer
        Get
            Return E_d4
        End Get
        Set(value As Integer)
            E_d4 = value
        End Set
    End Property

    Public Property d5 As Integer
        Get
            Return E_d5
        End Get
        Set(value As Integer)
            E_d5 = value
        End Set
    End Property

    Public Property d6 As Integer
        Get
            Return E_d6
        End Get
        Set(value As Integer)
            E_d6 = value
        End Set
    End Property

    Public Property d7 As Integer
        Get
            Return E_d7
        End Get
        Set(value As Integer)
            E_d7 = value
        End Set
    End Property

    Public Property d8 As Integer
        Get
            Return E_d8
        End Get
        Set(value As Integer)
            E_d8 = value
        End Set
    End Property

    Public Property d9 As Integer
        Get
            Return E_d9
        End Get
        Set(value As Integer)
            E_d9 = value
        End Set
    End Property

    Public Property d10 As Integer
        Get
            Return E_d10
        End Get
        Set(value As Integer)
            E_d10 = value
        End Set
    End Property

    Public Property d11 As Integer
        Get
            Return E_d11
        End Get
        Set(value As Integer)
            E_d11 = value
        End Set
    End Property

    Public Property d12 As Integer
        Get
            Return E_d12
        End Get
        Set(value As Integer)
            E_d12 = value
        End Set
    End Property

    Public Property d13 As Integer
        Get
            Return E_d13
        End Get
        Set(value As Integer)
            E_d13 = value
        End Set
    End Property

    Public Property d14 As Integer
        Get
            Return E_d14
        End Get
        Set(value As Integer)
            E_d14 = value
        End Set
    End Property

    Public Property d15 As Integer
        Get
            Return E_d15
        End Get
        Set(value As Integer)
            E_d15 = value
        End Set
    End Property

    Public Property d16 As Integer
        Get
            Return E_d16
        End Get
        Set(value As Integer)
            E_d16 = value
        End Set
    End Property

    Public Property d17 As Integer
        Get
            Return E_d17
        End Get
        Set(value As Integer)
            E_d17 = value
        End Set
    End Property

    Public Property d18 As Integer
        Get
            Return E_d18
        End Get
        Set(value As Integer)
            E_d18 = value
        End Set
    End Property

    Public Property d19 As Integer
        Get
            Return E_d19
        End Get
        Set(value As Integer)
            E_d19 = value
        End Set
    End Property

    Public Property d20 As Integer
        Get
            Return E_d20
        End Get
        Set(value As Integer)
            E_d20 = value
        End Set
    End Property

    Public Property d21 As Integer
        Get
            Return E_d21
        End Get
        Set(value As Integer)
            E_d21 = value
        End Set
    End Property

    Public Property d22 As Integer
        Get
            Return E_d22
        End Get
        Set(value As Integer)
            E_d22 = value
        End Set
    End Property

    Public Property d23 As Integer
        Get
            Return E_d23
        End Get
        Set(value As Integer)
            E_d23 = value
        End Set
    End Property

    Public Property d24 As Integer
        Get
            Return E_d24
        End Get
        Set(value As Integer)
            E_d24 = value
        End Set
    End Property

    Public Property d25 As Integer
        Get
            Return E_d25
        End Get
        Set(value As Integer)
            E_d25 = value
        End Set
    End Property

    Public Property d26 As Integer
        Get
            Return E_d26
        End Get
        Set(value As Integer)
            E_d26 = value
        End Set
    End Property

    Public Property d27 As Integer
        Get
            Return E_d27
        End Get
        Set(value As Integer)
            E_d27 = value
        End Set
    End Property

    Public Property d28 As Integer
        Get
            Return E_d28
        End Get
        Set(value As Integer)
            E_d28 = value
        End Set
    End Property

    Public Property d29 As Integer
        Get
            Return E_d29
        End Get
        Set(value As Integer)
            E_d29 = value
        End Set
    End Property

    Public Property d30 As Integer
        Get
            Return E_d30
        End Get
        Set(value As Integer)
            E_d30 = value
        End Set
    End Property

    Public Property d31 As Integer
        Get
            Return E_d31
        End Get
        Set(value As Integer)
            E_d31 = value
        End Set
    End Property
End Class
