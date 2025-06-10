Public Class E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA
    Private E_SEXO_DESC As String
    Private E_ID_PRUEBA As Long
    Private E_RF_ANO_DESDE As Integer
    Private E_RF_MESES_DESDE As Integer
    Private E_RF_DIAS_DESDE As Integer
    Private E_RF_V_B_DESDE As Double
    Private E_RF_V_DESDE As Double
    Private E_RF_V_HASTA As Double
    Private E_RF_V_A_HASTA As Double
    Private E_RF_R_TEXTO As String
    Private E_RF_ANO_HASTA As Integer
    Private E_RF_MESES_HASTA As Integer
    Private E_RF_DIAS_HASTA As Integer
    Private E_ATE_R_DESDE As String
    Private E_ATE_R_HASTA As String
    Public Property ATE_R_HASTA() As String
        Get
            Return E_ATE_R_HASTA
        End Get
        Set(ByVal value As String)
            E_ATE_R_HASTA = value
        End Set
    End Property
    Public Property ATE_R_DESDE() As String
        Get
            Return E_ATE_R_DESDE
        End Get
        Set(ByVal value As String)
            E_ATE_R_DESDE = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return E_SEXO_DESC
        End Get
        Set(value As String)
            E_SEXO_DESC = value
        End Set
    End Property
    Public Property ID_PRUEBA As Long
        Get
            Return E_ID_PRUEBA
        End Get
        Set(value As Long)
            E_ID_PRUEBA = value
        End Set
    End Property
    Public Property RF_ANO_DESDE As Integer
        Get
            Return E_RF_ANO_DESDE
        End Get
        Set(value As Integer)
            E_RF_ANO_DESDE = value
        End Set
    End Property
    Public Property RF_MESES_DESDE As Integer
        Get
            Return E_RF_MESES_DESDE
        End Get
        Set(value As Integer)
            E_RF_MESES_DESDE = value
        End Set
    End Property
    Public Property RF_DIAS_DESDE As Integer
        Get
            Return E_RF_DIAS_DESDE
        End Get
        Set(value As Integer)
            E_RF_DIAS_DESDE = value
        End Set
    End Property
    Public Property RF_V_B_DESDE As Double
        Get
            Return E_RF_V_B_DESDE
        End Get
        Set(value As Double)
            E_RF_V_B_DESDE = value
        End Set
    End Property
    Public Property RF_V_DESDE As Double
        Get
            Return E_RF_V_DESDE
        End Get
        Set(value As Double)
            E_RF_V_DESDE = value
        End Set
    End Property
    Public Property RF_V_HASTA As Double
        Get
            Return E_RF_V_HASTA
        End Get
        Set(value As Double)
            E_RF_V_HASTA = value
        End Set
    End Property
    Public Property RF_V_A_HASTA As Double
        Get
            Return E_RF_V_A_HASTA
        End Get
        Set(value As Double)
            E_RF_V_A_HASTA = value
        End Set
    End Property
    Public Property RF_R_TEXTO As String
        Get
            Return E_RF_R_TEXTO
        End Get
        Set(value As String)
            E_RF_R_TEXTO = value
        End Set
    End Property
    Public Property RF_ANO_HASTA As Integer
        Get
            Return E_RF_ANO_HASTA
        End Get
        Set(value As Integer)
            E_RF_ANO_HASTA = value
        End Set
    End Property
    Public Property RF_MESES_HASTA As Integer
        Get
            Return E_RF_MESES_HASTA
        End Get
        Set(value As Integer)
            E_RF_MESES_HASTA = value
        End Set
    End Property
    Public Property RF_DIAS_HASTA As Integer
        Get
            Return E_RF_DIAS_HASTA
        End Get
        Set(value As Integer)
            E_RF_DIAS_HASTA = value
        End Set
    End Property
End Class