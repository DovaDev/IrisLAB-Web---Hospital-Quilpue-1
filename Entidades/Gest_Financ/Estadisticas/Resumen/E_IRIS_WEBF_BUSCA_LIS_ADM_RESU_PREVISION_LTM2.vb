Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_LTM2
    Private E_TOTAL_ATE As Integer
    Private E_TOTAL_PREVE As String
    Private E_TOT_FONASA As String
    Private E_TOTA_SIS As Integer
    Private E_TOTA_USU As Integer
    Private E_TOTA_COPA As Integer
    Private E_ID_PREVE As Integer
    Private E_PREVE_DESC As String
    Public Property TOTAL_ATE As Integer
        Get
            Return E_TOTAL_ATE
        End Get
        Set(value As Integer)
            E_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Integer
        Get
            Return E_TOTAL_PREVE
        End Get
        Set(value As Integer)
            E_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Integer
        Get
            Return E_TOT_FONASA
        End Get
        Set(value As Integer)
            E_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Integer
        Get
            Return E_TOTA_SIS
        End Get
        Set(value As Integer)
            E_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Integer
        Get
            Return E_TOTA_USU
        End Get
        Set(value As Integer)
            E_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Integer
        Get
            Return E_TOTA_COPA
        End Get
        Set(value As Integer)
            E_TOTA_COPA = value
        End Set
    End Property
    Public Property ID_PREVE As Integer
        Get
            Return E_ID_PREVE
        End Get
        Set(value As Integer)
            E_ID_PREVE = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(value As String)
            E_PREVE_DESC = value
        End Set
    End Property
End Class
