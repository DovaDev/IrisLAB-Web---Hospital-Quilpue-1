Imports System.Web
Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Imports System.Configuration

Public Class D_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Public Function IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer) As List(Of E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION)
        'Declaraciones'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Integer).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION
            E_Proc_Item.CUP = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CVC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PICCLINE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.TET = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.TQT = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.AREpi = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agrega a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
