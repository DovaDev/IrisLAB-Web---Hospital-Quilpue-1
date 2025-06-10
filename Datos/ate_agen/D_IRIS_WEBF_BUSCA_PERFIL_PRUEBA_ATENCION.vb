'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PRU_RESU_INMEDIATO_REAL = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.IS_ANATO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO() As List(Of E_ESTUDIO_CLINICO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_ESTUDIO_CLINICO
        Dim E_Proc_List As New List(Of E_ESTUDIO_CLINICO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_PERFILES"
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
            E_Proc_Item = New E_ESTUDIO_CLINICO
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PER_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PER_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PER_CORTO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PER_HOST1 = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PER_HOST2 = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PER_BAC_EST = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PER_NUM_PRU = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_RLS_LS = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.RLS_LS_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_BUSCA_PRUEBAS_POR_CODIGO_PER(ByVal ID_PER As Integer) As List(Of E_PRUEBAS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_PRUEBAS
        Dim E_Proc_List As New List(Of E_PRUEBAS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PRUEBAS_POR_ID_PER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER

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
            E_Proc_Item = New E_PRUEBAS
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PRU_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PRU_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ID_TP_BAC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PRU_SOLICITADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PRU_CORTO = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PRU_P_CERO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.REQ_RES_VAL = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PRU_P_PUNTO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)

            'E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            'E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            'E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            'E_Proc_Item.TP_BAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)



            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_BUSCA_UNIDAD_MEDIDA() As List(Of E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVAS"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.UM_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_BUSCA_TP_RESULTADO() As List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_TP_RESULTADO_ACTIVADO"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_BUSCA_MUESTRA() As List(Of E_IRIS_WEBF_BUSCA_TP_RECIPIENTE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_TP_RECIPIENTE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_TP_RECIPIENTE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_TP_MUESTRAS_ACTIVAS"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_TP_RECIPIENTE
            E_Proc_Item.ID_G_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.GMUE_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_BUSCA_TP_BACTERIO() As List(Of E_IRIS_WEBF_BUSCA_BACTERIO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_BACTERIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_BACTERIO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_TIPO_BACTERIO_ACTIVO"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_BACTERIO
            E_Proc_Item.ID_TP_BAC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.TP_BAC_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.TP_BAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_ESTUDIOS(PER_COD, PER_DESC, PER_CORTO, PER_HOST1, PER_HOST2, PER_BAC_EST, ID_ESTADO, ID_RLS_LS, PER_NUM_PRU) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As String
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_PERFILES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@PER_COD", OleDbType.VarChar).Value = PER_COD
            .Add("@PER_DESC", OleDbType.VarChar).Value = PER_DESC
            .Add("@PER_CORTO", OleDbType.VarChar).Value = PER_CORTO
            .Add("@PER_HOST1", OleDbType.VarChar).Value = PER_HOST1
            .Add("@PER_HOST2", OleDbType.VarChar).Value = PER_HOST2
            .Add("@PER_BAC_EST", OleDbType.VarChar).Value = PER_BAC_EST
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
            .Add("@PER_NUM_PRU", OleDbType.Numeric).Value = PER_NUM_PRU

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        E_Proc_Item = "null"
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function

    Function IRIS_WEBF_UPDATE_ESTUDIOS_PERFIL(ID_PER, PER_COD, PER_DESC, PER_CORTO, PER_HOST1, PER_HOST2, PER_BAC_EST, ID_ESTADO, ID_RLS_LS) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_UPDATE_PERFILES"
            .CommandText = "IRIS_UPDATE_PERFILES_v2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@PER_COD", OleDbType.VarChar).Value = PER_COD
            .Add("@PER_DESC", OleDbType.VarChar).Value = PER_DESC
            .Add("@PER_CORTO", OleDbType.VarChar).Value = PER_CORTO
            .Add("@PER_HOST1", OleDbType.VarChar).Value = PER_HOST1
            .Add("@PER_HOST2", OleDbType.VarChar).Value = PER_HOST2
            .Add("@PER_BAC_EST", OleDbType.VarChar).Value = PER_BAC_EST
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@ID_RLS_LS", OleDbType.Numeric).Value = ID_RLS_LS
            '.Add("@PER_NUM_PRU", OleDbType.Numeric).Value = PER_NUM_PRU
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function


    Function IRIS_DELETE_PRUEBA(ByVal ID_PRUEBA As Integer) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PRUEBA_ELIMINAR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_PRUEBA(ID_PRUEBA, COD_P, DESC_P, CORTO_P, ID_UM_P, ID_TP_RESUL_P, ID_T_MUESTRA, ID_TP_BAC, ID_PER, ORDEN_P, SOLICITADOL_P, ID_USUARIO_P, FECHA_M, ID_ESTADO, NUM_DEC, PRU_P_CERO, REQ_RES_VAL, PRU_P_PUNTO) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_PRUEBA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@COD_P", OleDbType.VarChar).Value = COD_P
            .Add("@DESC_P", OleDbType.VarChar).Value = DESC_P
            .Add("@CORTO_P", OleDbType.VarChar).Value = CORTO_P
            .Add("@ID_UM_P", OleDbType.Numeric).Value = ID_UM_P
            .Add("@ID_TP_RESUL_P", OleDbType.Numeric).Value = ID_TP_RESUL_P
            .Add("@ID_T_MUESTRA", OleDbType.Numeric).Value = ID_T_MUESTRA
            .Add("@ID_TP_BAC", OleDbType.Numeric).Value = ID_TP_BAC
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ORDEN_P", OleDbType.Numeric).Value = ORDEN_P
            .Add("@SOLICITADOL_P", OleDbType.Numeric).Value = SOLICITADOL_P
            .Add("@ID_USUARIO_P", OleDbType.Numeric).Value = ID_USUARIO_P
            .Add("@FECHA_M", OleDbType.Date).Value = FECHA_M
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@NUM_DEC", OleDbType.Numeric).Value = NUM_DEC
            .Add("@PRU_P_CERO", OleDbType.Numeric).Value = PRU_P_CERO
            .Add("@REQ_RES_VAL", OleDbType.Numeric).Value = REQ_RES_VAL
            .Add("@PRU_P_PUNTO", OleDbType.Numeric).Value = PRU_P_PUNTO

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_GRABA_PRUEBA(COD_P, DESC_P, CORTO_P, ID_UM_P, ID_TP_RESUL_P, ID_T_MUESTRA, ID_TP_BAC, ID_PER, ORDEN_P, SOLICITADOL_P, ID_USUARIO_P, ID_ESTADO, NUM_DEC, HOST_P, PRU_P_CERO, REQ_RES_VAL, PRU_P_PUNTO) As List(Of E_PRUEBAS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As E_PRUEBAS
        Dim E_Proc_List As New List(Of E_PRUEBAS)
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_PRUEBA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@COD_P", OleDbType.VarChar).Value = COD_P
            .Add("@DESC_P", OleDbType.VarChar).Value = DESC_P
            .Add("@CORTO_P", OleDbType.VarChar).Value = CORTO_P
            .Add("@ID_UM_P", OleDbType.Numeric).Value = ID_UM_P
            .Add("@ID_TP_RESUL_P", OleDbType.Numeric).Value = ID_TP_RESUL_P
            .Add("@ID_T_MUESTRA", OleDbType.Numeric).Value = ID_T_MUESTRA
            .Add("@ID_TP_BAC", OleDbType.Numeric).Value = ID_TP_BAC
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@ORDEN_P", OleDbType.Numeric).Value = ORDEN_P
            .Add("@SOLICITADOL_P", OleDbType.Numeric).Value = SOLICITADOL_P
            .Add("@ID_USUARIO_P", OleDbType.Numeric).Value = ID_USUARIO_P
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
            .Add("@DECIMAL_P", OleDbType.Numeric).Value = NUM_DEC
            .Add("@HOST_P", OleDbType.Numeric).Value = HOST_P
            .Add("@PRU_P_CERO", OleDbType.Numeric).Value = PRU_P_CERO
            .Add("@REQ_RES_VAL", OleDbType.Numeric).Value = REQ_RES_VAL
            .Add("@PRU_P_PUNTO", OleDbType.Numeric).Value = PRU_P_PUNTO

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas

        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_PRUEBAS
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_UPDATE_DETERMINACIONES_PERFIL(ID_PER, DET) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_PERFILES_N_DETERMINACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@PER_NUMERO", OleDbType.VarChar).Value = DET
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_GRABA_FORMATO(PER_COD, PER_DESC, ID_PER, ID_ESTADO) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As String
        Dim E_Proc_List As String
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_FORMATO_ESTUDIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@COD_F", OleDbType.VarChar).Value = PER_COD
            .Add("@DESC_F", OleDbType.VarChar).Value = PER_DESC
            .Add("@ID_PER", OleDbType.VarChar).Value = ID_PER
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        E_Proc_List = "null"
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = ""
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            'Agregar items a la lista
            E_Proc_List = E_Proc_Item
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_UPDATE_FORMATO(PER_COD, PER_DESC, ID_PER) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Read_Sql As Integer
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_FORMATO_ESTUDIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@COD_F", OleDbType.VarChar).Value = PER_COD
            .Add("@DESC_F", OleDbType.VarChar).Value = PER_DESC
            .Add("@ID_PER", OleDbType.VarChar).Value = ID_PER

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_DELETE_FORMATO(ID_PER) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Read_Sql As Integer
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_FORMATO_ESTUDIO_DELETE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.VarChar).Value = ID_PER

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_BUSCA_FORMATO(COD_P, ID_PER) As List(Of E_IRIS_WEBF_BUSCA_FORMATO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_FORMATO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_FORMATO)
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_FORMATO_ACTUAL_COPIA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@COD", OleDbType.VarChar).Value = COD_P
            .Add("@ID_PER", OleDbType.VarChar).Value = ID_PER

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_FORMATO
            E_Proc_Item.ID_FORMATO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.FORMATO_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_FORMATO_RESULTADO(ID_FORMATO, FR_OBJETO, FR_ID_OBJETO, FR_FILA, FR_COLUMNA, FR_ALTO, FR_ANCHO, FR_TEXTO, ID_LETRA, FR_TAMANO, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, ID_PRUEBA, ID_ESTADO) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As String
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_FORMATO_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_FORMATO", OleDbType.Numeric).Value = ID_FORMATO
            .Add("@FR_OBJETO", OleDbType.VarChar).Value = FR_OBJETO
            .Add("@FR_ID_OBJETO", OleDbType.Numeric).Value = FR_ID_OBJETO
            .Add("@FR_FILA", OleDbType.Numeric).Value = FR_FILA
            .Add("@FR_COLUMNA", OleDbType.Numeric).Value = FR_COLUMNA
            .Add("@FR_ALTO", OleDbType.Numeric).Value = FR_ALTO
            .Add("@FR_ANCHO", OleDbType.Numeric).Value = FR_ANCHO
            .Add("@FR_TEXTO", OleDbType.VarChar).Value = FR_TEXTO
            .Add("@ID_LETRA", OleDbType.Numeric).Value = ID_LETRA
            .Add("@FR_TAMANO", OleDbType.Numeric).Value = FR_TAMANO
            .Add("@FR_EFECTO", OleDbType.VarChar).Value = FR_EFECTO
            .Add("@FR_DINAMICA", OleDbType.Numeric).Value = FR_DINAMICA
            .Add("@FR_DEPENDENCIA", OleDbType.Numeric).Value = FR_DEPENDENCIA
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        E_Proc_Item = "null"
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
        Obj_Reader = Cmd_SQL.ExecuteReader
    End Function

    Function IRIS_WEBF_UPDATE_FORMATO_RESULTADO(FR_OBJETO, FR_TEXTO, FR_TEXTOANT, FR_UNIDAD, ID_PRUEBA) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Read_Sql As Integer
        'Dim Obj_Reader As OleDbDataReader
        'Configuración general
        'Dim E_Proc_Item As String
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_FORMATO_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@FR_TEXTO", OleDbType.VarChar).Value = FR_TEXTO
            .Add("@FR_OBJETO", OleDbType.VarChar).Value = FR_OBJETO
            .Add("@FR_TEXTOANT", OleDbType.VarChar).Value = FR_TEXTOANT
            .Add("@FR_UNIDAD", OleDbType.VarChar).Value = FR_UNIDAD

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_DELETE_FORMATO_RESULTADO(ID_PRUEBA) As String
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Dim Read_Sql As OleDbDataReader
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        Dim E_Proc_Item As String
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_FORMATO_RESULTADO_DELETE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRUEBA", OleDbType.Numeric).Value = ID_PRUEBA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        E_Proc_Item = "null"
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
        Obj_Reader = Cmd_SQL.ExecuteReader
    End Function

    '------------------------------------------ REFER --------------------------------------'

    Function IRIS_BUSCA_RANGO_REFERENCIA(ByVal ID_DET As Integer) As List(Of E_IRIS_BUSCA_RANGO_REFERENCIA)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_RANGO_REFERENCIA
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_RANGO_REFERENCIA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_BUSCA_RANGO_REFERENCIA_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_DET", OleDbType.Numeric).Value = ID_DET

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
            E_Proc_Item = New E_IRIS_BUSCA_RANGO_REFERENCIA
            E_Proc_Item.ID_RF = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.RF_ANO_DESDE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.RF_MESES_DESDE = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.RF_DIAS_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.RF_ANO_HASTA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.RF_MESES_HASTA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.RF_DIAS_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.RF_V_B_DESDE = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.RF_V_DESDE = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.RF_V_HASTA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.RF_V_A_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.RF_R_TEXTO = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.RF_EMBARAZADA = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.RF_TEXTO_EXTRA = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)

            'E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            'E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            'E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            'E_Proc_Item.TP_BAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)



            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()

        Return E_Proc_List
    End Function


End Class
