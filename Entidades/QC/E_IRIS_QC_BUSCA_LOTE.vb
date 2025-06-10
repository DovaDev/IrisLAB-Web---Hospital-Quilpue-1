Public Class E_IRIS_QC_BUSCA_LOTE
    Private EE_ID_QC_LOTE As Long
    Public Property ID_QC_LOTE() As Long
        Get
            Return EE_ID_QC_LOTE
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE = value
        End Set
    End Property
    Private EE_ID_QC_ANALIZADOR As Long
    Public Property ID_QC_ANALIZADOR() As Long
        Get
            Return EE_ID_QC_ANALIZADOR
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_ANALIZADOR = value
        End Set
    End Property
    Private EE_QC_ANA_DESC As String
    Public Property QC_ANA_DESC() As String
        Get
            Return EE_QC_ANA_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_ANA_DESC = value
        End Set
    End Property
    Private EE_QC_LOTE_DESC As String
    Public Property QC_LOTE_DESC() As String
        Get
            Return EE_QC_LOTE_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_DESC = value
        End Set
    End Property
End Class
