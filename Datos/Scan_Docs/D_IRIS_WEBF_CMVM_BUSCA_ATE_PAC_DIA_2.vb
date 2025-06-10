Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2

    Function IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2(ByVal DESDE As String, ByVal HASTA As String, ByVal USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2
        Dim List_Reader As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_USUARIO", OleDbType.Integer).Value = USUARIO
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
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
