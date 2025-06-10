Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
    Private EE_TOTAL_PREVE As Integer
    Private EE_EST_DESCRIPCION As String
    Private EE_ID_ESTADO As Integer
    Private EE_ATE_DET_V_ID_ESTADO As Integer
    Public Property ATE_DET_V_ID_ESTADO() As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property
    Public Property TOTAL_PREVE() As Integer
        Get
            Return EE_TOTAL_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_PREVE = value
        End Set
    End Property
End Class
