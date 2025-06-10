Public Class E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA
    Private E_ID_AREA As Long
    Private E_AREA_COD As String
    Private E_AREA_DESC As String
    Private E_ID_ESTADO As Long
   
    Public Property ID_AREA As Long
        Get
            Return E_ID_AREA
        End Get
        Set(value As Long)
            E_ID_AREA = value
        End Set
    End Property
    Public Property AREA_COD As String
        Get
            Return E_AREA_COD
        End Get
        Set(value As String)
            E_AREA_COD = value
        End Set
    End Property
    Public Property AREA_DESC As String
        Get
            Return E_AREA_DESC
        End Get
        Set(value As String)
            E_AREA_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Long)
            E_ID_ESTADO = value
        End Set
    End Property
End Class
