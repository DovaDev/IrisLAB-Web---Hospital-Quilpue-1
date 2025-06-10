Public Class E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO
    Dim EE_ID_CF_PRECIO As Integer
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ID_AÑO As Integer
    Dim EE_CF_PRECIO_AMB As String
    Dim EE_CF_PRECIO_HOS As String
    Dim EE_ID_USUARIO_CREA As String
    Dim EE_CF_PRECIO_C_FECHA As String
    Dim EE_ID_USUARIO_MOD As Integer
    Dim EE_CF_PRECIO_M_FECHA As String
    Dim EE_CF_PRECIO_M_FECHA2 As String

    Public Property ID_CF_PRECIO As Integer
        Get
            Return EE_ID_CF_PRECIO
        End Get
        Set(value As Integer)
            EE_ID_CF_PRECIO = value
        End Set
    End Property

    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ID_AÑO As Integer
        Get
            Return EE_ID_AÑO
        End Get
        Set(value As Integer)
            EE_ID_AÑO = value
        End Set
    End Property

    Public Property CF_PRECIO_AMB As String
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(value As String)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property

    Public Property CF_PRECIO_HOS As String
        Get
            Return EE_CF_PRECIO_HOS
        End Get
        Set(value As String)
            EE_CF_PRECIO_HOS = value
        End Set
    End Property

    Public Property ID_USUARIO_CREA As String
        Get
            Return EE_ID_USUARIO_CREA
        End Get
        Set(value As String)
            EE_ID_USUARIO_CREA = value
        End Set
    End Property

    Public Property CF_PRECIO_C_FECHA As String
        Get
            Return EE_CF_PRECIO_C_FECHA
        End Get
        Set(value As String)
            EE_CF_PRECIO_C_FECHA = value
        End Set
    End Property

    Public Property ID_USUARIO_MOD As Integer
        Get
            Return EE_ID_USUARIO_MOD
        End Get
        Set(value As Integer)
            EE_ID_USUARIO_MOD = value
        End Set
    End Property

    Public Property CF_PRECIO_M_FECHA As String
        Get
            Return EE_CF_PRECIO_M_FECHA
        End Get
        Set(value As String)
            EE_CF_PRECIO_M_FECHA = value
        End Set
    End Property

    Public Property CF_PRECIO_M_FECHA2 As String
        Get
            Return EE_CF_PRECIO_M_FECHA2
        End Get
        Set(value As String)
            EE_CF_PRECIO_M_FECHA2 = value
        End Set
    End Property
End Class
