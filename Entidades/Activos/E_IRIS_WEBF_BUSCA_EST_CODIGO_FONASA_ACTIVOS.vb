Public Class E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_CF_DESC As String
    Dim EE_ID_ESTADO As Integer

    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_PER As Integer
    Private EE_ID_RLS_LS As Integer
    Private EE_ID_TP_CRITICO As Integer
    Private EE_TP_CRITICO_COD As String
    Private EE_TP_CRITICO_DESC As String


    Dim EE_ID_CODIGO_BARRA As Integer
    Dim EE_CB_DESC As String
    Dim EE_CB_COD As String
    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
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
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
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

    Public Property ID_TP_CRITICO As Integer
        Get
            Return EE_ID_TP_CRITICO
        End Get
        Set(value As Integer)
            EE_ID_TP_CRITICO = value
        End Set
    End Property

    Public Property TP_CRITICO_COD As String
        Get
            Return EE_TP_CRITICO_COD
        End Get
        Set(value As String)
            EE_TP_CRITICO_COD = value
        End Set
    End Property

    Public Property TP_CRITICO_DESC As String
        Get
            Return EE_TP_CRITICO_DESC
        End Get
        Set(value As String)
            EE_TP_CRITICO_DESC = value
        End Set
    End Property

    Public Property ID_RLS_LS As Integer
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As Integer)
            EE_ID_RLS_LS = value
        End Set
    End Property

    Public Property ID_CODIGO_BARRA As Integer
        Get
            Return EE_ID_CODIGO_BARRA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_BARRA = value
        End Set
    End Property

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Public Property CB_COD As String
        Get
            Return EE_CB_COD
        End Get
        Set(value As String)
            EE_CB_COD = value
        End Set
    End Property
End Class
