'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO(ByVal FOLIO_NUM As Integer, ByVal NUM_CURVA As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO)


        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO_NUM", OleDbType.Numeric).Value = FOLIO_NUM
            .Add("@NUM_CURVA", OleDbType.VarChar).Value = NUM_CURVA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO

            E_Proc_Item.ID_ENVIO_ETI = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
