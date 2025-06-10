Public Class E_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS_DESACTIVOS
    Dim EE_ID_COSTO As Integer
    Dim EE_COSTO_COD As String
    Dim EE_COSTO_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_COSTO As Integer
        Get
            Return EE_ID_COSTO
        End Get
        Set(value As Integer)
            EE_ID_COSTO = value
        End Set
    End Property
    Public Property COSTO_COD As String
        Get
            Return EE_COSTO_COD
        End Get
        Set(value As String)
            EE_COSTO_COD = value
        End Set
    End Property
    Public Property COSTO_DESC As String
        Get
            Return EE_COSTO_DESC
        End Get
        Set(value As String)
            EE_COSTO_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
