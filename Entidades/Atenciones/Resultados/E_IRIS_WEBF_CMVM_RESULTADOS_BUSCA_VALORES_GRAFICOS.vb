Public Class E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS
    Private E_ID_ATE As Long
    Public Property ID_ATE() As Long
        Get
            Return E_ID_ATE
        End Get
        Set(ByVal value As Long)
            E_ID_ATE = value
        End Set
    End Property

    Private E_NN_ATE As Long
    Public Property NN_ATE() As Long
        Get
            Return E_NN_ATE
        End Get
        Set(ByVal value As Long)
            E_NN_ATE = value
        End Set
    End Property

    Private E_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return E_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            E_ATE_FECHA = value
        End Set
    End Property

    Private E_ATE_R_VALUE As Double?
    Public Property ATE_R_VALUE() As Double?
        Get
            Return E_ATE_R_VALUE
        End Get
        Set(ByVal value As Double?)
            E_ATE_R_VALUE = value
        End Set
    End Property

    Private E_ATE_R_DESDE As Double?
    Public Property ATE_R_DESDE() As Double?
        Get
            Return E_ATE_R_DESDE
        End Get
        Set(ByVal value As Double?)
            E_ATE_R_DESDE = value
        End Set
    End Property

    Private E_ATE_R_HASTA As Double?
    Public Property ATE_R_HASTA() As Double?
        Get
            Return E_ATE_R_HASTA
        End Get
        Set(ByVal value As Double?)
            E_ATE_R_HASTA = value
        End Set
    End Property

    Private E_ATE_EST_VALIDA As Integer
    Public Property ATE_EST_VALIDA() As Integer
        Get
            Return E_ATE_EST_VALIDA
        End Get
        Set(ByVal value As Integer)
            E_ATE_EST_VALIDA = value
        End Set
    End Property
End Class
