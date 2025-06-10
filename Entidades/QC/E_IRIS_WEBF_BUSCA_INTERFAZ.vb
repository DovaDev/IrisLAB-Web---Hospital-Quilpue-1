Public Class E_IRIS_WEBF_BUSCA_INTERFAZ
    Private EE_IRIS_LNK_I_ID As Long
    Public Property IRIS_LNK_I_ID() As Long
        Get
            Return EE_IRIS_LNK_I_ID
        End Get
        Set(ByVal value As Long)
            EE_IRIS_LNK_I_ID = value
        End Set
    End Property
    Private EE_IRIS_LNK_I_DESCRIPCION As String
    Public Property IRIS_LNK_I_DESCRIPCION() As String
        Get
            Return EE_IRIS_LNK_I_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_IRIS_LNK_I_DESCRIPCION = value
        End Set
    End Property
End Class
