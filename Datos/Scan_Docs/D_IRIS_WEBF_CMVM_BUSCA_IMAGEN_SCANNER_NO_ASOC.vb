Imports Conexion
Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_NO_ASOC
    Dim CC_ConnBD As C_ConnBD
    Dim DD_GEN As New D_General_Functions
    'Function IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_NO_ASOC(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER)
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
    '        .CommandText = "IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER_NO_ASOC"
    '        .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
    '    End With
    '    With Cmd_SQL.Parameters
    '        .Add("@DESDE", OleDbType.Date).Value = CDate(DESDE)
    '        .Add("@HASTA", OleDbType.Date).Value = CDate(HASTA)
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
    '        'Agregar items a la lista
    '        E_Proc_List.Add(E_Proc_Item)
    '    End While
    '    CC_ConnBD.Oledbconexion.Close()
    '    Return E_Proc_List
    'End Function
End Class
