'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.VarChar).Value = ID_ATE_RES
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES

            E_Proc_Item.ID_DET_CRITICO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.DET_CRITICO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, New Date)
            E_Proc_Item.DET_CRITICO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ID_TP_CRITICO = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.TP_CRITICO_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.DET_CRITICO_FECHA_MANUAL = DD_GEN.DB_NULL(Obj_Reader, 10, New Date)
            E_Proc_Item.DET_CRITICO_CAUSA = DD_GEN.DB_NULL(Obj_Reader, 11, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class