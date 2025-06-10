'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Impr_Etiq
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_FILTRO(DESDE As String, HASTA As String, ID_PROC As Integer, ID_SECC As Integer, ID_CF As Integer, ID_AREA As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USUARIO As Integer = CType(objSession("ID_USER"), Integer)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_FILTRO_AREA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros 
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.VarChar).Value = DESDE
            .Add("@HASTA", OleDbType.VarChar).Value = HASTA
            .Add("@ID_PROC", OleDbType.Integer).Value = ID_PROC
            .Add("@ID_RLS_LS", OleDbType.Integer).Value = ID_SECC
            .Add("@ID_CF", OleDbType.Integer).Value = ID_CF
            .Add("@ID_USUARIO", OleDbType.Integer).Value = ID_USUARIO
            .Add("@ID_AREA", OleDbType.Integer).Value = ID_AREA

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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE With {
                .ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0),
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, ""),
                .ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date),
                .ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 3, 0),
                .ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 4, 0),
                .ID_CODIGO_BARRA = DD_GEN.DB_NULL(Obj_Reader, 5, 0),
                .CB_COD = DD_GEN.DB_NULL(Obj_Reader, 6, ""),
                .CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, ""),
                .ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 8, 0),
                .T_MUESTRA_COD = DD_GEN.DB_NULL(Obj_Reader, 9, ""),
                .T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, ""),
                .ID_G_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 11, 0),
                .GMUE_COD = DD_GEN.DB_NULL(Obj_Reader, 12, ""),
                .GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, ""),
                .PAC_FULLNAME = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            }

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_BARRA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CB_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.T_MUESTRA_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_G_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.GMUE_COD = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_POR_ID_ATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 3, 0)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 4, 0)
            E_Proc_Item.ID_CODIGO_BARRA = DD_GEN.DB_NULL(Obj_Reader, 5, 0)
            E_Proc_Item.CB_COD = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.ID_T_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 8, 0)
            E_Proc_Item.T_MUESTRA_COD = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.ID_G_MUESTRA = DD_GEN.DB_NULL(Obj_Reader, 11, 0)
            E_Proc_Item.GMUE_COD = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.GMUE_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As Integer = CType(objSession("ID_USER"), Integer)
        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_ETIQUETAS_GENERAL_INFO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_NUM", OleDbType.Numeric).Value = ATE_NUM
            .Add("@ID_USUARIO", OleDbType.Integer).Value = S_Id_User
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer datos devueltos
        E_Proc_Item = Nothing
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read
            E_Proc_Item = New E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO

            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 0, 0)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 2, New Date)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PREVE_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.SEXO_DESC = DD_GEN.DB_NULL(Obj_Reader, 8, "")
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_Item
    End Function
End Class