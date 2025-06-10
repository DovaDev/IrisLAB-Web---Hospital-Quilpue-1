Public Class E_IRIS_WEBF_BUSCA_RELACION_INDICACIONES_COD_FONASA
    Private EE_ID_IND As Integer
    Private EE_ID_CODIGO_FONASA As String
    Private EE_IND_DES As String
    Private EE_ID_ESTADO As Integer
    Private EE_ID_RLS_CF_IND As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property IND_DES() As String
        Get
            Return EE_IND_DES
        End Get
        Set(ByVal value As String)
            EE_IND_DES = value
        End Set
    End Property

    Public Property ID_IND() As Integer
        Get
            Return EE_ID_IND
        End Get
        Set(ByVal value As Integer)
            EE_ID_IND = value
        End Set
    End Property
    Public Property ID_RLS_CF_IND As Integer
        Get
            Return EE_ID_RLS_CF_IND
        End Get
        Set(value As Integer)
            EE_ID_RLS_CF_IND = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As String
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As String)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class
