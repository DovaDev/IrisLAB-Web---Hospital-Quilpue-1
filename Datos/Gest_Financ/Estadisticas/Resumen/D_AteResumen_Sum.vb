'Importar Capas
Imports Conexion
Imports Entidades
'Importar  Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_AteResumen_Sum
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2(ByVal ID_TM As Long, ByVal ID_PREVE As Long, ByVal ID_PRG As Long, ByVal ID_SUB As Long, ByVal Date_01 As Date, _
                                                                      ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Prev_Item As E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2
        Dim E_Prev_List As New List(Of E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = Date_01
            .Add("@HASTA", OleDbType.Date).Value = Date_02
            .Add("@ID_FP", OleDbType.Numeric).Value = ID_PRG
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREVE
            .Add("@ID_TM", OleDbType.Numeric).Value = ID_TM
            .Add("@ID_SUBP", OleDbType.Numeric).Value = ID_SUB
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
            E_Prev_Item = New E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2
            E_Prev_Item.ID_ATENCION = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Prev_Item.ATE_NUM = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Prev_Item.ATE_FECHA = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Prev_Item.PAC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 3, "")
            E_Prev_Item.PAC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 4, "")
            E_Prev_Item.CF_DESC = DD_Gen.DB_NULL(Obj_Reader, 5, "")
            E_Prev_Item.CF_COD = DD_Gen.DB_NULL(Obj_Reader, 6, 0)
            E_Prev_Item.ATE_AÑO = DD_Gen.DB_NULL(Obj_Reader, 7, 0)
            E_Prev_Item.PRU_DESC = DD_Gen.DB_NULL(Obj_Reader, 8, "")
            E_Prev_Item.ATE_RESULTADO = DD_Gen.DB_NULL(Obj_Reader, 9, "")
            E_Prev_Item.ATE_RESULTADO_NUM = DD_Gen.DB_NULL(Obj_Reader, 10, 0)
            E_Prev_Item.ID_CODIGO_FONASA = DD_Gen.DB_NULL(Obj_Reader, 11, 0)
            E_Prev_Item.ID_PRUEBA = DD_Gen.DB_NULL(Obj_Reader, 12, 0)
            E_Prev_Item.PAC_FNAC = DD_Gen.DB_NULL(Obj_Reader, 13, "")
            E_Prev_Item.UM_DESC = DD_Gen.DB_NULL(Obj_Reader, 14, "")
            E_Prev_Item.ID_TP_RESULTADO = DD_Gen.DB_NULL(Obj_Reader, 15, 0)
            E_Prev_Item.TP_RESUL_DESC = DD_Gen.DB_NULL(Obj_Reader, 16, "")
            E_Prev_Item.TP_RESUL_COD = DD_Gen.DB_NULL(Obj_Reader, 17, 0)
            E_Prev_Item.ID_U_MEDIDA = DD_Gen.DB_NULL(Obj_Reader, 18, 0)
            E_Prev_Item.PREVE_DESC = DD_Gen.DB_NULL(Obj_Reader, 19, "")
            E_Prev_Item.PROC_DESC = DD_Gen.DB_NULL(Obj_Reader, 20, "")
            E_Prev_Item.PROGRA_DESC = DD_Gen.DB_NULL(Obj_Reader, 21, "")
            E_Prev_Item.PAC_RUT = DD_Gen.DB_NULL(Obj_Reader, 22, "")
            E_Prev_Item.PRU_ORDEN = DD_Gen.DB_NULL(Obj_Reader, 23, 0)
            'E_Prev_Item.SUBP_DESC = DD_Gen.DB_NULL(Obj_Reader, 24, "")
            E_Prev_Item.ATE_OMI = DD_Gen.DB_NULL(Obj_Reader, 24, "")
            E_Prev_Item.SEXO_DESC = DD_Gen.DB_NULL(Obj_Reader, 25, "")

            E_Prev_List.Add(E_Prev_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Prev_List
    End Function
End Class
