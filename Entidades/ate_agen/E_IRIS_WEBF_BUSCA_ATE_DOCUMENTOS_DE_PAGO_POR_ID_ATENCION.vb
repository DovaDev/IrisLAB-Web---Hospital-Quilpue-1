Public Class E_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_ATE_DET_DOCP As Integer
    Dim EE_ID_ATE_DOCP As Integer
    Dim EE_ID_TP_PAGO As Integer
    Dim EE_ATE_DET_DOCP_V_TOTAL As Integer
    Dim EE_ATE_DET_DOCP_LISTO As Integer
    Dim EE_ID_TRX_PAGO As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_Expr1 As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_TP_PAGO_DESC As String
    Dim EE_ATE_DET_DOCP_V_SISTEMA As String
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_ATE_DET_DOCP As Integer
        Get
            Return EE_ID_ATE_DET_DOCP
        End Get
        Set(value As Integer)
            EE_ID_ATE_DET_DOCP = value
        End Set
    End Property
    Public Property ID_ATE_DOCP As Integer
        Get
            Return EE_ID_ATE_DOCP
        End Get
        Set(value As Integer)
            EE_ID_ATE_DOCP = value
        End Set
    End Property
    Public Property ID_TP_PAGO As Integer
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As Integer)
            EE_ID_TP_PAGO = value
        End Set
    End Property
    Public Property ATE_DET_DOCP_V_TOTAL As Integer
        Get
            Return EE_ATE_DET_DOCP_V_TOTAL
        End Get
        Set(value As Integer)
            EE_ATE_DET_DOCP_V_TOTAL = value
        End Set
    End Property
    Public Property ATE_DET_DOCP_LISTO As Integer
        Get
            Return EE_ATE_DET_DOCP_LISTO
        End Get
        Set(value As Integer)
            EE_ATE_DET_DOCP_LISTO = value
        End Set
    End Property
    Public Property ID_TRX_PAGO As Integer
        Get
            Return EE_ID_TRX_PAGO
        End Get
        Set(value As Integer)
            EE_ID_TRX_PAGO = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property Expr1 As Integer
        Get
            Return EE_Expr1
        End Get
        Set(value As Integer)
            EE_Expr1 = value
        End Set
    End Property
    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
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
    Public Property ATE_DET_DOCP_V_SISTEMA As String
        Get
            Return EE_ATE_DET_DOCP_V_SISTEMA
        End Get
        Set(value As String)
            EE_ATE_DET_DOCP_V_SISTEMA = value
        End Set
    End Property
End Class
