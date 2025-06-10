Public Class E_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES
    Dim EE_ID_TP_PAGO As Integer
    Dim EE_T_PREVI As Integer
    Dim EE_T_PAGADO As Integer
    Dim EE_T_COPAGO As Integer
    Dim EE_TP_PAGO_DESC As String
    Public Property ID_TP_PAGO As Integer
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As Integer)
            EE_ID_TP_PAGO = value
        End Set
    End Property
    Public Property T_PREVI As Integer
        Get
            Return EE_T_PREVI
        End Get
        Set(value As Integer)
            EE_T_PREVI = value
        End Set
    End Property
    Public Property T_PAGADO As Integer
        Get
            Return EE_T_PAGADO
        End Get
        Set(value As Integer)
            EE_T_PAGADO = value
        End Set
    End Property
    Public Property T_COPAGO As Integer
        Get
            Return EE_T_COPAGO
        End Get
        Set(value As Integer)
            EE_T_COPAGO = value
        End Set
    End Property
    Public Property TP_PAGO_DESC As String
        Get
            Return EE_TP_PAGO_DESC
        End Get
        Set(value As String)
            EE_TP_PAGO_DESC = value
        End Set
    End Property
End Class
