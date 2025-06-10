Public Class E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_IRIS_REL_PACK_CF As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Private EE_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property

    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property IRIS_REL_PACK_CF As Integer
        Get
            Return EE_IRIS_REL_PACK_CF
        End Get
        Set(value As Integer)
            EE_IRIS_REL_PACK_CF = value
        End Set
    End Property
End Class