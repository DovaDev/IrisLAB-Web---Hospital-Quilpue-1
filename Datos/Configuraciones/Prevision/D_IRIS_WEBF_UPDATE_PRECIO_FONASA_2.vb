'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_UPDATE_PRECIO_FONASA_2
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_UPDATE_PRECIO_FONASA_2(ByVal ID_PRECIO As Integer, ByVal AMB As Integer, ByVal HOSP As Integer, ByVal ID_USUARIO As Integer, ByVal FECHA As Date, ByVal ID_ESTADO As Integer, ByVal ID_P As Integer, ByVal ID_CF As Integer, ByVal ID_A As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PRECIO_FONASA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRECIO", OleDbType.Numeric).Value = ID_PRECIO
            .Add("@AMB", OleDbType.Numeric).Value = AMB
            .Add("@HOSP", OleDbType.Numeric).Value = HOSP
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_P", OleDbType.Numeric).Value = ID_P
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_A", OleDbType.Numeric).Value = ID_A
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
