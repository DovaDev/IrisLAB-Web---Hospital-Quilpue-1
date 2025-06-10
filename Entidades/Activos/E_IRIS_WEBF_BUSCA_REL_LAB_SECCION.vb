Public Class E_IRIS_WEBF_BUSCA_REL_LAB_SECCION
    Private EE_ID_RLS_LS As Integer
    Private EE_RLS_LS_DESC As String
    Public Property RLS_LS_DESC() As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(ByVal value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property
    Public Property ID_RLS_LS() As Integer
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(ByVal value As Integer)
            EE_ID_RLS_LS = value
        End Set
    End Property
End Class
