Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
    Function D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA)
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA)
        Dim Reader_Comm As OleDbDataReader
        Dim DD_GEN As New D_General_Functions
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@FECHA1", OleDbType.Date).Value = DateTime.Today
            .Add("@FECHA2", OleDbType.Date).Value = DateTime.Now
            .Add("@IDPRO", OleDbType.Integer).Value = CType(objSession("USU_TM"), Integer)
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
            Obj_Read_Dt.TOTAL_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.TOT_FONASA = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.Expr1 = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
