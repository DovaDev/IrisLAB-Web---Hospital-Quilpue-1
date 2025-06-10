Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    'Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand
    '    'Declaraciones 'lista'
    '    Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    '    Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER"
    '        '.Connection = CC_ConnBD.Connect_to_IrisLab_Imagenes
    '    End With
    '    With Cmd_SQL.Parameters
    '        .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
    '    End With
    '    'Conectar con la Base de Datos
    '    Select Case CC_ConnBD.Oledbconexion.State
    '        Case ConnectionState.Open
    '            CC_ConnBD.Oledbconexion.Close()
    '        Case Else
    '            CC_ConnBD.Oledbconexion.Open()
    '    End Select
    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    While Obj_Reader.Read
    '        E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    '        E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
    '        E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
    '        E_Proc_Item.NOMBRE_DOC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
    '        E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
    '        'Agregar items a la lista
    '        E_Proc_List.Add(E_Proc_Item)
    '    End While
    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_List
    'End Function
    'Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
    '    'Declaraciones
    '    CC_ConnBD = New C_ConnBD
    '    Dim Obj_Reader As OleDbDataReader
    '    Dim Cmd_SQL As New OleDb.OleDbCommand
    '    'Declaraciones 'lista'
    '    Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    '    Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
    '    'Configuración general
    '    With Cmd_SQL
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With
    '    With Cmd_SQL.Parameters
    '        .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
    '    End With
    '    'Conectar con la Base de Datos
    '    Select Case CC_ConnBD.Oledbconexion.State
    '        Case ConnectionState.Open
    '            CC_ConnBD.Oledbconexion.Close()
    '        Case Else
    '            CC_ConnBD.Oledbconexion.Open()
    '    End Select
    '    'Leer datos devueltos
    '    Obj_Reader = Cmd_SQL.ExecuteReader
    '    While Obj_Reader.Read
    '        E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    '        E_Proc_Item.ID = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
    '        E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
    '        E_Proc_Item.NOMBRE_DOC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
    '        E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
    '        'Agregar items a la lista
    '        E_Proc_List.Add(E_Proc_Item)
    '    End While
    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_List
    'End Function
    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_ASOC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_PDF(ByVal ID_ATENCION As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE_PDF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_ASOC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_PDF_PREI(ByVal PREI_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE_PDF_PREI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@PREI_NUM", OleDbType.BigInt).Value = PREI_NUM

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_ASOC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_PDF_ATE_PREI(ByVal PREI_NUM As Long, ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE_PDF_ATE_PREI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@PREI_NUM", OleDbType.BigInt).Value = PREI_NUM
            .Add("@ATE_NUM", OleDbType.BigInt).Value = ATE_NUM

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_ASOC = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_ASOC(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE_ASOC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
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
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.NO_ASOC_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_LOG = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_MOBILE_2_ASOC_PDF(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_MOBILE_ASOC_PDF"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
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
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
            E_Proc_Item.ID_FOTO_ATE = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.NO_ASOC_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.IMG = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.FECHA_LOG = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.FOTO_ATE_PLATAFORMA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.TIPO = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC(ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Long, ByVal ATE_NUM As String, ByVal IMG As Long) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@IMG", OleDbType.BigInt).Value = IMG

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc_List = Cmd_SQL.ExecuteNonQuery

        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC_PREI(ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Long, ByVal ATE_NUM As String, ByVal ID_PREINGRESO As Long,
                                            ByVal PREI_NUM As String, ByVal IMG As Long) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_GRABA_IMAGEN_MOBILE_ASOC_PREI"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@ID_PREINGRESO", OleDbType.VarChar).Value = ID_PREINGRESO
            .Add("@PREI_NUM", OleDbType.VarChar).Value = PREI_NUM
            .Add("@IMG", OleDbType.BigInt).Value = IMG

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc_List = Cmd_SQL.ExecuteNonQuery

        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE_ASOC(ByVal ID_FOTO_ATE As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE_ASOC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_FOTO_ATE", OleDbType.BigInt).Value = ID_FOTO_ATE

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc_List = Cmd_SQL.ExecuteNonQuery

        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE(ByVal ID_FOTO_ATE As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        'Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As Integer
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_ELIMINA_IMAGEN_MOBILE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_FOTO_ATE", OleDbType.BigInt).Value = ID_FOTO_ATE

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        E_Proc_List = Cmd_SQL.ExecuteNonQuery

        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_FOLIO_ID_ATE(ByVal ID_ATENCION As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'

        Dim E_Proc_List As String = ""
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_FOLIO_ID_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.BigInt).Value = ID_ATENCION

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
            E_Proc_List = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
        End While
        Return E_Proc_List
    End Function


End Class
