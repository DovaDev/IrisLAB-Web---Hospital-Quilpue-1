'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS)
        'Declaraciones Generales
        Dim CC_ConnBD As Conexion.ConexionBD
        Dim DD_GEN As New D_General_Functions
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS
        Dim E_Proc_List As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS)
        'Configuración general
        If (ID_PRUEBA = 0) Then
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        Else
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
        End If
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_PRUEBA ", OleDbType.Numeric).Value = ID_PRUEBA
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
            E_Proc_Item = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.ATE_AÑO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PRUEBA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.UM_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.ID_TP_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.TP_RESUL_DESC = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)
            E_Proc_Item.TP_RESUL_COD = DD_GEN.DB_NULL(Obj_Reader, 18, Nothing)
            E_Proc_Item.ID_U_MEDIDA = DD_GEN.DB_NULL(Obj_Reader, 19, Nothing)
            E_Proc_Item.ATE_EST_VALIDA = DD_GEN.DB_NULL(Obj_Reader, 20, Nothing)
            E_Proc_Item.ATE_RR_DESDE = DD_GEN.DB_NULL(Obj_Reader, 21, Nothing)
            E_Proc_Item.ATE_RR_HASTA = DD_GEN.DB_NULL(Obj_Reader, 22, Nothing)
            E_Proc_Item.ATE_R_DESDE = DD_GEN.DB_NULL(Obj_Reader, 23, Nothing)
            E_Proc_Item.ATE_R_HASTA = DD_GEN.DB_NULL(Obj_Reader, 24, Nothing)
            E_Proc_Item.PRU_DECIMAL = DD_GEN.DB_NULL(Obj_Reader, 25, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
