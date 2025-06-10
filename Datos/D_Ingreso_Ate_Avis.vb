'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Ingreso_Ate_Avis
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_AGREGAR_MEDICOS_CON_AVIS(ByVal HO_CC As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand



        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_AGREGAR_MEDICOS_CON_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@HO_CC", OleDbType.VarChar).Value = HO_CC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

End Class
