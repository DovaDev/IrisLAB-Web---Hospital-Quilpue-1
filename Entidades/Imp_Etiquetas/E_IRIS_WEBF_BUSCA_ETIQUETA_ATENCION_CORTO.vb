Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_ATENCION_CORTO
    Dim EE_ATE_NUM As Integer
    Dim EE_CF_CORTO As String
    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property CF_CORTO As String
        Get
            Return EE_CF_CORTO
        End Get
        Set(value As String)
            EE_CF_CORTO = value
        End Set
    End Property
End Class
