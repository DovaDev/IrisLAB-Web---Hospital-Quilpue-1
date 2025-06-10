Public Class E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE
    Dim EE_ID_DET_ATE As String
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As String
    Dim EE_USU_NIC As String
    Dim EE_ID_ATENCION As String
    Dim EE_ID_ESTADO As String
    Dim EE_CF_COD As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_DET_V_ID_USU As String
    Dim EE_ATE_DET_V_ID_ESTADO As String
    Dim EE_ATE_DET_V_FECHA As Date
    Dim EE_ID_PER As String
    Dim EE_ATE_DET_IMPRIME As String
    Dim EE_ID_TP_PAGO As String
    Dim EE_TP_PAGO_DESC As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_NUM_ATE As Integer
    Dim EE_ESTADO_WEB_DERIVADO As String
    Dim EE_ENCRYPTED_ID As String
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property ESTADO_WEB_DERIVADO() As String
        Get
            Return EE_ESTADO_WEB_DERIVADO
        End Get
        Set(ByVal value As String)
            EE_ESTADO_WEB_DERIVADO = value
        End Set
    End Property
    Public Property ID_DET_ATE As String
        Get
            Return EE_ID_DET_ATE
        End Get
        Set(value As String)
            EE_ID_DET_ATE = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As String
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As String)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property ID_ATENCION As String
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As String)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_USU As String
        Get
            Return EE_ATE_DET_V_ID_USU
        End Get
        Set(value As String)
            EE_ATE_DET_V_ID_USU = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO As String
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As String)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ATE_DET_V_FECHA As Date
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(value As Date)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Public Property ID_PER As String
        Get
            Return EE_ID_PER
        End Get
        Set(value As String)
            EE_ID_PER = value
        End Set
    End Property
    Public Property ATE_DET_IMPRIME As String
        Get
            Return EE_ATE_DET_IMPRIME
        End Get
        Set(value As String)
            EE_ATE_DET_IMPRIME = value
        End Set
    End Property
    Public Property ID_TP_PAGO As String
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As String)
            EE_ID_TP_PAGO = value
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
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property NUM_ATE As String
        Get
            Return EE_NUM_ATE
        End Get
        Set(value As String)
            EE_NUM_ATE = value
        End Set
    End Property
End Class