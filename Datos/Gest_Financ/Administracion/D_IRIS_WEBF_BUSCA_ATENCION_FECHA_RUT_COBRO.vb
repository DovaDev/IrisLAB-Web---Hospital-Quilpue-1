Imports Entidades
Imports System.Data.OleDb
Imports Conexion
Public Class D_IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO
    'Declaraciones Generales
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO(ByVal DESDE As String, ByVal HASTA As String, ByVal RUT_DNI As String) As List(Of E_Cobro_RUT)
        'Declaraciones
        CC_ConnBD = New ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_Cobro_RUT
        Dim E_Proc_List As New List(Of E_Cobro_RUT)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
            .Add("@RUT_DNI", OleDbType.VarChar).Value = RUT_DNI
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
            E_Proc_Item = New E_Cobro_RUT
            E_Proc_Item.FOLIO = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.FECHA = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.RUT = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.DNI = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PREVISION = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()

        For Each Item In E_Proc_List
            Dim DD_Data As New D_IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO
            Item.EXAMENES = DD_Data.IRIS_WEBF_BUSCA_EXA_FECHA_RUT_COBRO(Item.FOLIO)
        Next

        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_EXA_FECHA_RUT_COBRO(ByVal FOLIO As String) As List(Of E_EXA)
        'Declaraciones
        CC_ConnBD = New ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_EXA
        Dim E_Proc_List As New List(Of E_EXA)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EXA_FECHA_RUT_COBRO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@FOLIO", OleDbType.VarChar).Value = FOLIO
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
            E_Proc_Item = New E_EXA
            E_Proc_Item.CF_COD = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.VALOR = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()

        For Each Item In E_Proc_List

        Next

        Return E_Proc_List
    End Function

End Class
