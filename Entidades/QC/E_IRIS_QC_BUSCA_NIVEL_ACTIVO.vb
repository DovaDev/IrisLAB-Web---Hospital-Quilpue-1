Public Class E_IRIS_QC_BUSCA_NIVEL_ACTIVO
    Private EE_ID_QC_NIVEL As Long
    Private EE_QC_NIVEL_COD As String
    Private EE_QC_NIVEL_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property QC_NIVEL_DESC() As String
        Get
            Return EE_QC_NIVEL_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_NIVEL_DESC = value
        End Set
    End Property
    Public Property QC_NIVEL_COD() As String
        Get
            Return EE_QC_NIVEL_COD
        End Get
        Set(ByVal value As String)
            EE_QC_NIVEL_COD = value
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
End Class
