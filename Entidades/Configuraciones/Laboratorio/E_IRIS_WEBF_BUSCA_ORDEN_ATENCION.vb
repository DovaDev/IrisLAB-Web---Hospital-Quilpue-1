Public Class E_IRIS_WEBF_BUSCA_ORDEN_ATENCION
    Private EE_ID_ORDEN As Integer
    Private EE_ORD_COD As String
    Private EE_ORD_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Public Property ORD_COD() As String
        Get
            Return EE_ORD_COD
        End Get
        Set(ByVal value As String)
            EE_ORD_COD = value
        End Set
    End Property
    Public Property ID_ORDEN() As Integer
        Get
            Return EE_ID_ORDEN
        End Get
        Set(ByVal value As Integer)
            EE_ID_ORDEN = value
        End Set
    End Property
End Class
