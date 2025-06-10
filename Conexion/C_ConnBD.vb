Imports System.Configuration
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class C_ConnBD
    Public Oledbconexion
    Public ReadOnly Property Connect_to_IrisLab_LoBarnechea() As OleDbConnection
        Get
            If Oledbconexion Is Nothing Then
                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_LoBarnechea").ToString
                Oledbconexion = New OleDbConnection(sConnString)
            End If
            Return Oledbconexion
        End Get
    End Property
    Public ReadOnly Property Connect_to_IrisLab_Documentos() As OleDbConnection
        Get
            If Oledbconexion Is Nothing Then
                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_Documentos").ToString
                Oledbconexion = New OleDbConnection(sConnString)
            End If
            Return Oledbconexion
        End Get
    End Property

    Public ReadOnly Property Connect_to_IrisLab_Penalolen() As MySqlConnection
        Get
            If Oledbconexion Is Nothing Then
                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CadenaConexion_IrisLab_Penalolen").ToString
                Oledbconexion = New MySqlConnection(sConnString)
            End If
            Return Oledbconexion
        End Get
    End Property
End Class
