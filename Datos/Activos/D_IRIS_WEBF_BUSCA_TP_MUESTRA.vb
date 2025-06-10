'Importar Capas
Imports Conexion
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_BUSCA_TP_MUESTRA
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_BUSCA_TP_MUESTRA() As List(Of E_IRIS_WEBF_BUSCA_TP_MUESTRA)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_TP_MUESTRA
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_TP_MUESTRA)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_TP_MUESTRAS"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_TP_MUESTRA
            Obj_Read_Dt.ID_RE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.RE_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.RE_DES = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_RECEP = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ID_CB = DD_GEN.DB_NULL(Reader_Comm, 4, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 5, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_TP_MUESTRA_SANGRE_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_TP_MUESTRA_SANGRE_BY_ID_PER_NO_RELACIONADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE
            E_Proc_Item.MUESTRA_SANGRE_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_MUESTRA_SANGRE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.MUESTRA_SANGRE_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_TP_MUESTRA_SANGRE_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_RELACION_TP_MUESTRA_SANGRE_MANTENEDOR_REL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL
            E_Proc_Item.MUESTRA_SANGRE_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_MUESTRA_SANGRE = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_REL_PER_MSANGRE = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_GRABA_RELACION_TP_MUESTRA_SANGRE_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_RELACION_TP_MUESTRA_SANGRE_ESTUDIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Integer).Value = ID_PER
            .Add("@ID_DERIVADO", OleDbType.Integer).Value = ARRAY_
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_REL_TP_DE_MUESTRA_SANGRE_ESTUDIO_QUITAR_RELACION(ByVal ARRAY_ As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REL_TP_DE_MUESTRA_SANGRE_ESTUDIO_QUITAR_RELACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters

            .Add("@ID_REL_PER_MSANGRE ", OleDbType.Integer).Value = ARRAY_

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function
    '------------------------------------------------------ANALIZADOR------------------------------------------------------'
    Function IRIS_WEBF_CMVM_BUSCA_ANALIZADOR_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANALIZADOR
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ANALIZADOR_BY_ID_PER_NO_RELACIONADAS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANALIZADOR
            E_Proc_Item.ANAL_DESC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ANAL = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ANAL_COD = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_ANALIZADOR_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_ANALIZADOR_REL
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_RELACION_ANALIZADOR_MANTENEDOR_REL"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Numeric).Value = ID_PER
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_ANALIZADOR_REL
            E_Proc_Item.ANAL_DESC = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.ID_ANAL = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.ID_ESTADO = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_PER = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ID_REL_PER_ANAL = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_GRABA_RELACION_ANALIZADOR_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_GRABA_RELACION_ANALIZADOR_ESTUDIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_PER", OleDbType.Integer).Value = ID_PER
            .Add("@ID_ANAL", OleDbType.Integer).Value = ARRAY_
            .Add("@ID_USER", OleDbType.Integer).Value = ID_USER

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_REL_ANALIZADOR_QUITAR_RELACION(ByVal ARRAY_ As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_REL_ANALIZADOR_QUITAR_RELACION"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters

            .Add("@ID_REL_PER_ANAL", OleDbType.Integer).Value = ARRAY_

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    '----------------------------------------- Mantenedores de TIPO MUESTRA DE SANGRE --------------------------------------------'

    Function IRIS_WEBF_BUSCA_MUESTRA_SANGRE() As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_MUESTRA_SANGRE"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE
            Obj_Read_Dt.ID_MUESTRA_SANGRE = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.MUESTRA_SANGRE_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            Obj_Read_Dt.MUESTRA_SANGRE_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_GRABA_TP_DE_MUESTRA_SANGRE(ByVal MUESTRA_SANGRE_COD As String, ByVal MUESTRA_SANGRE_DESC As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_TP_DE_MUESTRA_SANGRE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@MUESTRA_SANGRE_COD", OleDbType.VarChar).Value = MUESTRA_SANGRE_COD
            .Add("@MUESTRA_SANGRE_DESC ", OleDbType.VarChar).Value = MUESTRA_SANGRE_DESC
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE(ByVal ID_MUESTRA_SANGRE As Integer,
                                      ByVal MUESTRA_SANGRE_COD As String,
                                      ByVal MUESTRA_SANGRE_DESC As String,
                                      ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_TP_MUESTRA_SANGRE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_MUESTRA_SANGRE", OleDbType.Numeric).Value = ID_MUESTRA_SANGRE
            .Add("@MUESTRA_SANGRE_COD", OleDbType.VarChar).Value = MUESTRA_SANGRE_COD
            .Add("@MUESTRA_SANGRE_DESC", OleDbType.VarChar).Value = MUESTRA_SANGRE_DESC
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    '----------------------------------------- Mantenedores de ANALIZADOR --------------------------------------------'

    Function IRIS_WEBF_BUSCA_ANALIZADOR() As List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        'Declaraciones
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Obj_Read_Dt As E_IRIS_WEBF_BUSCA_ANALIZADOR_REL
        Dim List_Reader As New List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        Dim Reader_Comm As OleDbDataReader

        'Configuración general
        Cmd_command.CommandType = CommandType.StoredProcedure
        Cmd_command.CommandText = "IRIS_WEBF_BUSCA_ANALIZADOR"
        Cmd_command.Connection = objconexion.Connect_to_IrisLab_LoBarnechea

        'establece conexion con la base de datos
        If (objconexion.Oledbconexion.State = ConnectionState.Open) Then
            objconexion.Oledbconexion.Close()
        Else
            objconexion.Oledbconexion.Open()
        End If
        'Leer datos devueltos
        Reader_Comm = Cmd_command.ExecuteReader
        While Reader_Comm.Read
            Obj_Read_Dt = New E_IRIS_WEBF_BUSCA_ANALIZADOR_REL
            Obj_Read_Dt.ID_ANAL = DD_GEN.DB_NULL(Reader_Comm, 0, Nothing)
            Obj_Read_Dt.ANAL_DESC = DD_GEN.DB_NULL(Reader_Comm, 2, Nothing)
            Obj_Read_Dt.ID_ESTADO = DD_GEN.DB_NULL(Reader_Comm, 3, Nothing)
            Obj_Read_Dt.ANAL_COD = DD_GEN.DB_NULL(Reader_Comm, 1, Nothing)
            'Agregar items a la lista
            List_Reader.Add(Obj_Read_Dt)
        End While
        objconexion.Oledbconexion.Close()
        Return List_Reader
    End Function

    Function IRIS_WEBF_GRABA_ANALIZADOR(ByVal ANAL_COD As String, ByVal ANAL_DESC As String, ByVal ID_ESTADO As Integer) As String
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_ANALIZADOR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ANAL_COD", OleDbType.VarChar).Value = ANAL_COD
            .Add("@ANAL_DESC ", OleDbType.VarChar).Value = ANAL_DESC
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_ANALIZADOR(ByVal ID_ANAL As Integer,
                                      ByVal ANAL_COD As String,
                                      ByVal ANAL_DESC As String,
                                      ByVal ID_ESTADO As Integer) As Integer
        'Declaraciones
        Dim CC_ConnBD = New Conexion.ConexionBD
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_ANALIZADOR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ANAL", OleDbType.Numeric).Value = ID_ANAL
            .Add("@ANAL_COD", OleDbType.VarChar).Value = ANAL_COD
            .Add("@ANAL_DESC", OleDbType.VarChar).Value = ANAL_DESC
            .Add("@ID_ESTADO", OleDbType.Numeric).Value = ID_ESTADO
        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'ejecutar PA y recibir un integer con la cantidad de filas afectadas
        Read_Sql = Cmd_SQL.ExecuteNonQuery
        CC_ConnBD.Oledbconexion.Close()
        Return Read_Sql
    End Function


End Class
