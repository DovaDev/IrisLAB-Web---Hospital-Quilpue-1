'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Ate_Det
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION() As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, 0)

            'Agreggar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, CDate("01/01/0001"))
            E_Proc_Item.ATE_FUR = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 10, CDate("01/01/0001"))
            E_Proc_Item.PAC_DIR = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.PAC_FONO1 = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.PAC_MOVIL1 = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_EMAIL = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.NAC_DESC = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.COM_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.CIU_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 19, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 20, "")
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.ATE_TOTAL = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
            E_Proc_Item.ATE_TOTAL_PREVI = DD_GEN.DB_NULL(Obj_Reader, 23, 0)
            E_Proc_Item.ATE_TOTAL_COPA = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ATE_AUTORIZO_RETIRO = DD_GEN.DB_NULL(Obj_Reader, 25, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 26, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 27, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 28, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 29, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.ATE_DET_V_ID_USU = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ATE_DET_V_FECHA = DD_GEN.DB_NULL(Obj_Reader, 8, CDate("01/01/0001"))
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.ATE_DET_IMPRIME = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 11, CDate("01/01/0001"))
            E_Proc_Item.TP_PAGO_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_TP_PAGO = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.ATE_DET_NUM_COPIA = DD_GEN.DB_NULL(Obj_Reader, 14, 0)
            E_Proc_Item.CF_DIAS = DD_GEN.DB_NULL(Obj_Reader, 15, 0)
            E_Proc_Item.CF_IMP_SOLA = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.CF_IMP_NOM_PER = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.CF_IMP_PARCIAL = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.CF_IMP_POSX = DD_GEN.DB_NULL(Obj_Reader, 19, 0)
            E_Proc_Item.CF_IMP_POSY = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.CF_IMP_LETRA = DD_GEN.DB_NULL(Obj_Reader, 21, "")
            E_Proc_Item.CF_IMP_TAMANO = DD_GEN.DB_NULL(Obj_Reader, 22, 0)
            E_Proc_Item.SECC_DESC = DD_GEN.DB_NULL(Obj_Reader, 23, "")
            E_Proc_Item.ESTADO_WEB_DERIVADO = DD_GEN.DB_NULL(Obj_Reader, 24, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 25, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DETALLE_ATENCION3(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_ATENCION3)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DETALLE_ATENCION3
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DETALLE_ATENCION3)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DETALLE_ATENCION3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DETALLE_ATENCION3
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.CF_CORTO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCAR_RUTA_PDF_DER(ByVal ID_ATE As Long, ByVal ID_CF As Long) As List(Of E_IRIS_WEBF_BUSCAR_RUTA_PDF_DER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCAR_RUTA_PDF_DER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCAR_RUTA_PDF_DER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCAR_RUTA_PDF_DER"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCAR_RUTA_PDF_DER
            E_Proc_Item.IRIS_ID_REL = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.IRIS_ID_CF = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.IRIS_ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.IRIS_RUTA_PDF = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.IRIS_ID_USU_SUBE_EX = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.IRIS_ID_PAC = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.IRIS_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 6, 0)
            E_Proc_Item.IRIS_FECHA_REL = DD_GEN.DB_NULL(Obj_Reader, 7, CDate("01/01/0001"))
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
