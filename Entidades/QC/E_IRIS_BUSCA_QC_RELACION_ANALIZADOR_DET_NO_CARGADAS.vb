Public Class E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS
    Private EE_QC_DET_DESC As String
    Public Property QC_DET_DESC() As String
        Get
            Return EE_QC_DET_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_DET_DESC = value
        End Set
    End Property
    Private EE_ID_QC_DETERMINACION As Long
    Public Property ID_QC_DETERMINACION() As Long
        Get
            Return EE_ID_QC_DETERMINACION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_DETERMINACION = value
        End Set
    End Property
End Class
