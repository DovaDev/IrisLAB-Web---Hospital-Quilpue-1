Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
    Dim DD_GEN As New D_General_Functions

    Function D_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(ByVal FECHA1 As Date, ByVal FECHA2 As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)
        Dim Reader_Comm As OleDbDataReader

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'definiendo tipo de consulta a la BD
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ATENCION_PACIENTE_BY_ID_PROC_AND_ID_PREV"
            .Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = FECHA1
            .Add("@HASTA", OleDbType.Date).Value = FECHA2
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER
        End With

        'If (TM = "xx") Then
        '    Cmd_command.CommandType = CommandType.StoredProcedure
        '    Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_ATENCION_PACIENTE_FECHA_2"
        '    Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        '    With Cmd_command.Parameters
        '        .Add("@DESDE", OleDbType.Date).Value = Date.ParseExact(FECHA1, "dd-MM-yyyy", Nothing)
        '        .Add("@HASTA", OleDbType.Date).Value = Date.ParseExact(FECHA2, "dd-MM-yyyy", Nothing)
        '        .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
        '    End With
        'ElseIf (TM = "yy") Then
        '    Cmd_command.CommandType = CommandType.StoredProcedure
        '    Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_LUGAR_TM_TODOS_2"
        '    Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        '    With Cmd_command.Parameters
        '        .Add("@DESDE", OleDbType.Date).Value = Date.ParseExact(FECHA1, "dd-MM-yyyy", Nothing)
        '        .Add("@HASTA", OleDbType.Date).Value = Date.ParseExact(FECHA2, "dd-MM-yyyy", Nothing)
        '        .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
        '    End With
        'Else
        '    Cmd_command.CommandType = CommandType.StoredProcedure
        '    Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_2_2"
        '    Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        '    With Cmd_command.Parameters
        '        .Add("@DESDE", OleDbType.Date).Value = Date.ParseExact(FECHA1, "dd-MM-yyyy", Nothing)
        '        .Add("@HASTA", OleDbType.Date).Value = Date.ParseExact(FECHA2, "dd-MM-yyyy", Nothing)
        '        .Add("@ID_TM", OleDbType.Integer).Value = Convert.ToInt32(LUGARTM)
        '        .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
        '    End With
        'End If

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If

        'Leer Datos entregados por la BD
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_AÑO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.SEXO_DESC = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.ID_SEXO = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While

        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
