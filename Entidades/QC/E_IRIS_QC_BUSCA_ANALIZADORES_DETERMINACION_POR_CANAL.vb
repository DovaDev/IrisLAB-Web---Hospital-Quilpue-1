Public Class E_IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL
    Private EE_QC_REL_CA_DESC As String
    Private EE_QC_DET_DESC As String
    Private EE_ID_QC_REL_CA As Long
    Public Property ID_QC_REL_CA() As Long
        Get
            Return EE_ID_QC_REL_CA
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_REL_CA = value
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
    Public Property QC_REL_CA_DESC() As String
        Get
            Return EE_QC_REL_CA_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_REL_CA_DESC = value
        End Set
    End Property
End Class
