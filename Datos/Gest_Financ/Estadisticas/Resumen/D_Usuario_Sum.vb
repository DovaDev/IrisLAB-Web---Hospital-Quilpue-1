'Importar Capas
Imports Conexion
Imports Entidades
'Importar  Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Usuario_Sum
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_USUARIO2() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Usuario_Item As E_IRIS_WEBF_BUSCA_USUARIO2
        Dim E_Usuario_List As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_USUARIO_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la base de datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Usuario_Item = New E_IRIS_WEBF_BUSCA_USUARIO2
            E_Usuario_Item.ID_USUARIO = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Usuario_Item.USU_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Usuario_Item.USU_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Usuario_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Usuario_Item.PER_USU_DESC = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Usuario_Item.USU_NIC = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            E_Usuario_List.Add(E_Usuario_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Usuario_List
    End Function
    Function IRIS_WEBF_BUSCA_USUARIO3() As List(Of E_IRIS_WEBF_BUSCA_USUARIO3)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Usuario_Item As E_IRIS_WEBF_BUSCA_USUARIO3
        Dim E_Usuario_List As New List(Of E_IRIS_WEBF_BUSCA_USUARIO3)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_USUARIO3_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Conectar con la base de datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Usuario_Item = New E_IRIS_WEBF_BUSCA_USUARIO3
            E_Usuario_Item.ID_USUARIO = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Usuario_Item.USU_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Usuario_Item.USU_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Usuario_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Usuario_Item.USU_NIC = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Usuario_Item.USU_ID_PREV = DD_Gen.DB_NULL(Obj_Reader, 5, "")
            E_Usuario_Item.USU_ID_PROC = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            E_Usuario_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 7, "")
            E_Usuario_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 8, "")
            E_Usuario_Item.ADMIN_DESC = DD_Gen.DB_NULL(Obj_Reader, 9, "")
            E_Usuario_List.Add(E_Usuario_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Usuario_List
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO(ByVal ID_USUARIO As Integer, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Usuario_Sum_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO
        Dim E_Usuario_Sum_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE", OleDbType.BigInt).Value = ID_USUARIO
            .Add("@DESDE", OleDbType.Date).Value = Date_01
            .Add("@HASTA", OleDbType.Date).Value = Date_02
        End With
        'Conectar con la base de datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Usuario_Sum_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO
            E_Usuario_Sum_Item.TOTAL_ATE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Usuario_Sum_Item.TOTAL_PREVE = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Usuario_Sum_Item.TOT_FONASA = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Usuario_Sum_Item.TOTA_SIS = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Usuario_Sum_Item.TOTA_USU = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Usuario_Sum_Item.TOTA_COPA = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            E_Usuario_Sum_Item.USU_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 6, 0)
            E_Usuario_Sum_Item.USU_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 7, 0)
            E_Usuario_Sum_Item.ID_USUARIO = DD_Gen.DB_NULL(Obj_Reader, 8, 0)
            E_Usuario_Sum_List.Add(E_Usuario_Sum_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Usuario_Sum_List
    End Function
End Class
