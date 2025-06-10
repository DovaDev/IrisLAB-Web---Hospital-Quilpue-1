Public Class E_IRIS_WEBF_BUSCA_DETALLE_ATENCION3
    Private E_CF_DESC As String
    Private E_CF_CORTO As String
    Private E_ID_CODIGO_FONASA As Long
    Private E_ID_ATENCION As Long
    Private E_ATE_DET_V_ID_ESTADO As Integer
    Private E_EST_DESCRIPCION As String
    Private E_CF_COD As String
    Private E_ID_ESTADO As Integer
    Private E_ID_DET_ATE As Long
    Private E_ID_PER As Long
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
    Public Property CF_CORTO As String
        Get
            Return E_CF_CORTO
        End Get
        Set(value As String)
            E_CF_CORTO = value
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
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO As Integer
        Get
            Return E_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION As String
        Get
            Return E_EST_DESCRIPCION
        End Get
        Set(value As String)
            E_EST_DESCRIPCION = value
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
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_DET_ATE As Long
        Get
            Return E_ID_DET_ATE
        End Get
        Set(value As Long)
            E_ID_DET_ATE = value
        End Set
    End Property
    Public Property ID_PER As Long
        Get
            Return E_ID_PER
        End Get
        Set(value As Long)
            E_ID_PER = value
        End Set
    End Property
End Class