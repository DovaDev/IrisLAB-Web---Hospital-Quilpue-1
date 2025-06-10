'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class D_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
    'Declaraciones Generales
    Dim CC_ConnBD As Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions


    Function IRIS_WEBF_EDITA_DOC(ByVal RUT As String, ByVal NOMBRE As String, ByVal ID As Long) As Long
        If (NOMBRE <> "") Then
            'Declaraciones
            CC_ConnBD = New Conexion.ConexionBD
            Dim Cmd_SQL As New OleDb.OleDbCommand
            Dim Obj_Reader As Integer
            'Configuración general
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_EDITA_DOC_ING"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
            'Enviar parámetros
            With Cmd_SQL.Parameters
                .Add("@RUT", OleDbType.VarChar).Value = RUT
                .Add("@NOM", OleDbType.VarChar).Value = NOMBRE
                .Add("@ID", OleDbType.BigInt).Value = ID
            End With
            'Conectar con la Base de Datos
            Select Case CC_ConnBD.Oledbconexion.State
                Case ConnectionState.Open
                    CC_ConnBD.Oledbconexion.Close()
                Case Else
                    CC_ConnBD.Oledbconexion.Open()
            End Select
            'ejecutar PA y recibir un integer con la cantidad de filas afectadas
            Obj_Reader = Cmd_SQL.ExecuteNonQuery()

            CC_ConnBD.Oledbconexion.Close()
            Return ID
        Else
            Return Nothing
        End If

    End Function

    Function IRIS_WEBF_GRABA_DOC(ByVal RUT As String, ByVal NOMBRE As String, ByVal APELLIDO As String) As Long

        If (NOMBRE <> "") Then
            'Declaraciones
            CC_ConnBD = New Conexion.ConexionBD
            Dim Cmd_SQL As New OleDb.OleDbCommand
            Dim Obj_Reader As OleDbDataReader
            Dim E_Proc_Item As Long
            'Configuración general
            With Cmd_SQL
                .CommandType = CommandType.StoredProcedure
                .CommandText = "IRIS_WEBF_GRABA_DOC_ING"
                .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
            End With
            'Enviar parámetros
            With Cmd_SQL.Parameters
                .Add("@RUT", OleDbType.VarChar).Value = RUT
                .Add("@NOM", OleDbType.VarChar).Value = NOMBRE
                .Add("@APE", OleDbType.VarChar).Value = APELLIDO
            End With
            'Conectar con la Base de Datos
            Select Case CC_ConnBD.Oledbconexion.State
                Case ConnectionState.Open
                    CC_ConnBD.Oledbconexion.Close()
                Case Else
                    CC_ConnBD.Oledbconexion.Open()
            End Select
            'ejecutar PA y recibir un integer con la cantidad de filas afectadas
            Obj_Reader = Cmd_SQL.ExecuteReader()
            While Obj_Reader.Read
                E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            End While
            CC_ConnBD.Oledbconexion.Close()
            Return E_Proc_Item
        Else
            Return Nothing
        End If


    End Function


    Function IRIS_WEBF_BUSCA_DOC_POR_NOM_APE(ByVal NOM As String) As List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim E_Proc_Item As New E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_3"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NOM", OleDbType.VarChar).Value = NOM
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
            E_Proc_Item.ID_DOC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.DOC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_2(ByVal NOM As String, ByVal APE As String) As List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim E_Proc_Item As New E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOC_POR_NOM_APE_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@NOM", OleDbType.VarChar).Value = NOM
            .Add("@APE", OleDbType.VarChar).Value = APE
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
            E_Proc_Item.ID_DOC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.DOC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE(ByVal RUT As String) As E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim E_Proc_Item As New E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        Dim Obj_Reader As OleDbDataReader
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
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
            E_Proc_Item.ID_DOC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.DOC_RUT = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)

        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class
