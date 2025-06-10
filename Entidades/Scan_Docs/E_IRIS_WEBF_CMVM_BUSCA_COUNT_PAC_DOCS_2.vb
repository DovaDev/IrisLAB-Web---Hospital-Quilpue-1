Public Class E_IRIS_WEBF_CMVM_BUSCA_COUNT_PAC_DOCS_2
    Private EE_COUNT As Long
    Private EE_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property _COUNT() As Long
        Get
            Return EE_COUNT
        End Get
        Set(ByVal value As Long)
            EE_COUNT = value
        End Set
    End Property
End Class
