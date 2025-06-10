'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS_3(ByVal ID_ATE As Integer,
                                                         ByVal ID_USUARIO As Integer,
                                                         ByVal ID_CF As Integer,
                                                         ByVal ID_PER As Integer,
                                                         ByVal ID_TP_PAGO As Integer,
                                                         ByVal ATE_DET_DOC As String,
                                                         ByVal ATE_DET_V_PREVI As Integer,
                                                         ByVal ATE_DET_V_PAGADO As Integer,
                                                         ByVal ATE_DET_V_CCOPAGO As Integer,
                                                         ByVal ATE_NUM_INTERFAZ As String,
                                                        ByVal ATE_CF_MULTIPLICADOS As String,
                                                        ByVal ATE_CODIGO_TEST As String) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_HISTORICO_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_CF_MULTIPLICADOS", OleDbType.VarChar).Value = ATE_CF_MULTIPLICADOS
            If (IsNothing(ATE_CODIGO_TEST) = True) Then
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = ATE_CODIGO_TEST
            End If


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
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(ByVal ID_ATE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal ID_PER As Integer,
                                                            ByVal ID_TP_PAGO As Integer,
                                                            ByVal ATE_DET_DOC As String,
                                                            ByVal ATE_DET_V_PREVI As Integer,
                                                            ByVal ATE_DET_V_PAGADO As Integer,
                                                            ByVal ATE_DET_V_CCOPAGO As Integer,
                                                            ByVal ATE_NUM_INTERFAZ As String,
                                                            ByVal SITIO_ANATO As String
                                                            ) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
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

    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI(ByVal ID_ATE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal ID_PER As Integer,
                                                            ByVal ID_TP_PAGO As Integer,
                                                            ByVal ATE_DET_DOC As String,
                                                            ByVal ATE_DET_V_PREVI As Integer,
                                                            ByVal ATE_DET_V_PAGADO As Integer,
                                                            ByVal ATE_DET_V_CCOPAGO As Integer,
                                                            ByVal ATE_NUM_INTERFAZ As String,
                                                           ByVal ATE_CF_MULTIPLICADOS As String) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_CF_MULTIPLICADOS", OleDbType.VarChar).Value = ATE_CF_MULTIPLICADOS

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

    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_2(ByVal ID_ATE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal ID_PER As Integer,
                                                            ByVal ID_TP_PAGO As Integer,
                                                            ByVal ATE_DET_DOC As String,
                                                            ByVal ATE_DET_V_PREVI As Integer,
                                                            ByVal ATE_DET_V_PAGADO As Integer,
                                                            ByVal ATE_DET_V_CCOPAGO As Integer,
                                                            ByVal ATE_NUM_INTERFAZ As String,
                                                           ByVal ATE_CF_MULTIPLICADOS As String,
                                                           ByVal ATE_CODIGO_TEST As String) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_CF_MULTIPLICADOS", OleDbType.VarChar).Value = ATE_CF_MULTIPLICADOS
            If (IsNothing(ATE_CODIGO_TEST) = True) Then
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = ATE_CODIGO_TEST
            End If


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

    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX(ByVal ID_ATE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal ID_PER As Integer,
                                                            ByVal ID_TP_PAGO As Integer,
                                                            ByVal ATE_DET_DOC As String,
                                                            ByVal ATE_DET_V_PREVI As Integer,
                                                            ByVal ATE_DET_V_PAGADO As Integer,
                                                            ByVal ATE_DET_V_CCOPAGO As Integer,
                                                            ByVal ATE_NUM_INTERFAZ As String) As Integer

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
            .CommandText = "IRIS_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
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


    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_saydex_01(ByVal ID_ATE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal ID_PER As Integer,
                                                            ByVal ID_TP_PAGO As Integer,
                                                            ByVal ATE_DET_DOC As String,
                                                            ByVal ATE_DET_V_PREVI As Integer,
                                                            ByVal ATE_DET_V_PAGADO As Integer,
                                                            ByVal ATE_DET_V_CCOPAGO As Integer,
                                                            ByVal ATE_NUM_INTERFAZ As String,
                                                           ByVal ATE_CF_MULTIPLICADOS As String) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_CF_MULTIPLICADOS", OleDbType.VarChar).Value = ATE_CF_MULTIPLICADOS

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
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SIDRA(ByVal ID_ATE As Integer,
                                                      ByVal ID_USUARIO As Integer,
                                                      ByVal ID_CF As Integer,
                                                      ByVal ID_PER As Integer,
                                                      ByVal ID_TP_PAGO As Integer,
                                                      ByVal ATE_DET_DOC As String,
                                                      ByVal ATE_DET_V_PREVI As Integer,
                                                      ByVal ATE_DET_V_PAGADO As Integer,
                                                      ByVal ATE_DET_V_CCOPAGO As Integer,
                                                      ByVal ATE_NUM_INTERFAZ As String) As Integer

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
            .CommandText = "IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SIDRA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
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
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW(ByVal ID_ATE As Integer,
                                                     ByVal ID_USUARIO As Integer,
                                                     ByVal ID_CF As Integer,
                                                     ByVal ID_PER As Integer,
                                                     ByVal ID_TP_PAGO As Integer,
                                                     ByVal ATE_DET_DOC As String,
                                                     ByVal ATE_DET_V_PREVI As Integer,
                                                     ByVal ATE_DET_V_PAGADO As Integer,
                                                     ByVal ATE_DET_V_CCOPAGO As Integer,
                                                     ByVal ATE_NUM_INTERFAZ As String,
                                                       ByVal ATE_TP_PREVE As String,
                                                       ByVal ATE_TP_PAGO As String,
                                                       ByVal ATE_DET_VALOR_BENEF As Integer,               '1
                                                       ByVal ATE_DET_VALOR_CS As Integer,                  '2
                                                       ByVal ATE_DET_TP_1 As Integer,                      '3
                                                       ByVal ATE_DET_TP_OBS As String,                     '4
                                                       ByVal ATE_DET_NUM_BOL As Integer,                   '5
                                                       ByVal ATE_DET_NUM_BONO As String) As Integer       '6

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ATE_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.VarChar).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_TP_PREVE", OleDbType.Numeric).Value = ATE_TP_PREVE
            '---------------------------- caja ----------------------------------------
            .Add("@ATE_DET_VALOR_BENEF", OleDbType.Numeric).Value = ATE_DET_VALOR_BENEF         '1
            .Add("@ATE_DET_VALOR_CS", OleDbType.Numeric).Value = ATE_DET_VALOR_CS               '2
            .Add("@ATE_DET_TP_1", OleDbType.Numeric).Value = ATE_DET_TP_1                       '3
            .Add("@ATE_DET_TP_OBS", OleDbType.VarChar).Value = ATE_DET_TP_OBS                   '4
            .Add("@ATE_DET_NUM_BOL", OleDbType.Numeric).Value = ATE_DET_NUM_BOL                 '5
            .Add("@ATE_DET_NUM_BONO", OleDbType.VarChar).Value = ATE_DET_NUM_BONO               '6
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

    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_NEW_TP_PAGO(ByVal ID_ATENCION As Integer,
                                                                                 ByVal ID_CODIGO_FONASA As Integer,
                                                                                 ByVal ID_TP_PAGO As Integer,
                                                                                 ByVal ATE_DET_V_PREVI As Integer,
                                                                                 ByVal ATE_DET_V_PAGADO As Integer,
                                                                                 ByVal ATE_DET_V_COPAGO As Integer,
                                                                                 ByVal ATE_DET_VALOR_BENEF As Integer,
                                                                                 ByVal ATE_DET_VALOR_CS As Integer) As Integer

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As Integer
        'Declaraciones 'lista      
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_COPAGO", OleDbType.Numeric).Value = ATE_DET_V_COPAGO
            .Add("@ATE_DET_VALOR_BENEF", OleDbType.Numeric).Value = ATE_DET_VALOR_BENEF
            .Add("@ATE_DET_VALOR_CS", OleDbType.Numeric).Value = ATE_DET_VALOR_CS


        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'While Reader_Comm.Read
        '    Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        'End While
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function

    Function IRIS_WEBF_CMVM_GRABA_AUDITORIA_CAMBIO_TP_PAGO(ByVal TIPO As String,
                                                           ByVal LOG As String,
                                                           ByVal FECHA As Date,
                                                           ByVal ID_USUARIO As String,
                                                           ByVal ID_ATENCION As Integer,
                                                           ByVal ID_PACIENTE As String) As Integer

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As Integer
        'Declaraciones 'lista      
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_AUDITORIA_CAMBIO_TP_PAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.VarChar).Value = TIPO
            .Add("@LOG", OleDbType.VarChar).Value = LOG
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
            .Add("@ID_PACIENTE", OleDbType.Integer).Value = ID_PACIENTE
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'While Reader_Comm.Read
        '    Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        'End While
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_ATE_DET_PREVE(ByVal ID_ATE As Integer,
                                                  ByVal ID_USUARIO As Integer,
                                                  ByVal ID_CF As Integer,
                                                  ByVal ID_PER As Integer,
                                                  ByVal ID_TP_PAGO As Integer,
                                                  ByVal ATE_DET_DOC As String,
                                                  ByVal ATE_DET_V_PREVI As Integer,
                                                  ByVal ATE_DET_V_PAGADO As Integer,
                                                  ByVal ATE_DET_V_CCOPAGO As Integer,
                                                  ByVal ATE_NUM_INTERFAZ As String,
                                                    ByVal ATE_TP_PREVE As String,
                                                    ByVal ATE_TP_PAGO As String,
                                                    ByVal ATE_DET_VALOR_BENEF As Integer,               '1
                                                    ByVal ATE_DET_VALOR_CS As Integer,                  '2
                                                    ByVal ATE_DET_TP_1 As Integer,                      '3
                                                    ByVal ATE_DET_TP_OBS As String,                     '4
                                                    ByVal ATE_DET_NUM_BOL As Integer,                   '5
                                                    ByVal ATE_DET_NUM_BONO As String,                   '6
                                                    ByVal ATE_PREV_WEB As Integer) As Integer          '7

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_ATE_DET_PREVE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ATE_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.VarChar).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_TP_PREVE", OleDbType.Numeric).Value = ATE_TP_PREVE
            '---------------------------- caja ----------------------------------------
            .Add("@ATE_DET_VALOR_BENEF", OleDbType.Numeric).Value = ATE_DET_VALOR_BENEF         '1
            .Add("@ATE_DET_VALOR_CS", OleDbType.Numeric).Value = ATE_DET_VALOR_CS               '2
            .Add("@ATE_DET_TP_1", OleDbType.Numeric).Value = ATE_DET_TP_1                       '3
            .Add("@ATE_DET_TP_OBS", OleDbType.VarChar).Value = ATE_DET_TP_OBS                   '4
            .Add("@ATE_DET_NUM_BOL", OleDbType.Numeric).Value = ATE_DET_NUM_BOL                 '5
            .Add("@ATE_DET_NUM_BONO", OleDbType.VarChar).Value = ATE_DET_NUM_BONO               '6
            .Add("@ATE_PREV_WEB", OleDbType.Numeric).Value = ATE_PREV_WEB                      '7
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
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3_NEW_AGREGA_EXAM(ByVal ID_ATE As Integer,
                                                       ByVal ID_USUARIO As Integer,
                                                       ByVal ID_CF As Integer,
                                                       ByVal ID_PER As Integer,
                                                       ByVal ID_TP_PAGO As Integer,
                                                       ByVal ATE_DET_DOC As String,
                                                       ByVal ATE_DET_V_PREVI As Integer,
                                                       ByVal ATE_DET_V_PAGADO As Integer,
                                                       ByVal ATE_DET_V_CCOPAGO As Integer,
                                                       ByVal ATE_NUM_INTERFAZ As String,
                                                      ByVal ATE_CF_MULTIPLICADOS As String,
                                                      ByVal ATE_CODIGO_TEST As String,
                                                                               ByVal ATE_DET_VALOR_BENEF As Integer,
                                                                               ByVal ATE_DET_VALOR_CS As Integer) As Integer

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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3_NEW_AGREGA_EXAM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_DOC", OleDbType.VarChar).Value = ATE_DET_DOC
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_CCOPAGO", OleDbType.Numeric).Value = ATE_DET_V_CCOPAGO
            .Add("@ATE_NUM_INTERFAZ", OleDbType.Numeric).Value = ATE_NUM_INTERFAZ
            .Add("@ATE_CF_MULTIPLICADOS", OleDbType.VarChar).Value = ATE_CF_MULTIPLICADOS
            If (IsNothing(ATE_CODIGO_TEST) = True) Then
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_CODIGO_TEST", OleDbType.VarChar).Value = ATE_CODIGO_TEST
            End If
            .Add("@ATE_DET_VALOR_BENEF", OleDbType.VarChar).Value = ATE_DET_VALOR_BENEF
            .Add("@ATE_DET_VALOR_CS", OleDbType.VarChar).Value = ATE_DET_VALOR_CS


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
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO_ID_DET_PREVE(ByVal ID_ATENCION As Integer,
                                                                               ByVal ID_CODIGO_FONASA As Integer,
                                                                               ByVal ID_TP_PAGO As Integer,
                                                                               ByVal ATE_DET_V_PREVI As Integer,
                                                                               ByVal ATE_DET_V_PAGADO As Integer,
                                                                               ByVal ATE_DET_V_COPAGO As Integer,
                                                                               ByVal ATE_DET_VALOR_BENEF As Integer,
                                                                               ByVal ATE_DET_VALOR_CS As Integer,
                                                                               ByVal ID_DET_PREVE As Integer) As Integer

        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As Integer
        'Declaraciones 'lista      
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO_ID_DET_PREVE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@ID_TP_PAGO", OleDbType.Numeric).Value = ID_TP_PAGO
            .Add("@ATE_DET_V_PREVI", OleDbType.Numeric).Value = ATE_DET_V_PREVI
            .Add("@ATE_DET_V_PAGADO", OleDbType.Numeric).Value = ATE_DET_V_PAGADO
            .Add("@ATE_DET_V_COPAGO", OleDbType.Numeric).Value = ATE_DET_V_COPAGO
            .Add("@ATE_DET_VALOR_BENEF", OleDbType.Numeric).Value = ATE_DET_VALOR_BENEF
            .Add("@ATE_DET_VALOR_CS", OleDbType.Numeric).Value = ATE_DET_VALOR_CS
            .Add("@ID_DET_PREVE", OleDbType.Numeric).Value = ID_DET_PREVE


        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'While Reader_Comm.Read
        '    Obj_Read_Dt = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
        'End While
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function
End Class
