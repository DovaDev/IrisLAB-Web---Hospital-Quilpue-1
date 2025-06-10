Public Class E_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ
    Private EE_IRIS_LNK_MAQ_ID As Long
    Public Property IRIS_LNK_MAQ_ID() As Long
        Get
            Return EE_IRIS_LNK_MAQ_ID
        End Get
        Set(ByVal value As Long)
            EE_IRIS_LNK_MAQ_ID = value
        End Set
    End Property
    Private EE_IRIS_LNK_MAQ_DESCRIPCION As String
    Public Property IRIS_LNK_MAQ_DESCRIPCION() As String
        Get
            Return EE_IRIS_LNK_MAQ_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_IRIS_LNK_MAQ_DESCRIPCION = value
        End Set
    End Property
End Class
