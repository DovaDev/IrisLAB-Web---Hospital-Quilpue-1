Public Class E_IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION
    Private E_ID_ATENCION As Long
    Private E_ID_RLS_LS As Long
    Private E_RLS_LS_DESC As String

    Private E_ID_SECCION As Long
    Public Property ID_SECCION() As Long
        Get
            Return E_ID_SECCION
        End Get
        Set(ByVal value As Long)
            E_ID_SECCION = value
        End Set
    End Property
    Public Property ID_RLS_LS As Long
        Get
            Return E_ID_RLS_LS
        End Get
        Set(value As Long)
            E_ID_RLS_LS = value
        End Set
    End Property

    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property

    Public Property RLS_LS_DESC As String
        Get
            Return E_RLS_LS_DESC
        End Get
        Set(value As String)
            E_RLS_LS_DESC = value
        End Set
    End Property

    Private E_ID_CODIGO_FONASA As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class