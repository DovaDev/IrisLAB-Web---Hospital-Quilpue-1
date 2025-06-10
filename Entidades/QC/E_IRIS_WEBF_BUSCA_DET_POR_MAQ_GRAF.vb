Public Class E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Private EE_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
        End Set
    End Property
    Private EE_ID_PRUEBA As Integer
    Public Property ID_PRUEBA() As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRUEBA = value
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
    Private EE_ATE_RESULTADO As String
    Public Property ATE_RESULTADO() As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Private EE_ATE_RESULTADO_NUM As Long
    Public Property ATE_RESULTADO_NUM() As Long
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(ByVal value As Long)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property
    Private EE_ATE_R_DESDE As String
    Public Property ATE_R_DESDE() As String
        Get
            Return EE_ATE_R_DESDE
        End Get
        Set(ByVal value As String)
            EE_ATE_R_DESDE = value
        End Set
    End Property
    Private EE_ATE_R_HASTA As String
    Public Property ATE_R_HASTA() As String
        Get
            Return EE_ATE_R_HASTA
        End Get
        Set(ByVal value As String)
            EE_ATE_R_HASTA = value
        End Set
    End Property
    Private EE_ATE_RR_DESDE As String
    Public Property ATE_RR_DESDE() As String
        Get
            Return EE_ATE_RR_DESDE
        End Get
        Set(ByVal value As String)
            EE_ATE_RR_DESDE = value
        End Set
    End Property
    Private EE_ATE_RR_HASTA As String
    Public Property ATE_RR_HASTA() As String
        Get
            Return EE_ATE_RR_HASTA
        End Get
        Set(ByVal value As String)
            EE_ATE_RR_HASTA = value
        End Set
    End Property
    Private EE_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
End Class
