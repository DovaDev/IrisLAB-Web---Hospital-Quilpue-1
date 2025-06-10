'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_RESULTADO_ATENCION
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_ANATO(ByVal ID_ATE As Integer, ByVal SITIO_ANATO As String, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal id_det_ate As Integer) As Integer
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
            .CommandText = "IRIS_WEBF_GRABA_RESULTADO_ATENCION_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@id_det_ate", OleDbType.Numeric).Value = id_det_ate
            .Add("@SITIO_ANATO", OleDbType.VarChar).Value = SITIO_ANATO
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

    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION(ByVal ID_ATE As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal id_det_ate As Integer) As Integer
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
            .CommandText = "IRIS_WEBF_GRABA_RESULTADO_ATENCION_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@id_det_ate", OleDbType.Numeric).Value = id_det_ate
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
    Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ByVal ID_ATE As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_PRUEBA As Integer, ByVal DEFECTO As String, ByVal id_det_ate As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@DEFECTO", OleDbType.VarChar).Value = DEFECTO
            .Add("@id_det_ate", OleDbType.Numeric).Value = id_det_ate
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
