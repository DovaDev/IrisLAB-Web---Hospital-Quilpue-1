'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_PREINGRESO2
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_PREINGRESO2(ByVal ATE_NUM As String,
                                         ByVal ID_PACIENTE As Integer,
                                         ByVal ID_USUARIO As Integer,
                                         ByVal ATE_FUR As Date,
                                         ByVal ID_PROCE As Integer,
                                         ByVal ID_ORDEN As Integer,
                                         ByVal ID_TP_PACI As Integer,
                                         ByVal ID_DOCTOR As Integer,
                                         ByVal ID_PREVE As Integer,
                                         ByVal ID_LOCAL As Integer,
                                         ByVal ID_ESTADO As Integer,
                                         ByVal ATE_OBS As String,
                                         ByVal ATE_CAMA As String,
                                         ByVal ATE_AÑO As Integer,
                                         ByVal ATE_MES As Integer,
                                         ByVal ATE_DIA As Integer,
                                         ByVal ATE_TOTAL As Integer,
                                         ByVal ATE_TOTAL_PREVI As Integer,
                                         ByVal ATE_TOTAL_COPA As Integer,
                                         ByVal PREI_FECHA_PRE As Date) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista      
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_PREINGRESO2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ATE_FUR", OleDbType.Date).Value = ATE_FUR
            .Add("@ID_PROCE", OleDbType.Numeric).Value = ID_PROCE
            .Add("@ID_ORDEN", OleDbType.Numeric).Value = ID_ORDEN
            .Add("@ID_TP_PACI", OleDbType.Numeric).Value = ID_TP_PACI
            .Add("@ID_DOCTOR", OleDbType.Numeric).Value = ID_DOCTOR
            .Add("@ID_PREVE", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_LOCAL", OleDbType.Numeric).Value = ID_LOCAL
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ATE_OBS", OleDbType.VarChar).Value = ATE_OBS
            .Add("@ATE_CAMA", OleDbType.VarChar).Value = ATE_CAMA
            .Add("@ATE_AÑO", OleDbType.Numeric).Value = ATE_AÑO
            .Add("@ATE_MES", OleDbType.Numeric).Value = ATE_MES
            .Add("@ATE_DIA", OleDbType.Numeric).Value = ATE_DIA
            .Add("@ATE_TOTAL", OleDbType.Numeric).Value = ATE_TOTAL
            .Add("@ATE_TOTAL_PREVI", OleDbType.Numeric).Value = ATE_TOTAL_PREVI
            .Add("@ATE_TOTAL_COPA", OleDbType.Numeric).Value = ATE_TOTAL_COPA
            .Add("@PREI_FECHA_PRE", OleDbType.Date).Value = PREI_FECHA_PRE
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
