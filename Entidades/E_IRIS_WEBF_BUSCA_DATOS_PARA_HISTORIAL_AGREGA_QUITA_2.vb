Public Class E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2
    Private EE_ID_PER As Integer
    Public Property ID_PER() As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(ByVal value As Integer)
            EE_ID_PER = value
        End Set
    End Property

    Private EE_ATE_DET_V_COPAGO As Integer
    Public Property ATE_DET_V_COPAGO() As Integer
        Get
            Return EE_ATE_DET_V_COPAGO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_COPAGO = value
        End Set
    End Property

    Private EE_ATE_DET_V_PAGADO As Integer
    Public Property ATE_DET_V_PAGADO() As Integer
        Get
            Return EE_ATE_DET_V_PAGADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_PAGADO = value
        End Set
    End Property

    Private EE_ATE_DET_V_PREVI As Integer
    Public Property ATE_DET_V_PREVI() As Integer
        Get
            Return EE_ATE_DET_V_PREVI
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_PREVI = value
        End Set
    End Property

    Private EE_ID_CODIGO_FONASA As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class