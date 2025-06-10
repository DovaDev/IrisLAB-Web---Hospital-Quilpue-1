Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_LUGAR
    Dim E_TOTAL_ATE As Long
    Dim E_TOTAL_PREVE As Long
    Dim E_TOT_FONASA As Long
    Dim E_TOTA_SIS As Long
    Dim E_TOTA_USU As Long
    Dim E_TOTA_COPA As Long
    Dim E_ID_PROCEDENCIA As Long
    Dim E_PROC_DESC As String
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
    Public Property ID_PROCEDENCIA As Long
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            E_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
End Class
