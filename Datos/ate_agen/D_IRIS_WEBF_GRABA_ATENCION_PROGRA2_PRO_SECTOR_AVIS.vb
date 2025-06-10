'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Shared Function IRIS_WEBF_ELIMINA_EXAMEN_ATE_RESULTADO_UPDATE_VALOR_ATE_GRABA_HISTORIAL(ID_ATENCION As Integer,
                                                                                            ID_CODIGO_FONASA As Integer,
                                                                                            ID_USUARIO As Integer) As Integer
        Dim CC_ConnBD = New ConexionBD
        Dim Cmd_SQL As New OleDbCommand
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_ELIMINA_EXAMEN_ATE_RESULTADO_UPDATE_VALOR_ATE_GRABA_HISTORIAL_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With
        'Conectar con la Base de Datos
        CC_ConnBD.Oledbconexion.Open()
        'Leer datos devueltos
        Dim Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'cerrar conexion con Base de Datos
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function


    Function IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ByVal ID_ATENCION As Integer,
                ByVal ID_CODIGO_FONASA As Integer,
                ByVal ATE_TOTAL_OLD As Integer,
                ByVal ATE_V_CF_OLD As Integer,
                ByVal ATE_TOTAL_PREVI_OLD As Integer,
                ByVal VALOR_PREVI_NEW As Integer,
                ByVal VALOR_CF_NEW As Integer,
                ByVal VALOR_PAGADO_NEW As Integer,
                ByVal VALOR_PREVI_FINAL_NEW As Integer,
                ByVal ID_ESTADO As Integer,
                ByVal ID_USUARIO As Integer,
                ByVal ID_DET_ATE As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        'Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA_PARA_VISOR_2"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@TOT_ANT", OleDbType.Numeric).Value = ATE_TOTAL_OLD
            .Add("@COP_ANT", OleDbType.Numeric).Value = ATE_V_CF_OLD
            .Add("@PRE_ANT", OleDbType.Numeric).Value = ATE_TOTAL_PREVI_OLD
            .Add("@PRE_NV", OleDbType.Numeric).Value = VALOR_PREVI_NEW
            .Add("@COP_NV", OleDbType.Numeric).Value = VALOR_CF_NEW
            .Add("@TOT_NV", OleDbType.Numeric).Value = VALOR_PAGADO_NEW
            .Add("@TOT_FIN", OleDbType.Numeric).Value = VALOR_PREVI_FINAL_NEW
            .Add("@ID_EST", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_DET_ATE", OleDbType.Numeric).Value = ID_DET_ATE
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

    Shared Function IRIS_WEBF_ELIMINA_EXAMEN_ATE_RESULTADO_UPDATE_VALOR_ATE_GRABA_HISTORIAL_CAMBIO(ID_ATENCION As Integer,
                                                                                                   ID_CODIGO_FONASA As Integer,
                                                                                                   ID_USUARIO As Integer) As Integer
        Dim CC_ConnBD = New ConexionBD
        Dim Cmd_SQL As New OleDbCommand
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_ELIMINA_EXAMEN_ATE_RESULTADO_UPDATE_VALOR_ATE_GRABA_HISTORIAL_CAMBIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
        End With
        'Conectar con la Base de Datos
        CC_ConnBD.Oledbconexion.Open()
        'Leer datos devueltos
        Dim Reader_Comm = Cmd_SQL.ExecuteNonQuery
        'cerrar conexion con Base de Datos
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function
    
    Function IRIS_WEBF_CMVM_GRABA_REL_COPAGO_2(ByVal ID_ATENCION As Integer,
                                          ByVal ID_USUARIO As Integer,
                                          ByVal ATE_FECHA As Date,
                                           ByVal ATE_VALOR_COPAGO_1 As String,                '1 VALOR COPAGO 1
                                           ByVal ATE_TP_COPAGO_1 As String,                   '2 TIPO COPAGO 1
                                           ByVal ATE_VALOR_COPAGO_2 As String,                '3 VALOR COPAGO 2
                                           ByVal ATE_TP_COPAGO_2 As String,                   '4 TIPO COPAGO 2
                                           ByVal ATE_V_CP_FP_2 As Integer,                    '5 TIPO PARTICULAR
                                           ByVal ATE_V_CP_2 As String,                        '6 VALOR PARTICULAR
                                           ByVal ATE_TP_PARTICULAR_1 As String,
                                           ByVal ATE_VALOR_PARTICULAR_1 As String,
                                           ByVal ATE_TP_PARTICULAR_2 As String,
                                           ByVal ATE_VALOR_PARTICULAR_2 As String,
                                               ByVal ORIGEN As String) As Integer
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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_REL_COPAGO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@ATE_FECHA", OleDbType.Date).Value = ATE_FECHA
            .Add("@ATE_TP_COPAGO_1", OleDbType.Integer).Value = ATE_VALOR_COPAGO_1
            .Add("@ATE_VALOR_COPAGO_1", OleDbType.VarChar).Value = ATE_TP_COPAGO_1
            .Add("@ATE_TP_COPAGO_2", OleDbType.Integer).Value = ATE_VALOR_COPAGO_2
            .Add("@ATE_VALOR_COPAGO_2", OleDbType.VarChar).Value = ATE_TP_COPAGO_2
            .Add("@ATE_TP_PARTICULAR", OleDbType.Integer).Value = ATE_TP_PARTICULAR_1
            .Add("@ATE_VALOR_PARTICULAR", OleDbType.VarChar).Value = ATE_VALOR_PARTICULAR_1
            .Add("@ATE_TP_PARTICULAR_2", OleDbType.Integer).Value = ATE_TP_PARTICULAR_2
            .Add("@ATE_VALOR_PARTICULAR_2", OleDbType.VarChar).Value = ATE_VALOR_PARTICULAR_2
            .Add("@ORIGEN", OleDbType.VarChar).Value = ORIGEN

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
    Function IRIS_WEBF_CMVM_RESET_REL_COPAGO_BY_ID_ATENCION(ByVal ID_ATENCION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As Integer = 0
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESET_REL_COPAGO_BY_ID_ATENCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION

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
        CC_ConnBD.Oledbconexion.Close()
        Return Reader_Comm
    End Function

    Function IRIS_WEBF_CMVM_UPDATE_ATE_ELIMINAR_EXAMEN_DET_ATE_CAJA(ByVal ID_ATENCION As Integer,
                                                                   ByVal ID_CODIGO_FONASA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        'Declaraciones 'lista
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ATE_ELIMINAR_EXAMEN_DET_ATE_CAJA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Read_Dt = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Read_Dt
    End Function
    Function IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ByVal ID_ATENCION As Integer,
                                                                                                    ByVal VALOR_PREVI As Integer,
                                                                                                    ByVal VALOR_BENEFI As Integer,
                                                                                                    ByVal VALOR_SC As Integer,
                                                                                                    ByVal VALOR_PAGADO As Integer,
                                                                                                    ByVal VALOR_CF As Integer,
                                                                                                    ByVal VALOR_CP As Integer) As Integer
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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
            .Add("@VALOR_PREVI", OleDbType.Integer).Value = VALOR_PREVI
            .Add("@VALOR_BENEFI", OleDbType.Integer).Value = VALOR_BENEFI
            .Add("@VALOR_SC", OleDbType.Integer).Value = VALOR_SC
            .Add("@VALOR_PAGADO", OleDbType.Integer).Value = VALOR_PAGADO
            .Add("@VALOR_CF", OleDbType.Integer).Value = VALOR_CF
            .Add("@VALOR_CP", OleDbType.Integer).Value = VALOR_CP


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

    Function IRIS_WEBF_BUSCA_REL_COPAGO_AGREGA_EXAMEN(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim PA As String

        PA = "IRIS_WEBF_BUSCA_REL_COPAGO_AGREGA_EXAMEN"

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = PA
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 999999999
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_TP_PAGO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_1 = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_TP_PAGO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.REL_MONTO_COPAGO_2 = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_TP_PAGO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.REL_MONTO_PARTICULAR_2 = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_TP_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_DET_ATENCION_ELIMINA_EXAMEN(ByVal ID_ATENCION As Integer,
                                                            ByVal ID_CODIGO_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_DET_ATENCION_ELIMINA_EXAMEN"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Reader_Comm, 1, 0)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Reader_Comm, 2, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Reader_Comm, 3, 0)
            E_Proc_Item.ID_TP_PAGO = DD_GEN.DB_NULL(Reader_Comm, 4, 0)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Reader_Comm, 5, 0)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Reader_Comm, 6, 0)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Reader_Comm, 7, 0)
            E_Proc_Item.ATE_DET_VALOR_BENEF = DD_GEN.DB_NULL(Reader_Comm, 8, 0)
            E_Proc_Item.ATE_DET_VALOR_CS = DD_GEN.DB_NULL(Reader_Comm, 9, 0)
            E_Proc_Item.ATE_DET_TP_1 = DD_GEN.DB_NULL(Reader_Comm, 10, 0)
            E_Proc_Item.ATE_DET_NUM_BOL = DD_GEN.DB_NULL(Reader_Comm, 11, 0)
            E_Proc_Item.ATE_DET_NUM_BONO = DD_GEN.DB_NULL(Reader_Comm, 12, 0)


            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As Integer = 0
        Dim Reader_Comm As OleDbDataReader
        'Declaraciones 'lista
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP
            E_Proc_Item.ATE_TOTAL = DD_GEN.DB_NULL(Reader_Comm, 0, 0)
            E_Proc_Item.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Reader_Comm, 1, 0)
            E_Proc_Item.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Reader_Comm, 2, 0)
            E_Proc_Item.ATE_V_SISTEMA = DD_GEN.DB_NULL(Reader_Comm, 3, 0)
            E_Proc_Item.ATE_V_BENEF = DD_GEN.DB_NULL(Reader_Comm, 4, 0)
            E_Proc_Item.ATE_V_CF = DD_GEN.DB_NULL(Reader_Comm, 5, 0)
            E_Proc_Item.ATE_V_CP = DD_GEN.DB_NULL(Reader_Comm, 6, 0)
            E_Proc_Item.ATE_V_PAGADO = DD_GEN.DB_NULL(Reader_Comm, 7, 0)
            E_Proc_Item.ATE_V_SC = DD_GEN.DB_NULL(Reader_Comm, 8, 0)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(ByVal ATE_NUM As String,
                                                              ByVal ID_PACIENTE As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal ATE_FUR As String,
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
                                                              ByVal ID_PROGRA As Integer,
                                                              ByVal ATE_RETIRO As String,
                                                              ByVal SECTOR As Integer,
                                                              ByVal ATE_AVIS As String,
                                                              ByVal Interno As String,
                                                              ByVal Diag As String,
                                                              ByVal Diag2 As String,
                                                              ByVal VIH As String,
                                                              ByVal dni As String,
                                                              ByVal ATE_TM As String, ByVal SUB_PROGRAMA As String,
                                                              ByVal EPIVIGILA As String,
                                                              ByVal BUSQUEDA_ACTIVA As Integer,
                                                              ByVal EXAMED As String,
                                                              ByVal EMPRESA As Integer,
                                                              ByVal ID_GRUPO_PESQUISA As Integer) As Integer
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
            '.CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_8_NEW_3_EMPRESA"
            '.CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_8_NEW_3_EMPRESA_v2"
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_8_NEW_3_EMPRESA_v3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

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
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM

            .Add("@SUB_PROGRAMA", OleDbType.VarChar).Value = SUB_PROGRAMA
            .Add("@EPIVIGILA", OleDbType.VarChar).Value = EPIVIGILA
            .Add("@BUSQUEDA_ACTIVA", OleDbType.Integer).Value = BUSQUEDA_ACTIVA
            .Add("@EXAMED", OleDbType.VarChar).Value = EXAMED
            .Add("@EMPRESA", OleDbType.VarChar).Value = EMPRESA
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

    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX(ByVal ATE_NUM As String,
                                                          ByVal ID_PACIENTE As Integer,
                                                          ByVal ID_USUARIO As Integer,
                                                          ByVal ATE_FUR As String,
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
                                                          ByVal ID_PROGRA As Integer,
                                                          ByVal ATE_RETIRO As String,
                                                          ByVal SECTOR As Integer,
                                                          ByVal ATE_AVIS As String,
                                                          ByVal Interno As String,
                                                            ByVal Diag As String,
                                                          ByVal Diag2 As String,
                                                          ByVal VIH As String,
                                                          ByVal dni As String) As Integer
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
            .CommandText = "IRIS_WEBF_GRABA_ATENCION_PROGRA2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

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
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            'If (ATE_AVIS = Nothing) Then
            '    .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            'Else
            '    .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            'End If
            '.Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            '.Add("@Diag", OleDbType.Numeric).Value = Diag
            '.Add("@Diag2", OleDbType.Numeric).Value = Diag2
            '.Add("@VIH", OleDbType.VarChar).Value = VIH
            '.Add("@DNI", OleDbType.VarChar).Value = dni



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
    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_VIH_NEW(ByVal ATE_NUM As String,
                                                            ByVal ID_PACIENTE As Integer,
                                                            ByVal ID_USUARIO As Integer,
                                                            ByVal ATE_FUR As String,
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
                                                            ByVal ID_PROGRA As Integer,
                                                            ByVal ATE_RETIRO As String,
                                                            ByVal SECTOR As Integer,
                                                            ByVal ATE_AVIS As String,
                                                            ByVal Interno As String,
                                                              ByVal Diag As String,
                                                            ByVal Diag2 As String,
                                                            ByVal VIH As String,
                                                            ByVal dni As String,
                                                            ByVal ATE_TM As String,
                                                            ByVal NEW_VIH As String) As Integer
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
            .CommandText = "IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_VIH_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

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
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR

            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
            .Add("@DNI", OleDbType.VarChar).Value = dni
            .Add("@ATE_TM", OleDbType.VarChar).Value = ATE_TM
            .Add("@NEW_VIH", OleDbType.VarChar).Value = NEW_VIH


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


    Function IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX_POSTA(ByVal ATE_NUM As String,
                                                      ByVal ID_PACIENTE As Integer,
                                                      ByVal ID_USUARIO As Integer,
                                                      ByVal ATE_FUR As String,
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
                                                      ByVal ID_PROGRA As Integer,
                                                      ByVal ATE_RETIRO As String,
                                                      ByVal SECTOR As Integer,
                                                      ByVal ATE_AVIS As String,
                                                      ByVal Interno As String,
                                                        ByVal Diag As String,
                                                      ByVal Diag2 As String,
                                                      ByVal VIH As String,
                                                      ByVal dni As String) As Integer
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
            .CommandText = "IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX_3_NEW_POSTA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PACIENTE", OleDbType.Numeric).Value = ID_PACIENTE
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO

            If (ATE_FUR = Nothing) Then
                .Add("@ATE_FUR", OleDbType.VarChar).Value = "01/01/1900"
            Else
                .Add("@ATE_FUR", OleDbType.VarChar).Value = ATE_FUR
            End If

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
            .Add("@ID_PROGRA", OleDbType.Numeric).Value = ID_PROGRA
            .Add("@ATE_RETIRO", OleDbType.VarChar).Value = ATE_RETIRO
            .Add("@SECTOR", OleDbType.Numeric).Value = SECTOR
            If (ATE_AVIS = Nothing) Then
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = DBNull.Value
            Else
                .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            End If
            .Add("@ATE_NUM_INTERNO", OleDbType.VarChar).Value = Interno

            .Add("@Diag", OleDbType.Numeric).Value = Diag
            .Add("@Diag2", OleDbType.Numeric).Value = Diag2
            .Add("@VIH", OleDbType.VarChar).Value = VIH
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

End Class
