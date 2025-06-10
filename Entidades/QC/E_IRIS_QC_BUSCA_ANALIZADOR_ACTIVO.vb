Public Class E_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO
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
End Class
