'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Ate_Resultados_Info
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    'Function IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand

    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA_2"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With

    '    'Enviar parámetros
    '    With Cmd_SQL.Parameters
    '        .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
    '    End With

    '    'Conectar con la Base de Datos
    '    Select Case CC_ConnBD.Oledbconexion.State
    '        Case ConnectionState.Open
    '            CC_ConnBD.Oledbconexion.Close()
    '        Case Else
    '            CC_ConnBD.Oledbconexion.Open()
    '    End Select

    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

    '    While Obj_Reader.Read
    '        E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
    '        E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
    '        E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
    '        E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
    '        E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
    '        E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
    '        E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
    '        E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
    '        E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
    '        E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
    '        E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
    '        E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
    '        E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
    '        E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
    '        E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
    '        E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
    '        E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
    '        E_Proc_Item.CANT_HIST = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
    '        E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
    '        E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
    '        E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
    '        E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
    '        E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
    '        E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, "")
    '        E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, "")
    '        E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 25, "")
    '        E_Proc_Item.ATE_CAMA = DD_GEN.DB_NULL(Obj_Reader, 26, "")
    '        E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 27, "")
    '        E_Proc_Item.ATE_AVIS = DD_GEN.DB_NULL(Obj_Reader, 28, 0)
    '        E_Proc_Item.FECHA_HORA_ULTIMA_DOSIS = DD_GEN.DB_NULL(Obj_Reader, 29, "Sin Registro")
    '        E_Proc_Item.HGT = DD_GEN.DB_NULL(Obj_Reader, 30, "Sin Registro")
    '    End While

    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_Item
    'End Function

    'Function IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand

    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_2"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With

    '    'Enviar parámetros
    '    With Cmd_SQL.Parameters
    '        .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
    '    End With

    '    'Conectar con la Base de Datos
    '    Select Case CC_ConnBD.Oledbconexion.State
    '        Case ConnectionState.Open
    '            CC_ConnBD.Oledbconexion.Close()
    '        Case Else
    '            CC_ConnBD.Oledbconexion.Open()
    '    End Select

    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

    '    While Obj_Reader.Read
    '        E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
    '        E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
    '        E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
    '        E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
    '        E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
    '        E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
    '        E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
    '        E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
    '        E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
    '        E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
    '        E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
    '        E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
    '        E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
    '        E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
    '        E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
    '        E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
    '        E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
    '        E_Proc_Item.CANT_HIST = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
    '        E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
    '        E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
    '        E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
    '        E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
    '        E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
    '        E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, "")
    '        E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, "")
    '    End While

    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_Item
    'End Function
    Function IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
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
        Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

        While Obj_Reader.Read
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.CANT_ATENCIONES = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, "")
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function


    'Function IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand

    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        '.CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3"
    '        .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_test_2"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With

    '    'Enviar parámetros
    '    With Cmd_SQL.Parameters
    '        .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
    '    End With

    '    'Conectar con la Base de Datos
    '    CC_ConnBD.Oledbconexion.Open()
    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

    '    While Obj_Reader.Read
    '        E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
    '        E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
    '        E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
    '        E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
    '        E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
    '        E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
    '        E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
    '        E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
    '        E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
    '        E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
    '        E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
    '        E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
    '        E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
    '        E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
    '        E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
    '        E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
    '        E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
    '        E_Proc_Item.CANT_HIST = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
    '        E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
    '        E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
    '        E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
    '        E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
    '        E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
    '        E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
    '        E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
    '        E_Proc_Item.ATE_SYDEX = DD_GEN.DB_NULL(Obj_Reader, 25, 0)
    '        E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
    '        E_Proc_Item.ATE_CAMA = DD_GEN.DB_NULL(Obj_Reader, 27, 0)
    '        E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 28, "")
    '        E_Proc_Item.ATE_AVIS = DD_GEN.DB_NULL(Obj_Reader, 29, 0)
    '        E_Proc_Item.ACCU_CHEK_BASAL = DD_GEN.DB_NULL(Obj_Reader, 30, "")
    '        E_Proc_Item.ACCU_CHEK_120 = DD_GEN.DB_NULL(Obj_Reader, 31, "")
    '        E_Proc_Item.CAUSA_ELIMINACION = DD_GEN.DB_NULL(Obj_Reader, 32, "")
    '        E_Proc_Item.USUARIO_ELIMINACION = DD_GEN.DB_NULL(Obj_Reader, 33, "")
    '        E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 34, "")
    '        E_Proc_Item.PESO = DD_GEN.DB_NULL(Obj_Reader, 35, "")
    '        E_Proc_Item.TALLA = DD_GEN.DB_NULL(Obj_Reader, 36, "")
    '        E_Proc_Item.HGT = DD_GEN.DB_NULL(Obj_Reader, 37, "")
    '        E_Proc_Item.PAC_RUT_VIH = DD_GEN.DB_NULL(Obj_Reader, 38, "")

    '    End While

    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_Item
    'End Function

    Function IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3(ByVal ID_ATE As Long) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA_NEW_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.BigInt).Value = ID_ATE
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
        Dim E_Proc_Item As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

        While Obj_Reader.Read
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 8, New Date)
            E_Proc_Item.SEXO_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ID_PROGRA = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.ID_INTEXT = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.ID_SECTOR = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.SECTOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.CANT_ATENCIONES = DD_GEN.DB_NULL(Obj_Reader, 17, 0)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_DIA = DD_GEN.DB_NULL(Obj_Reader, 22, "")
            E_Proc_Item.ATE_MES = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 24, "")
            E_Proc_Item.ORDEN_H2M = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.ATE_CAMA = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.ATE_AVIS = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            E_Proc_Item.ULTIMA_DOSIS_DROGA = DD_GEN.DB_NULL(Obj_Reader, 30, "Sin Registro")
            E_Proc_Item.HGT = DD_GEN.DB_NULL(Obj_Reader, 31, "Sin Registro")
            E_Proc_Item.CAUSA_ELIMINACION = DD_GEN.DB_NULL(Obj_Reader, 32, "")
            E_Proc_Item.USUARIO_ELIMINACION = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.CANT_EXAMENES = DD_GEN.DB_NULL(Obj_Reader, 34, 0)
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.PAC_NOM_SOCIAL = DD_GEN.DB_NULL(Obj_Reader, 36, "")
            E_Proc_Item.ID_GENERO = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)
            E_Proc_Item.GENERO_DESC = DD_GEN.DB_NULL(Obj_Reader, 38, "")
            E_Proc_Item.ID_TP_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 39, Nothing)
            E_Proc_Item.TP_ATENCION_DESC = DD_GEN.DB_NULL(Obj_Reader, 40, "")
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class