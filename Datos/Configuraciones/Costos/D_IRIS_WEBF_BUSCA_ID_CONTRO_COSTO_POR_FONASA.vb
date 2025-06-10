'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA(ByVal ID_FONASA As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_FONASA", OleDbType.Numeric).Value = ID_FONASA
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA

            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CONTROL_COSTO_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_CONTROL_COSTO = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.EXIST = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.COUNT_DET = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While


        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class