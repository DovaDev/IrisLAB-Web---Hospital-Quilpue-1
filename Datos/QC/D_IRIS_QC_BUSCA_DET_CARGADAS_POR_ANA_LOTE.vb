Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE(ByVal ID_ANA As Long, ByVal ID_LOTE As Long) As List(Of E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@ID_LOTE", OleDbType.BigInt).Value = ID_LOTE
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE

            E_Proc_Item.ID_QC_ANALIZADOR = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_QC_DETERMINACION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_QC_LOTE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_QC_NIVEL = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.REL_ADL_LI_F = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.REL_ADL_LS_F = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.REL_ADL_MEDIA_F = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.REL_ADLL_DESV_F = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.REL_ADL_LI_P = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.REL_ADL_LS_P = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.REL_ADL_MEDIA_P = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.REL_ADLL_DESV_P = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_REL_ADL = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.QC_DET_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.REL_ADL_CANT_F = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.REL_ADL_CV_F = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
