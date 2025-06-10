
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.VarChar).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.Cod_Barra = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.Establecimiento_Contenedor = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.Caja_Transporte = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.Fecha_irislab = DD_GEN.DB_NULL(Obj_Reader, 3, New Date)
            E_Proc_Item.Muestras_recepcionadas = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.Muestras_enviadas = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.Folio_Hoja_trabajo = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.Fecha_envio_HGF = DD_GEN.DB_NULL(Obj_Reader, 7, New Date)
            E_Proc_Item.Fecha_recepcion_Resultados = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.Fecha_Validacion_en_Irislab = DD_GEN.DB_NULL(Obj_Reader, 9, New Date)
            E_Proc_Item.num = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 11, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.VarChar).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.Cod_Barra = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.Establecimiento_Contenedor = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.Caja_Transporte = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.Fecha_irislab = DD_GEN.DB_NULL(Obj_Reader, 3, New Date)
            E_Proc_Item.Muestras_recepcionadas = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.Muestras_enviadas = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.Folio_Hoja_trabajo = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.Fecha_envio_HGF = DD_GEN.DB_NULL(Obj_Reader, 7, New Date)
            E_Proc_Item.Fecha_recepcion_Resultados = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.Fecha_Validacion_en_Irislab = DD_GEN.DB_NULL(Obj_Reader, 9, New Date)
            E_Proc_Item.num = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_USUARIO_UNION = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.FECHA_UNION = DD_GEN.DB_NULL(Obj_Reader, 13, New Date)
            E_Proc_Item.ATE_AVIS_UNION = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_NUM_UNION = DD_GEN.DB_NULL(Obj_Reader, 15, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ByVal ID As String, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure

        Select Case CASILLA
            Case "1"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_1"
            Case "2"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_2"
            Case "3"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_3"
            Case "4"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_4"
            Case "5"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_5"
            Case "6"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_6"
            Case "7"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_7"
            Case "8"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_8"
            Case "9"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_9"
            Case "10"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_10"
            Case "11111"
                Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_11_CONTENEDOR_ENVIO"
        End Select


        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros
        Select Case CASILLA
            Case "1", "2", "3", "4", "8", "9", "11111"
                With Cmd_command.Parameters
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.VarChar).Value = CAMBIO
                End With
            Case "10"
                With Cmd_command.Parameters
                    Dim ARR = CAMBIO.Split("-")
                    Dim HH As New D_Date
                    Dim tiem As DateTime = HH.strToDate(ARR(0), ARR(1), ARR(2), Format(Date.Now(), "HH"), Format(Date.Now(), "mm"))
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.Date).Value = tiem
                End With
            Case "5", "6", "7"
                With Cmd_command.Parameters
                    Dim ARR = CAMBIO.Split("-")
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.Date).Value = D_Date.toDate(ARR(2) & "/" & ARR(1) & "/" & ARR(0))
                End With
        End Select

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function



    Function IRIS_WEBF_ELIMINAR(ByVal ID As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure

        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_UPDATE_ELIMINAR"

        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros

        With Cmd_command.Parameters

            .Add("@ID", OleDbType.Numeric).Value = ID

        End With

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    '---------------------------------------------------------------- RESIDUOS -------------------------------------------------------------
    Function IRIS_WEBF_BUSCA_DATOS_RESIDUOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_RESIDUOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.ID_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FOLIO_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.FECHA_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.COD_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.SECC_RESIDUO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.TP_RESIDUO_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.BOLSA_CONT_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.KILOS_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.RESPONSABLE_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ESTADO_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_TP_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 13, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO() As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.ID_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.COD_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.SECC_RESIDUO_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_ELIMINAR_RESIDUO(ByVal ID As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure

        Cmd_command.CommandText = "IRIS_WEBF_ELIMINAR_RESIDUO"

        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros

        With Cmd_command.Parameters
            .Add("@ID", OleDbType.Numeric).Value = ID
        End With

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_UPDATE_RESIDUOS(ByVal ID As Integer, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure

        Select Case CASILLA
            Case "1"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_1_FOLIO"
            Case "2"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_2_FECHA_RESIDUO"
            Case "3"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_3_ID_SECCION_RESIDUO"
            Case "4"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_3_ID_SECCION_RESIDUO"
            Case "5"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_4_ID_TIPO_RESIDUO"
            Case "6"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_5_BOLSA_CONT_RESIDUO"
            Case "7"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_6_KILOS_RESIDUO"
            Case "8"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_7_RESPONSABLE_RESIDUO"
            Case "9"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_8_ID_PROCEDENCIA"
            Case "10"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_8_ID_PROCEDENCIA"
        End Select


        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros
        Select Case CASILLA
            Case "1", "3", "4", "5", "6", "7", "8", "9"
                With Cmd_command.Parameters
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.VarChar).Value = CAMBIO
                End With
            Case "2"
                With Cmd_command.Parameters
                    Dim ARR = CAMBIO.Split("-")
                    Dim HH As New D_Date
                    Dim tiem As DateTime = HH.strToDate(ARR(0), ARR(1), ARR(2), Format(Date.Now(), "HH"), Format(Date.Now(), "mm"))
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.Date).Value = tiem
                End With
        End Select

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_CONTENEDOR_ENVIO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_CONTENEDOR_ENVIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.VarChar).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.Cod_Barra = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.Establecimiento_Contenedor = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.Caja_Transporte = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.Fecha_irislab = DD_GEN.DB_NULL(Obj_Reader, 3, New Date)
            E_Proc_Item.Muestras_recepcionadas = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.Muestras_enviadas = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.Folio_Hoja_trabajo = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.Fecha_envio_HGF = DD_GEN.DB_NULL(Obj_Reader, 7, New Date)
            E_Proc_Item.Fecha_recepcion_Resultados = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.Fecha_Validacion_en_Irislab = DD_GEN.DB_NULL(Obj_Reader, 9, New Date)
            E_Proc_Item.num = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.Contenedor_Envio = DD_GEN.DB_NULL(Obj_Reader, 12, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.VarChar).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.Cod_Barra = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.Establecimiento_Contenedor = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.Caja_Transporte = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.Fecha_irislab = DD_GEN.DB_NULL(Obj_Reader, 3, New Date)
            E_Proc_Item.Muestras_recepcionadas = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.Muestras_enviadas = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.Folio_Hoja_trabajo = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.Fecha_envio_HGF = DD_GEN.DB_NULL(Obj_Reader, 7, New Date)
            E_Proc_Item.Fecha_recepcion_Resultados = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.Fecha_Validacion_en_Irislab = DD_GEN.DB_NULL(Obj_Reader, 9, New Date)
            E_Proc_Item.num = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_USUARIO_UNION = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.FECHA_UNION = DD_GEN.DB_NULL(Obj_Reader, 13, New Date)
            E_Proc_Item.ATE_AVIS_UNION = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_NUM_UNION = DD_GEN.DB_NULL(Obj_Reader, 15, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL

            E_Proc_Item.ID_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FOLIO_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.FECHA_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.COD_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.SECC_RESIDUO_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.TP_RESIDUO_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.BOLSA_CONT_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.KILOS_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.RESPONSABLE_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ESTADO_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_TP_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_SECC_RESIDUO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.SUPERVISOR = DD_GEN.DB_NULL(Obj_Reader, 14, "")


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_UPDATE_RESIDUOS_2(ByVal ID As Integer, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure

        Select Case CASILLA
            Case "1"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_1_FOLIO"
            Case "2"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_2_FECHA_RESIDUO"
            Case "3"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_3_ID_SECCION_RESIDUO"
            Case "4"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_3_ID_SECCION_RESIDUO"
            Case "5"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_4_ID_TIPO_RESIDUO"
            Case "6"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_5_BOLSA_CONT_RESIDUO"
            Case "7"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_6_KILOS_RESIDUO"
            Case "8"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_7_RESPONSABLE_RESIDUO"
            Case "9"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_8_ID_PROCEDENCIA"
            Case "10"
                Cmd_command.CommandText = "IRIS_WEBF_UPDATE_RESIDUOS_10_SUPERVISOR"
        End Select


        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Enviar parámetros
        Select Case CASILLA
            Case "1", "3", "4", "5", "6", "7", "8", "9", "10"
                With Cmd_command.Parameters
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.VarChar).Value = CAMBIO
                End With
            Case "2"
                With Cmd_command.Parameters
                    Dim ARR = CAMBIO.Split("-")
                    Dim HH As New D_Date
                    Dim tiem As DateTime = HH.strToDate(ARR(0), ARR(1), ARR(2), Format(Date.Now(), "HH"), Format(Date.Now(), "mm"))
                    .Add("@ID", OleDbType.Numeric).Value = ID
                    .Add("@CAMBIO", OleDbType.Date).Value = tiem
                End With
        End Select

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class
