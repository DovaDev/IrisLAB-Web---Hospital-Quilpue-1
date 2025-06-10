Public Class E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_ORDEN_ATE
    Private E_CANT_ATE As Long
    Private E_CANT_EXA As Long
    Private E_PREVI As Long
    Private E_PAGADO As Long
    Private E_COPAGO As Long
    Private E_ID_ORDEN As Long
    Public Property CANT_ATE As Long
        Get
            Return E_CANT_ATE
        End Get
        Set(value As Long)
            E_CANT_ATE = value
        End Set
    End Property
    Public Property CANT_EXA As Long
        Get
            Return E_CANT_EXA
        End Get
        Set(value As Long)
            E_CANT_EXA = value
        End Set
    End Property
    Public Property PREVI As Long
        Get
            Return E_PREVI
        End Get
        Set(value As Long)
            E_PREVI = value
        End Set
    End Property
    Public Property PAGADO As Long
        Get
            Return E_PAGADO
        End Get
        Set(value As Long)
            E_PAGADO = value
        End Set
    End Property
    Public Property COPAGO As Long
        Get
            Return E_COPAGO
        End Get
        Set(value As Long)
            E_COPAGO = value
        End Set
    End Property
    Public Property ID_ORDEN As Long
        Get
            Return E_ID_ORDEN
        End Get
        Set(value As Long)
            E_ID_ORDEN = value
        End Set
    End Property
End Class
