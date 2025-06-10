Public Class E_IRIS_WEBF_BUSCA_PASS
    Private EE_USU_PASS As String
    Public Property USU_PASS() As String
        Get
            Return EE_USU_PASS
        End Get
        Set(ByVal value As String)
            EE_USU_PASS = value
        End Set
    End Property
End Class