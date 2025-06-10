'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_historial
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CODIGO_FONASA", OleDbType.Numeric).Value = ID_CODIGO_FONASA
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA

            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 3, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ByVal ID_ATE As Integer,
                                                            ByVal ID_CF As Integer,
                                                            ByVal TOT_ANT As Integer,
                                                            ByVal COP_ANT As Integer,
                                                            ByVal PRE_ANT As Integer,
                                                            ByVal PRE_NV As Integer,
                                                            ByVal COP_NV As Integer,
                                                            ByVal TOT_NV As Integer,
                                                            ByVal TOT_FIN As Integer,
                                                            ByVal ID_EST As Integer,
                                                            ByVal ID_USU As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand


        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@TOT_ANT", OleDbType.Numeric).Value = TOT_ANT
            .Add("@COP_ANT", OleDbType.Numeric).Value = COP_ANT
            .Add("@PRE_ANT", OleDbType.Numeric).Value = PRE_ANT
            .Add("@PRE_NV", OleDbType.Numeric).Value = PRE_NV
            .Add("@COP_NV", OleDbType.Numeric).Value = COP_NV
            .Add("@TOT_NV", OleDbType.Numeric).Value = TOT_NV
            .Add("@TOT_FIN", OleDbType.Numeric).Value = TOT_FIN
            .Add("@ID_EST", OleDbType.Numeric).Value = ID_EST
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function



    Function IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2(ByVal ID_ATE As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2"
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2

            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_DET_V_COPAGO = DD_GEN.DB_NULL(Obj_Reader, 1, 0)
            E_Proc_Item.ATE_DET_V_PAGADO = DD_GEN.DB_NULL(Obj_Reader, 2, 0)
            E_Proc_Item.ATE_DET_V_PREVI = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 4, 0)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function



End Class