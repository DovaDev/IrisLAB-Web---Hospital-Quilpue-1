'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer, ByVal ID_VAL As Integer, ByVal ID_RECHA As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@TIPO", OleDbType.Numeric).Value = TIPO
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_VAL", OleDbType.Numeric).Value = ID_VAL
            .Add("@ID_RECHA", OleDbType.Numeric).Value = ID_RECHA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_EXAMEN_VALIDADO
            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.IDTM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_DET_V_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_DET_REV_ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.Expr1 = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.Expr2 = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)


            E_Proc_Item.FECHA_NAC = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.NACIONALIDAD = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.SECTOR = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.NUMERO_INTERNO = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.MEDICO_SOLICITANTE = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.MEDICO_SOLICITANTE_2 = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)




            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
