'Importar Capas
Imports Conexion
Imports Entidades
'Importar  Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_Paciente_Sum
    'Declaraciones generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_Gen As New D_General_Functions
    Function IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES(ByVal ID_PREVE As Integer, ByVal Date_01 As Date, _
                                               ByVal Date_02 As Date) As  _
                                                List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        'Declaraciones SQL
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones "lista"
        Dim E_Pac_Item As E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES
        Dim E_Pac_List As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        'Configuración General
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PRE", OleDbType.BigInt).Value = ID_PREVE
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
            E_Pac_Item = New E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES
            E_Pac_Item.ATE_NUM = DD_Gen.DB_NULL(Obj_Reader, 0, 0)
            E_Pac_Item.PAC_RUT = DD_Gen.DB_NULL(Obj_Reader, 1, 0)
            E_Pac_Item.PAC_NOMBRE = DD_Gen.DB_NULL(Obj_Reader, 2, 0)
            E_Pac_Item.PAC_APELLIDO = DD_Gen.DB_NULL(Obj_Reader, 3, 0)
            E_Pac_Item.TP_PAGO_DESC = DD_Gen.DB_NULL(Obj_Reader, 4, 0)
            E_Pac_Item.ATE_TOTAL_PREVI = DD_Gen.DB_NULL(Obj_Reader, 5, 0)
            E_Pac_Item.ATE_TOTAL_COPA = DD_Gen.DB_NULL(Obj_Reader, 6, 0)
            E_Pac_List.Add(E_Pac_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Pac_List
    End Function
End Class
