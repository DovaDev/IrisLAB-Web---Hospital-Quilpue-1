'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC(ByVal ATE_NUM As String,
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
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                  ByVal diag As String,
                                                 ByVal diag2 As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC"
            .CommandText = "IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_4_diag"
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
            .Add("@PROGRAMA", OleDbType.Numeric).Value = PROGRAMA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            .Add("@Diag", OleDbType.Numeric).Value = CInt(diag)
            .Add("@Diag2", OleDbType.Numeric).Value = CInt(diag2)
            .Add("@HORA", OleDbType.VarChar).Value = xHora
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

    Function IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(ByVal ATE_NUM As String,
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
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                  ByVal diag As String,
                                                 ByVal diag2 As String,
                                                  ByVal sub_atencion As String,
                                                     ByVal vih As String,
                                                     ByVal dni As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC"
            .CommandText = "IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_4_diag_NEW"
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
            .Add("@PROGRAMA", OleDbType.Numeric).Value = PROGRAMA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            .Add("@Diag", OleDbType.Numeric).Value = CInt(diag)
            .Add("@Diag2", OleDbType.Numeric).Value = CInt(diag2)
            .Add("@HORA", OleDbType.VarChar).Value = xHora
            .Add("@SUB_ATENCION", OleDbType.Numeric).Value = CInt(sub_atencion)
            .Add("@VIH", OleDbType.VarChar).Value = vih
            .Add("@DNI", OleDbType.VarChar).Value = dni
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




    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(ByVal ATE_NUM As String,
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
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                 ByVal sub_atencion As String,
                                                 ByVal vih As String, ByVal sub_programa As String, ByVal EMPRESA As Integer,
                                                 ByVal ID_GRUPO_PESQUISA As Integer,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_CMVM_GRABA_PREINGRESO3_PRO_SEC_AVIS"
            '.CommandText = "IRIS_WEBF_CMVM_GRABA_PREINGRESO3_PRO_SEC_AVIS_3_NEW"
            .CommandText = "IRIS_WEBF_CMVM_GRABA_PREINGRESO3_PRO_SEC_AVIS_3_NEW_EMPRESA_CON_GRUPO_PESQUISA"
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
            .Add("@PROGRAMA", OleDbType.Numeric).Value = PROGRAMA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            .Add("@ATE_SAYDEX", OleDbType.VarChar).Value = DBNull.Value
            .Add("@DIAG1", OleDbType.Numeric).Value = DIAG1
            .Add("@DIAG2", OleDbType.Numeric).Value = DIAG2
            .Add("@HORA", OleDbType.VarChar).Value = xHora
            .Add("@SUB_ATENCION", OleDbType.VarChar).Value = sub_atencion

            .Add("@VIH", OleDbType.VarChar).Value = vih
            .Add("@SUB_PROGRAMA", OleDbType.VarChar).Value = sub_programa
            .Add("@EMPRESA", OleDbType.Numeric).Value = EMPRESA
            .Add("@ID_GRUPO_PESQUISA", OleDbType.Numeric).Value = ID_GRUPO_PESQUISA
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
    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_SAYDEX_NEW(ByVal ATE_NUM As String,
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
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                      ByVal sub_atencion As String,
                                                          ByVal vih As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS"
            .CommandText = "IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_SAYDEX_2_NEW"
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
            .Add("@PROGRAMA", OleDbType.Numeric).Value = PROGRAMA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            .Add("@ATE_SAYDEX", OleDbType.VarChar).Value = DBNull.Value
            .Add("@DIAG1", OleDbType.Numeric).Value = DIAG1
            .Add("@DIAG2", OleDbType.Numeric).Value = DIAG2
            .Add("@HORA", OleDbType.VarChar).Value = xHora
            .Add("@SUB_ATENCION", OleDbType.VarChar).Value = sub_atencion
            .Add("@VIH", OleDbType.VarChar).Value = vih
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

    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS(ByVal ATE_NUM As String,
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
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS"
            .CommandText = "IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_2"
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
            .Add("@PROGRAMA", OleDbType.Numeric).Value = PROGRAMA
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            .Add("@ATE_SAYDEX", OleDbType.VarChar).Value = DBNull.Value
            .Add("@DIAG1", OleDbType.Numeric).Value = DIAG1
            .Add("@DIAG2", OleDbType.Numeric).Value = DIAG2
            .Add("@HORA", OleDbType.VarChar).Value = xHora
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
