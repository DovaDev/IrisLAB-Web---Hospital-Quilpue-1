Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS(ByVal ID_ANA As Long) As List(Of E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
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
            E_Proc_Item = New E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS
            E_Proc_Item.ID_QC_DETERMINACION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_DET_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
