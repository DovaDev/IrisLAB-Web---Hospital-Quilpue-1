Public Class E_IRIS_WEBF_BUSCA_AGRUPA
    Private EE_ID_AGRU As Integer
    Private EE_AGRU_COD As String
    Private EE_AGRU_DESC As String
    Private EE_ID_ESTADO As String
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property AGRU_DESC() As String
        Get
            Return EE_AGRU_DESC
        End Get
        Set(ByVal value As String)
            EE_AGRU_DESC = value
        End Set
    End Property
    Public Property AGRU_COD() As String
        Get
            Return EE_AGRU_COD
        End Get
        Set(ByVal value As String)
            EE_AGRU_COD = value
        End Set
    End Property
    Public Property ID_AGRU() As Integer
        Get
            Return EE_ID_AGRU
        End Get
        Set(ByVal value As Integer)
            EE_ID_AGRU = value
        End Set
    End Property
End Class
