Public Class E_IRIS_WEBF_BUSCA_TP_RECHAZO
    Private EE_ID_TP_RECHA As Integer
    Private EE_TP_RECHA_COD As String
    Private EE_TP_RECHA_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property TP_RECHA_DESC() As String
        Get
            Return EE_TP_RECHA_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_RECHA_DESC = value
        End Set
    End Property
    Public Property TP_RECHA_COD() As String
        Get
            Return EE_TP_RECHA_COD
        End Get
        Set(ByVal value As String)
            EE_TP_RECHA_COD = value
        End Set
    End Property
    Public Property ID_TP_RECHA() As Integer
        Get
            Return EE_ID_TP_RECHA
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_RECHA = value
        End Set
    End Property
End Class
