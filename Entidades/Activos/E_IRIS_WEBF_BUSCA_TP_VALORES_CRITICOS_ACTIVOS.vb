Public Class E_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS
    Private EE_ID_TP_CRITICO As Integer
    Public Property ID_TP_CRITICO() As Integer
        Get
            Return EE_ID_TP_CRITICO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_CRITICO = value
        End Set
    End Property

    Private EE_TP_CRITICO_COD As String
    Public Property TP_CRITICO_COD() As String
        Get
            Return EE_TP_CRITICO_COD
        End Get
        Set(ByVal value As String)
            EE_TP_CRITICO_COD = value
        End Set
    End Property

    Private EE_TP_CRITICO_DESC As String
    Public Property TP_CRITICO_DESC() As String
        Get
            Return EE_TP_CRITICO_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_CRITICO_DESC = value
        End Set
    End Property

    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
