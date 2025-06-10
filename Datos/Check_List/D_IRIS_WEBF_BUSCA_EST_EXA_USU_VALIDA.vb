'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.VarChar).Value = DESDE
            .Add("@HASTA", OleDbType.VarChar).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
            E_Proc_Item.Folio = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            Dim F_Ing As String() = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing).ToString().Split(" ")

            E_Proc_Item.Fecha_Ingreso = F_Ing(0)
            E_Proc_Item.Hora_Ingreso = F_Ing(1)

            E_Proc_Item.Rut = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.Nombre_Pac = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)


            Dim F_Val As String() = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing).ToString().Split(" ")

            E_Proc_Item.Fecha_Valida = F_Val(0)
            E_Proc_Item.Hora_Valida = F_Val(1)

            E_Proc_Item.Usuario_Valida = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.Examen = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.Procedencia = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA_3(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.VarChar).Value = DESDE
            .Add("@HASTA", OleDbType.VarChar).Value = HASTA
            .Add("@ID_CF", OleDbType.Numeric).Value = ID_CF
            .Add("@ID_USU", OleDbType.Numeric).Value = ID_USU
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
            E_Proc_Item.Folio = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)

            Dim F_Ing As String() = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing).ToString().Split(" ")

            E_Proc_Item.Fecha_Ingreso = F_Ing(0)
            E_Proc_Item.Hora_Ingreso = F_Ing(1)

            E_Proc_Item.Rut = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.Nombre_Pac = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)


            Dim F_Val As String() = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing).ToString().Split(" ")

            E_Proc_Item.Fecha_Valida = F_Val(0)
            E_Proc_Item.Hora_Valida = F_Val(1)

            E_Proc_Item.Usuario_Valida = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.Examen = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.Procedencia = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.PRU_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.ATE_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.ATE_RESULTADO_NUM = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.ATE_OBS_FICHA = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.ATE_OBS_TM = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
