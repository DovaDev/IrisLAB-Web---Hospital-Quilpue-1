Public Class E_IRIS_QC_BUSCA_SECCION_ACTIVO
    Private EE_QC_SECCION_DESC As String
    Public Property QC_SECCION_DESC() As String
        Get
            Return EE_QC_SECCION_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_SECCION_DESC = value
        End Set
    End Property
    Private EE_ID_QC_SECCION As Long
    Public Property ID_QC_SECCION() As Long
        Get
            Return EE_ID_QC_SECCION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_SECCION = value
        End Set
    End Property
End Class
