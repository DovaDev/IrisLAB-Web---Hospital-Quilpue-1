Public Class E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
    Private EE_ID_DOC As Long
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_RUT As String
    Public Property DOC_RUT() As String
        Get
            Return EE_DOC_RUT
        End Get
        Set(ByVal value As String)
            EE_DOC_RUT = value
        End Set
    End Property
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property ID_DOC() As Long
        Get
            Return EE_ID_DOC
        End Get
        Set(ByVal value As Long)
            EE_ID_DOC = value
        End Set
    End Property
End Class
