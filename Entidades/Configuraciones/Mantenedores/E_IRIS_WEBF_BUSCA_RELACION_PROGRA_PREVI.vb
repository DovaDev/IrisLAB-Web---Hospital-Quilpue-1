Public Class E_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI
    Dim EE_ID_PROGRA As Integer
    Dim EE_PROGRA_COD As String
    Dim EE_PROGRA_DESC As String
    Dim EE_ID_ESTADO As Integer


    Public Property ID_PROGRA As Integer
        Get
            Return EE_ID_PROGRA
        End Get
        Set(value As Integer)
            EE_ID_PROGRA = value
        End Set
    End Property

    Public Property PROGRA_COD As String
        Get
            Return EE_PROGRA_COD
        End Get
        Set(value As String)
            EE_PROGRA_COD = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
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
