Public Class E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
    Private EE_ID_QC_RESULTADO As Long
    Private EE_ID_QC_ANALIZADOR As Long
    Private EE_QC_ANA_DESC As String
    Private EE_ID_QC_LOTE As Long
    Private EE_QC_LOTE_DESC As String
    Private EE_ID_QC_DETERMINACION As Long
    Private EE_QC_DET_DESC As String
    Private EE_QC_RESUL_FECHA As DateTime
    Private EE_QC_RESUL_VALOR_1 As String
    Private EE_QC_RESUL_COMENTARIOS As String
    Private EE_QC_RESUL_HORA As DateTime
    Private EE_QC_RESUL_OMITIDO As String
    Private EE_TP_QC_DESC As String
    Private EE_REL_ADL_LI_F As String
    Private EE_REL_ADL_LS_F As String
    Private EE_REL_ADL_MEDIA_F As String
    Private EE_REL_ADLL_DESV_F As String
    Private EE_REL_ADL_LI_P As String
    Private EE_REL_ADL_LS_P As String
    Private EE_REL_ADL_MEDIA_P As String
    Private EE_REL_ADLL_DESV_P As String
    Private EE_REL_ADL_CANT_F As String
    Private EE_REL_ADL_CANT_P As String
    Private EE_REL_ADL_CV_F As String
    Private EE_REL_ADL_CV_P As String
    Private EE_ID_TP_QC_ACCION As Long
    Public Property ID_TP_QC_ACCION() As Long
        Get
            Return EE_ID_TP_QC_ACCION
        End Get
        Set(ByVal value As Long)
            EE_ID_TP_QC_ACCION = value
        End Set
    End Property
    Public Property REL_ADL_CV_P() As String
        Get
            Return EE_REL_ADL_CV_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_CV_P = value
        End Set
    End Property
    Public Property REL_ADL_CV_F() As String
        Get
            Return EE_REL_ADL_CV_F
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_CV_F = value
        End Set
    End Property
    Public Property REL_ADL_CANT_P() As String
        Get
            Return EE_REL_ADL_CANT_P
        End Get
        Set(ByVal value As String)
            EE_REL_ADL_CANT_P = value
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
    Public Property TP_QC_DESC() As String
        Get
            Return EE_TP_QC_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_QC_DESC = value
        End Set
    End Property
    Public Property QC_RESUL_OMITIDO() As String
        Get
            Return EE_QC_RESUL_OMITIDO
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_OMITIDO = value
        End Set
    End Property
    Public Property QC_RESUL_HORA() As DateTime
        Get
            Return EE_QC_RESUL_HORA
        End Get
        Set(ByVal value As DateTime)
            EE_QC_RESUL_HORA = value
        End Set
    End Property
    Public Property QC_RESUL_COMENTARIOS() As String
        Get
            Return EE_QC_RESUL_COMENTARIOS
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_COMENTARIOS = value
        End Set
    End Property
    Public Property QC_RESUL_VALOR_1() As String
        Get
            Return EE_QC_RESUL_VALOR_1
        End Get
        Set(ByVal value As String)
            EE_QC_RESUL_VALOR_1 = value
        End Set
    End Property
    Public Property QC_RESUL_FECHA() As DateTime
        Get
            Return EE_QC_RESUL_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_QC_RESUL_FECHA = value
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
    Public Property ID_QC_DETERMINACION() As Long
        Get
            Return EE_ID_QC_DETERMINACION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_DETERMINACION = value
        End Set
    End Property
    Public Property QC_LOTE_DESC() As String
        Get
            Return EE_QC_LOTE_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_DESC = value
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
    Public Property QC_ANA_DESC() As String
        Get
            Return EE_QC_ANA_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_ANA_DESC = value
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
    Public Property ID_QC_RESULTADO() As Long
        Get
            Return EE_ID_QC_RESULTADO
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_RESULTADO = value
        End Set
    End Property
End Class
