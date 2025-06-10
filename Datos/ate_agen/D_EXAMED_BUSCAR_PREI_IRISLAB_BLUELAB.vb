Imports Entidades
Imports System.Collections.Generic
Imports System.Data.OleDb
Public Class D_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
    'Declaraciones Generales
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions


    Function EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB(ByVal PREI_NUM As String) As List(Of E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
        Dim E_Proc_List As New List(Of E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB"
            .Connection = CC_ConnBD.Connect_to_Examed
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@PREI_NUM", OleDbType.VarChar).Value = PREI_NUM
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
            E_Proc_Item = New E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB

            E_Proc_Item.RUT_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.NOM_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.APE_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.FNAC_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.SEXO_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.FONO_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.DIR_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.EMAIL_PAC_EXA = DD_GEN.DB_NULL(Obj_Reader, 7, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
