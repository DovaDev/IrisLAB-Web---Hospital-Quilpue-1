Public Class E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
    Private EE_ID_CIUDAD As Integer
    Public Property ID_CIUDAD() As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(ByVal value As Integer)
            EE_ID_CIUDAD = value
        End Set
    End Property

    Private EE_ID_COMUNA As Integer
    Public Property ID_COMUNA() As Integer
        Get
            Return EE_ID_COMUNA
        End Get
        Set(ByVal value As Integer)
            EE_ID_COMUNA = value
        End Set
    End Property
End Class