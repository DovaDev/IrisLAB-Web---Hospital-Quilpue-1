Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION
    Private E_ID_ATENCION As Long
    Private E_ATE_NUM As Long
    Private E_ATE_FECHA As Date
    Private E_PREVE_DESC As String
    Private E_ID_PREVE As Long
    Private E_ID_ESTADO As Integer
    Private E_CF_DESC As String
    Private E_CF_COD As String
    Private E_ATE_DET_V_PREVI As Long
    Private E_ATE_DET_V_PAGADO As Long
    Private E_ATE_DET_V_COPAGO As Long
    Private E_PROC_DESC As String
    Private E_ID_CODIGO_FONASA As Long
    Private E_PAC_NOMBRE As String
    Private E_SEXO_DESC As String
    Private E_PAC_APELLIDO As String
    Private E_PAC_RUT As String
    Private E_PAC_DNI As String
    Public Property PAC_DNI() As String
        Get
            Return E_PAC_DNI
        End Get
        Set(ByVal value As String)
            E_PAC_DNI = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return E_PAC_RUT
        End Get
        Set(ByVal value As String)
            E_PAC_RUT = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_NUM As Long
        Get
            Return E_ATE_NUM
        End Get
        Set(value As Long)
            E_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return E_ATE_FECHA
        End Get
        Set(value As Date)
            E_ATE_FECHA = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(value As String)
            E_PREVE_DESC = value
        End Set
    End Property
    Public Property ID_PREVE As Long
        Get
            Return E_ID_PREVE
        End Get
        Set(value As Long)
            E_ID_PREVE = value
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
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property
    Public Property ATE_DET_V_PREVI As Long
        Get
            Return E_ATE_DET_V_PREVI
        End Get
        Set(value As Long)
            E_ATE_DET_V_PREVI = value
        End Set
    End Property
    Public Property ATE_DET_V_PAGADO As Long
        Get
            Return E_ATE_DET_V_PAGADO
        End Get
        Set(value As Long)
            E_ATE_DET_V_PAGADO = value
        End Set
    End Property
    Public Property ATE_DET_V_COPAGO As Long
        Get
            Return E_ATE_DET_V_COPAGO
        End Get
        Set(value As Long)
            E_ATE_DET_V_COPAGO = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            E_ID_CODIGO_FONASA = value
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
End Class
