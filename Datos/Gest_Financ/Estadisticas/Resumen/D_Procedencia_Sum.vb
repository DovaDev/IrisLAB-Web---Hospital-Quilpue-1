'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Procedencia_Sum
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR(ByVal ID_PRE As Integer, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE", OleDbType.BigInt).Value = ID_PRE
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR
            E_Prev_Item.TOTAL_ATE = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.TOTAL_PREVE = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Prev_Item.TOT_FONASA = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Prev_Item.TOTA_SIS = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Prev_Item.TOTA_USU = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Prev_Item.TOTA_COPA = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            E_Prev_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            E_Prev_Item.ID_PROCEDENCIA = DD_Gen.DB_NULL(Obj_Reader, 7, 0)
            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function
End Class
