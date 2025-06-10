Public Class E_IRIS_QC_BUSCA_ANALIZADOR
    Private EE_QC_SECCION_DESC As String
    Public Property QC_SECCION_DESC() As String
        Get
            Return EE_QC_SECCION_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_SECCION_DESC = value
        End Set
    End Property
    Private EE_ID_QC_SECCION As Integer
    Public Property ID_QC_SECCION() As Integer
        Get
            Return EE_ID_QC_SECCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_QC_SECCION = value
        End Set
    End Property
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
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
    Private EE_QC_ANA_COD As String
    Public Property QC_ANA_COD() As String
        Get
            Return EE_QC_ANA_COD
        End Get
        Set(ByVal value As String)
            EE_QC_ANA_COD = value
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
End Class
