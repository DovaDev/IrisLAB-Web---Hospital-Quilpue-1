Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_MONITOR_CONTROLES_3(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ANA As Long) As List(Of E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_MONITOR_CONTROLES_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@ID_ANA", OleDbType.BigInt).Value = ID_ANA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3

            E_Proc_Item.ID_QC_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_QC_ANALIZADOR = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.QC_ANA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_QC_LOTE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.QC_LOTE_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_QC_DETERMINACION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.QC_DET_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.QC_RESUL_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_1 = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.QC_RESUL_COMENTARIOS = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.QC_RESUL_HORA = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.QC_RESUL_OMITIDO = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.TP_QC_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.REL_ADL_LI_F = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.REL_ADL_LS_F = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.REL_ADL_MEDIA_F = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.REL_ADLL_DESV_F = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.REL_ADL_LI_P = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.REL_ADL_LS_P = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.REL_ADL_MEDIA_P = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.REL_ADLL_DESV_P = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.REL_ADL_CANT_F = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.REL_ADL_CANT_P = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.REL_ADL_CV_F = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.REL_ADL_CV_P = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ID_TP_QC_ACCION = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
