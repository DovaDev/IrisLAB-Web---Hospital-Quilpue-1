'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222(ByVal ID_ATE As Integer, ByVal ID_PER As Integer, ByVal CB As String) As List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_666"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@CB", OleDbType.VarChar).Value = CB
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222

            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FEC_TM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_USU_TM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_EST_TM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.EST1 = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_FEC_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_USU_RECEP = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.EST2 = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_FEC_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_USU_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST3 = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_FEC_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_USU_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_FEC_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_USU_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.EST_D = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.EST_R = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.UTM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.URECEP = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.UVALIDA = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.URECHAZO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.UDERI = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.UENVIO = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.ATE_FEC_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.EST_E = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_2(ByVal ID_ATE As Integer, ByVal ID_PER As Integer, ByVal CB As String) As List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_666_2_TEST"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
            .Add("@CB", OleDbType.VarChar).Value = CB
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222

            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_FEC_TM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_USU_TM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ATE_EST_TM = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.EST1 = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_FEC_RECEP = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_USU_RECEP = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_EST_RECEP = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.EST2 = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ATE_FEC_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_USU_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.EST3 = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ATE_FEC_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.ATE_USU_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ATE_EST_DERIVA = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_FEC_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_USU_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.EST_D = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.EST_R = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.UTM = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.URECEP = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            E_Proc_Item.UVALIDA = DD_GEN.DB_NULL(Obj_Reader, 26, Nothing)
            E_Proc_Item.URECHAZO = DD_GEN.DB_NULL(Obj_Reader, 27, Nothing)
            E_Proc_Item.UDERI = DD_GEN.DB_NULL(Obj_Reader, 28, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 29, Nothing)
            E_Proc_Item.UENVIO = DD_GEN.DB_NULL(Obj_Reader, 30, Nothing)
            E_Proc_Item.ATE_FEC_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 31, Nothing)
            E_Proc_Item.EST_E = DD_GEN.DB_NULL(Obj_Reader, 32, Nothing)
            E_Proc_Item.ATE_EST_ENVIO = DD_GEN.DB_NULL(Obj_Reader, 33, Nothing)

            E_Proc_Item.ENVIO_FECHA_RECEP = DD_GEN.DB_NULL(Obj_Reader, 34, Nothing)
            E_Proc_Item.ID_USUARIO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 35, Nothing)
            E_Proc_Item.ID_ESTADO_RECEP = DD_GEN.DB_NULL(Obj_Reader, 36, Nothing)
            E_Proc_Item.USUARIO_ENV_RECEP = DD_GEN.DB_NULL(Obj_Reader, 37, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
