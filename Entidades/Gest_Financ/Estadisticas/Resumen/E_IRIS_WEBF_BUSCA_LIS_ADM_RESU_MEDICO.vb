Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_MEDICO
    Private E_TOTAL_ATE As Long
    Private E_TOTAL_PREVE As Long
    Private E_TOT_FONASA As Long
    Private E_TOTA_SIS As Long
    Private E_TOTA_USU As Long
    Private E_TOTA_COPA As Long
    Private E_DOC_NOMBRE As String
    Private E_DOC_APELLIDO As String
    Private E_ID_DOCTOR As Long
    Public Property TOTAL_ATE As Long
        Get
            Return E_TOTAL_ATE
        End Get
        Set(value As Long)
            E_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Long
        Get
            Return E_TOTAL_PREVE
        End Get
        Set(value As Long)
            E_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Long
        Get
            Return E_TOT_FONASA
        End Get
        Set(value As Long)
            E_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return E_TOTA_SIS
        End Get
        Set(value As Long)
            E_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Long
        Get
            Return E_TOTA_USU
        End Get
        Set(value As Long)
            E_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Long
        Get
            Return E_TOTA_COPA
        End Get
        Set(value As Long)
            E_TOTA_COPA = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return E_DOC_NOMBRE
        End Get
        Set(value As String)
            E_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return E_DOC_APELLIDO
        End Get
        Set(value As String)
            E_DOC_APELLIDO = value
        End Set
    End Property
    Public Property ID_DOCTOR As Long
        Get
            Return E_ID_DOCTOR
        End Get
        Set(value As Long)
            E_ID_DOCTOR = value
        End Set
    End Property
End Class