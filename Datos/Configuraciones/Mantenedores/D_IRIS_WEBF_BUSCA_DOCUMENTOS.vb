'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_DOCUMENTOS

    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
        Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.ID_DCTO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DCTO_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.DCTO_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.DCTO_TIPO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.DCTO_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DCTO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.DCTO_RUTA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_DOCUMENTOS() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.ID_DCTO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DCTO_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.DCTO_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.DCTO_TIPO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.DCTO_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DCTO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.DCTO_RUTA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS2() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.ID_DCTO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DCTO_COD = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.DCTO_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.DCTO_TIPO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.DCTO_ORDEN = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.DCTO_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.DCTO_RUTA = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.DCTO_CATEGORIA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.DCTO_SUBCATEGORIA = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_DOCUMENTO(ByVal DCTO_DESC As String,
                                        ByVal DCTO_TIPO As Integer,
                                        ByVal DCTO_FECHA As Date,
                                        ByVal DCTO_RUTA As String,
                                        ByVal DCTO_BITS As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_GRABA_DOCUMENTO"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Dim base64 As String = DCTO_BITS
        'Dim bitmapData As Byte()
        'Dim B64_Clear As String = FixBase64ForImage(base64)
        'bitmapData = Convert.FromBase64String(B64_Clear)

        With Cmd_command.Parameters

            .Add("@DCTO_DESC", OleDbType.VarChar).Value = DCTO_DESC
            .Add("@DCTO_TIPO", OleDbType.Numeric).Value = DCTO_TIPO
            .Add("@DCTO_FECHA", OleDbType.Date).Value = DCTO_FECHA
            .Add("@DCTO_RUTA", OleDbType.VarChar).Value = DCTO_RUTA

            '.Add("@DCTO_BITS", OleDbType.Binary).Value = bitmapData

            'If (base64 <> "") Then
            '    .Add("@DCTO_BITS", OleDbType.Binary).Value = bitmapData
            'Else
            '    .Add("@DCTO_BITS", OleDbType.Binary).Value = Nothing
            'End If

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_GRABA_DOCUMENTO_2(ByVal DCTO_DESC As String,
                                        ByVal DCTO_TIPO As Integer,
                                        ByVal DCTO_FECHA As Date,
                                        ByVal DCTO_RUTA As String,
                                        ByVal DCTO_BITS As String,
                                         ByVal DCTO_COD As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_GRABA_DOCUMENTO_2"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'Dim base64 As String = DCTO_BITS
        'Dim bitmapData As Byte()
        'Dim B64_Clear As String = FixBase64ForImage(base64)
        'bitmapData = Convert.FromBase64String(B64_Clear)

        With Cmd_command.Parameters

            .Add("@DCTO_DESC", OleDbType.VarChar).Value = DCTO_DESC
            .Add("@DCTO_TIPO", OleDbType.Numeric).Value = DCTO_TIPO
            .Add("@DCTO_FECHA", OleDbType.Date).Value = DCTO_FECHA
            .Add("@DCTO_RUTA", OleDbType.VarChar).Value = DCTO_RUTA
            .Add("@DCTO_COD", OleDbType.VarChar).Value = DCTO_COD

            '.Add("@DCTO_BITS", OleDbType.Binary).Value = bitmapData

            'If (base64 <> "") Then
            '    .Add("@DCTO_BITS", OleDbType.Binary).Value = bitmapData
            'Else
            '    .Add("@DCTO_BITS", OleDbType.Binary).Value = Nothing
            'End If

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ByVal ID_DCTO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@ID_DCTO", OleDbType.VarChar).Value = ID_DCTO

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ByVal ID_DCTO As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@ID_DCTO", OleDbType.VarChar).Value = ID_DCTO

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS_SI_EXISTE(ByVal DCTO_RUTA As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_SI_EXISTE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@DCTO_RUTA", OleDbType.VarChar).Value = DCTO_RUTA

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_DCTO_DESC(ByVal ID_DCTO As Integer,
                                        ByVal DCTO_DESC As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_UPDATE_DCTO_DESC"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@DCTO_DESC", OleDbType.Numeric).Value = ID_DCTO
            .Add("@DCTO_TIPO", OleDbType.VarChar).Value = DCTO_DESC

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION

            E_Proc_Item.ID_PRESTA_PRESTA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.DCTO_PRESTA_PRESTA_DESC = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PRESTA_PRESTA_LUGAR = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.PRESTA_PRESTA_PLAZO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PRESTA_PRESTA_DOCU = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PRESTA_PRESTA_SECCION = DD_GEN.DB_NULL(Obj_Reader, 5, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function


    Function FixBase64ForImage(ByVal image As String)
        Dim regex As New Regex("d^.+base64", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)

        'Dim sbText As New StringBuilder(image, image.Length)
        Dim ayyy As String = ""

        ayyy = regex.Match(image).ToString


        'sbText.Replace("data:image/jpeg;base64,", String.Empty)
        'sbText.Replace("data:image/png;base64,", String.Empty)
        'sbText.Replace("data:image/bmp;base64,", String.Empty)
        'sbText.Replace("data:application/pdf;base64,", String.Empty)
        'sbText.Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", String.Empty)
        'sbText.Replace("data:application/x-msdownload;base64,", String.Empty)
        'sbText.Replace("data:application/octet-stream;base64,", String.Empty)
        'sbText.Replace("\r\n", String.Empty)
        'sbText.Replace(" ", String.Empty)
        'Return sbText.ToString()

        Return ayyy
    End Function
    '---------------------------------------          TRAZABILIDAD PAP CAJAS            --------------------------------------------------------------

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ByVal ID_CAJA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters

            .Add("@ID_CAJA", OleDbType.Numeric).Value = ID_CAJA

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.ID_TRAZA_PAP = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.FECHA_TRAZA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.NUM_TRAZA = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ID_ESTADO_USU = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.USU_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_ESTADO_CAJA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA(ByVal DESDE As Date, ByVal HASTA As Date, ByVal LUGARTM As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@LUGARTM", OleDbType.Integer).Value = LUGARTM


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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.ID_PAP_CAJA = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.FECHA_CREACION_CAJA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.COMENTARIO_CAJA = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.TIPO_CAJA = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.ID_ESTADO_USU = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.USU_ADMIN = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.MATRIZ_NUM_AVIS = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)


            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_GRABA_CAJA_TRAZA_PAP(ByVal COMENTARIO As String, ByVal TIPO As String, ByVal ID_USUARIO As Integer, ByVal MATRIZ_NUM_AVIS As String, ByVal ID_PROC As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_GRABA_CAJA_TRAZA_PAP"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@COMENTARIO", OleDbType.VarChar).Value = COMENTARIO
            .Add("@TIPO", OleDbType.VarChar).Value = TIPO
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@MATRIZ_NUM_AVIS", OleDbType.VarChar).Value = MATRIZ_NUM_AVIS
            .Add("@ID_PROC", OleDbType.VarChar).Value = ID_PROC


        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_RECIBIR_CAJA(ByVal ID_USUARIO As Integer, ByVal NUM_TRAZA As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_RECIBIR_CAJA"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@NUM_TRAZA", OleDbType.Numeric).Value = NUM_TRAZA

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_FINALIZAR_TRAZA_PAP(ByVal ID_CAJA As Integer, ByVal COMENATRIO As String) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_FINALIZAR_TRAZA_PAP"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@ID_CAJA", OleDbType.Integer).Value = ID_CAJA
            .Add("@COMENTARIO", OleDbType.VarChar).Value = COMENATRIO

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS(ByVal ID_CAJA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        With Cmd_SQL.Parameters
            .Add("@ID_CAJ", OleDbType.Numeric).Value = ID_CAJA

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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DOCUMENTOS

            E_Proc_Item.MATRIZ_NUM_AVIS = DD_GEN.DB_NULL(Obj_Reader, 0, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_ELIMINAR_TRAZA_PAP(ByVal ID_CAJA As Integer) As Integer
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'definiendo tipo de consulta a la BD
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_ELIMINAR_TRAZA_PAP"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        With Cmd_command.Parameters

            .Add("@ID_CAJA", OleDbType.Integer).Value = ID_CAJA

        End With
        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        objconexion.Oledbconexion.Close()
        Return Read_Sql
    End Function
End Class
