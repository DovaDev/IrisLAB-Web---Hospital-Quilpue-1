'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
    'Declaraciones Generales
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER(ByVal ID_PAC As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@ID_PRO", OleDbType.Integer).Value = CType(objSession("USU_ID_PROC"), Integer)
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.TP_ATE_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER_AGENDA(ByVal ID_PAC As Integer) As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER_AGENDA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PAC", OleDbType.Numeric).Value = ID_PAC
            .Add("@IDPRO", OleDbType.Integer).Value = CType(objSession("USU_TM"), Integer)
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.TP_ATE_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PREI_FECHA_PRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
