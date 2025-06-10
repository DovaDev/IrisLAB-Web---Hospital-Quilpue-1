Public Class E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL

    Dim EE_ID_MUESTRA_SANGRE As Integer
    Dim EE_MUESTRA_SANGRE_COD As String

    Dim EE_MUESTRA_SANGRE_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_ID_REL_PER_MSANGRE As Integer
    Dim EE_REL_PER_MSANGRE As Integer

    Public Property ID_MUESTRA_SANGRE As Integer
        Get
            Return EE_ID_MUESTRA_SANGRE
        End Get
        Set(value As Integer)
            EE_ID_MUESTRA_SANGRE = value
        End Set
    End Property

    Public Property MUESTRA_SANGRE_COD As String
        Get
            Return EE_MUESTRA_SANGRE_COD
        End Get
        Set(value As String)
            EE_MUESTRA_SANGRE_COD = value
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

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property ID_REL_PER_MSANGRE As Integer
        Get
            Return EE_ID_REL_PER_MSANGRE
        End Get
        Set(value As Integer)
            EE_ID_REL_PER_MSANGRE = value
        End Set
    End Property

    Public Property REL_PER_MSANGRE As Integer
        Get
            Return EE_REL_PER_MSANGRE
        End Get
        Set(value As Integer)
            EE_REL_PER_MSANGRE = value
        End Set
    End Property

    Public Property MUESTRA_SANGRE_DESC As String
        Get
            Return EE_MUESTRA_SANGRE_DESC
        End Get
        Set(value As String)
            EE_MUESTRA_SANGRE_DESC = value
        End Set
    End Property
End Class