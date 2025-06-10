Public Class E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    Private EE_AÑO_DESC As String
    Private EE_ID_PREVE As Integer
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_PRECIO_AMB As Integer
    Private EE_CF_PRECIO_HOS As Integer
    Private EE_CF_DESC As String
    Private EE_CF_COD As String
    Private EE_ID_AÑO As Integer
    Private EE_ID_CF_PRECIO As Integer
    Private EE_CF_BONIFICACION As Integer
    Private EE_CF_PRECIO_PARTICULAR As Integer
    Public Property CF_PRECIO_PARTICULAR() As Integer
        Get
            Return EE_CF_PRECIO_PARTICULAR
        End Get
        Set(ByVal value As Integer)
            EE_CF_PRECIO_PARTICULAR = value
        End Set
    End Property
    Public Property CF_BONIFICACION() As Integer
        Get
            Return EE_CF_BONIFICACION
        End Get
        Set(ByVal value As Integer)
            EE_CF_BONIFICACION = value
        End Set
    End Property
    Public Property ID_CF_PRECIO() As Integer
        Get
            Return EE_ID_CF_PRECIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_CF_PRECIO = value
        End Set
    End Property
    Public Property ID_AÑO() As Integer
        Get
            Return EE_ID_AÑO
        End Get
        Set(ByVal value As Integer)
            EE_ID_AÑO = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CF_PRECIO_HOS() As Integer
        Get
            Return EE_CF_PRECIO_HOS
        End Get
        Set(ByVal value As Integer)
            EE_CF_PRECIO_HOS = value
        End Set
    End Property
    Public Property CF_PRECIO_AMB() As Integer
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(ByVal value As Integer)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_PREVE() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property
    Public Property AÑO_DESC() As String
        Get
            Return EE_AÑO_DESC
        End Get
        Set(ByVal value As String)
            EE_AÑO_DESC = value
        End Set
    End Property
End Class
