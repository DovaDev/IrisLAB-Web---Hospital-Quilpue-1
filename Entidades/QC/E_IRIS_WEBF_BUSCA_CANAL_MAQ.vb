Public Class E_IRIS_WEBF_BUSCA_CANAL_MAQ
    Private EE_REL_CM_CANAL_DESC As String
    Private EE_REL_CM_DETER_DESC As String
    Public Property REL_CM_DETER_DESC() As String
        Get
            Return EE_REL_CM_DETER_DESC
        End Get
        Set(ByVal value As String)
            EE_REL_CM_DETER_DESC = value
        End Set
    End Property
    Public Property REL_CM_CANAL_DESC() As String
        Get
            Return EE_REL_CM_CANAL_DESC
        End Get
        Set(ByVal value As String)
            EE_REL_CM_CANAL_DESC = value
        End Set
    End Property
End Class
