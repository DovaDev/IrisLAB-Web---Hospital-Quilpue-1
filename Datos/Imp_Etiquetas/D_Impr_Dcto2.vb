Imports Conexion
Imports Entidades
Imports System.Data.OleDb

Public Class D_Impr_Dcto2
    'Declaraciones Generales
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions

    Function IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_1(ByVal DESDE As Date, ByVal HASTA As Date,
                                                                       ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                                                       ByVal ID_PROG As Long, ByVal ID_SUBP As Long) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_1"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@DESDE", OleDbType.Date).Value = DESDE
            .Add("@HASTA", OleDbType.Date).Value = HASTA
            .Add("@ID_PROC", OleDbType.Numeric).Value = ID_PROC
            .Add("@ID_PREV", OleDbType.Numeric).Value = ID_PREV
            .Add("@ID_PROG", OleDbType.Numeric).Value = ID_PROG
            .Add("@ID_SUBP", OleDbType.Numeric).Value = ID_SUBP
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER

            E_Proc_Item.ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PREI_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PREI_FECHA_PRE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PREV_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_SUBP = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.COUNT_PEND = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function

    Function IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_2(ByVal PRE_NUM As String, ByVal ATE_NUM As String, ByVal PAC_RUT As String,
                                                                       ByVal PAC_DNI As String, ByVal PAC_NAME As String, ByVal PAC_LAST As String) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)
        'Declaraciones
        CC_ConnBD = New C_ConnBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Declaraciones 'lista'
        Dim E_Proc_Item As E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER
        Dim E_Proc_List As New List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_2"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@PRE_NUM", OleDbType.VarChar).Value = PRE_NUM
            .Add("@ATE_NUM", OleDbType.VarChar).Value = ATE_NUM
            .Add("@PAC_RUT", OleDbType.VarChar).Value = PAC_RUT
            .Add("@PAC_DNI", OleDbType.VarChar).Value = PAC_DNI
            .Add("@PAC_NAME", OleDbType.VarChar).Value = PAC_NAME
            .Add("@PAC_LAST", OleDbType.VarChar).Value = PAC_LAST
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
            E_Proc_Item = New E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER

            E_Proc_Item.ID_PREINGRESO = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            E_Proc_Item.PREI_NUM = DD_GEN.DB_NULL(Obj_Reader, 1, Nothing)
            E_Proc_Item.PREI_FECHA_PRE = DD_GEN.DB_NULL(Obj_Reader, 2, Nothing)
            E_Proc_Item.ID_ATENCION = DD_GEN.DB_NULL(Obj_Reader, 3, Nothing)
            E_Proc_Item.ATE_NUM = DD_GEN.DB_NULL(Obj_Reader, 4, Nothing)
            E_Proc_Item.ATE_FECHA = DD_GEN.DB_NULL(Obj_Reader, 5, Nothing)
            E_Proc_Item.PAC_COD = DD_GEN.DB_NULL(Obj_Reader, 6, Nothing)
            E_Proc_Item.PAC_NOMBRE = DD_GEN.DB_NULL(Obj_Reader, 7, Nothing)
            E_Proc_Item.ID_PROCEDENCIA = DD_GEN.DB_NULL(Obj_Reader, 8, Nothing)
            E_Proc_Item.PROC_DESC = DD_GEN.DB_NULL(Obj_Reader, 9, Nothing)
            E_Proc_Item.ID_PREVE = DD_GEN.DB_NULL(Obj_Reader, 10, Nothing)
            E_Proc_Item.PREV_DESC = DD_GEN.DB_NULL(Obj_Reader, 11, Nothing)
            E_Proc_Item.ID_PROGRAMA = DD_GEN.DB_NULL(Obj_Reader, 12, Nothing)
            E_Proc_Item.PROGRA_DESC = DD_GEN.DB_NULL(Obj_Reader, 13, Nothing)
            E_Proc_Item.ID_SUBP = DD_GEN.DB_NULL(Obj_Reader, 14, Nothing)
            E_Proc_Item.SUBP_DESC = DD_GEN.DB_NULL(Obj_Reader, 15, Nothing)
            E_Proc_Item.EST_DESCRIPCION = DD_GEN.DB_NULL(Obj_Reader, 16, Nothing)
            E_Proc_Item.COUNT_PEND = DD_GEN.DB_NULL(Obj_Reader, 17, Nothing)

            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While

        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class