Public Class E_IRIS_WEBF_BUSCA_DET_POR_MAKINA
    Private EE_ID_PRUEBA As Long
    Public Property ID_PRUEBA() As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Long)
            EE_ID_PRUEBA = value
        End Set
    End Property
    Private EE_IRIS_LNK_DET_DESCRIPCION As String
    Public Property IRIS_LNK_DET_DESCRIPCION() As String
        Get
            Return EE_IRIS_LNK_DET_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_IRIS_LNK_DET_DESCRIPCION = value
        End Set
    End Property
End Class
