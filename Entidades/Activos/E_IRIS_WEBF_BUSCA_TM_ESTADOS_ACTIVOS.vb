Public Class E_IRIS_WEBF_BUSCA_TM_ESTADOS_ACTIVOS
    Private EE_EST_DESCRIPCION As String
    Private EE_EST_TM_ACTIVA As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_TM_ACTIVA() As String
        Get
            Return EE_EST_TM_ACTIVA
        End Get
        Set(ByVal value As String)
            EE_EST_TM_ACTIVA = value
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
End Class
