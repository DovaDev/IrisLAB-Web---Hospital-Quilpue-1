Public Class E_IRIS_WEBF_BUSCA_CODIGO_FONASA
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_COD As String
    Private EE_CF_DESC As String
    Private EE_CF_CORTO As String
    Private EE_CF_IMP_SOLA As String
    Private EE_CF_IMP_NOM_PER As String
    Private EE_CF_SEL_PRUE As String
    Private EE_CF_DIAS As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_CF_IMP_NUEVO As String
    Private EE_CF_IMP_PARCIAL As String
    Private EE_CF_HOST As String
    Private EE_ID_AMUESTRA As Integer
    Public Property ID_AMUESTRA() As Integer
        Get
            Return EE_ID_AMUESTRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_AMUESTRA = value
        End Set
    End Property
    Public Property CF_HOST() As String
        Get
            Return EE_CF_HOST
        End Get
        Set(ByVal value As String)
            EE_CF_HOST = value
        End Set
    End Property
    Public Property CF_IMP_PARCIAL() As String
        Get
            Return EE_CF_IMP_PARCIAL
        End Get
        Set(ByVal value As String)
            EE_CF_IMP_PARCIAL = value
        End Set
    End Property
    Public Property CF_IMP_NUEVO() As String
        Get
            Return EE_CF_IMP_NUEVO
        End Get
        Set(ByVal value As String)
            EE_CF_IMP_NUEVO = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_DIAS() As Integer
        Get
            Return EE_CF_DIAS
        End Get
        Set(ByVal value As Integer)
            EE_CF_DIAS = value
        End Set
    End Property
    Public Property CF_SEL_PRUE() As String
        Get
            Return EE_CF_SEL_PRUE
        End Get
        Set(ByVal value As String)
            EE_CF_SEL_PRUE = value
        End Set
    End Property
    Public Property CF_IMP_NOM_PER() As String
        Get
            Return EE_CF_IMP_NOM_PER
        End Get
        Set(ByVal value As String)
            EE_CF_IMP_NOM_PER = value
        End Set
    End Property
    Public Property CF_IMP_SOLA() As String
        Get
            Return EE_CF_IMP_SOLA
        End Get
        Set(ByVal value As String)
            EE_CF_IMP_SOLA = value
        End Set
    End Property
    Public Property CF_CORTO() As String
        Get
            Return EE_CF_CORTO
        End Get
        Set(ByVal value As String)
            EE_CF_CORTO = value
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
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
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
End Class
