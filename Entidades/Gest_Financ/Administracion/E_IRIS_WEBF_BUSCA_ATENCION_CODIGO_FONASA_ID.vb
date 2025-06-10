Public Class E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID
    Private E_CF_COD As String
    Private E_CF_DESC As String
    Private E_CF_PRECIO_AMB As Long
    Private E_CF_SEL_PRUE As String
    Private E_CF_NO_FONASA As String
    Private E_CF_PRECIO_HOS As Long
    Private E_AÑO_COD As String
    Private E_CF_DIAS As Long
    Private E_ID_PER As Long
    Private E_ID_PREVE As Long
    Private E_ID_ESTADO As Integer
    Private E_ID_CF_PRECIO As Long
    Private E_ID_CODIGO_FONASA As Long
    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
    Public Property CF_PRECIO_AMB As Long
        Get
            Return E_CF_PRECIO_AMB
        End Get
        Set(value As Long)
            E_CF_PRECIO_AMB = value
        End Set
    End Property
    Public Property CF_SEL_PRUE As String
        Get
            Return E_CF_SEL_PRUE
        End Get
        Set(value As String)
            E_CF_SEL_PRUE = value
        End Set
    End Property
    Public Property CF_NO_FONASA As String
        Get
            Return E_CF_NO_FONASA
        End Get
        Set(value As String)
            E_CF_NO_FONASA = value
        End Set
    End Property
    Public Property CF_PRECIO_HOS As Long
        Get
            Return E_CF_PRECIO_HOS
        End Get
        Set(value As Long)
            E_CF_PRECIO_HOS = value
        End Set
    End Property
    Public Property AÑO_COD As String
        Get
            Return E_AÑO_COD
        End Get
        Set(value As String)
            E_AÑO_COD = value
        End Set
    End Property
    Public Property CF_DIAS As Long
        Get
            Return E_CF_DIAS
        End Get
        Set(value As Long)
            E_CF_DIAS = value
        End Set
    End Property
    Public Property ID_PER As Long
        Get
            Return E_ID_PER
        End Get
        Set(value As Long)
            E_ID_PER = value
        End Set
    End Property
    Public Property ID_PREVE As Long
        Get
            Return E_ID_PREVE
        End Get
        Set(value As Long)
            E_ID_PREVE = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_CF_PRECIO As Long
        Get
            Return E_ID_CF_PRECIO
        End Get
        Set(value As Long)
            E_ID_CF_PRECIO = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class