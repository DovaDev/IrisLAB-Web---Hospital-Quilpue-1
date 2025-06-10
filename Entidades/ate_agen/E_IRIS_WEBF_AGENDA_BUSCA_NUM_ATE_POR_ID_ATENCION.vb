Public Class E_IRIS_WEBF_AGENDA_BUSCA_NUM_ATE_POR_ID_ATENCION
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

End Class
