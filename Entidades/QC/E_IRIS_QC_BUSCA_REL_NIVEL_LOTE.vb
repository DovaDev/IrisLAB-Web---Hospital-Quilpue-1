Public Class E_IRIS_QC_BUSCA_REL_NIVEL_LOTE
    Private EE_ID_QC_REL_NIVEL_LOTE As Long
    Private EE_ID_QC_LOTE_1 As Long
    Private EE_QC_LOTE_DESC_1 As String
    Private EE_ID_QC_NIVEL_1 As Long
    Private EE_QC_NIVEL_DESC_1 As String
    Private EE_ID_QC_LOTE_2 As Long
    Private EE_QC_LOTE_DESC_2 As String
    Private EE_ID_QC_NIVEL_2 As Long
    Private EE_QC_NIVEL_DESC_2 As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property QC_NIVEL_DESC_2() As String
        Get
            Return EE_QC_NIVEL_DESC_2
        End Get
        Set(ByVal value As String)
            EE_QC_NIVEL_DESC_2 = value
        End Set
    End Property
    Public Property ID_QC_NIVEL_2() As Long
        Get
            Return EE_ID_QC_NIVEL_2
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_NIVEL_2 = value
        End Set
    End Property
    Public Property QC_LOTE_DESC_2() As String
        Get
            Return EE_QC_LOTE_DESC_2
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_DESC_2 = value
        End Set
    End Property
    Public Property ID_QC_LOTE_2() As Long
        Get
            Return EE_ID_QC_LOTE_2
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE_2 = value
        End Set
    End Property
    Public Property QC_NIVEL_DESC_1() As String
        Get
            Return EE_QC_NIVEL_DESC_1
        End Get
        Set(ByVal value As String)
            EE_QC_NIVEL_DESC_1 = value
        End Set
    End Property
    Public Property ID_QC_NIVEL_1() As Long
        Get
            Return EE_ID_QC_NIVEL_1
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_NIVEL_1 = value
        End Set
    End Property
    Public Property QC_LOTE_DESC_1() As String
        Get
            Return EE_QC_LOTE_DESC_1
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_DESC_1 = value
        End Set
    End Property
    Public Property ID_QC_LOTE_1() As Long
        Get
            Return EE_ID_QC_LOTE_1
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE_1 = value
        End Set
    End Property
    Public Property ID_QC_REL_NIVEL_LOTE() As Long
        Get
            Return EE_ID_QC_REL_NIVEL_LOTE
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_REL_NIVEL_LOTE = value
        End Set
    End Property
End Class
