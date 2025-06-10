Public Class E_IRIS_WEBF_BUSCA_BACTERIO
    Private EE_ID_TP_BAC As Integer
    Private EE_TP_BAC_COD As String
    Private EE_TP_BAC_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property TP_BAC_DESC() As String
        Get
            Return EE_TP_BAC_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_BAC_DESC = value
        End Set
    End Property
    Public Property TP_BAC_COD() As String
        Get
            Return EE_TP_BAC_COD
        End Get
        Set(ByVal value As String)
            EE_TP_BAC_COD = value
        End Set
    End Property


    Public Property ID_TP_BAC() As Integer
        Get
            Return EE_ID_TP_BAC
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_BAC = value
        End Set
    End Property
End Class
