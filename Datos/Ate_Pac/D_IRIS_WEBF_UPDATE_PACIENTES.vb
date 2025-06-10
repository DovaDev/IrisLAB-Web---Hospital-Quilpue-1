'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_UPDATE_PACIENTES
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_UPDATE_PACIENTES(ByVal ID_PAC As Integer, ByVal RUT_PAC As String, ByVal NOMBRE_PAC As String, ByVal APE_PAC As String, ByVal ID_SEXO As Integer, ByVal FNAC_PAC As Date, ByVal ID_NACIONALIDAD As Integer, ByVal DIR_PAC As String, ByVal ID_CIU_COM As Integer, ByVal FONO1 As String, ByVal FONO2 As String, ByVal MOVIL1 As String, ByVal MOVIL2 As String, ByVal EMAIL_PAC As String, ByVal ID_DIAGNOSTICO As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PACIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@RUT_PAC", OleDbType.VarChar).Value = RUT_PAC
            .Add("@NOMBRE_PAC", OleDbType.VarChar).Value = NOMBRE_PAC
            .Add("@APE_PAC", OleDbType.VarChar).Value = APE_PAC
            .Add("@ID_SEXO", OleDbType.Numeric).Value = ID_SEXO
            .Add("@FNAC_PAC", OleDbType.Date).Value = FNAC_PAC
            .Add("@ID_NACIONALIDAD", OleDbType.Numeric).Value = ID_NACIONALIDAD
            .Add("@DIR_PAC", OleDbType.VarChar).Value = DIR_PAC
            .Add("@ID_CIU_COM", OleDbType.Numeric).Value = ID_CIU_COM
            .Add("@FONO1", OleDbType.VarChar).Value = FONO1
            .Add("@FONO2", OleDbType.VarChar).Value = FONO2
            .Add("@MOVIL1", OleDbType.VarChar).Value = MOVIL1
            .Add("@MOVIL2", OleDbType.VarChar).Value = MOVIL2
            .Add("@EMAIL_PAC", OleDbType.VarChar).Value = EMAIL_PAC
            .Add("@ID_DIAGNOSTICO", OleDbType.Numeric).Value = ID_DIAGNOSTICO
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
    Function IRIS_WEBF_UPDATE_PACIENTES_DNI(ByVal ID_PAC As Integer, ByVal RUT_PAC As String, ByVal DNI_PAC As String, ByVal NOMBRE_PAC As String, ByVal APE_PAC As String, ByVal ID_SEXO As Integer, ByVal FNAC_PAC As Date, ByVal ID_NACIONALIDAD As Integer, ByVal DIR_PAC As String, ByVal ID_CIU_COM As Integer, ByVal FONO1 As String, ByVal FONO2 As String, ByVal MOVIL1 As String, ByVal MOVIL2 As String, ByVal EMAIL_PAC As String, ByVal ID_DIAGNOSTICO As Integer, ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PACIENTES_DNI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@RUT_PAC", OleDbType.VarChar).Value = RUT_PAC
            .Add("@DNI_PAC", OleDbType.VarChar).Value = DNI_PAC
            .Add("@NOMBRE_PAC", OleDbType.VarChar).Value = NOMBRE_PAC
            .Add("@APE_PAC", OleDbType.VarChar).Value = APE_PAC
            .Add("@ID_SEXO", OleDbType.Numeric).Value = ID_SEXO
            .Add("@FNAC_PAC", OleDbType.Date).Value = FNAC_PAC
            .Add("@ID_NACIONALIDAD", OleDbType.Numeric).Value = ID_NACIONALIDAD
            .Add("@DIR_PAC", OleDbType.VarChar).Value = DIR_PAC
            .Add("@ID_CIU_COM", OleDbType.Numeric).Value = ID_CIU_COM
            .Add("@FONO1", OleDbType.VarChar).Value = FONO1
            .Add("@FONO2", OleDbType.VarChar).Value = FONO2
            .Add("@MOVIL1", OleDbType.VarChar).Value = MOVIL1
            .Add("@MOVIL2", OleDbType.VarChar).Value = MOVIL2
            .Add("@EMAIL_PAC", OleDbType.VarChar).Value = EMAIL_PAC
            .Add("@ID_DIAGNOSTICO", OleDbType.Numeric).Value = ID_DIAGNOSTICO
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
