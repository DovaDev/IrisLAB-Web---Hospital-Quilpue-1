'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Prevision_Details
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_PREVISION(ByVal ID_PRE As Long, ByVal Date_1 As Date, ByVal Date_2 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION
        Dim E_Prev_list As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_PREVISION_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE", OleDbType.Numeric).Value = ID_PRE
            .Add("@DESDE", OleDbType.Date).Value = Date_1
            .Add("@HASTA", OleDbType.Date).Value = Date_2
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION
            E_Prev_Item.ID_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.ATE_NUM = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Prev_Item.ATE_FECHA = DD_Gen.DB_NULL(Obj_Reader, 2, CDate("01/01/0001"))
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Prev_Item.ID_PREVE = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Prev_Item.ID_ESTADO = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            E_Prev_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 6, "")
            E_Prev_Item.CF_COD = DD_Gen.DB_NULL(Obj_Reader, 7, "")
            E_Prev_Item.ATE_DET_V_PREVI = DD_Gen.DB_NULL(Obj_Reader, 8, 0)
            E_Prev_Item.ATE_DET_V_PAGADO = DD_Gen.DB_NULL(Obj_Reader, 9, 0)
            E_Prev_Item.ATE_DET_V_COPAGO = DD_Gen.DB_NULL(Obj_Reader, 10, 0)
            E_Prev_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 11, "")
            E_Prev_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 12, 0)
            E_Prev_Item.PAC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 13, "")
            E_Prev_Item.PAC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 14, "")
            E_Prev_Item.PAC_RUT = DD_Gen.DB_NULL(Obj_Reader, 15, "")
            E_Prev_Item.PAC_DNI = DD_Gen.DB_NULL(Obj_Reader, 16, "")
            'Agreggar items a la lista
            E_Prev_list.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_list
    End Function
End Class
