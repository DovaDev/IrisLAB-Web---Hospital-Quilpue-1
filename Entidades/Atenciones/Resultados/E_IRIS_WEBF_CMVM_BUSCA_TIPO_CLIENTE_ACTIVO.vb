Public Class E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO
    Private EE_ID_INTEXT As Integer
    Public Property ID_INTEXT() As Integer
        Get
            Return EE_ID_INTEXT
        End Get
        Set(ByVal value As Integer)
            EE_ID_INTEXT = value
        End Set
    End Property

    Private EE_INTEXT_COD As String
    Public Property INTEXT_COD() As String
        Get
            Return EE_INTEXT_COD
        End Get
        Set(ByVal value As String)
            EE_INTEXT_COD = value
        End Set
    End Property

    Private EE_INTEXT_DESC As String
    Public Property INTEXT_DESC() As String
        Get
            Return EE_INTEXT_DESC
        End Get
        Set(ByVal value As String)
            EE_INTEXT_DESC = value
        End Set
    End Property
End Class