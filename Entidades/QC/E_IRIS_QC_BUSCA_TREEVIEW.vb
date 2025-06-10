Public Class E_IRIS_QC_BUSCA_TREEVIEW
    Private EE_ID_QC_SECCION As Long
    Private EE_QC_SECCION_DESC As String
    Private EE_ID_QC_ANALIZADOR As Long
    Private EE_QC_ANA_DESC As String
    Private EE_ID_QC_LOTE As Long
    Private EE_QC_LOTE_DESC As String
    Private EE_ID_QC_DETERMINACION As Long
    Private EE_QC_DET_DESC As String
    Private EE_UM_DESC As String
    Public Property UM_DESC() As String
        Get
            Return EE_UM_DESC
        End Get
        Set(ByVal value As String)
            EE_UM_DESC = value
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
    Public Property ID_QC_DETERMINACION() As Long
        Get
            Return EE_ID_QC_DETERMINACION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_DETERMINACION = value
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
    Public Property QC_ANA_DESC() As String
        Get
            Return EE_QC_ANA_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_ANA_DESC = value
        End Set
    End Property
    Public Property ID_QC_ANALIZADOR() As Long
        Get
            Return EE_ID_QC_ANALIZADOR
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_ANALIZADOR = value
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
    Public Property ID_QC_SECCION() As Long
        Get
            Return EE_ID_QC_SECCION
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_SECCION = value
        End Set
    End Property
End Class
