'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEB_BUSCA_EXAMENES(ID_PREVE As Integer, ID_AREA As Integer, ID_SECCION As Integer, ID_RLS_LS As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEB_BUSCA_EXAMENES"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_PREVE", OleDbType.Integer).Value = ID_PREVE
            .Add("@ID_AREA", OleDbType.Integer).Value = ID_AREA
            .Add("@ID_SECCION", OleDbType.Integer).Value = ID_SECCION
            .Add("@ID_RLS_LS", OleDbType.Integer).Value = ID_RLS_LS
        End With
        'establece conexion con la base de datos
        objconexion.Oledbconexion.Open()
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEBF_BUSCA_EXAMENES_POR_SECCION(ID_SECCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_SECCION", OleDbType.Integer).Value = ID_SECCION
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE(ID_SECCION As Integer, ID_AREA As Integer, ID_ATENCION As Integer, ID_RLS_LS As Integer) As List(Of E_Codigo_Fonasa_Para_Los_Select)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_SECCION", ID_SECCION),
            New SqlParameter("@ID_AREA", ID_AREA),
            New SqlParameter("@ID_ATENCION", ID_ATENCION),
            New SqlParameter("@ID_RLS_LS", ID_RLS_LS)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_Codigo_Fonasa_Para_Los_Select)("IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE", params)
    End Function

    Shared Function IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE_NEW(ID_RLS_LS As Integer, ID_AREA As Integer, ID_SECCION As Integer, ID_PREVE As Integer, ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        Dim objconexion As New ConexionBD
        Dim Cmd_command As New OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE_ID_ATE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_RLS_LS", OleDbType.Integer).Value = ID_RLS_LS
            .Add("@ID_AREA", OleDbType.Integer).Value = ID_AREA
            .Add("@ID_SECCION", OleDbType.Integer).Value = ID_SECCION
            .Add("@ID_PREVE", OleDbType.Integer).Value = ID_PREVE
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS With {
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing),
                .CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing),
                .ID_RLS_LS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            }
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE(ID_RLS_LS As Integer, ID_AREA As Integer, ID_SECCION As Integer, ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        Dim objconexion As New ConexionBD
        Dim Cmd_command As New OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEB_BUSCA_EXAMENES_POR_REL_AREA_SECCION_PREVE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_RLS_LS", OleDbType.Integer).Value = ID_RLS_LS
            .Add("@ID_AREA", OleDbType.Integer).Value = ID_AREA
            .Add("@ID_SECCION", OleDbType.Integer).Value = ID_SECCION
            .Add("@ID_PREVE", OleDbType.Integer).Value = ID_PREVE
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS With {
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing),
                .CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing),
                .ID_RLS_LS = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            }
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        Dim objconexion As New ConexionBD
        Dim Cmd_command As New OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        objconexion.Oledbconexion.Open()
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader()
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS With {
                .ID_TP_CRITICO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing),
                .TP_CRITICO_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing),
                .TP_CRITICO_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing),
                .ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            }
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_PREVISION(ID_PREVISION As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_por_prevision"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Integer).Value = ID_PREVISION
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_CB_DESC_TODOS() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CB_DESC_TODOS"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
            Obj_Read_Dt.ID_CODIGO_BARRA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CB_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CB_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Shared Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE_SIN_ID_RLS(ID_SECCION As Integer, ID_AREA As Integer, ID_ATENCION As Integer) As List(Of E_Codigo_Fonasa_Para_Los_Select)
        Dim params = New List(Of SqlParameter) From {
            New SqlParameter("@ID_SECCION", ID_SECCION),
            New SqlParameter("@ID_AREA", ID_AREA),
            New SqlParameter("@ID_ATENCION", ID_ATENCION)
        }
        Return D_General_Functions.ExecuteReaderSP(Of E_Codigo_Fonasa_Para_Los_Select)("IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_SECCION_AREA_ID_ATE_SIN_ID_RLS", params)
    End Function

    Public Class E_Codigo_Fonasa_Para_Los_Select
        Dim EE_ID_CODIGO_FONASA As Integer
        Dim EE_CF_DESC As String
        Public Property ID_CODIGO_FONASA As Integer
            Get
                Return EE_ID_CODIGO_FONASA
            End Get
            Set(value As Integer)
                EE_ID_CODIGO_FONASA = value
            End Set
        End Property
        Public Property CF_DESC As String
            Get
                Return EE_CF_DESC
            End Get
            Set(value As String)
                EE_CF_DESC = value
            End Set
        End Property
    End Class
End Class
