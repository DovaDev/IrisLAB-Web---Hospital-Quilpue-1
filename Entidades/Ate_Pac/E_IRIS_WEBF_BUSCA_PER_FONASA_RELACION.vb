Public Class E_IRIS_WEBF_BUSCA_PER_FONASA_RELACION
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_PER_DESC As String
    Dim EE_ID_PER As Integer
    Dim EE_PER_COD As String
    Dim EE_PER_NUM_PRU As String
    Dim EE_RLS_LS_DESC As String


    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property

    Public Property PER_DESC As String
        Get
            Return EE_PER_DESC
        End Get
        Set(value As String)
            EE_PER_DESC = value
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

    Public Property PER_COD As String
        Get
            Return EE_PER_COD
        End Get
        Set(value As String)
            EE_PER_COD = value
        End Set
    End Property

    Public Property PER_NUM_PRU As String
        Get
            Return EE_PER_NUM_PRU
        End Get
        Set(value As String)
            EE_PER_NUM_PRU = value
        End Set
    End Property

    Public Property RLS_LS_DESC As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property
End Class
