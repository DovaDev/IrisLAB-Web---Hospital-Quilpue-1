'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Med_Details
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_MEDICO(ByVal ID_PRE As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_MEDICO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE", OleDbType.numeric).Value = ID_PRE
            .Add("@DESDE", OleDbType.date).Value = DESDE
            .Add("@HASTA", OleDbType.date).Value = HASTA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ATE_FECHA = DD_Gen.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 10, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_DOCTOR = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.PAC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.PAC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 17, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
