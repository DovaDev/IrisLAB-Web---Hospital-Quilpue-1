Public Class E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS
    Dim EE_ID_TP_RECHA As Integer
    Dim EE_TP_RECHA_COD As String
    Dim EE_TP_RECHA_DESC As String
    Dim EE_ID_ESTADO As Integer

    Public Property ID_TP_RECHA As Integer
        Get
            Return EE_ID_TP_RECHA
        End Get
        Set(value As Integer)
            EE_ID_TP_RECHA = value
        End Set
    End Property

    Public Property TP_RECHA_COD As String
        Get
            Return EE_TP_RECHA_COD
        End Get
        Set(value As String)
            EE_TP_RECHA_COD = value
        End Set
    End Property

    Public Property TP_RECHA_DESC As String
        Get
            Return EE_TP_RECHA_DESC
        End Get
        Set(value As String)
            EE_TP_RECHA_DESC = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
