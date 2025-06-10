Public Class E_IRIS_QC_BUSCA_ANALITO
    Private EE_UM_DESC As String
    Public Property UM_DESC() As String
        Get
            Return EE_UM_DESC
        End Get
        Set(ByVal value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Private EE_ID_U_MEDIDA As Integer
    Public Property ID_U_MEDIDA() As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(ByVal value As Integer)
            EE_ID_U_MEDIDA = value
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
    Private EE_QC_DET_DESC As String
    Public Property QC_DET_DESC() As String
        Get
            Return EE_QC_DET_DESC
        End Get
        Set(ByVal value As String)
            EE_QC_DET_DESC = value
        End Set
    End Property
    Private EE_QC_DET_COD As String
    Public Property QC_DET_COD() As String
        Get
            Return EE_QC_DET_COD
        End Get
        Set(ByVal value As String)
            EE_QC_DET_COD = value
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
