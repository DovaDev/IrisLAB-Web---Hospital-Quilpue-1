Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports Conexion
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Entidades

Public Class D_IRIS_WEBF_BUSCA_CANT_EXAMENES
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim D_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA With {
              .ID_ATE_RES = D_GEN.DB_NULL(Obj_Reader, 0, 0),
              .ATE_RESULTADO_NUM = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
              .ID_PROCEDENCIA = D_GEN.DB_NULL(Obj_Reader, 2, 0)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_VHS_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_VHS_POR_FECHA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VHS_POR_FECHA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VHS_POR_FECHA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_VHS_POR_FECHA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VHS_POR_FECHA With {
              .ID_ATE_RES = D_GEN.DB_NULL(Obj_Reader, 0, 0),
              .ATE_RESULTADO_NUM = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
              .ID_PROCEDENCIA = D_GEN.DB_NULL(Obj_Reader, 2, 0)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_CONTEO_TRANSAMINASA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CONTEO_TRANSAMINASA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES With {
                .CAE = D_GEN.DB_NULL(Obj_Reader, 0, 0),
                .USM_HDIURNO = D_GEN.DB_NULL(Obj_Reader, 1, 0),
                .PERSONAL = D_GEN.DB_NULL(Obj_Reader, 2, 0),
                .MQ1 = D_GEN.DB_NULL(Obj_Reader, 3, 0),
                .MQ2 = D_GEN.DB_NULL(Obj_Reader, 4, 0),
                .MQ3 = D_GEN.DB_NULL(Obj_Reader, 5, 0),
                .UAPQ_PABELLON = D_GEN.DB_NULL(Obj_Reader, 6, 0),
                .PEDIATRIA = D_GEN.DB_NULL(Obj_Reader, 7, 0),
                .NEONATOLOGIA = D_GEN.DB_NULL(Obj_Reader, 8, 0),
                .UPC = D_GEN.DB_NULL(Obj_Reader, 9, 0),
                .UCI_A = D_GEN.DB_NULL(Obj_Reader, 10, 0),
                .UTI = D_GEN.DB_NULL(Obj_Reader, 11, 0),
                .MATERNIDAD = D_GEN.DB_NULL(Obj_Reader, 12, 0),
                .CMA = D_GEN.DB_NULL(Obj_Reader, 13, 0),
                .HOSP_DOCIMI = D_GEN.DB_NULL(Obj_Reader, 14, 0),
                .UEA_HOSP = D_GEN.DB_NULL(Obj_Reader, 15, 0),
                .UEA = D_GEN.DB_NULL(Obj_Reader, 16, 0),
                .UEI = D_GEN.DB_NULL(Obj_Reader, 17, 0),
                .SAUD = D_GEN.DB_NULL(Obj_Reader, 18, 0),
                .UEGO = D_GEN.DB_NULL(Obj_Reader, 19, 0),
                .ANATOMIA_PATO = D_GEN.DB_NULL(Obj_Reader, 20, 0),
                .IMAGENOLOGIA = D_GEN.DB_NULL(Obj_Reader, 21, 0),
                .CESFAM_IVAN_MAN = D_GEN.DB_NULL(Obj_Reader, 22, 0),
                .CESFAM_AV_AC = D_GEN.DB_NULL(Obj_Reader, 23, 0),
                .CESFAM_QUILPUE = D_GEN.DB_NULL(Obj_Reader, 24, 0),
                .CESFAM_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 25, 0),
                .CONS_POMPEYA = D_GEN.DB_NULL(Obj_Reader, 26, 0),
                .CECOSF_RETIRO = D_GEN.DB_NULL(Obj_Reader, 27, 0),
                .CONS_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 28, 0),
                .CESFAM_VILLA_AL = D_GEN.DB_NULL(Obj_Reader, 29, 0),
                .CESFAM_AMERICAS = D_GEN.DB_NULL(Obj_Reader, 30, 0),
                .CONS_EDUARDO_FREI = D_GEN.DB_NULL(Obj_Reader, 31, 0),
                .CESFAM_JUAN_BT = D_GEN.DB_NULL(Obj_Reader, 32, 0),
                .CONS_AGUILAS = D_GEN.DB_NULL(Obj_Reader, 33, 0),
                .SAPU_FREI = D_GEN.DB_NULL(Obj_Reader, 34, 0),
                .CESFAM_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 35, 0),
                .CESFAM_OLMUE = D_GEN.DB_NULL(Obj_Reader, 36, 0),
                .APS_CABILDO = D_GEN.DB_NULL(Obj_Reader, 37, 0),
                .APS_HIJUELAS = D_GEN.DB_NULL(Obj_Reader, 38, 0),
                .APS_CALERA = D_GEN.DB_NULL(Obj_Reader, 39, 0),
                .APS_LIGUA = D_GEN.DB_NULL(Obj_Reader, 40, 0),
                .APS_NOGALES = D_GEN.DB_NULL(Obj_Reader, 41, 0),
                .APS_PETORCA = D_GEN.DB_NULL(Obj_Reader, 42, 0),
                .HOSP_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 43, 0),
                .HOSP_GERIATRICO_LMCHE = D_GEN.DB_NULL(Obj_Reader, 44, 0),
                .HOSP_MODULAR_LMCHE = D_GEN.DB_NULL(Obj_Reader, 45, 0),
                .HOSP_PENBLANCA = D_GEN.DB_NULL(Obj_Reader, 46, 0),
                .HOSP_GUSTAVO_FRICKE = D_GEN.DB_NULL(Obj_Reader, 47, 0),
                .HOSP_CALERA = D_GEN.DB_NULL(Obj_Reader, 48, 0),
                .HOSP_PETORCA = D_GEN.DB_NULL(Obj_Reader, 49, 0),
                .HOSP_QUILLOTA = D_GEN.DB_NULL(Obj_Reader, 50, 0),
                .HOSP_CABILDO = D_GEN.DB_NULL(Obj_Reader, 51, 0),
                .HOSP_LIGUA = D_GEN.DB_NULL(Obj_Reader, 52, 0),
                .HOSP_QUINTERO = D_GEN.DB_NULL(Obj_Reader, 53, 0),
                .OTROS = D_GEN.DB_NULL(Obj_Reader, 54, 0),
                .ID_PRUEBA = D_GEN.DB_NULL(Obj_Reader, 55, 0),
                .CANTIDAD = D_GEN.DB_NULL(Obj_Reader, 56, 0)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_CONTEO_RETICULO(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CONTEO_RETICULO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With


        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES With {
                .CAE = D_GEN.DB_NULL(Obj_Reader, 0, 0),
                .USM_HDIURNO = D_GEN.DB_NULL(Obj_Reader, 1, 0),
                .PERSONAL = D_GEN.DB_NULL(Obj_Reader, 2, 0),
                .MQ1 = D_GEN.DB_NULL(Obj_Reader, 3, 0),
                .MQ2 = D_GEN.DB_NULL(Obj_Reader, 4, 0),
                .MQ3 = D_GEN.DB_NULL(Obj_Reader, 5, 0),
                .UAPQ_PABELLON = D_GEN.DB_NULL(Obj_Reader, 6, 0),
                .PEDIATRIA = D_GEN.DB_NULL(Obj_Reader, 7, 0),
                .NEONATOLOGIA = D_GEN.DB_NULL(Obj_Reader, 8, 0),
                .UPC = D_GEN.DB_NULL(Obj_Reader, 9, 0),
                .UCI_A = D_GEN.DB_NULL(Obj_Reader, 10, 0),
                .UTI = D_GEN.DB_NULL(Obj_Reader, 11, 0),
                .MATERNIDAD = D_GEN.DB_NULL(Obj_Reader, 12, 0),
                .CMA = D_GEN.DB_NULL(Obj_Reader, 13, 0),
                .HOSP_DOCIMI = D_GEN.DB_NULL(Obj_Reader, 14, 0),
                .UEA_HOSP = D_GEN.DB_NULL(Obj_Reader, 15, 0),
                .UEA = D_GEN.DB_NULL(Obj_Reader, 16, 0),
                .UEI = D_GEN.DB_NULL(Obj_Reader, 17, 0),
                .SAUD = D_GEN.DB_NULL(Obj_Reader, 18, 0),
                .UEGO = D_GEN.DB_NULL(Obj_Reader, 19, 0),
                .ANATOMIA_PATO = D_GEN.DB_NULL(Obj_Reader, 20, 0),
                .IMAGENOLOGIA = D_GEN.DB_NULL(Obj_Reader, 21, 0),
                .CESFAM_IVAN_MAN = D_GEN.DB_NULL(Obj_Reader, 22, 0),
                .CESFAM_AV_AC = D_GEN.DB_NULL(Obj_Reader, 23, 0),
                .CESFAM_QUILPUE = D_GEN.DB_NULL(Obj_Reader, 24, 0),
                .CESFAM_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 25, 0),
                .CONS_POMPEYA = D_GEN.DB_NULL(Obj_Reader, 26, 0),
                .CECOSF_RETIRO = D_GEN.DB_NULL(Obj_Reader, 27, 0),
                .CONS_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 28, 0),
                .CESFAM_VILLA_AL = D_GEN.DB_NULL(Obj_Reader, 29, 0),
                .CESFAM_AMERICAS = D_GEN.DB_NULL(Obj_Reader, 30, 0),
                .CONS_EDUARDO_FREI = D_GEN.DB_NULL(Obj_Reader, 31, 0),
                .CESFAM_JUAN_BT = D_GEN.DB_NULL(Obj_Reader, 32, 0),
                .CONS_AGUILAS = D_GEN.DB_NULL(Obj_Reader, 33, 0),
                .SAPU_FREI = D_GEN.DB_NULL(Obj_Reader, 34, 0),
                .CESFAM_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 35, 0),
                .CESFAM_OLMUE = D_GEN.DB_NULL(Obj_Reader, 36, 0),
                .APS_CABILDO = D_GEN.DB_NULL(Obj_Reader, 37, 0),
                .APS_HIJUELAS = D_GEN.DB_NULL(Obj_Reader, 38, 0),
                .APS_CALERA = D_GEN.DB_NULL(Obj_Reader, 39, 0),
                .APS_LIGUA = D_GEN.DB_NULL(Obj_Reader, 40, 0),
                .APS_NOGALES = D_GEN.DB_NULL(Obj_Reader, 41, 0),
                .APS_PETORCA = D_GEN.DB_NULL(Obj_Reader, 42, 0),
                .HOSP_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 43, 0),
                .HOSP_GERIATRICO_LMCHE = D_GEN.DB_NULL(Obj_Reader, 44, 0),
                .HOSP_MODULAR_LMCHE = D_GEN.DB_NULL(Obj_Reader, 45, 0),
                .HOSP_PENBLANCA = D_GEN.DB_NULL(Obj_Reader, 46, 0),
                .HOSP_GUSTAVO_FRICKE = D_GEN.DB_NULL(Obj_Reader, 47, 0),
                .HOSP_CALERA = D_GEN.DB_NULL(Obj_Reader, 48, 0),
                .HOSP_PETORCA = D_GEN.DB_NULL(Obj_Reader, 49, 0),
                .HOSP_QUILLOTA = D_GEN.DB_NULL(Obj_Reader, 50, 0),
                .HOSP_CABILDO = D_GEN.DB_NULL(Obj_Reader, 51, 0),
                .HOSP_LIGUA = D_GEN.DB_NULL(Obj_Reader, 52, 0),
                .HOSP_QUINTERO = D_GEN.DB_NULL(Obj_Reader, 53, 0),
                .OTROS = D_GEN.DB_NULL(Obj_Reader, 54, 0),
                .ID_PRUEBA = D_GEN.DB_NULL(Obj_Reader, 55, 0),
                .CANTIDAD = D_GEN.DB_NULL(Obj_Reader, 56, 0)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



    Function IRIS_WEBF_ACTUALIZA_EXCL_PRIO_REM(ID_FONASA_REM As Integer, ID_CF_EX As Integer, ByVal OPT As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc As Integer

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CF_EX", OleDbType.Numeric).Value = ID_CF_EX
            .Add("@ID_FONASA_REM", OleDbType.Numeric).Value = ID_FONASA_REM
        End With

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            If OPT = "1" Then
                .CommandText = "IRIS_WEBF_ACTUALIZA_PRIORI_REL_REM"
            ElseIf OPT = "2" Then
                .CommandText = "IRIS_WEBF_ACTUALIZA_EXCLUIR_REL_REM"
            End If
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function


    Function IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO(ByVal ID_CF As Integer, ByVal ID_FONASA_REM As Integer, ByVal TYPE As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc As Integer

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_FONASA_REM", OleDbType.Numeric).Value = ID_FONASA_REM
        End With

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            If TYPE = "Crea" Then
                .CommandText = "IRIS_WEBF_GUARDA_PANEL_CODIGO"
            Else
                .CommandText = "IRIS_WEBF_QUITA_PANEL_CODIGO"
            End If
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        E_Proc = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc
    End Function
    Function IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM(ByVal ID_FONASA_REM_HOSP As Integer) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM)

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_FONASA_REM_HOSP", OleDbType.Numeric).Value = ID_FONASA_REM_HOSP
        End With

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM With {
               .ID_REL_PRU_REM = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .ID_FONASA_REM_HOSP = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .CF_COD_IRIS = D_GEN.DB_NULL(Obj_Reader, 2, Nothing),
               .CF_COD_REM = D_GEN.DB_NULL(Obj_Reader, 3, Nothing),
               .CF_DESC_HOSP = D_GEN.DB_NULL(Obj_Reader, 4, Nothing),
               .ID_CF_EX = D_GEN.DB_NULL(Obj_Reader, 5, Nothing),
               .CF_COD = D_GEN.DB_NULL(Obj_Reader, 6, Nothing),
               .CF_DESC = D_GEN.DB_NULL(Obj_Reader, 7, Nothing),
               .PRIORI = D_GEN.DB_NULL(Obj_Reader, 8, Nothing),
               .EXCLUIR = D_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_TODOS_EXAMENES() As List(Of E_IRIS_WEBF_BUSCA_TODOS_EXAMENES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_TODOS_EXAMENES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_TODOS_EXAMENES)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_TODOS_EXAMENES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_TODOS_EXAMENES With {
               .ID_CODIGO_FONASA = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .CF_COD = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .CF_DESC = D_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List

    End Function

    Function IRIS_WEBF_BUSCA_SECCION_FORMATO_REM() As List(Of E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_SECCION_FORMATO_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM With {
               .ID_SECC_REM = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .SECC_REM_DESC = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .ID_ESTADO = D_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List

    End Function
    Function IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM(ByVal ID_DDL_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM)
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_DDL_SECC", OleDbType.Numeric).Value = ID_DDL_SECC
        End With


        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM With {
               .ID_FONASA_REM_HOSP = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .CF_COD_IRIS = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .CF_DESC_HOSP = D_GEN.DB_NULL(Obj_Reader, 2, Nothing),
               .ID_ESTADO = D_GEN.DB_NULL(Obj_Reader, 3, Nothing),
               .ID_SECC_REM = D_GEN.DB_NULL(Obj_Reader, 4, Nothing),
               .SECC_REM_DESC = D_GEN.DB_NULL(Obj_Reader, 5, Nothing),
               .CF_COD_REM = D_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List

    End Function

    Function IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            .CommandTimeout = 600
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA With {
               .ID_ATENCION = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .CF_COD = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .ID_CODIGO_FONASA = D_GEN.DB_NULL(Obj_Reader, 2, Nothing),
               .ID_PROCEDENCIA = D_GEN.DB_NULL(Obj_Reader, 3, Nothing),
               .ID_TIPO_PAC = D_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_REL_PRU_REM() As List(Of E_IRIS_WEBF_BUSCA_REL_PRU_REM)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_REL_PRU_REM
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_REL_PRU_REM)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_REL_PRU_REM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devuletos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_REL_PRU_REM With {
               .ID_REL_PRU_REM = D_GEN.DB_NULL(Obj_Reader, 0, Nothing),
               .ID_FONASA_REM_HOSP = D_GEN.DB_NULL(Obj_Reader, 1, Nothing),
               .ID_CF_EX = D_GEN.DB_NULL(Obj_Reader, 2, Nothing),
               .ID_ESTADO = D_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            }
            'Agregamos el item a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_CANT_EXAMENES(ByVal DESDE As Date, ByVal HASTA As Date, ByVal opt As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)

        Try

            'Configuración general
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea

                If opt = "noCompile" Then
                    .CommandText = "IRIS_WEBF_BUSCA_CANT_EXAMENES_NOCOMP"
                    .CommandTimeout = 60
                Else
                    .CommandText = "IRIS_WEBF_BUSCA_CANT_EXAMENES_COMP"
                    .CommandTimeout = 60
                End If
            End With

            'Enviar parámetros
            With Cmd_SQL.Parameters
                .Add("@DESDE", OleDbType.Date).Value = DESDE
                .Add("@HASTA", OleDbType.Date).Value = HASTA
            End With

            'Conectar con la Base de Datos
            Select Case CC_ConnBD.Oledbconexion.State
                Case ConnectionState.Open
                    CC_ConnBD.Oledbconexion.Close()
                Case Else
                    CC_ConnBD.Oledbconexion.Open()
            End Select

            'Leer datos devuletos
            Obj_Reader = Cmd_SQL.ExecuteReader
            While Obj_Reader.Read
                E_Proc_Item = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES With {
                    .CF_COD_IRIS = D_GEN.DB_NULL(Obj_Reader, 0, ""),
                    .ID_CODIGO_FONASA = D_GEN.DB_NULL(Obj_Reader, 1, 0),
                    .CF_DESC_HOSP = D_GEN.DB_NULL(Obj_Reader, 2, ""),
                    .ID_PER = D_GEN.DB_NULL(Obj_Reader, 3, 0),
                    .PER_DESC = D_GEN.DB_NULL(Obj_Reader, 4, ""),
                    .CANTIDAD = D_GEN.DB_NULL(Obj_Reader, 5, 0),
                    .EXISTE_CF = D_GEN.DB_NULL(Obj_Reader, 6, 0),
                    .ID_RLS_LS = D_GEN.DB_NULL(Obj_Reader, 7, 0),
                    .RLS_LS_DESC = D_GEN.DB_NULL(Obj_Reader, 8, ""),
                    .SECC_DESC = D_GEN.DB_NULL(Obj_Reader, 9, ""),
                    .ID_SECCION = D_GEN.DB_NULL(Obj_Reader, 10, 0),
                    .CAE = D_GEN.DB_NULL(Obj_Reader, 11, 0),
                    .USM_HDIURNO = D_GEN.DB_NULL(Obj_Reader, 12, 0),
                    .PERSONAL = D_GEN.DB_NULL(Obj_Reader, 13, 0),
                    .TOTAL_ABIERTA = D_GEN.DB_NULL(Obj_Reader, 14, 0),
                    .MQ1 = D_GEN.DB_NULL(Obj_Reader, 15, 0),
                    .MQ2 = D_GEN.DB_NULL(Obj_Reader, 16, 0),
                    .MQ3 = D_GEN.DB_NULL(Obj_Reader, 17, 0),
                    .UAPQ_PABELLON = D_GEN.DB_NULL(Obj_Reader, 18, 0),
                    .PEDIATRIA = D_GEN.DB_NULL(Obj_Reader, 19, 0),
                    .NEONATOLOGIA = D_GEN.DB_NULL(Obj_Reader, 20, 0),
                    .UPC = D_GEN.DB_NULL(Obj_Reader, 21, 0),
                    .UCI_A = D_GEN.DB_NULL(Obj_Reader, 22, 0),
                    .UTI = D_GEN.DB_NULL(Obj_Reader, 23, 0),
                    .MATERNIDAD = D_GEN.DB_NULL(Obj_Reader, 24, 0),
                    .CMA = D_GEN.DB_NULL(Obj_Reader, 25, 0),
                    .HOSP_DOCIMI = D_GEN.DB_NULL(Obj_Reader, 26, 0),
                    .UEA_HOSP = D_GEN.DB_NULL(Obj_Reader, 27, 0),
                    .TOTAL_CERRADA = D_GEN.DB_NULL(Obj_Reader, 28, 0),
                    .UEA = D_GEN.DB_NULL(Obj_Reader, 29, 0),
                    .UEI = D_GEN.DB_NULL(Obj_Reader, 30, 0),
                    .SAUD = D_GEN.DB_NULL(Obj_Reader, 31, 0),
                    .TOTAL_UE = D_GEN.DB_NULL(Obj_Reader, 32, 0),
                    .UEGO = D_GEN.DB_NULL(Obj_Reader, 33, 0),
                    .ANATOMIA_PATO = D_GEN.DB_NULL(Obj_Reader, 34, 0),
                    .IMAGENOLOGIA = D_GEN.DB_NULL(Obj_Reader, 35, 0),
                    .TOTAL_UNIDAD_APOYO = D_GEN.DB_NULL(Obj_Reader, 36, 0),
                    .CESFAM_IVAN_MAN = D_GEN.DB_NULL(Obj_Reader, 37, 0),
                    .CESFAM_AV_AC = D_GEN.DB_NULL(Obj_Reader, 38, 0),
                    .CESFAM_QUILPUE = D_GEN.DB_NULL(Obj_Reader, 39, 0),
                    .CESFAM_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 40, 0),
                    .CONS_POMPEYA = D_GEN.DB_NULL(Obj_Reader, 41, 0),
                    .CECOSF_RETIRO = D_GEN.DB_NULL(Obj_Reader, 42, 0),
                    .CONS_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 43, 0),
                    .CESFAM_VILLA_AL = D_GEN.DB_NULL(Obj_Reader, 44, 0),
                    .CESFAM_AMERICAS = D_GEN.DB_NULL(Obj_Reader, 45, 0),
                    .CONS_EDUARDO_FREI = D_GEN.DB_NULL(Obj_Reader, 46, 0),
                    .CESFAM_JUAN_BT = D_GEN.DB_NULL(Obj_Reader, 47, 0),
                    .CONS_AGUILAS = D_GEN.DB_NULL(Obj_Reader, 48, 0),
                    .SAPU_FREI = D_GEN.DB_NULL(Obj_Reader, 49, 0),
                    .CESFAM_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 50, 0),
                    .CESFAM_OLMUE = D_GEN.DB_NULL(Obj_Reader, 51, 0),
                    .APS_CABILDO = D_GEN.DB_NULL(Obj_Reader, 52, 0),
                    .APS_HIJUELAS = D_GEN.DB_NULL(Obj_Reader, 53, 0),
                    .APS_CALERA = D_GEN.DB_NULL(Obj_Reader, 54, 0),
                    .APS_LIGUA = D_GEN.DB_NULL(Obj_Reader, 55, 0),
                    .APS_NOGALES = D_GEN.DB_NULL(Obj_Reader, 56, 0),
                    .APS_PETORCA = D_GEN.DB_NULL(Obj_Reader, 57, 0),
                    .HOSP_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 58, 0),
                    .HOSP_GERIATRICO_LMCHE = D_GEN.DB_NULL(Obj_Reader, 59, 0),
                    .HOSP_MODULAR_LMCHE = D_GEN.DB_NULL(Obj_Reader, 60, 0),
                    .HOSP_PENBLANCA = D_GEN.DB_NULL(Obj_Reader, 61, 0),
                    .HOSP_GUSTAVO_FRICKE = D_GEN.DB_NULL(Obj_Reader, 62, 0),
                    .HOSP_CALERA = D_GEN.DB_NULL(Obj_Reader, 63, 0),
                    .HOSP_PETORCA = D_GEN.DB_NULL(Obj_Reader, 64, 0),
                    .HOSP_QUILLOTA = D_GEN.DB_NULL(Obj_Reader, 65, 0),
                    .HOSP_CABILDO = D_GEN.DB_NULL(Obj_Reader, 66, 0),
                    .HOSP_LIGUA = D_GEN.DB_NULL(Obj_Reader, 67, 0),
                    .HOSP_QUINTERO = D_GEN.DB_NULL(Obj_Reader, 68, 0),
                    .OTROS = D_GEN.DB_NULL(Obj_Reader, 69, 0),
                    .TOTAL_EXTRA = D_GEN.DB_NULL(Obj_Reader, 70, 0),
                    .ID_SECC_REM = D_GEN.DB_NULL(Obj_Reader, 71, 0),
                    .SECC_REM_DESC = D_GEN.DB_NULL(Obj_Reader, 72, ""),
                    .ID_AREA_REM = D_GEN.DB_NULL(Obj_Reader, 73, 0),
                    .AREA_DESC = D_GEN.DB_NULL(Obj_Reader, 74, ""),
                    .ID_FONASA_REM_HOSP = D_GEN.DB_NULL(Obj_Reader, 75, Nothing)
                }
                'Agregamos el item a la lista
                E_Proc_List.Add(E_Proc_Item)
            End While

            CC_ConnBD.Oledbconexion.Close()
            Return E_Proc_List
        Catch ex As OleDbException
            ' Si hay un timeout, intenta con la opción contraria
            If opt = "noCompile" Then
                Return IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA, "compile")
            Else
                Return IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA, "noCompile")
                End If

            ' Si el error no es un timeout, relanzar la excepción
            Throw
        End Try
    End Function

    'Function IRIS_WEBF_BUSCA_CANT_EXAMENES(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand

    '    'Declaraciones 'lista'
    '    Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
    '    Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)

    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEBF_BUSCA_CANT_EXAMENES_PROC"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With


    '    'Enviar parámetros
    '    With Cmd_SQL.Parameters
    '        .Add("@DESDE", OleDbType.Date).Value = DESDE
    '        .Add("@HASTA", OleDbType.Date).Value = HASTA
    '    End With

    '    'Conectar con la Base de Datos
    '    Select Case CC_ConnBD.Oledbconexion.State
    '        Case ConnectionState.Open
    '            CC_ConnBD.Oledbconexion.Close()
    '        Case Else
    '            CC_ConnBD.Oledbconexion.Open()
    '    End Select

    '    'Leer datos devuletos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    While Obj_Reader.Read
    '        E_Proc_Item = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES With {
    '            .CF_COD_IRIS = D_GEN.DB_NULL(Obj_Reader, 0, ""),
    '            .CF_DESC_HOSP = D_GEN.DB_NULL(Obj_Reader, 1, ""),
    '            .CANTIDAD = D_GEN.DB_NULL(Obj_Reader, 2, 0),
    '            .CAE = D_GEN.DB_NULL(Obj_Reader, 3, 0),
    '            .USM_HDIURNO = D_GEN.DB_NULL(Obj_Reader, 4, 0),
    '            .PERSONAL = D_GEN.DB_NULL(Obj_Reader, 5, 0),
    '            .TOTAL_ABIERTA = D_GEN.DB_NULL(Obj_Reader, 6, 0),
    '            .MQ1 = D_GEN.DB_NULL(Obj_Reader, 7, 0),
    '            .MQ2 = D_GEN.DB_NULL(Obj_Reader, 8, 0),
    '            .MQ3 = D_GEN.DB_NULL(Obj_Reader, 9, 0),
    '            .UAPQ_PABELLON = D_GEN.DB_NULL(Obj_Reader, 10, 0),
    '            .PEDIATRIA = D_GEN.DB_NULL(Obj_Reader, 11, 0),
    '            .NEONATOLOGIA = D_GEN.DB_NULL(Obj_Reader, 12, 0),
    '            .UPC = D_GEN.DB_NULL(Obj_Reader, 13, 0),
    '            .UCI_A = D_GEN.DB_NULL(Obj_Reader, 14, 0),
    '            .UTI = D_GEN.DB_NULL(Obj_Reader, 15, 0),
    '            .MATERNIDAD = D_GEN.DB_NULL(Obj_Reader, 16, 0),
    '            .CMA = D_GEN.DB_NULL(Obj_Reader, 17, 0),
    '            .HOSP_DOCIMI = D_GEN.DB_NULL(Obj_Reader, 18, 0),
    '            .UEA_HOSP = D_GEN.DB_NULL(Obj_Reader, 19, 0),
    '            .TOTAL_CERRADA = D_GEN.DB_NULL(Obj_Reader, 20, 0),
    '            .UEA = D_GEN.DB_NULL(Obj_Reader, 21, 0),
    '            .UEI = D_GEN.DB_NULL(Obj_Reader, 22, 0),
    '            .SAUD = D_GEN.DB_NULL(Obj_Reader, 23, 0),
    '            .TOTAL_UE = D_GEN.DB_NULL(Obj_Reader, 24, 0),
    '            .UEGO = D_GEN.DB_NULL(Obj_Reader, 25, 0),
    '            .ANATOMIA_PATO = D_GEN.DB_NULL(Obj_Reader, 26, 0),
    '            .IMAGENOLOGIA = D_GEN.DB_NULL(Obj_Reader, 27, 0),
    '            .TOTAL_UNIDAD_APOYO = D_GEN.DB_NULL(Obj_Reader, 28, 0),
    '            .CESFAM_IVAN_MAN = D_GEN.DB_NULL(Obj_Reader, 29, 0),
    '            .CESFAM_AV_AC = D_GEN.DB_NULL(Obj_Reader, 30, 0),
    '            .CESFAM_QUILPUE = D_GEN.DB_NULL(Obj_Reader, 31, 0),
    '            .CESFAM_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 32, 0),
    '            .CONS_POMPEYA = D_GEN.DB_NULL(Obj_Reader, 33, 0),
    '            .CECOSF_RETIRO = D_GEN.DB_NULL(Obj_Reader, 34, 0),
    '            .CONS_BELLOTO = D_GEN.DB_NULL(Obj_Reader, 35, 0),
    '            .CESFAM_VILLA_AL = D_GEN.DB_NULL(Obj_Reader, 36, 0),
    '            .CESFAM_AMERICAS = D_GEN.DB_NULL(Obj_Reader, 37, 0),
    '            .CONS_EDUARDO_FREI = D_GEN.DB_NULL(Obj_Reader, 38, 0),
    '            .CESFAM_JUAN_BT = D_GEN.DB_NULL(Obj_Reader, 39, 0),
    '            .CONS_AGUILAS = D_GEN.DB_NULL(Obj_Reader, 40, 0),
    '            .SAPU_FREI = D_GEN.DB_NULL(Obj_Reader, 41, 0),
    '            .CESFAM_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 42, 0),
    '            .CESFAM_OLMUE = D_GEN.DB_NULL(Obj_Reader, 43, 0),
    '            .APS_CABILDO = D_GEN.DB_NULL(Obj_Reader, 44, 0),
    '            .APS_HIJUELAS = D_GEN.DB_NULL(Obj_Reader, 45, 0),
    '            .APS_CALERA = D_GEN.DB_NULL(Obj_Reader, 46, 0),
    '            .APS_LIGUA = D_GEN.DB_NULL(Obj_Reader, 47, 0),
    '            .APS_NOGALES = D_GEN.DB_NULL(Obj_Reader, 48, 0),
    '            .APS_PETORCA = D_GEN.DB_NULL(Obj_Reader, 49, 0),
    '            .HOSP_LIMACHE = D_GEN.DB_NULL(Obj_Reader, 50, 0),
    '            .HOSP_GERIATRICO_LMCHE = D_GEN.DB_NULL(Obj_Reader, 51, 0),
    '            .HOSP_MODULAR_LMCHE = D_GEN.DB_NULL(Obj_Reader, 52, 0),
    '            .HOSP_PENBLANCA = D_GEN.DB_NULL(Obj_Reader, 53, 0),
    '            .HOSP_GUSTAVO_FRICKE = D_GEN.DB_NULL(Obj_Reader, 54, 0),
    '            .HOSP_CALERA = D_GEN.DB_NULL(Obj_Reader, 55, 0),
    '            .HOSP_PETORCA = D_GEN.DB_NULL(Obj_Reader, 56, 0),
    '            .HOSP_QUILLOTA = D_GEN.DB_NULL(Obj_Reader, 57, 0),
    '            .HOSP_CABILDO = D_GEN.DB_NULL(Obj_Reader, 58, 0),
    '            .HOSP_LIGUA = D_GEN.DB_NULL(Obj_Reader, 59, 0),
    '            .HOSP_QUINTERO = D_GEN.DB_NULL(Obj_Reader, 60, 0),
    '            .OTROS = D_GEN.DB_NULL(Obj_Reader, 61, 0),
    '            .TOTAL_EXTRA = D_GEN.DB_NULL(Obj_Reader, 62, 0),
    '            .ID_SECC_REM = D_GEN.DB_NULL(Obj_Reader, 63, 0),
    '            .SECC_REM_DESC = D_GEN.DB_NULL(Obj_Reader, 64, ""),
    '            .ID_AREA_REM = D_GEN.DB_NULL(Obj_Reader, 65, 0),
    '            .AREA_DESC = D_GEN.DB_NULL(Obj_Reader, 66, ""),
    '            .ID_FONASA_REM_HOSP = D_GEN.DB_NULL(Obj_Reader, 67, Nothing)
    '        }
    '        'Agregamos el item a la lista
    '        E_Proc_List.Add(E_Proc_Item)
    '    End While

    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_List
    'End Function
End Class
