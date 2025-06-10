Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_SECCIONES
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_SECCIONES() As List(Of E_IRIS_QC_BUSCA_SECCIONES)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_SECCIONES
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_SECCIONES)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_SECCIONES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_SECCIONES
            E_Proc_Item.ID_QC_SECCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_SECCION_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.QC_SECCION_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
