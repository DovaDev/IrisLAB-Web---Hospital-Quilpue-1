'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2 With {
                .ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, ""),
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, ""),
                .ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, ""),
                .PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, ""),
                .PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, ""),
                .CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, ""),
                .CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, ""),
                .ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, ""),
                .PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, ""),
                .ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, ""),
                .ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, ""),
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, ""),
                .ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, ""),
                .PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, ""),
                .ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, ""),
                .UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, ""),
                .ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, ""),
                .TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, ""),
                .TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, ""),
                .ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, ""),
                .ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, ""),
                .ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, ""),
                .ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, ""),
                .ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, ""),
                .ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, ""),
                .PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing),
                .PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, ""),
                .ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, ""),
                .ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, ""),
                .DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, ""),
                .DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, ""),
                .id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, ""),
                .NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, ""),
                .PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, ""),
                .SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, ""),
                .PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            }
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_SCREENING_SIFILIS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_SCREENING_SIFILIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_4(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA As Object, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)

        Dim HASTA_2 As Date

        HASTA_2 = HASTA.AddDays(1)

        Dim kueri As String = ""

        Dim CB As String = ""
        Dim activador As Integer = 0

        For i = 0 To (MUESTRA.GetUpperBound(0))
            If MUESTRA(i).contains("~") Then

            Else
                If i = 0 Then
                    CB = " (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                Else
                    CB += " OR (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                End If
            End If



        Next i

        kueri += " SELECT "
        kueri += " dbo.IRIS_ATENCION.ID_ATENCION, "
        kueri += " dbo.IRIS_ATENCION.ATE_NUM, "
        kueri += "	dbo.IRIS_ATENCION.ATE_FECHA, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_NOMBRE, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_APELLIDO, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_DESC, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_COD, "
        kueri += "	dbo.IRIS_ATENCION.ATE_AÑO, "
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DESC, "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO_NUM, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_PRUEBA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_ATE_RES, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_FNAC, "
        kueri += "	dbo.IRIS_PACIENTES.ID_SEXO, "
        kueri += "	dbo.IRIS_UNI_MEDIDA.UM_DESC, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_TP_RESULTADO, "
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_DESC,"
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_COD, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_U_MEDIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_HASTA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_HASTA,"
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DECIMAL,"
        kueri += "	dbo.IRIS_PROCEDENCIA.PROC_DESC,"
        kueri += "	dbo.IRIS_ATENCION.ATE_NUM_INTERNO,"
        kueri += "	dbo.IRIS_ATENCION.ATE_DNI,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_NOMBRE,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_APELLIDO,"
        kueri += "	dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA,"
        kueri += "	dbo.IRIS_NACIONALIDAD.NAC_DESC,"
        kueri += "	dbo.IRIS_PROGRAMA.PROGRA_DESC,"
        kueri += "	dbo.IRIS_SECTOR.SECTOR_DESC,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_REVISION_1"
        kueri += "   FROM      dbo.IRIS_CODIGO_FONASA INNER JOIN"
        kueri += "    dbo.IRIS_PRUEBAS INNER JOIN"
        kueri += "  dbo.IRIS_ATE_RESULTADO ON dbo.IRIS_PRUEBAS.ID_PRUEBA = dbo.IRIS_ATE_RESULTADO.ID_PRUEBA INNER JOIN"
        kueri += "   dbo.IRIS_PACIENTES INNER JOIN"
        kueri += "   dbo.IRIS_ATENCION ON dbo.IRIS_PACIENTES.ID_PACIENTE = dbo.IRIS_ATENCION.ID_PACIENTE ON "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ID_ATENCION = dbo.IRIS_ATENCION.ID_ATENCION On "
        kueri += " dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA INNER JOIN"
        kueri += "  dbo.IRIS_UNI_MEDIDA On dbo.IRIS_PRUEBAS.ID_U_MEDIDA = dbo.IRIS_UNI_MEDIDA.ID_U_MEDIDA INNER JOIN"
        kueri += "   dbo.IRIS_TP_RESULTADO ON dbo.IRIS_PRUEBAS.ID_TP_RESULTADO = dbo.IRIS_TP_RESULTADO.ID_TP_RESULTADO INNER JOIN"
        kueri += "  dbo.IRIS_PROCEDENCIA On dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA INNER JOIN"
        kueri += "  dbo.IRIS_DOCTORES ON dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR INNER JOIN"
        kueri += "  dbo.IRIS_NACIONALIDAD On dbo.IRIS_PACIENTES.ID_NACIONALIDAD = dbo.IRIS_NACIONALIDAD.ID_NACIONALIDAD INNER JOIN"
        kueri += "  dbo.IRIS_PROGRAMA ON dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA INNER JOIN"
        kueri += "  dbo.IRIS_SECTOR On dbo.IRIS_ATENCION.ID_SECTOR = dbo.IRIS_SECTOR.ID_SECTOR"
        kueri += " WHERE     (dbo.IRIS_ATENCION.ATE_FECHA  BETWEEN  CONVERT(datetime,'" & DESDE & "',103) AND CONVERT(datetime,'" & HASTA_2 & "',103))"

        'If activador = 0 Then
        kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'Else
        '    kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'End If


        kueri += "((dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 6) Or (dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 14))"
        kueri += " ORDER BY dbo.IRIS_ATENCION.ATE_FECHA ASC , dbo.IRIS_ATE_RESULTADO.ID_PRUEBA asc"

        kueri.ToString()

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = kueri
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        End With

        'Enviar parámetros
        'With Cmd_SQL.Parameters
        '    .Add("@DESDE", OleDbType.Date).Value = DESDE
        '    .Add("@HASTA", OleDbType.Date).Value = HASTA
        '    .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
        '    .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
        '    .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
        'End With
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.ATE_REVISION_1 = DD_GEN.DB_NULL(Obj_Reader, 36, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_MARCADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_MARCADOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = 0
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = 0
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "-")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.ATE_REVISION_1 = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_y_MARCADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA As Object, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)

        Dim HASTA_2 As Date

        HASTA_2 = HASTA.AddDays(1)

        Dim kueri As String = ""

        Dim CB As String = ""
        Dim activador As Integer = 0

        For i = 0 To (MUESTRA.GetUpperBound(0))
            If MUESTRA(i).contains("~") Then

            Else
                If i = 0 Then
                    CB = " (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                Else
                    CB += " OR (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                End If
            End If



        Next i

        kueri += " SELECT "
        kueri += " dbo.IRIS_ATENCION.ID_ATENCION, "
        kueri += " dbo.IRIS_ATENCION.ATE_NUM, "
        kueri += "	dbo.IRIS_ATENCION.ATE_FECHA, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_NOMBRE, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_APELLIDO, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_DESC, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_COD, "
        kueri += "	dbo.IRIS_ATENCION.ATE_AÑO, "
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DESC, "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO_NUM, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_PRUEBA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_ATE_RES, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_FNAC, "
        kueri += "	dbo.IRIS_PACIENTES.ID_SEXO, "
        kueri += "	dbo.IRIS_UNI_MEDIDA.UM_DESC, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_TP_RESULTADO, "
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_DESC,"
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_COD, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_U_MEDIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_HASTA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_HASTA,"
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DECIMAL,"
        kueri += "	dbo.IRIS_PROCEDENCIA.PROC_DESC,"
        kueri += "	dbo.IRIS_ATENCION.ATE_NUM_INTERNO,"
        kueri += "	dbo.IRIS_ATENCION.ATE_DNI,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_NOMBRE,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_APELLIDO,"
        kueri += "	dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA,"
        kueri += "	dbo.IRIS_NACIONALIDAD.NAC_DESC,"
        kueri += "	dbo.IRIS_PROGRAMA.PROGRA_DESC,"
        kueri += "	dbo.IRIS_SECTOR.SECTOR_DESC,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_REVISION_1"
        kueri += "   FROM      dbo.IRIS_CODIGO_FONASA INNER JOIN"
        kueri += "    dbo.IRIS_PRUEBAS INNER JOIN"
        kueri += "  dbo.IRIS_ATE_RESULTADO ON dbo.IRIS_PRUEBAS.ID_PRUEBA = dbo.IRIS_ATE_RESULTADO.ID_PRUEBA INNER JOIN"
        kueri += "   dbo.IRIS_PACIENTES INNER JOIN"
        kueri += "   dbo.IRIS_ATENCION ON dbo.IRIS_PACIENTES.ID_PACIENTE = dbo.IRIS_ATENCION.ID_PACIENTE ON "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ID_ATENCION = dbo.IRIS_ATENCION.ID_ATENCION On "
        kueri += " dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA INNER JOIN"
        kueri += "  dbo.IRIS_UNI_MEDIDA On dbo.IRIS_PRUEBAS.ID_U_MEDIDA = dbo.IRIS_UNI_MEDIDA.ID_U_MEDIDA INNER JOIN"
        kueri += "   dbo.IRIS_TP_RESULTADO ON dbo.IRIS_PRUEBAS.ID_TP_RESULTADO = dbo.IRIS_TP_RESULTADO.ID_TP_RESULTADO INNER JOIN"
        kueri += "  dbo.IRIS_PROCEDENCIA On dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA INNER JOIN"
        kueri += "  dbo.IRIS_DOCTORES ON dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR INNER JOIN"
        kueri += "  dbo.IRIS_NACIONALIDAD On dbo.IRIS_PACIENTES.ID_NACIONALIDAD = dbo.IRIS_NACIONALIDAD.ID_NACIONALIDAD INNER JOIN"
        kueri += "  dbo.IRIS_PROGRAMA ON dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA INNER JOIN"
        kueri += "  dbo.IRIS_SECTOR On dbo.IRIS_ATENCION.ID_SECTOR = dbo.IRIS_SECTOR.ID_SECTOR"
        kueri += " WHERE     (dbo.IRIS_ATENCION.ATE_FECHA  BETWEEN  CONVERT(datetime,'" & DESDE & "',103) AND CONVERT(datetime,'" & HASTA_2 & "',103))"

        'If activador = 0 Then
        kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'Else
        '    kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'End If


        kueri += "((dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 6) Or (dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 14)) "
        kueri += " AND (dbo.IRIS_ATE_RESULTADO.ATE_REVISION_1 = 1) "
        kueri += " ORDER BY dbo.IRIS_ATENCION.ATE_FECHA ASC , dbo.IRIS_ATE_RESULTADO.ID_PRUEBA asc"

        kueri.ToString()

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = kueri
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        End With

        'Enviar parámetros
        'With Cmd_SQL.Parameters
        '    .Add("@DESDE", OleDbType.Date).Value = DESDE
        '    .Add("@HASTA", OleDbType.Date).Value = HASTA
        '    .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
        '    .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
        '    .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
        'End With
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.ATE_REVISION_1 = DD_GEN.DB_NULL(Obj_Reader, 36, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_ID_PER(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA As Object, ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)

        Dim HASTA_2 As Date

        HASTA_2 = HASTA.AddDays(1)

        Dim kueri As String = ""

        Dim CB As String = ""
        Dim activador As Integer = 0

        For i = 0 To (MUESTRA.GetUpperBound(0))
            If MUESTRA(i).contains("~") Then

            Else
                If i = 0 Then
                    CB = " (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                Else
                    CB += " OR (dbo.IRIS_PRUEBAS.ID_PRUEBA = " & MUESTRA(i) & ")"
                End If
            End If



        Next i

        kueri += " SELECT "
        kueri += " dbo.IRIS_ATENCION.ID_ATENCION, "
        kueri += " dbo.IRIS_ATENCION.ATE_NUM, "
        kueri += "	dbo.IRIS_ATENCION.ATE_FECHA, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_NOMBRE, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_APELLIDO, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_DESC, "
        kueri += "	dbo.IRIS_CODIGO_FONASA.CF_COD, "
        kueri += "	dbo.IRIS_ATENCION.ATE_AÑO, "
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DESC, "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO_NUM, "
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_PRUEBA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_ATE_RES, "
        kueri += "	dbo.IRIS_PACIENTES.PAC_FNAC, "
        kueri += "	dbo.IRIS_PACIENTES.ID_SEXO, "
        kueri += "	dbo.IRIS_UNI_MEDIDA.UM_DESC, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_TP_RESULTADO, "
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_DESC,"
        kueri += "	dbo.IRIS_TP_RESULTADO.TP_RESUL_COD, "
        kueri += "	dbo.IRIS_PRUEBAS.ID_U_MEDIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_RR_HASTA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_DESDE,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_R_HASTA,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ID_PER,"
        kueri += "	dbo.IRIS_PRUEBAS.PRU_DECIMAL,"
        kueri += "	dbo.IRIS_PROCEDENCIA.PROC_DESC,"
        kueri += "	dbo.IRIS_ATENCION.ATE_NUM_INTERNO,"
        kueri += "	dbo.IRIS_ATENCION.ATE_DNI,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_NOMBRE,"
        kueri += "	dbo.IRIS_DOCTORES.DOC_APELLIDO,"
        kueri += "	dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA,"
        kueri += "	dbo.IRIS_NACIONALIDAD.NAC_DESC,"
        kueri += "	dbo.IRIS_PROGRAMA.PROGRA_DESC,"
        kueri += "	dbo.IRIS_SECTOR.SECTOR_DESC,"
        kueri += "	dbo.IRIS_ATE_RESULTADO.ATE_REVISION_1"
        kueri += "   FROM      dbo.IRIS_CODIGO_FONASA INNER JOIN"
        kueri += "    dbo.IRIS_PRUEBAS INNER JOIN"
        kueri += "  dbo.IRIS_ATE_RESULTADO ON dbo.IRIS_PRUEBAS.ID_PRUEBA = dbo.IRIS_ATE_RESULTADO.ID_PRUEBA INNER JOIN"
        kueri += "   dbo.IRIS_PACIENTES INNER JOIN"
        kueri += "   dbo.IRIS_ATENCION ON dbo.IRIS_PACIENTES.ID_PACIENTE = dbo.IRIS_ATENCION.ID_PACIENTE ON "
        kueri += "  dbo.IRIS_ATE_RESULTADO.ID_ATENCION = dbo.IRIS_ATENCION.ID_ATENCION On "
        kueri += " dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA INNER JOIN"
        kueri += "  dbo.IRIS_UNI_MEDIDA On dbo.IRIS_PRUEBAS.ID_U_MEDIDA = dbo.IRIS_UNI_MEDIDA.ID_U_MEDIDA INNER JOIN"
        kueri += "   dbo.IRIS_TP_RESULTADO ON dbo.IRIS_PRUEBAS.ID_TP_RESULTADO = dbo.IRIS_TP_RESULTADO.ID_TP_RESULTADO INNER JOIN"
        kueri += "  dbo.IRIS_PROCEDENCIA On dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA INNER JOIN"
        kueri += "  dbo.IRIS_DOCTORES ON dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR INNER JOIN"
        kueri += "  dbo.IRIS_NACIONALIDAD On dbo.IRIS_PACIENTES.ID_NACIONALIDAD = dbo.IRIS_NACIONALIDAD.ID_NACIONALIDAD INNER JOIN"
        kueri += "  dbo.IRIS_PROGRAMA ON dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA LEFT JOIN"
        kueri += "  dbo.IRIS_SECTOR On dbo.IRIS_ATENCION.ID_SECTOR = dbo.IRIS_SECTOR.ID_SECTOR"
        kueri += " WHERE     (dbo.IRIS_ATENCION.ATE_FECHA  BETWEEN  CONVERT(datetime,'" & DESDE & "',103) AND CONVERT(datetime,'" & HASTA_2 & "',103))"

        'If activador = 0 Then
        kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'Else
        '    kueri += "And  (dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_CF & ") and	(((" & ID_PROC & " != 0) And (dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA = " & ID_PROC & "))	Or	((" & ID_PROC & " = 0) And	(dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA Is Not null))) And	((" & CB & "))	And "
        'End If


        kueri += "((dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 6) Or (dbo.IRIS_ATE_RESULTADO.ATE_EST_VALIDA = 14))"
        kueri += " ORDER BY dbo.IRIS_ATENCION.ATE_FECHA ASC , dbo.IRIS_ATE_RESULTADO.ID_PRUEBA asc"

        kueri.ToString()

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.Text
            .CommandText = kueri
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

        End With

        'Enviar parámetros
        'With Cmd_SQL.Parameters
        '    .Add("@DESDE", OleDbType.Date).Value = DESDE
        '    .Add("@HASTA", OleDbType.Date).Value = HASTA
        '    .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
        '    .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
        '    .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
        'End With
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 26, 0)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.ATE_REVISION_1 = DD_GEN.DB_NULL(Obj_Reader, 37, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_GR(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Integer,
                                                                ByVal ID_PRUEBA As Integer,
                                                                ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_GR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ATE_SUR_VIH = DD_GEN.DB_NULL(Obj_Reader, 33, "0")
            E_Proc_Item.NEW_VIH = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_PCR(ByVal DESDE As Date,
                                                               ByVal HASTA As Date,
                                                               ByVal ID_CF As Integer,
                                                               ByVal ID_PRUEBA As Integer,
                                                               ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_PCR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ATE_SUR_VIH = DD_GEN.DB_NULL(Obj_Reader, 33, 0)
            E_Proc_Item.NEW_VIH = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_VIH_PDF(ByVal DESDE As Date,
                                                           ByVal HASTA As Date,
                                                           ByVal ID_CF As Integer,
                                                           ByVal ID_PRUEBA As Integer,
                                                           ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_VIH_PDF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ATE_SUR_VIH = DD_GEN.DB_NULL(Obj_Reader, 33, 0)
            E_Proc_Item.NEW_VIH = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 36, 0)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 37, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_CC(ByVal DESDE As Date,
                                                             ByVal HASTA As Date,
                                                             ByVal ID_CF As Integer,
                                                             ByVal ID_PRUEBA As Integer,
                                                             ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Declaraciones GeneralesUPSI
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_CC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
            .Add("@ID_PROC ", OleDbType.Numeric).Value = ID_PROC
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_NUM_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.ATE_DNI = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 30, "")
            E_Proc_Item.id_proce = DD_GEN.DB_NULL(Obj_Reader, 31, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            'E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            'E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            E_Proc_Item.ATE_SUR_VIH = DD_GEN.DB_NULL(Obj_Reader, 33, 0)
            E_Proc_Item.NEW_VIH = DD_GEN.DB_NULL(Obj_Reader, 34, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class

