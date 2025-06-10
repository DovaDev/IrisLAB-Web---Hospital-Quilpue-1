Public Class E_IRIS_WEBF_BUSCA_TODOS_EXAMENES

    Private E_ID_CODIGO_FONASA As Integer
    Private E_CF_COD As String
    Private E_CF_DESC As String

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
End Class
