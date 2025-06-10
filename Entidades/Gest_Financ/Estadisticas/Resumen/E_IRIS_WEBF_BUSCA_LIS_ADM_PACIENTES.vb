Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES
    Private E_ATE_NUM As Long
    Private E_PAC_RUT As String
    Private E_PAC_NOMBRE As String
    Private E_PAC_APELLIDO As String
    Private E_TP_PAGO_DESC As String
    Private E_ATE_TOTAL_PREVI As Long
    Private E_ATE_TOTAL_COPA As Long
    Public Property ATE_NUM As Long
        Get
            Return E_ATE_NUM
        End Get
        Set(value As Long)
            E_ATE_NUM = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return E_PAC_RUT
        End Get
        Set(value As String)
            E_PAC_RUT = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return E_PAC_NOMBRE
        End Get
        Set(value As String)
            E_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return E_PAC_APELLIDO
        End Get
        Set(value As String)
            E_PAC_APELLIDO = value
        End Set
    End Property
    Public Property TP_PAGO_DESC As String
        Get
            Return E_TP_PAGO_DESC
        End Get
        Set(value As String)
            E_TP_PAGO_DESC = value
        End Set
    End Property
    Public Property ATE_TOTAL_PREVI As Long
        Get
            Return E_ATE_TOTAL_PREVI
        End Get
        Set(value As Long)
            E_ATE_TOTAL_PREVI = value
        End Set
    End Property
    Public Property ATE_TOTAL_COPA As Long
        Get
            Return E_ATE_TOTAL_COPA
        End Get
        Set(value As Long)
            E_ATE_TOTAL_COPA = value
        End Set
    End Property
End Class
