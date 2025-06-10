'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(ByVal ID_ATE As Integer, ByVal ID_PRU As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RESULTADO_DIALISIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PRU", OleDbType.Numeric).Value = ID_PRU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 4, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
