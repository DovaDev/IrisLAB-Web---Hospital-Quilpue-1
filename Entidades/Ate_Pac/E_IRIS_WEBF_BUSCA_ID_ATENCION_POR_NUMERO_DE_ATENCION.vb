Public Class E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
    Dim EE_ATE_NUM As String
    Dim EE_ID_ATENCION As String
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_ATENCION As String
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As String)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
