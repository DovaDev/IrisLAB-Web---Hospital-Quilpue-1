Public Class E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_COD As String
    Private EE_CF_DESC As String
    Private EE_USU_NIC As String
    Private EE_ID_DET_ATE As Long
    Private EE_ATE_DET_V_ID_ESTADO As Integer
    Private EE_ATE_DET_V_FECHA As DateTime
    Public Property ATE_DET_V_FECHA() As DateTime
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO() As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
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
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
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
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
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
End Class

Public Class E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS_2
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
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
End Class

Public Class E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS_2
    Inherits E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS
    Private EE_ID_REL_CF_ANTIB As Long
    Private EE_ID_ATENCION As Long
    Private EE_ID_DET_ATE As Long
    Private EE_ID_CF_ANTIBIOGRAMA As Integer
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
    Public Property ID_REL_CF_ANTIB() As Long
        Get
            Return EE_ID_REL_CF_ANTIB
        End Get
        Set(ByVal value As Long)
            EE_ID_REL_CF_ANTIB = value
        End Set
    End Property
End Class


Public Class E_IRIS_WEBF_GUARDA_QUITA_PANEL_2
    Private EE_ID_PANEL As Integer
    Private EE_ID_ATE As Long
    Private EE_ID_CF_CULT As Integer
    Private EE_ID_PREVE As Integer
    Public Property ID_PREVE() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property
    Public Property ID_CF_CULT() As Integer
        Get
            Return EE_ID_CF_CULT
        End Get
        Set(ByVal value As Integer)
            EE_ID_CF_CULT = value
        End Set
    End Property
    Private EE_TYPE As String
    Public Property TYPE() As String
        Get
            Return EE_TYPE
        End Get
        Set(ByVal value As String)
            EE_TYPE = value
        End Set
    End Property
    Public Property ID_ATE() As Long
        Get
            Return EE_ID_ATE
        End Get
        Set(ByVal value As Long)
            EE_ID_ATE = value
        End Set
    End Property
    Public Property ID_PANEL() As Integer
        Get
            Return EE_ID_PANEL
        End Get
        Set(ByVal value As Integer)
            EE_ID_PANEL = value
        End Set
    End Property
End Class