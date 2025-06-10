'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb


Public Class D_IRIS_WEBF_GRABA_RANGO_REFERENCIA
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_GRABA_RANGO_REFERENCIA(ByVal ID_PRUEBA As Integer,
                                                       ByVal ID_SEXO As Integer,
                                                       ByVal ANO_DESDE As Integer,
                                                       ByVal MES_DESDE As Integer,
                                                       ByVal DIAS_DESDE As Integer,
                                                       ByVal ANO_HASTA As Integer,
                                                       ByVal MES_HASTA As Integer,
                                                       ByVal DIAS_HASTA As Integer,
                                                       ByVal MBAJO As Double,
                                                       ByVal BAJO As Double,
                                                       ByVal ALTO As Double,
                                                       ByVal MALTO As Double,
                                                       ByVal TEXTO As String,
                                                       ByVal EMBARA As Integer,
                                                       ByVal ID_USUARIO As Integer) As String

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_RANGO_REFERENCIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_SEXO", OleDbType.Numeric).Value = ID_SEXO
            .Add("@ANO_DESDE", OleDbType.Numeric).Value = ANO_DESDE
            .Add("@MES_DESDE ", OleDbType.Numeric).Value = MES_DESDE
            .Add("@DIA_DESDE", OleDbType.Numeric).Value = DIAS_DESDE
            .Add("@ANO_HASTA", OleDbType.Numeric).Value = ANO_HASTA
            .Add("@MES_HASTA", OleDbType.Numeric).Value = MES_HASTA
            .Add("@DIA_HASTA ", OleDbType.Numeric).Value = DIAS_HASTA
            .Add("@MBAJO", OleDbType.Double).Value = MBAJO
            .Add("@BAJO", OleDbType.Double).Value = BAJO
            .Add("@ALTO", OleDbType.Double).Value = ALTO
            .Add("@MALTO", OleDbType.Double).Value = MALTO
            .Add("@TEXTO", OleDbType.VarChar).Value = TEXTO
            .Add("@EMBARA", OleDbType.Numeric).Value = EMBARA
            .Add("@ID_USUARIO", OleDbType.VarChar).Value = ID_USUARIO
        End With

        'Coneca con la base de datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Ececutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class