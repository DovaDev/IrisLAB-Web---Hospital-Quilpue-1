Public Class E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
    Dim EE_ID_ESTADO As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_EST_MANTENEDOR As String
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property
    Public Property EST_MANTENEDOR As String
        Get
            Return EE_EST_MANTENEDOR
        End Get
        Set(value As String)
            EE_EST_MANTENEDOR = value
        End Set
    End Property
End Class
