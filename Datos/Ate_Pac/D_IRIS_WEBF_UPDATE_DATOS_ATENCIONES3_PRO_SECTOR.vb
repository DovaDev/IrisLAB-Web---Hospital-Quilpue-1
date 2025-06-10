'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR(ByVal ID_ATE As Integer,
                                                           ByVal ID_PROCE As Integer,
                                                           ByVal ID_TP_PACI As Integer,
                                                           ByVal ID_ORDEN As Integer,
                                                           ByVal ID_DOCTOR As Integer,
                                                           ByVal ID_PREVE As Integer,
                                                           ByVal ID_LOCAL As Integer,
                                                           ByVal ATE_CAMA As String,
                                                           ByVal ATE_OBS_FICHA As String,
                                                           ByVal ID_PROGRA As Integer,
                                                           ByVal EDAD As Integer,
                                                           ByVal MES As Integer,
                                                           ByVal DIA As Integer,
                                                           ByVal SECTOR As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_OBS_FICHA", OleDbType.VarChar).Value = ATE_OBS_FICHA
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@EDAD", OleDbType.Numeric).Value = EDAD
            .Add("@MES", OleDbType.Numeric).Value = MES
            .Add("@DIA", OleDbType.Numeric).Value = DIA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
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
