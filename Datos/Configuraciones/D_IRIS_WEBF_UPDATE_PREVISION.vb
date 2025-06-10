'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_UPDATE_PREVISION
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_UPDATE_PREVISION(ByVal ID_PREVE As Integer,
                                        ByVal PREVE_COD As String,
                                        ByVal PREVE_DES As String,
                                        ByVal PREVE_ARH As String,
                                        ByVal PREVE_FACTORH As String,
                                        ByVal PREVE_ARHA As String,
                                        ByVal PREVE_FACTORHA As String,
                                        ByVal PREVE_HOST As String,
                                        ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PREVISION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@PREVE_COD", OleDbType.VarChar).Value = PREVE_COD
            .Add("@PREVE_DES", OleDbType.VarChar).Value = PREVE_DES
            .Add("@PREVE_ARH", OleDbType.VarChar).Value = PREVE_ARH
            .Add("@PREVE_FACTORH", OleDbType.VarChar).Value = PREVE_FACTORH
            .Add("@PREVE_ARHA", OleDbType.VarChar).Value = PREVE_ARHA
            .Add("@PREVE_FACTORHA", OleDbType.VarChar).Value = PREVE_FACTORHA
            .Add("@PREVE_HOST", OleDbType.VarChar).Value = PREVE_HOST
            .Add("@ID_ESTADO", OleDbType.VarChar).Value = ID_ESTADO
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
