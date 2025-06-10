Public Class E_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS
    Dim EE_ID_SECTOR As Integer
    Dim EE_SECTOR_COD As String
    Dim EE_SECTOR_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_SECTOR As Integer
        Get
            Return EE_ID_SECTOR
        End Get
        Set(value As Integer)
            EE_ID_SECTOR = value
        End Set
    End Property
    Public Property SECTOR_COD As String
        Get
            Return EE_SECTOR_COD
        End Get
        Set(value As String)
            EE_SECTOR_COD = value
        End Set
    End Property
    Public Property SECTOR_DESC As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(value As String)
            EE_SECTOR_DESC = value
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
