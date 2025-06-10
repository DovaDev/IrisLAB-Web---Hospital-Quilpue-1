Public Class E_IRIS_QC_BUSCA_SECCIONES
    Private EE_ID_QC_SECCION As Long
    Private EE_QC_SECCION_COD As String
    Private EE_QC_SECCION_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property QC_SECCION_DESC() As String
        Get
            Return EE_QC_SECCION_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_SECCION_DESC = value
        End Set
    End Property
    Public Property QC_SECCION_COD() As String
        Get
            Return EE_QC_SECCION_COD
        End Get
        Set(ByVal value As String)
            EE_QC_SECCION_COD = value
        End Set
    End Property
    Public Property ID_QC_SECCION() As Long
        Get
            Return EE_ID_QC_SECCION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_SECCION = value
        End Set
    End Property
End Class
