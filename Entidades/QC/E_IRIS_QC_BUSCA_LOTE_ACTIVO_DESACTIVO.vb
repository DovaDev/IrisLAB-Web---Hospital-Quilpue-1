Public Class E_IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO
    Private EE_QC_NIVEL_DESC As String
    Public Property QC_NIVEL_DESC() As String
        Get
            Return EE_QC_NIVEL_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_NIVEL_DESC = value
        End Set
    End Property
    Private EE_ID_QC_NIVEL As Long
    Public Property ID_QC_NIVEL() As Long
        Get
            Return EE_ID_QC_NIVEL
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_NIVEL = value
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
    Private EE_QC_CONTROL_ANA As String
    Public Property QC_CONTROL_ANA() As String
        Get
            Return EE_QC_CONTROL_ANA
        End Get
        Set(ByVal value As String)
            EE_QC_CONTROL_ANA = value
        End Set
    End Property
    Private EE_QC_LOTE_FECHA_EXP As Date
    Public Property QC_LOTE_FECHA_EXP() As Date
        Get
            Return EE_QC_LOTE_FECHA_EXP
        End Get
        Set(ByVal value As Date)
            EE_QC_LOTE_FECHA_EXP = value
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
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Private EE_QC_LOTE_DESC As String
    Public Property QC_LOTE_DESC() As String
        Get
            Return EE_QC_LOTE_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_DESC = value
        End Set
    End Property
    Private EE_QC_LOTE_COD As String
    Public Property QC_LOTE_COD() As String
        Get
            Return EE_QC_LOTE_COD
        End Get
        Set(ByVal value As String)
            EE_QC_LOTE_COD = value
        End Set
    End Property
    Private EE_ID_QC_LOTE As Long
    Public Property ID_QC_LOTE() As Long
        Get
            Return EE_ID_QC_LOTE
        End Get
        Set(ByVal value As Long)
            EE_ID_QC_LOTE = value
        End Set
    End Property
End Class
