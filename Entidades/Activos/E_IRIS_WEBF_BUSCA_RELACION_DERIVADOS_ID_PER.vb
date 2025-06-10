Public Class E_IRIS_WEBF_BUSCA_RELACION_DERIVADOS_ID_PER
    Dim EE_ID_REL_PER_DER As Integer
    Dim EE_ID_PER As Integer

    Dim EE_ID_DERIVADO As Integer
    Dim EE_ID_ESTADO As Integer

    Dim EE_ID_USUARIO As Integer

    Dim EE_REL_PER_DERIV As Date

    Dim EE_DERI_DESC As String

    Dim EE_DERI_COD As String

    Public Property ID_DERIVADO As Integer
        Get
            Return EE_ID_DERIVADO
        End Get
        Set(value As Integer)
            EE_ID_DERIVADO = value
        End Set
    End Property

    Public Property DERI_DESC As String
        Get
            Return EE_DERI_DESC
        End Get
        Set(value As String)
            EE_DERI_DESC = value
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

    Public Property DERI_COD As String
        Get
            Return EE_DERI_COD
        End Get
        Set(value As String)
            EE_DERI_COD = value
        End Set
    End Property

    Public Property ID_REL_PER_DER As Integer
        Get
            Return EE_ID_REL_PER_DER
        End Get
        Set(value As Integer)
            EE_ID_REL_PER_DER = value
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

    Public Property REL_PER_DERIV As Date
        Get
            Return EE_REL_PER_DERIV
        End Get
        Set(value As Date)
            EE_REL_PER_DERIV = value
        End Set
    End Property
End Class
