'Importar Capa
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_UPDATE_MEDICOS
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_UPDATE_MEDICOS(ByVal ID_DOC As Integer,
                                     ByVal RUT_DOC As String,
                                     ByVal NOMBRE_DOC As String,
                                     ByVal APE_DOC As String,
                                     ByVal ID_SEXO As Integer,
                                     ByVal FNAC_DOC As Date,
                                     ByVal ID_NACIONALIDAD As Integer,
                                     ByVal DIR_DOC As String,
                                     ByVal ID_CIU_COM As Integer,
                                     ByVal FONO1 As String,
                                     ByVal FONO2 As String,
                                     ByVal MOVIL1 As String,
                                     ByVal MOVIL2 As String,
                                     ByVal EMAIL_DESC As String,
                                     ByVal ID_ESPECIALIDAD As Integer,
                                     ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MEDICO)

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_MEDICOS"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea
        With Cmd_command.Parameters
            .Add("@ID_DOC", OleDbType.Integer).Value = ID_DOC
            .Add("@RUT_DOC", OleDbType.VarChar).Value = RUT_DOC
            .Add("@NOMBRE_DOC", OleDbType.VarChar).Value = NOMBRE_DOC
            .Add("@APE_DOC", OleDbType.VarChar).Value = APE_DOC
            .Add("@ID_SEXO", OleDbType.Integer).Value = ID_SEXO
            .Add("@FNAC_DOC", OleDbType.Date).Value = FNAC_DOC
            .Add("@ID_NACIONALIDAD", OleDbType.Integer).Value = ID_NACIONALIDAD
            .Add("@DIR_DOC", OleDbType.VarChar).Value = DIR_DOC
            .Add("@ID_CIU_COM", OleDbType.Integer).Value = ID_CIU_COM
            .Add("@FONO1", OleDbType.VarChar).Value = FONO1
            .Add("@FONO2", OleDbType.VarChar).Value = FONO2
            .Add("@MOVIL1", OleDbType.VarChar).Value = MOVIL1
            .Add("@MOVIL2", OleDbType.VarChar).Value = MOVIL2
            .Add("@EMAIL_DESC", OleDbType.VarChar).Value = EMAIL_DESC
            .Add("@ID_ESPECIALIDAD", OleDbType.Integer).Value = ID_ESPECIALIDAD
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class