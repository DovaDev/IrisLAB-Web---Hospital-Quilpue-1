Public Class E_IRIS_WEBF_BUSCA_AÑO_ACTIVO
    Private EE_ID_AÑO As String
    Private EE_AÑO_COD As String
    Private EE_AÑO_DESC As String
    Private EE_ID_ESTADO As String
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property AÑO_DESC() As String
        Get
            Return EE_AÑO_DESC
        End Get
        Set(ByVal value As String)
            EE_AÑO_DESC = value
        End Set
    End Property
    Public Property AÑO_COD() As String
        Get
            Return EE_AÑO_COD
        End Get
        Set(ByVal value As String)
            EE_AÑO_COD = value
        End Set
    End Property
    Public Property ID_AÑO() As String
        Get
            Return EE_ID_AÑO
        End Get
        Set(ByVal value As String)
            EE_ID_AÑO = value
        End Set
    End Property
End Class
