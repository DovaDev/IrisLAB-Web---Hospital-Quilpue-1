Public Class E_IRIS_WEBF_BUSCA_LIS_CANTIAD_EXAMENES_DIARIOS
    Dim EE_TOTAL_ATE As Integer
    Dim EE_TOTAL_EXA As Integer
    Dim EE_TOTA_SIS As Integer
    Dim EE_TOTA_USU As Integer
    Dim EE_TOTA_COPA As Integer
    Public Property TOTAL_ATE As Integer
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(value As Integer)
            EE_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_EXA As Integer
        Get
            Return EE_TOTAL_EXA
        End Get
        Set(value As Integer)
            EE_TOTAL_EXA = value
        End Set
    End Property
    Public Property TOTA_SIS As Integer
        Get
            Return EE_TOTA_SIS
        End Get
        Set(value As Integer)
            EE_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Integer
        Get
            Return EE_TOTA_USU
        End Get
        Set(value As Integer)
            EE_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Integer
        Get
            Return EE_TOTA_COPA
        End Get
        Set(value As Integer)
            EE_TOTA_COPA = value
        End Set
    End Property
End Class
