Public Class E_IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE
    Private EE_ID_QC_DETERMINACION As Long
    Private EE_QC_DET_COD As String
    Private EE_QC_DET_DESC As String
    Public Property QC_DET_DESC() As String
        Get
            Return EE_QC_DET_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_DET_DESC = value
        End Set
    End Property
    Public Property QC_DET_COD() As String
        Get
            Return EE_QC_DET_COD
        End Get
        Set(ByVal value As String)
            EE_QC_DET_COD = value
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
End Class
