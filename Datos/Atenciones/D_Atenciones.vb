'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Atenciones
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS(ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS)
        'Declaraciones Internas
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar Parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = Date_01
            .Add("@HASTA", OleDbType.Date).Value = Date_02
        End With
        'Establecer conexión
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, CDate("01/01/0001"))
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM(ByVal Date_1 As Date, ByVal Date_2 As Date, ByVal ID_TM As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = Date_1
            .Add("@HASTA", OleDbType.Date).Value = Date_2
            .Add("@ID_TM", OleDbType.Numeric).Value = ID_TM
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, CDate("01/01/0001"))
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 12, 0)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, "")

            'Agreggar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
