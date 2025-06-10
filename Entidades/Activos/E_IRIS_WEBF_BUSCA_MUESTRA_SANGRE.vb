Public Class E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE
    Private EE_ID_MUESTRA_SANGRE As Integer
    Private EE_MUESTRA_SANGRE_COD As String
    Private EE_MUESTRA_SANGRE_DESC As String
    Private EE_ID_ESTADO As Integer

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

    Public Property MUESTRA_SANGRE_DESC As String
        Get
            Return EE_MUESTRA_SANGRE_DESC
        End Get
        Set(value As String)
            EE_MUESTRA_SANGRE_DESC = value
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