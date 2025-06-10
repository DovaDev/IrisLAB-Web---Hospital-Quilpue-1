Public Class E_IRIS_WEBF_BUSCA_RELACION_METODO_ID_PER
    Dim EE_ID_METODO As Integer
    Dim EE_METO_COD As String
    Dim EE_METO_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_REL_PER_METO As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_REL_PER_METOD As Date

    Public Property ID_METODO As Integer
        Get
            Return EE_ID_METODO
        End Get
        Set(value As Integer)
            EE_ID_METODO = value
        End Set
    End Property
    Public Property METO_COD As String
        Get
            Return EE_METO_COD
        End Get
        Set(value As String)
            EE_METO_COD = value
        End Set
    End Property
    Public Property METO_DESC As String
        Get
            Return EE_METO_DESC
        End Get
        Set(value As String)
            EE_METO_DESC = value
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

    Public Property ID_REL_PER_METO As Integer
        Get
            Return EE_ID_REL_PER_METO
        End Get
        Set(value As Integer)
            EE_ID_REL_PER_METO = value
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

    Public Property REL_PER_METOD As Date
        Get
            Return EE_REL_PER_METOD
        End Get
        Set(value As Date)
            EE_REL_PER_METOD = value
        End Set
    End Property
End Class
