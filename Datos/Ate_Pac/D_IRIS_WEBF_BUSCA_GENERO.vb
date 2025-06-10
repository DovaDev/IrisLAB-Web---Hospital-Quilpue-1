Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class D_IRIS_WEBF_BUSCA_GENERO
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_GENERO() As List(Of E_IRIS_WEBF_BUSCA_GENERO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_GENERO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_GENERO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_GENERO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_GENERO
            E_Proc_Item.ID_GENERO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.GENERO_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


End Class
