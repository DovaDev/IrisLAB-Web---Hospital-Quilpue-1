Public Class E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
    Private EE_ID_QC_ANALIZADOR As Long
    Private EE_ID_QC_DETERMINACION As Long
    Private EE_ID_QC_LOTE As Long
    Private EE_ID_QC_NIVEL As Long
    Private EE_REL_ADL_LI_F As String
    Private EE_REL_ADL_LS_F As String
    Private EE_REL_ADL_MEDIA_F As String
    Private EE_REL_ADLL_DESV_F As String
    Private EE_REL_ADL_LI_P As String
    Private EE_REL_ADL_LS_P As String
    Private EE_REL_ADL_MEDIA_P As String
    Private EE_REL_ADLL_DESV_P As String
    Private EE_ID_REL_ADL As Long
    Private EE_QC_DET_DESC As String
    Private EE_REL_ADL_CANT_F As String
    Private EE_REL_ADL_CV_F As String
    Public Property REL_ADL_CV_F() As String
        Get
            Return EE_REL_ADL_CV_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_CV_F = value
        End Set
    End Property
    Public Property REL_ADL_CANT_F() As String
        Get
            Return EE_REL_ADL_CANT_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_CANT_F = value
        End Set
    End Property
    Public Property QC_DET_DESC() As String
        Get
            Return EE_QC_DET_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_DET_DESC = value
        End Set
    End Property
    Public Property ID_REL_ADL() As Long
        Get
            Return EE_ID_REL_ADL
        End Get
        Set(ByVal value As Long)
            EE_ID_REL_ADL = value
        End Set
    End Property
    Public Property REL_ADLL_DESV_P() As String
        Get
            Return EE_REL_ADLL_DESV_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADLL_DESV_P = value
        End Set
    End Property
    Public Property REL_ADL_MEDIA_P() As String
        Get
            Return EE_REL_ADL_MEDIA_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_MEDIA_P = value
        End Set
    End Property
    Public Property REL_ADL_LS_P() As String
        Get
            Return EE_REL_ADL_LS_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_LS_P = value
        End Set
    End Property
    Public Property REL_ADL_LI_P() As String
        Get
            Return EE_REL_ADL_LI_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_LI_P = value
        End Set
    End Property
    Public Property REL_ADLL_DESV_F() As String
        Get
            Return EE_REL_ADLL_DESV_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADLL_DESV_F = value
        End Set
    End Property
    Public Property REL_ADL_MEDIA_F() As String
        Get
            Return EE_REL_ADL_MEDIA_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_MEDIA_F = value
        End Set
    End Property
    Public Property REL_ADL_LS_F() As String
        Get
            Return EE_REL_ADL_LS_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_LS_F = value
        End Set
    End Property
    Public Property REL_ADL_LI_F() As String
        Get
            Return EE_REL_ADL_LI_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_LI_F = value
        End Set
    End Property
    Public Property ID_QC_NIVEL() As Long
        Get
            Return EE_ID_QC_NIVEL
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_NIVEL = value
        End Set
    End Property
    Public Property ID_QC_LOTE() As Long
        Get
            Return EE_ID_QC_LOTE
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE = value
        End Set
    End Property
    Public Property ID_QC_DETERMINACION() As Long
        Get
            Return EE_ID_QC_DETERMINACION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_DETERMINACION = value
        End Set
    End Property
    Public Property ID_QC_ANALIZADOR() As Long
        Get
            Return EE_ID_QC_ANALIZADOR
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_ANALIZADOR = value
        End Set
    End Property


End Class
