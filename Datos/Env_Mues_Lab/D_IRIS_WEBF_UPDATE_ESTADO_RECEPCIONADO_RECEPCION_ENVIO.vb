'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class D_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions


    Shared Function IRIS_WEB_GRABA_ENVIO_ETIQUETA_Y_UPDATE_ATE_RESULTADO(ID_ATE As Integer, NUM_ATE As Integer, CB As String, ID_USU As Integer) As Integer
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        Dim Cmd_SQL As New OleDb.OleDbCommand

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_GRABA_ENVIO_ETIQUETA_Y_UPDATE_ATE_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@NUM_ATE", OleDbType.Numeric).Value = NUM_ATE
            .Add("@CB", OleDbType.VarChar).Value = CB
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU

        End With

        CC_ConnBD.Oledbconexion.Open()
        Dim res = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return res
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.VarChar).Value = ID_USUARIO
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

    Shared Function IRIS_WEB_GRABA_ENVIO_ETIQUETA_Y_UPDATE_ATE_RESULTADO_LASER(NUM_ATE As Integer, CB As String, ID_USU As Integer) As Integer
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@NUM_ATE", NUM_ATE),
            New SqlParameter("@CB", CB),
            New SqlParameter("@ID_USUARIO", ID_USU)}

        Return D_General_Functions.ExecuteReaderSP(Of Integer)("IRIS_WEB_GRABA_ENVIO_ETIQUETA_Y_UPDATE_ATE_RESULTADO_LASER", params)(0)
    End Function
End Class
