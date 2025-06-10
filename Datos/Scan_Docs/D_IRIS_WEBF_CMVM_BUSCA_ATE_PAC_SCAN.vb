Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN

    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN(ByVal ID_ATENCION As Long) As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2 = Nothing
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION

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
            Obj_Read_Dt = New E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
        End While
        objconexion.Oledbconexion.Close()

        If IsNothing(Obj_Read_Dt) Then
            Return Nothing
        Else
            Return Obj_Read_Dt
        End If
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN_ATE(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA = Nothing
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_ATE_PAC_SCAN_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM

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
            Obj_Read_Dt = New E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
        End While
        objconexion.Oledbconexion.Close()

        If IsNothing(Obj_Read_Dt) Then
            Return Nothing
        Else
            Return Obj_Read_Dt
        End If
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_PREI_PAC_SCAN(ByVal PREI_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA = Nothing
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_PREI_PAC_SCAN"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@PREI_NUM", OleDbType.BigInt).Value = PREI_NUM

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
            Obj_Read_Dt = New E_IRIS_WEBF_CMVM_BUSCA_PREI_PAC_DIA
            Obj_Read_Dt.ID_PREINGRESO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.PREI_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.PREI_FECHA = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.PAC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.PAC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_PACIENTE = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.PAC_RUT = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
        End While
        objconexion.Oledbconexion.Close()

        If IsNothing(Obj_Read_Dt) Then
            Return Nothing
        Else
            Return Obj_Read_Dt
        End If
    End Function
End Class
