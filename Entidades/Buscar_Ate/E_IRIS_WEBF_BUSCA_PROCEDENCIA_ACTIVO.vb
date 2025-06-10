
Public Class E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
    Private EE_ID_PROCEDENCIA As String
    Private EE_PROC_COD As String
    Private EE_PROC_DESC As String
    Private EE_ID_ESTADO As String
    Private EE_ID_TP_RESIDUO As Integer
    Private EE_TP_RESIDUO_DESC As String
    Private EE_ID_SECC_RESIDUO As Integer
    Private EE_COD_SECC_RESIDUO As String
    Private EE_SECC_RESIDUO_DESC As String
    Public Property SECC_RESIDUO_DESC() As String
        Get
            Return EE_SECC_RESIDUO_DESC
        End Get
        Set(ByVal value As String)
            EE_SECC_RESIDUO_DESC = value
        End Set
    End Property
    Public Property COD_SECC_RESIDUO() As String
        Get
            Return EE_COD_SECC_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_COD_SECC_RESIDUO = value
        End Set
    End Property
    Public Property ID_SECC_RESIDUO() As Integer
        Get
            Return EE_ID_SECC_RESIDUO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SECC_RESIDUO = value
        End Set
    End Property
    Public Property TP_RESIDUO_DESC() As String
        Get
            Return EE_TP_RESIDUO_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_RESIDUO_DESC = value
        End Set
    End Property
    Public Property ID_TP_RESIDUO() As Integer
        Get
            Return EE_ID_TP_RESIDUO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_RESIDUO = value
        End Set
    End Property
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PROC_COD() As String
        Get
            Return EE_PROC_COD
        End Get
        Set(ByVal value As String)
            EE_PROC_COD = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As String
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
End Class
