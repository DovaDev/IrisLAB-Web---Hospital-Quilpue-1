'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_REP_LAB_CANT_EXA_AREA
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA(ByVal ID_CODIGO_FONASA As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA
            E_Proc_Item.TOTAL_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.TOTAL_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.TOT_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.TOTA_SIS = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.TOTA_USU = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.TOTA_COPA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.AREA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_AREA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        Return E_Proc_List
    End Function
End Class
