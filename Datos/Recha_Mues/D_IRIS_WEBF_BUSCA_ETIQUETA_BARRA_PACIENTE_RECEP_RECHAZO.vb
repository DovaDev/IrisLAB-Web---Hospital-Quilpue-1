'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO_2(ByVal NUM_ATE As String, ByVal CB As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO_2_NEW"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.VarChar).Value = NUM_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.CB_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_FEC_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_USU_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_DET_ATE = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_NUM_OMI = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_CODIGO_TEST = DD_GEN.DB_NULL(Obj_Reader, 14, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO(ByVal NUM_ATE As String, ByVal CB As String) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NUM_ATE", OleDbType.VarChar).Value = NUM_ATE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO

            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.CB_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ATE_FEC_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_USU_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_EST_RECHAZO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
