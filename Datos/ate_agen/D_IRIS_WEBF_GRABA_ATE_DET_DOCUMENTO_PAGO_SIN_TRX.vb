'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(ByVal ID_ATE_DOCP As Integer, ByVal ID_FP As Integer, ByVal V_TOTAL As Integer, ByVal ID_USU As Integer, ByVal V_SISTEMA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_DOCP", OleDbType.Numeric).Value = ID_ATE_DOCP
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@V_TOTAL", OleDbType.Numeric).Value = V_TOTAL
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
            .Add("@V_SISTEMA", OleDbType.Numeric).Value = V_SISTEMA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(ByVal ID_ATE_DOCP As Integer, ByVal ID_FP As Integer, ByVal V_TOTAL As Integer, ByVal ID_TRX As Integer, ByVal ID_USU As Integer, ByVal V_SISTEMA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_DOCP", OleDbType.Numeric).Value = ID_ATE_DOCP
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_FP
            .Add("@V_TOTAL", OleDbType.Numeric).Value = V_TOTAL
            .Add("@@ID_TRX", OleDbType.Numeric).Value = ID_TRX
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
            .Add("@V_SISTEMA", OleDbType.Numeric).Value = V_SISTEMA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function

End Class
