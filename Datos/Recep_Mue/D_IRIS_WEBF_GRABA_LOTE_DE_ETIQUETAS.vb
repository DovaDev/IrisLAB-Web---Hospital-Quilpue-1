'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS
    Function IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS(ByVal NUM_LOTE As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS)

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_LOTE", OleDbType.Numeric).Value = NUM_LOTE
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
            E_Proc_Item = New E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS

            E_Proc_Item.IDENTIFICADOR = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
