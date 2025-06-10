'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class D_Exa_Esp_V
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Shared Function IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES_TIPO(ID_USER As Integer,
                                                           CB_DESC As String,
                                                           ATE_NUM As String,
                                                           ATE_NUM_OMI As String,
                                                           ID_CODIGO_FONASA As Integer,
                                                           CF_DESC As String,
                                                           FECHA_PEND As Date,
                                                           USU_ID_PROC As Integer,
                                                           ID_REGISTRO_TIPO As Integer) As Integer
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@ID_USER", ID_USER),
            New SqlParameter("@CB_DESC", CB_DESC),
            New SqlParameter("@ATE_NUM", ATE_NUM),
            New SqlParameter("@ATE_NUM_OMI", ATE_NUM_OMI),
            New SqlParameter("@ID_CODIGO_FONASA", ID_CODIGO_FONASA),
            New SqlParameter("@CF_DESC", CF_DESC),
            New SqlParameter("@FECHA_PEND", FECHA_PEND),
            New SqlParameter("@USU_ID_PROC", USU_ID_PROC),
            New SqlParameter("@ID_REGISTRO_TIPO", ID_REGISTRO_TIPO)
        }
        Return D_General_Functions.ExecuteNonQuerySP("IRIS_WEBF_CMVM_GRABA_REGISTRO_PENDIENTES_TIPO", params)
    End Function


    Function IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO(ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO)

        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_USUARIO", OleDbType.Numeric).Value = ID_USUARIO
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO With {
                .ID_REGISTRO = DD_GEN.DB_NULL(Obj_Reader, 0, 0),
                .ID_USUARIO = DD_GEN.DB_NULL(Obj_Reader, 1, 0),
                .USU_NIC = DD_GEN.DB_NULL(Obj_Reader, 2, ""),
                .CB_DESC = DD_GEN.DB_NULL(Obj_Reader, 3, ""),
                .T_MUESTRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 4, ""),
                .ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 5, 0),
                .ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 6, ""),
                .ATE_NUM_OMI = DD_GEN.DB_NULL(Obj_Reader, 7, ""),
                .ID_CODIGO_FONASA = DD_GEN.DB_NULL(Obj_Reader, 8, 0),
                .CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, ""),
                .FECHA_PEND = DD_GEN.DB_NULL(Obj_Reader, 10, ""),
                .ID_PROC = DD_GEN.DB_NULL(Obj_Reader, 11, 0),
                .PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 12, ""),
                .PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            }

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_ESTADO_EXAMEN_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.Numeric).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.Numeric).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

    Function IRIS_UPDATE_ESTADO_INTEGRACION_AVIS(ByVal AVIS As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_UPDATE_ESTADO_INTEGRACION_AVIS"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@AVIS", OleDbType.VarChar).Value = AVIS
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function


    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_SAYDEX(ByVal ID_ATE As Integer, ByVal ID_CODIGO_FONSA As Integer) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ORDEN", OleDbType.Numeric).Value = ID_ATE
            .Add("@CODIGO_EXAMEN", OleDbType.Numeric).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function
    Function IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SIDRA"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(ByVal ID_ATE As String, ByVal ID_CODIGO_FONSA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim objconexion As New Conexion.ConexionBD
        Dim Cmd_command As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        'Configuración general
        With Cmd_command
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX_222"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_command.Parameters
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ID_CODIGO_FONSA", OleDbType.VarChar).Value = ID_CODIGO_FONSA
        End With

        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select

        'Leer Datos entregados por la BD
        Read_Sql = Cmd_command.ExecuteNonQuery
        Return Read_Sql
    End Function

End Class