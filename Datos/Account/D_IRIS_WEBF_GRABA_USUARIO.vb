'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_USUARIO
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_USUARIO(ByVal USU_RUT As String,
                                    ByVal NOMBRE_USU As String,
                                     ByVal APE_USU As String,
                                     ByVal FNAC_USU As Date,
                                     ByVal DIR_USU As String,
                                     ByVal EMAIL_USU As String,
                                     ByVal ID_EST_USU As Integer,
                                     ByVal ID_CIU_COM As Integer,
                                     ByVal ID_PRO_USU As Integer,
                                     ByVal ID_CAR_USU As Integer,
                                     ByVal USUARIO As String,
                                     ByVal PASS As String,
                                     ByVal FONO As String,
                                     ByVal MOVIL As String,
                                     ByVal USU_ADMIN As Integer,
                                     ByVal USU_TM As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_USUARIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@USU_RUT", OleDbType.VarChar).Value = USU_RUT
            .Add("@NOMBRE_USU", OleDbType.VarChar).Value = NOMBRE_USU
            .Add("@APE_USU", OleDbType.VarChar).Value = APE_USU
            .Add("@FNAC_USU", OleDbType.Date).Value = FNAC_USU
            .Add("@DIR_USU", OleDbType.VarChar).Value = DIR_USU
            .Add("@EMAIL_USU", OleDbType.VarChar).Value = EMAIL_USU
            .Add("@ID_EST_USU", OleDbType.Numeric).Value = ID_EST_USU
            .Add("@ID_REL_CIU", OleDbType.Numeric).Value = ID_CIU_COM
            .Add("@ID_PRO_USU", OleDbType.Numeric).Value = ID_PRO_USU
            .Add("@ID_CAR_USU", OleDbType.Numeric).Value = ID_CAR_USU
            .Add("@USUARIO", OleDbType.VarChar).Value = USUARIO
            .Add("@PASS", OleDbType.VarChar).Value = PASS
            .Add("@FONO", OleDbType.VarChar).Value = FONO
            .Add("@MOVIL", OleDbType.VarChar).Value = MOVIL
            .Add("@USU_ADMIN", OleDbType.Numeric).Value = USU_ADMIN
            .Add("@USU_TM", OleDbType.Numeric).Value = USU_TM
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
