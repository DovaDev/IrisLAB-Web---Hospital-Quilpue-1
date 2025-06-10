'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO

            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_PACIENTE = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 7, New Date)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 9, 0)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.ATE_RR_ALTOBAJO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 15, "")
            E_Proc_Item.ATE_RESULTADO_ALT = DD_GEN.DB_NULL(Obj_Reader, 16, "")
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, "")
            E_Proc_Item.ORD_DESC = DD_GEN.DB_NULL(Obj_Reader, 18, "")
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 19, "")
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 20, 0)
            E_Proc_Item.ID_ATE_RES = DD_GEN.DB_NULL(Obj_Reader, 21, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ByVal ID_ATE_RES As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal DET_CRITICO_DESC As String,
                                                              ByVal ID_TP_CRITICO As Integer,
                                                              ByVal FECHA As Date,
                                                              ByVal CAUSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@DET_CRITICO_DESC", OleDbType.VarChar).Value = DET_CRITICO_DESC
            .Add("@ID_TP_CRITICO", OleDbType.Numeric).Value = ID_TP_CRITICO
            .Add("@FECHA", OleDbType.Date).Value = FECHA
            .Add("@CAUSA", OleDbType.VarChar).Value = CAUSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
    Function IRIS_WEBF_UPDATE_DET_ATENCION_ATE_RESULTADO_NOTIFICACION_AVISO(ByVal ID_ATENCION As Integer,
                                                            ByVal ID_CODIGO_FONASA As Integer,
                                                            ByVal ID_ATE_RES As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_DET_ATENCION_ATE_RESULTADO_NOTIFICACION_AVISO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
            .Add("@ID_ATE_RES", OleDbType.Numeric).Value = ID_ATE_RES
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function
End Class