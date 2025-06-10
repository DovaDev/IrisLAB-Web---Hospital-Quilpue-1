'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO(ByVal ID_USUARIO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devue.ltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO

            E_Proc_Item.ID_NOTIF = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.TIPO_MSG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.MSG = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_D = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FECHA_H = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.NOTIF_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PERMANENTE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.CONFIRMA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_REL_N_U = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
