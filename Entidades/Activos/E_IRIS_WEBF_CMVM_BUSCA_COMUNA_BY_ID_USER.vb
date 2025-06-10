Public Class E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER
    Private EE_ID_CIUDAD As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_ID_REL_CIU_COM As Integer
    Private EE_ID_COMUNA As Integer
    Public Property ID_COMUNA() As Integer
        Get
            Return EE_ID_COMUNA
        End Get
        Set(ByVal value As Integer)
            EE_ID_COMUNA = value
        End Set
    End Property

    Private EE_COM_COD As String
    Public Property COM_COD() As String
        Get
            Return EE_COM_COD
        End Get
        Set(ByVal value As String)
            EE_COM_COD = value
        End Set
    End Property

    Private EE_COM_DESC As String
    Public Property COM_DESC() As String
        Get
            Return EE_COM_DESC
        End Get
        Set(ByVal value As String)
            EE_COM_DESC = value
        End Set
    End Property

    Public Property ID_REL_CIU_COM As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(value As Integer)
            EE_ID_REL_CIU_COM = value
        End Set
    End Property

    Public Property ID_CIUDAD As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(value As Integer)
            EE_ID_CIUDAD = value
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
