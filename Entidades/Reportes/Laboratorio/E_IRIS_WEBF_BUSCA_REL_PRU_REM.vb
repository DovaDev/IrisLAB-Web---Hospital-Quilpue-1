Public Class E_IRIS_WEBF_BUSCA_REL_PRU_REM
    Private E_ID_REL_PRU_REM As Integer
    Private E_ID_FONASA_REM_HOSP As Integer
    Private E_ID_CF_EX As Integer
    Private E_ID_ESTADO As Integer

    Public Property ID_REL_PRU_REM As Integer
        Get
            Return E_ID_REL_PRU_REM
        End Get
        Set(value As Integer)
            E_ID_REL_PRU_REM = value
        End Set
    End Property

    Public Property ID_FONASA_REM_HOSP As Integer
        Get
            Return E_ID_FONASA_REM_HOSP
        End Get
        Set(value As Integer)
            E_ID_FONASA_REM_HOSP = value
        End Set
    End Property

    Public Property ID_CF_EX As Integer
        Get
            Return E_ID_CF_EX
        End Get
        Set(value As Integer)
            E_ID_CF_EX = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
End Class
