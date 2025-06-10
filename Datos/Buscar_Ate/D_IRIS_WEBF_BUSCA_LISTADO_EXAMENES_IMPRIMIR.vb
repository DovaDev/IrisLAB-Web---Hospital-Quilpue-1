'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
    'Declaraciones Generales
    Dim objconexion As New Conexion.ConexionBD
    Dim Cmd_command As New OleDb.OleDbCommand
    Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
    Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
    Dim DD_GEN As New D_General_Functions
    Dim Reader_Comm As OleDbDataReader
    Function IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            Obj_Read_Dt.ID_DET_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.USU_NIC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.TP_PAGO_DESC = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.ID_TP_PAGO = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_DET_NUM_COPIA = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.CF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.CF_IMP_SOLA = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.CF_IMP_POSX = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.CF_IMP_POSY = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.CF_IMP_LETRA = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.CF_IMP_TAMANO = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.SECC_DESC = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ESTADO_WEB_DERIVADO = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)


            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_2(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_2"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            Obj_Read_Dt.ID_DET_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.USU_NIC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.TP_PAGO_DESC = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.ID_TP_PAGO = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_DET_NUM_COPIA = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.CF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.CF_IMP_SOLA = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.CF_IMP_POSX = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.CF_IMP_POSY = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.CF_IMP_LETRA = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.CF_IMP_TAMANO = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.SECC_DESC = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ESTADO_WEB_DERIVADO = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.CF_AVIS = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.ATE_NUM_AVIS = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)



            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_PAP(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_PAP"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            Obj_Read_Dt.ID_DET_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.USU_NIC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.TP_PAGO_DESC = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.ID_TP_PAGO = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_DET_NUM_COPIA = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.CF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.CF_IMP_SOLA = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.CF_IMP_POSX = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.CF_IMP_POSY = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.CF_IMP_LETRA = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.CF_IMP_TAMANO = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.SECC_DESC = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ESTADO_WEB_DERIVADO = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.ATE_NUM = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)
            Obj_Read_Dt.PROC_DESC = DD_GEN.DB_NULL(Reader_Comm, 28, Nothing)
            Obj_Read_Dt.PREVE_DESC = DD_GEN.DB_NULL(Reader_Comm, 29, Nothing)
            Obj_Read_Dt.DOC_NOMBRE = DD_GEN.DB_NULL(Reader_Comm, 30, Nothing)
            Obj_Read_Dt.DOC_APELLIDO = DD_GEN.DB_NULL(Reader_Comm, 31, "")



            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
    Function IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_ATE_ACT_WEB(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_ATE_ACT_WEB_2"
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
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            Obj_Read_Dt.ID_DET_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.CF_DESC = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.USU_NIC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.CF_COD = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Reader_Comm, 6, Nothing)
            Obj_Read_Dt.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 7, Nothing)
            Obj_Read_Dt.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Reader_Comm, 8, Nothing)
            Obj_Read_Dt.ID_PER = DD_GEN.DB_NULL(Reader_Comm, 9, Nothing)
            Obj_Read_Dt.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Reader_Comm, 10, Nothing)
            Obj_Read_Dt.ATE_FECHA = DD_GEN.DB_NULL(Reader_Comm, 11, Nothing)
            Obj_Read_Dt.TP_PAGO_DESC = DD_GEN.DB_NULL(Reader_Comm, 12, Nothing)
            Obj_Read_Dt.ID_TP_PAGO = DD_GEN.DB_NULL(Reader_Comm, 13, Nothing)
            Obj_Read_Dt.ATE_DET_NUM_COPIA = DD_GEN.DB_NULL(Reader_Comm, 14, Nothing)
            Obj_Read_Dt.CF_DIAS = DD_GEN.DB_NULL(Reader_Comm, 15, Nothing)
            Obj_Read_Dt.CF_IMP_SOLA = DD_GEN.DB_NULL(Reader_Comm, 16, Nothing)
            Obj_Read_Dt.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Reader_Comm, 17, Nothing)
            Obj_Read_Dt.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Reader_Comm, 18, Nothing)
            Obj_Read_Dt.CF_IMP_POSX = DD_GEN.DB_NULL(Reader_Comm, 19, Nothing)
            Obj_Read_Dt.CF_IMP_POSY = DD_GEN.DB_NULL(Reader_Comm, 20, Nothing)
            Obj_Read_Dt.CF_IMP_LETRA = DD_GEN.DB_NULL(Reader_Comm, 21, Nothing)
            Obj_Read_Dt.CF_IMP_TAMANO = DD_GEN.DB_NULL(Reader_Comm, 22, Nothing)
            Obj_Read_Dt.SECC_DESC = DD_GEN.DB_NULL(Reader_Comm, 23, Nothing)
            Obj_Read_Dt.ESTADO_WEB_DERIVADO = DD_GEN.DB_NULL(Reader_Comm, 24, Nothing)
            Obj_Read_Dt.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 25, Nothing)
            Obj_Read_Dt.ATE_ACT_WEB = DD_GEN.DB_NULL(Reader_Comm, 26, Nothing)
            Obj_Read_Dt.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 27, Nothing)


            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function
End Class
