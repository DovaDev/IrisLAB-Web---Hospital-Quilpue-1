Public Class E_IRIS_WEBF_BUSCA_AREA
    Private EE_ID_AREA As Integer
    Private EE_AREA_COD As String
    Private EE_AREA_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property AREA_DESC() As String
        Get
            Return EE_AREA_DESC
        End Get
        Set(ByVal value As String)
            EE_AREA_DESC = value
        End Set
    End Property
    Public Property AREA_COD() As String
        Get
            Return EE_AREA_COD
        End Get
        Set(ByVal value As String)
            EE_AREA_COD = value
        End Set
    End Property
    Public Property ID_AREA() As Integer
        Get
            Return EE_ID_AREA
        End Get
        Set(ByVal value As Integer)
            EE_ID_AREA = value
        End Set
    End Property
End Class
