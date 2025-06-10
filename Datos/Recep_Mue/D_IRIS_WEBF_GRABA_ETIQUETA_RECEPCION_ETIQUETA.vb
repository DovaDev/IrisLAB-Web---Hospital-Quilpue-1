'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA(ByVal ID_ATE As Integer, ByVal NUM_ATE As Integer, ByVal CB As String, ByVal ID_USUARIO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@NUM_ATE", OleDbType.Numeric).Value = NUM_ATE
            .Add("@CB", OleDbType.VarChar).Value = CB
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql

    End Function
End Class
