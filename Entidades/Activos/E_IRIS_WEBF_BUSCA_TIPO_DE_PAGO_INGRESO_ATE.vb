Public Class E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE
    Private E_ID_TP_PAGO As Integer
    Private E_TP_PAGO_DESC As String
    Private E_TP_PAGO_ING As String
    Private E_ID_ESTADO As Integer
    Public Property ID_TP_PAGO As Integer
        Get
            Return E_ID_TP_PAGO
        End Get
        Set(value As Integer)
            E_ID_TP_PAGO = value
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
    Public Property TP_PAGO_ING As String
        Get
            Return E_TP_PAGO_ING
        End Get
        Set(value As String)
            E_TP_PAGO_ING = value
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
