﻿'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA(ByVal RUT As String) As List(Of E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA)

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PREI_NUM = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PREI_FECHA_PRE = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PREI_FECHA_A = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
