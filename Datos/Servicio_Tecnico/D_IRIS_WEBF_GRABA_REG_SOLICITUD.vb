Imports Entidades
Imports System.Data.OleDb
Public Class D_IRIS_WEBF_GRABA_REG_SOLICITUD
    Dim CC_ConnBD As New Conexion.ConexionBD
    Dim DD_GEN As New D_General_Functions
    Function IRIS_WEBF_GRABA_REG_SOLICITUD(ByVal RUT As String,
                 ByVal NOMBRE As String,
                 ByVal APEPELLIDO As String,
                 ByVal NACIONALIDAD As String,
                ByVal FECHA_NAC As String,
                 ByVal SEXO As String,
                 ByVal MOVIL As String,
                 ByVal MOVIL2 As String,
                 ByVal EMAIL As String,
                 ByVal LUGARTM As String,
                 ByVal MOTIVO As String,
                 ByVal FECHA_EVENTO As Date,
                 ByVal MENSAJE As String,
                ByVal PAIS As String) As Integer
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As Integer
        Dim Cmd_SQL As New OleDb.OleDbCommand

        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_GRABA_REG_SOLICITUD"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With
        'Enviar parámetros
        With Cmd_SQL.Parameters
            .Add("@RUT", OleDbType.VarChar).Value = RUT
            .Add("@NOMBRE", OleDbType.VarChar).Value = NOMBRE
            .Add("@APEPELLIDO", OleDbType.VarChar).Value = APEPELLIDO
            .Add("@NACIONALIDAD", OleDbType.VarChar).Value = NACIONALIDAD
            .Add("@FECHA_NAC", OleDbType.VarChar).Value = FECHA_NAC
            .Add("@SEXO", OleDbType.VarChar).Value = SEXO
            .Add("@MOVIL", OleDbType.VarChar).Value = MOVIL
            .Add("@MOVIL2", OleDbType.VarChar).Value = MOVIL2
            .Add("@EMAIL", OleDbType.VarChar).Value = EMAIL
            .Add("@LUGARTM", OleDbType.VarChar).Value = LUGARTM
            .Add("@MOTIVO", OleDbType.VarChar).Value = MOTIVO
            .Add("@FECHA_EVENTO", OleDbType.Date).Value = FECHA_EVENTO
            .Add("@MENSAJE", OleDbType.VarChar).Value = MENSAJE
            .Add("@PAIS", OleDbType.VarChar).Value = PAIS

        End With
        'Conectar con la Base de Datos
        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteNonQuery

        CC_ConnBD.Oledbconexion.Close()
        Return Obj_Reader
    End Function

    Function IRIS_WEBF_BUSCA_EMAIL_REG_SOLICITUD() As List(Of String)
        'Declaraciones
        CC_ConnBD = New Conexion.ConexionBD
        Dim Obj_Reader As OleDbDataReader
        Dim Cmd_SQL As New OleDb.OleDbCommand
        'Declaraciones 'lista'
        Dim E_Proc_Item As String
        Dim E_Proc_List As New List(Of String)
        'Configuración general
        With Cmd_SQL
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IRIS_WEBF_BUSCA_EMAIL_REG_SOLICITUD"
            .Connection = CC_ConnBD.Connect_to_IrisLab_LoBarnechea
        End With

        Select Case CC_ConnBD.Oledbconexion.State
            Case ConnectionState.Open
                CC_ConnBD.Oledbconexion.Close()
            Case Else
                CC_ConnBD.Oledbconexion.Open()
        End Select
        'Leer datos devueltos
        Obj_Reader = Cmd_SQL.ExecuteReader
        While Obj_Reader.Read

            E_Proc_Item = DD_GEN.DB_NULL(Obj_Reader, 0, Nothing)
            'Agregar items a la lista
            E_Proc_List.Add(E_Proc_Item)
        End While
        CC_ConnBD.Oledbconexion.Close()
        Return E_Proc_List
    End Function
End Class
