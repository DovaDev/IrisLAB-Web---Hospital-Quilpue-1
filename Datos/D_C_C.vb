'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_C_C
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_PASS(ByVal ID As Integer) As List(Of E_IRIS_WEBF_BUSCA_PASS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PASS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PASS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PASS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID", OleDbType.Numeric).Value = ID
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PASS

            E_Proc_Item.USU_PASS = DD_GEN.DB_NULL(Obj_Reader, 0, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



    Function IRIS_WEBF_G_PASS(ByVal NCONTRASEÑA As String, ByVal ID As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_G_PASS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID", OleDbType.Numeric).Value = ID
            .Add("@NCONTRASEÑA", OleDbType.VarChar).Value = NCONTRASEÑA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        Read_Sql = Cmd_SQL.ExecuteNonQuery
        Return Read_Sql
    End Function
End Class