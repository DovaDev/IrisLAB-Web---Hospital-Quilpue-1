Public Class E_IRIS_QC_BUSCA_TP_ACCION
    Private EE_ID_TP_QC_ACCION As Long
    Private EE_TP_QC_COD As String
    Private EE_TP_QC_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property TP_QC_DESC() As String
        Get
            Return EE_TP_QC_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_QC_DESC = value
        End Set
    End Property
    Public Property TP_QC_COD() As String
        Get
            Return EE_TP_QC_COD
        End Get
        Set(ByVal value As String)
            EE_TP_QC_COD = value
        End Set
    End Property
    Public Property ID_TP_QC_ACCION() As Long
        Get
            Return EE_ID_TP_QC_ACCION
        End Get
        Set(ByVal value As Long)
            EE_ID_TP_QC_ACCION = value
        End Set
    End Property
End Class
