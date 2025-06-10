Public Class E_IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA
    Private EE_ID_COSTO As Integer
    Public Property ID_COSTO() As Integer
        Get
            Return EE_ID_COSTO
        End Get
        Set(ByVal value As Integer)
            EE_ID_COSTO = value
        End Set
    End Property

    Private EE_COSTO_COD As String
    Public Property COSTO_COD() As String
        Get
            Return EE_COSTO_COD
        End Get
        Set(ByVal value As String)
            EE_COSTO_COD = value
        End Set
    End Property

    Private EE_COSTO_DESC As String
    Public Property COSTO_DESC() As String
        Get
            Return EE_COSTO_DESC
        End Get
        Set(ByVal value As String)
            EE_COSTO_DESC = value
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
End Class