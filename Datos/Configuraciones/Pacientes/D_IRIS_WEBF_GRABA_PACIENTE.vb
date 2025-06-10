'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_GRABA_PACIENTE
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_PACIENTE(ByVal RUT_PAC As String,
                                      ByVal NOMBRE_PAC As String,
                                      ByVal APE_PAC As String,
                                      ByVal ID_SEXO As Integer,
                                      ByVal FNAC_PAC As Date,
                                      ByVal ID_NACIONALIDAD As Integer,
                                      ByVal DIR_PAC As String,
                                      ByVal ID_CIU_COM As Integer,
                                      ByVal FONO1 As String,
                                      ByVal FONO2 As String,
                                      ByVal MOVIL1 As String,
                                      ByVal MOVIL2 As String,
                                      ByVal EMAIL_PAC As String,
                                      ByVal ID_DIAGNOSTICO As Integer,
                                      ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_PACIENTE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
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
            .Add("@ID_DIAGNOSTICO", OleDbType.VarChar).Value = ID_DIAGNOSTICO
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
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
