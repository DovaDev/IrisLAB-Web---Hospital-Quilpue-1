Public Class E_IRIS_WEBF_GRABA_CODIGO_FONASA
    Private EE_COD_CF As String
    Private EE_DESC_CF As String
    Private EE_CORTO_CF As String
    Private EE_DIAS_CF As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_SOLA_CF As String
    Private EE_IMP_NOM_CF As String
    Private EE_IMP_SEL_CF As String
    Private EE_IMP_PAR_CF As String
    Private EE_HOST_CF As String
    Private EE_ID_MUESTRA As Integer
    Public Property ID_MUESTRA() As Integer
        Get
            Return EE_ID_MUESTRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_MUESTRA = value
        End Set
    End Property
    Public Property HOST_CF() As String
        Get
            Return EE_HOST_CF
        End Get
        Set(ByVal value As String)
            EE_HOST_CF = value
        End Set
    End Property
    Public Property IMP_PAR_CF() As String
        Get
            Return EE_IMP_PAR_CF
        End Get
        Set(ByVal value As String)
            EE_IMP_PAR_CF = value
        End Set
    End Property
    Public Property IMP_SEL_CF() As String
        Get
            Return EE_IMP_SEL_CF
        End Get
        Set(ByVal value As String)
            EE_IMP_SEL_CF = value
        End Set
    End Property
    Public Property IMP_NOM_CF() As String
        Get
            Return EE_IMP_NOM_CF
        End Get
        Set(ByVal value As String)
            EE_IMP_NOM_CF = value
        End Set
    End Property
    Public Property SOLA_CF() As String
        Get
            Return EE_SOLA_CF
        End Get
        Set(ByVal value As String)
            EE_SOLA_CF = value
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
    Public Property DIAS_CF() As Integer
        Get
            Return EE_DIAS_CF
        End Get
        Set(ByVal value As Integer)
            EE_DIAS_CF = value
        End Set
    End Property
    Public Property CORTO_CF() As String
        Get
            Return EE_CORTO_CF
        End Get
        Set(ByVal value As String)
            EE_CORTO_CF = value
        End Set
    End Property
    Public Property DESC_CF() As String
        Get
            Return EE_DESC_CF
        End Get
        Set(ByVal value As String)
            EE_DESC_CF = value
        End Set
    End Property
    Public Property COD_CF() As String
        Get
            Return EE_COD_CF
        End Get
        Set(ByVal value As String)
            EE_COD_CF = value
        End Set
    End Property
End Class
