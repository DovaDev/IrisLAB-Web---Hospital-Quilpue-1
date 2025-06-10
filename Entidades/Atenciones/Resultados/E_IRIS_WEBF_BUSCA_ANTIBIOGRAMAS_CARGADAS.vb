Public Class E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS
    Private EE_ID_REL_CF_ANTIB As Long
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_ID_ATENCION As Long
    Private EE_ID_DET_ATE As Long
    Private EE_ID_CF_ANTIBIOGRAMA As Integer
    Private EE_CF_DESC As String
    Private EE_CF_COD As String
    Private EE_CF_DESC_CULT As String
    Private EE_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property CF_DESC_CULT() As String
        Get
            Return EE_CF_DESC_CULT
        End Get
        Set(ByVal value As String)
            EE_CF_DESC_CULT = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_CF_ANTIBIOGRAMA() As Integer
        Get
            Return EE_ID_CF_ANTIBIOGRAMA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CF_ANTIBIOGRAMA = value
        End Set
    End Property
    Public Property ID_DET_ATE() As Long
        Get
            Return EE_ID_DET_ATE
        End Get
        Set(ByVal value As Long)
            EE_ID_DET_ATE = value
        End Set
    End Property
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_REL_CF_ANTIB() As Long
        Get
            Return EE_ID_REL_CF_ANTIB
        End Get
        Set(ByVal value As Long)
            EE_ID_REL_CF_ANTIB = value
        End Set
    End Property
End Class
