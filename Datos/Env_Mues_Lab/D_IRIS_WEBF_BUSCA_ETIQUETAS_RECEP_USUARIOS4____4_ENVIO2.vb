'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2

            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ENVIO_ETI = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2_CON_PENDIENTES_666(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2_CON_PENDIENTES_666_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2

            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ENVIO_ETI_NUM_ATE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ENVIO_ETI_CURVA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ENVIO_ETI_FECHA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ENVIO_ETI = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            'E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ENVIO_NUM = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.ATE_NUM_OMI = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ATE_CODIGO_TEST = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ATE_CF_MULTIPLICADOS = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.HEX = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.COLOR_DESC = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
