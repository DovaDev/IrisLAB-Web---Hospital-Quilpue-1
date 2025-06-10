'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_BUSCA_CONTROL_COSTO_RELACIONADOS(ByVal ID_CONTROL As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CONTROL", OleDbType.Numeric).Value = ID_CONTROL
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS

            E_Proc_Item.ID_COSTO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.DET_CONT_COSTO_PRECIO = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class