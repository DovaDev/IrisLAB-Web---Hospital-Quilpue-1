Public Class E_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS
    Private EE_ID_PACIENTE As Long
    Private EE_COUNT As String
    Public Property COUNT() As String
        Get
            Return EE_COUNT
        End Get
        Set(ByVal value As String)
            EE_COUNT = value
        End Set
    End Property
    Public Property ID_PACIENTE() As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Long)
            EE_ID_PACIENTE = value
        End Set
    End Property
End Class
