'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF(ByVal DESDE As String, ByVal HASTA As String, ByVal IRIS_LNK_MAQ_ID As Long, ByVal ID_PRUEBA As Long) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@IRIS_LNK_MAQ_ID", OleDbType.Numeric).Value = IRIS_LNK_MAQ_ID

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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
            Obj_Read_Dt.ATE_RESULTADO = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_R_DESDE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ATE_R_HASTA = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ATE_RR_DESDE = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ATE_RR_HASTA = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF_MM(ByVal DESDE As String, ByVal HASTA As String, ByVal IRIS_LNK_I_ID As Long, ByVal IRIS_LNK_MAQ_ID As Long, ByVal CANAL As String) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF_MM_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@IRIS_LNK_I_ID", OleDbType.Numeric).Value = IRIS_LNK_I_ID
            .Add("@IRIS_LNK_MAQ_ID", OleDbType.Numeric).Value = IRIS_LNK_MAQ_ID
            .Add("@CANAL", OleDbType.VarChar).Value = CANAL
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
            Obj_Read_Dt.ATE_RESULTADO = DD_GEN.DB_NULL(Reader_Comm, 0, "")
            Obj_Read_Dt.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.ATE_R_DESDE = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ATE_R_HASTA = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ATE_RR_DESDE = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ATE_RR_HASTA = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PRUEBA = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.PRU_DESC = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
