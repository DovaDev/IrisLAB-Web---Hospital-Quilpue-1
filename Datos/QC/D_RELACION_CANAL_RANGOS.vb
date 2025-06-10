Imports Entidades
Imports System.Data.OleDb
Public Class D_RELACION_CANAL_RANGOS
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_RELACION_CANAL_RANGOS(ByVal ID_I As Integer,
                                          ByVal ID_MAQ As Integer,
                                          ByVal CANAL As String,
                                          ByVal DETER As String,
                                          ByVal R_DESDE As String,
                                          ByVal R_HASTA As String,
                                          ByVal RR_DESDE As String,
                                          ByVal RR_HASTA As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_RELACION_CANAL_RANGOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_I", OleDbType.Integer).Value = ID_I
            .Add("@ID_MAQ", OleDbType.Integer).Value = ID_MAQ
            .Add("@CANAL", OleDbType.VarChar).Value = CANAL
            .Add("@DETER", OleDbType.VarChar).Value = DETER
            .Add("@R_DESDE", OleDbType.VarChar).Value = R_DESDE
            .Add("@R_HASTA", OleDbType.VarChar).Value = R_HASTA
            .Add("@RR_DESDE", OleDbType.VarChar).Value = RR_DESDE
            .Add("@RR_HASTA", OleDbType.VarChar).Value = RR_HASTA

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


    Function IRIS_WEBF_UPDATE_ESTADO_RELACION_CANAL_RANGOS(ByVal ID_REL As Integer,
                                                    ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_ESTADO_RELACION_CANAL_RANGOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_REL", OleDbType.Integer).Value = ID_REL
            .Add("@ID_ESTADO", OleDbType.Integer).Value = ID_ESTADO

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
    Function IRIS_WEBF_UPDATE_RELACION_CANAL_RANGOS(ByVal ID_REL As Integer,
                                                    ByVal ID_I As Integer,
                                          ByVal ID_MAQ As Integer,
                                          ByVal CANAL As String,
                                          ByVal DETER As String,
                                          ByVal R_DESDE As String,
                                          ByVal R_HASTA As String,
                                          ByVal RR_DESDE As String,
                                          ByVal RR_HASTA As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_RELACION_CANAL_RANGOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_REL", OleDbType.Integer).Value = ID_REL
            .Add("@ID_I", OleDbType.Integer).Value = ID_I
            .Add("@ID_MAQ", OleDbType.Integer).Value = ID_MAQ
            .Add("@CANAL", OleDbType.VarChar).Value = CANAL
            .Add("@DETER", OleDbType.VarChar).Value = DETER
            .Add("@R_DESDE", OleDbType.VarChar).Value = R_DESDE
            .Add("@R_HASTA", OleDbType.VarChar).Value = R_HASTA
            .Add("@RR_DESDE", OleDbType.VarChar).Value = RR_DESDE
            .Add("@RR_HASTA", OleDbType.VarChar).Value = RR_HASTA

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


    Function IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS() As List(Of E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS

            E_Proc_Item.ID_REL_CANAL_MAQ = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IRIS_LNK_I_ID = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.IRIS_LNK_MAQ_ID = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.REL_CM_CANAL_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.REL_CM_DETER_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.REL_CM_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.REL_CM_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.REL_CM_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.REL_CM_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.IRIS_LNK_I_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.IRIS_LNK_MAQ_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

End Class
