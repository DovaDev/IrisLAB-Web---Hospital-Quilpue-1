'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA
    'Declaraciones Generales
    Dim objconexion As New Conexion.ConexionBD
    Dim Cmd_command As New OleDb.OleDbCommand
    Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
    Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
    Dim DD_GEN As New D_General_Functions
    Dim Reader_Comm As OleDbDataReader
    Function IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA(ByVal ID_ATE As Integer) As List(Of E_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA)

        'Declaraciones Generales
        Dim CC_ConnBD As C_ConnBD
        Dim DD_GEN As New D_General_Functions

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA

            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_TP_PAGO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
