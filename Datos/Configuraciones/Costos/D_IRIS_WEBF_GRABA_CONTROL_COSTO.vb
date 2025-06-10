'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_GRABA_CONTROL_COSTO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_CONTROL_COSTO(ByVal ID_CF As Integer, ByVal NUM As Integer, ByVal ID_USUARIO As Integer, ByVal PRECIO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_CONTROL_COSTO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@NUM", OleDbType.Numeric).Value = NUM
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@PRECIO", OleDbType.Numeric).Value = PRECIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = 0

            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, 0)

        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class