Public Class E_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL
    Private EE_ID_QC_LOTE As Long
    Private EE_QC_LOTE_DESC As String
    Private EE_ID_QC_NIVEL As Long
    Public Property ID_QC_NIVEL() As Long
        Get
            Return EE_ID_QC_NIVEL
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_NIVEL = value
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
End Class
