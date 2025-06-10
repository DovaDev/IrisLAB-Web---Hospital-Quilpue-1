'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Convenio
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ByVal ID_PREV As Long, ByVal DATE_01 As Date, ByVal DATE_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREV", OleDbType.BigInt).Value = ID_PREV
            .Add("@DATE_01", OleDbType.Date).Value = DATE_01
            .Add("@DATE_02", OleDbType.Date).Value = DATE_02
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
            E_Proc_Item.ID_CF = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CANTIDAD = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.CF_PRECIO_AMB = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.COSTO_AMB = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.COSTO_DERIV = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.COSTO_TOTAL = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.PJE_CONV = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.PJE_LAB = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
