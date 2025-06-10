Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@DETE", OleDbType.BigInt).Value = ID_DET
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20

            E_Proc_Item.ID_QC_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_QC_ANALIZADOR = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_QC_LOTE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_QC_DETERMINACION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.QC_RESUL_FECHA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_1 = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_2 = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_3 = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.QC_RESUL_COMENTARIOS = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.QC_RESUL_HORA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.QC_RESUL_OMITIDO = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long, ByVal FECHA As String, ByVal N As Long) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        Dim _Time As Date

        _Time = CDate(FECHA)
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@DETE", OleDbType.BigInt).Value = ID_DET
            .Add("@FECHA", OleDbType.Date).Value = _Time
            .Add("@N", OleDbType.BigInt).Value = N
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2

            E_Proc_Item.QC_RESUL_VALOR_1 = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_2 = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_3 = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.QC_RESUL_HORA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.QC_COMENTARIOS = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_QC_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_TP_QC_ACCION = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.QC_RESUL_OMITIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_ULT(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long, ByVal N As Long) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_ULT"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@DETE", OleDbType.BigInt).Value = ID_DET
            .Add("@N", OleDbType.BigInt).Value = N
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2

            E_Proc_Item.QC_RESUL_VALOR_1 = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_2 = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_3 = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.QC_RESUL_HORA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.QC_COMENTARIOS = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_QC_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_TP_QC_ACCION = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.QC_RESUL_OMITIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long, ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2
        Dim E_Proc_List As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANA", OleDbType.BigInt).Value = ID_ANA
            .Add("@LOTE", OleDbType.BigInt).Value = ID_LOTE
            .Add("@DETE", OleDbType.BigInt).Value = ID_DET
            .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
            .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
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
            E_Proc_Item = New E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2

            E_Proc_Item.QC_RESUL_VALOR_1 = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_2 = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.QC_RESUL_VALOR_3 = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.QC_RESUL_HORA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.QC_COMENTARIOS = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_QC_RESULTADO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.ID_TP_QC_ACCION = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.QC_RESUL_OMITIDO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

End Class
