'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Ana_PAC
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI(ByVal ID_PAC As Long, ByVal Año As Long, ByVal Mes As Long) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@ANO", OleDbType.Numeric).Value = Año
            .Add("@MES", OleDbType.Numeric).Value = Mes
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_TP_PACI
            E_Proc_Item.CANT_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CANT_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PREVI = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAGADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.COPAGO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_TP_PACI = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
