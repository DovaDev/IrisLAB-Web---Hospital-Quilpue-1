'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_GRABA_USUARIOS_CONVENIO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_USUARIOS_CONVENIO(ByVal ID_USU As Integer,
                                               ByVal USU_CONV_NIC As String,
                                               ByVal USU_CONV_PASS As String,
                                               ByVal USU_CONV_NOMBRE As String,
                                               ByVal USU_CONV_APELLIDO As String,
                                               ByVal USU_RUT As String,
                                               ByVal USU_DIR As String,
                                               ByVal USU_FONO As String,
                                               ByVal USU_MOVIL As String,
                                               ByVal USU_EMAIL As String,
                                               ByVal ID_ESTADO As Integer,
                                               ByVal ID_LAB As Integer,
                                               ByVal ID_PREVE As Integer,
                                               ByVal ID_PREVE2 As Integer,
                                               ByVal ID_PROCEDENCIA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_USUARIOS_CONVENIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
            .Add("@USU_CONV_NIC", OleDbType.VarChar).Value = USU_CONV_NIC
            .Add("@USU_CONV_PASS", OleDbType.VarChar).Value = USU_CONV_PASS
            .Add("@USU_CONV_NOMBRE", OleDbType.VarChar).Value = USU_CONV_NOMBRE
            .Add("@USU_CONV_APELLIDO", OleDbType.VarChar).Value = USU_CONV_APELLIDO
            .Add("@USU_RUT", OleDbType.VarChar).Value = USU_RUT
            .Add("@USU_DIR", OleDbType.VarChar).Value = USU_DIR
            .Add("@USU_FONO", OleDbType.VarChar).Value = USU_FONO
            .Add("@USU_MOVIL", OleDbType.VarChar).Value = USU_MOVIL
            .Add("@USU_EMAIL", OleDbType.VarChar).Value = USU_EMAIL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_LAB", OleDbType.Numeric).Value = ID_LAB
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_PREVE2", OleDbType.Numeric).Value = ID_PREVE2
            .Add("@ID_PROCEDENCIA", OleDbType.Numeric).Value = ID_PROCEDENCIA
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
