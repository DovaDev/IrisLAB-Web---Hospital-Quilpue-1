﻿'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ByVal ANO As String, ByVal ID_P As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANO", OleDbType.VarChar).Value = ANO
            .Add("@ID_P", OleDbType.Numeric).Value = ID_P
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS

            E_Proc_Item.ID_ANO = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.AGRU_PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ANO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class