'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Shared Function IRIS_WEB_GRABA_RECHAZO_ETIQUETA_UPDATE_ATE_RES(ID_ATE As Integer, NUM_ATE As Integer, CB As String, ID_USUARIO As Integer, ID_RECHA As Integer, OBSERVAC As String, VALOR As String, idCodigoFonasaMarcado As Integer, MENSAJE_GENERADO As String) As String

        Dim CC_ConnBD As C_ConnBD
        Dim DD_GEN As New D_General_Functions
        CC_ConnBD = New C_ConnBD
        Dim Cmd_SQL As New OleDb.OleDbCommand

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEB_GRABA_RECHAZO_ETIQUETA_UPDATE_ATE_RES_CHECK_EXISTS_ADD_AUDIT"
            .CommandText = "IRIS_WEB_GRABA_RECHAZO_ETIQUETA_UPDATE_ATE_RES_CHECK_EXISTS_ADD_AUDIT_v2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@NUM_ATE", OleDbType.Numeric).Value = NUM_ATE
            .Add("@CB", OleDbType.VarChar).Value = CB
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA
            .Add("@OBSERVAC", OleDbType.VarChar).Value = OBSERVAC
            .Add("@VALOR", OleDbType.VarChar).Value = VALOR
            .Add("@idCodigoFonasaMarcado", OleDbType.Integer).Value = idCodigoFonasaMarcado
            .Add("@MENSAJE_GENERADO", OleDbType.VarChar).Value = MENSAJE_GENERADO
        End With
        Dim respuesta As String = ""
        Dim Obj_Reader
        CC_ConnBD.Oledbconexion.Open()
        Try
            Obj_Reader = Cmd_SQL.ExecuteReader()
            While Obj_Reader.Read
                respuesta = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            End While
            CC_ConnBD.Oledbconexion.Close()
            Return respuesta
        Catch ex As Exception
            CC_ConnBD.Oledbconexion.Close()
            Return "error"
        End Try
    End Function
    Function IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO(ByVal ID_ATE As Integer, ByVal NUM_ATE As Integer, ByVal CB As String, ByVal ID_USUARIO As Integer, ByVal ID_RECHA As Integer, ByVal OBSERVAC As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@NUM_ATE", OleDbType.Numeric).Value = NUM_ATE
            .Add("@CB", OleDbType.VarChar).Value = CB
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA
            .Add("@OBSERVAC", OleDbType.VarChar).Value = OBSERVAC
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class
