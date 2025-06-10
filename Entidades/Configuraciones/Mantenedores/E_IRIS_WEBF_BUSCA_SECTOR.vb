Public Class E_IRIS_WEBF_BUSCA_SECTOR
    Private EE_ID_SECTOR As Integer
    Private EE_SECTOR_COD As String
    Private EE_SECTOR_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_SECTOR() As Integer
        Get
            Return EE_ID_SECTOR
        End Get
        Set(ByVal value As Integer)
            EE_ID_SECTOR = value
        End Set
    End Property
    Public Property SECTOR_COD() As String
        Get
            Return EE_SECTOR_COD
        End Get
        Set(ByVal value As String)
            EE_SECTOR_COD = value
        End Set
    End Property
    Public Property SECTOR_DESC() As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(ByVal value As String)
            EE_SECTOR_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
