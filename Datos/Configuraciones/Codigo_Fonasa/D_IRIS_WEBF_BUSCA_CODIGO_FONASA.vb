Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_CODIGO_FONASA
    Dim DD_GEN As New D_General_Functions
    Function D_IRIS_WEBF_BUSCA_CODIGO_FONASA() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_CODIGO_FONASA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_CODIGO_FONASA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_CODIGO_FONASA
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.CF_CORTO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.CF_IMP_SOLA = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.CF_SEL_PRUE = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.CF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.CF_IMP_NUEVO = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.CF_HOST = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_AMUESTRA = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function


    Function LLENAR_TABLA_CODIGO_FONASA_ESTUDIO(ID_FONASA) As List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_BUSCA_PER_FONASA_RELACION"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_FONASA", OleDbType.Numeric).Value = ID_FONASA
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PER_DESC = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.PER_COD = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function LLENAR_TABLA_CODIGO_FONASA_ESTUDIO_SIN_ID() As List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION)
        Dim Reader_Comm As OleDbDataReader
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_PER_FONASA_ALL"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        'With Cmd_command.Parameters
        '    .Add("@ID_FONASA", OleDbType.Numeric).Value = ID_FONASA
        'End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PER_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PER_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PER_NUM_PRU = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.RLS_LS_DESC = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function


End Class
