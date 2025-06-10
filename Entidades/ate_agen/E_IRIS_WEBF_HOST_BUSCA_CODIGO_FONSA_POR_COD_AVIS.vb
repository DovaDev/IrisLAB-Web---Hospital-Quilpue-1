Public Class E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_ID_ESTADO As String
    Dim EE_CF_AVIS As String
    Dim EE_CF_DIAS As Integer
    Dim EE_HO_CC As String
    Dim EE_CODIGO_TEST As String
    Dim EE_CF_MULTIPLICADOS As String
    Dim EE_ID_PER As Integer
    Dim EE_CF_PRECIO_AMB As Integer
    Dim EE_CF_PRECIO_HOS As Integer




    Public Property CF_PRECIO_AMB As Integer
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(value As Integer)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property

    Public Property CF_PRECIO_HOS As Integer
        Get
            Return EE_CF_PRECIO_HOS
        End Get
        Set(value As Integer)
            EE_CF_PRECIO_HOS = value
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
    Public Property CF_MULTIPLICADOS As String
        Get
            Return EE_CF_MULTIPLICADOS
        End Get
        Set(value As String)
            EE_CF_MULTIPLICADOS = value
        End Set
    End Property
    Public Property CODIGO_TEST As String
        Get
            Return EE_CODIGO_TEST
        End Get
        Set(value As String)
            EE_CODIGO_TEST = value
        End Set
    End Property
    Public Property HO_CC As String
        Get
            Return EE_HO_CC
        End Get
        Set(value As String)
            EE_HO_CC = value
        End Set
    End Property
    Public Property CF_DIAS As Integer
        Get
            Return EE_CF_DIAS
        End Get
        Set(value As Integer)
            EE_CF_DIAS = value
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
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_AVIS As String
        Get
            Return EE_CF_AVIS
        End Get
        Set(value As String)
            EE_CF_AVIS = value
        End Set
    End Property
End Class
