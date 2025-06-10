'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions



    Shared Function Update_Anatomico(SITIO_ANATO As String, ID_ATE_RES As Integer, ID_CODIGO_FONASA As Integer)
        Dim CC_ConnBD As New Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        Dim Read_Sql As Integer

        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_UPDATE_ZONA_ANATOMICA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ATE_RESULTADO", OleDbType.VarChar).Value = SITIO_ANATO
            .Add("@ID_ATE_RES", OleDbType.Integer).Value = ID_ATE_RES
            .Add("@ID_CODIGO_FONASA", OleDbType.Integer).Value = ID_CODIGO_FONASA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Read_Sql = Cmd_SQL.ExecuteNonQuery

        Return Read_Sql
    End Function
    Shared Function Detalle_Atencion_Toma_De_Muestra(ID_ATENCION As Integer) As List(Of E_Detalle_Atencion_Toma_De_Muestra)
        Dim CC_ConnBD As New Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEB_BUSCA_DETALLE_TOMA_MUESTRA_PARA_ATENDER_POR_EXAMEN_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Integer).Value = ID_ATENCION
        End With
        CC_ConnBD.Oledbconexion.Open()
        Obj_Reader = Cmd_SQL.ExecuteReader
        Dim E_Proc_List As New List(Of E_Detalle_Atencion_Toma_De_Muestra)
        While Obj_Reader.Read
            Dim E_Proc_Item = New E_Detalle_Atencion_Toma_De_Muestra
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ATE_FEC_TM = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.USU_FULL_NAME = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_EST_TM = DD_GEN.DB_NULL(Obj_Reader, 7, 0)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.SITIO_ANATO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.IS_ANATO = DD_GEN.DB_NULL(Obj_Reader, 11, False)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 13, 0)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORD As Integer, ByVal ID_PROC As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)
        'Declaraciones'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS_TEST3"
            '.CommandText = "IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS_TEST3_V2"
            .CommandText = "IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS_TEST3_V4"

            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = Date.ParseExact(DESDE, "dd-MM-yyyy", Nothing)
            .Add("@HASTA", OleDbType.Date).Value = Date.ParseExact(HASTA, "dd-MM-yyyy", Nothing)
            .Add("@ID_ORD", OleDbType.Integer).Value = ID_ORD
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PAC_FONO1 = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PAC_MOVIL1 = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ESPERA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_ID_ESTADO_TM = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            
            E_Proc_Item.PESO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.TALLA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.HGT = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.FECHA_HORA_ULTIMA_DOSIS = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.DIURESIS = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.GRAMAJE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.PAC_OBS_PERMA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.ZONA_TM = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.NOM_SOC = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.FECHA_ACTUAL = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.GENERO_DESC = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.ETNIA_DESC = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.HORA_SEGUNDA_PTGO = DD_GEN.DB_NULL(Obj_Reader, 33, "")
            E_Proc_Item.TIENE_PTGO = DD_GEN.DB_NULL(Obj_Reader, 34, False)
            E_Proc_Item.HORA_TOMA_SEGUNDA_CARGA = DD_GEN.DB_NULL(Obj_Reader, 35, "")
            E_Proc_Item.IS_COMPLETE_ANATO = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
