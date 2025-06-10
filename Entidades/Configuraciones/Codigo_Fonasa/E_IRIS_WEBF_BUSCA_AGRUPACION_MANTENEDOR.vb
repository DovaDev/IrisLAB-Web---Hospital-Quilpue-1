Public Class E_IRIS_WEBF_BUSCA_AGRUPACION_MANTENEDOR
    Private EE_ID_AMUESTRA As Integer
    Private EE_AMUE_COD As String
    Private EE_AMUE_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property AMUE_DESC() As String
        Get
            Return EE_AMUE_DESC
        End Get
        Set(ByVal value As String)
            EE_AMUE_DESC = value
        End Set
    End Property
    Public Property AMUE_COD() As String
        Get
            Return EE_AMUE_COD
        End Get
        Set(ByVal value As String)
            EE_AMUE_COD = value
        End Set
    End Property
    Public Property ID_AMUESTRA() As Integer
        Get
            Return EE_ID_AMUESTRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_AMUESTRA = value
        End Set
    End Property
End Class
