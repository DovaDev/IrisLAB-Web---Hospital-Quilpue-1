'Importar Capas
Imports Conexion
Imports Entidades

'Importar Funciones
Imports System.Web
Imports System.Data.OleDb

Public Class D_Lis_Pac_TDM
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.Numeric).Value = ID_ATENCION
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR

            E_Proc_Item.ATE_AVIS = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 1, "")
            E_Proc_Item.PAC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 2, "")
            E_Proc_Item.ID_SEXO = DD_GEN.DB_NULL(Obj_Reader, 3, "")
            E_Proc_Item.PAC_FNAC = DD_GEN.DB_NULL(Obj_Reader, 4, New Date)
            E_Proc_Item.PAC_FONO1 = DD_GEN.DB_NULL(Obj_Reader, 5, "")
            E_Proc_Item.PAC_EMAIL = DD_GEN.DB_NULL(Obj_Reader, 6, "")
            E_Proc_Item.PAC_DNI = DD_GEN.DB_NULL(Obj_Reader, 7, "")
            E_Proc_Item.DOC_RUT = DD_GEN.DB_NULL(Obj_Reader, 8, "")
            E_Proc_Item.DOC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 9, "")
            E_Proc_Item.DOC_APELLIDO = DD_GEN.DB_NULL(Obj_Reader, 10, "")
            E_Proc_Item.CF_AVIS = DD_GEN.DB_NULL(Obj_Reader, 11, "")
            E_Proc_Item.CF_DESC = DD_GEN.DB_NULL(Obj_Reader, 12, "")
            E_Proc_Item.COD_AVIS_PROC = DD_GEN.DB_NULL(Obj_Reader, 13, "")
            E_Proc_Item.PAC_RUT = DD_GEN.DB_NULL(Obj_Reader, 14, "")
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 15, "")

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE(
                                                          ByVal ATE_AVIS As String,
                                                          ByVal PAC_RUT As String,
                                                          ByVal PAC_NOMBRE As String,
                                                          ByVal PAC_APELLIDO As String,
                                                          ByVal PAC_APELLIDO_M As String,
                                                          ByVal ID_SEXO As String,
                                                          ByVal PAC_FNAC As String,
                                                          ByVal PAC_FONO1 As String,
                                                          ByVal PAC_EMAIL As String,
                                                          ByVal DOC_RUT As String,
                                                          ByVal DOC_NOMBRE As String,
                                                          ByVal DOC_APELLIDO As String,
                                                          ByVal CF_AVIS As String,
                                                          ByVal CF_DESC As String,
                                                          ByVal COD_AVIS_PROC As String,
                                                          ByVal ID_ATE As String,
                                                          ByVal ATE_FECHA As String) As Integer
        'Declaraciones
        CC_ConnBD = New C_ConnBD

        Dim Cmd_SQL As New OleDb.OleDbCommand
        Dim Read_Sql As Integer

        ''Declaraciones 'lista'
        'Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE
        'Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ATE_AVIS", OleDbType.VarChar).Value = ATE_AVIS
            .Add("@PAC_RUT", OleDbType.VarChar).Value = PAC_RUT
            .Add("@PAC_NOMBRE", OleDbType.VarChar).Value = PAC_NOMBRE
            .Add("@PAC_APELLIDO", OleDbType.VarChar).Value = PAC_APELLIDO
            .Add("@PAC_APELLIDO_M", OleDbType.VarChar).Value = PAC_APELLIDO_M
            .Add("@ID_SEXO", OleDbType.VarChar).Value = ID_SEXO
            .Add("@PAC_FNAC", OleDbType.VarChar).Value = PAC_FNAC
            .Add("@PAC_FONO1", OleDbType.VarChar).Value = PAC_FONO1
            .Add("@PAC_EMAIL", OleDbType.VarChar).Value = PAC_EMAIL
            .Add("@DOC_RUT", OleDbType.VarChar).Value = DOC_RUT
            .Add("@DOC_NOMBRE", OleDbType.VarChar).Value = DOC_NOMBRE
            .Add("@DOC_APELLIDO", OleDbType.VarChar).Value = DOC_APELLIDO
            .Add("@CF_AVIS", OleDbType.VarChar).Value = CF_AVIS
            .Add("@CF_DESC", OleDbType.VarChar).Value = CF_DESC
            .Add("@COD_AVIS_PROC", OleDbType.VarChar).Value = COD_AVIS_PROC
            .Add("@ID_ATE", OleDbType.VarChar).Value = ID_ATE
            .Add("@ATE_FECHA", OleDbType.VarChar).Value = ATE_FECHA
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


    Function IRIS_WEBF_BUSCA_SI_EXISTE_HO_CC(ByVal ID_ATENCION As String) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_SI_EXISTE_HO_CC"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@ID_ATENCION", OleDbType.VarChar).Value = ID_ATENCION
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
            E_Proc_Item = New E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR

            E_Proc_Item.ATE_AVIS = DD_GEN.DB_NULL(Obj_Reader, 0, "")
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
