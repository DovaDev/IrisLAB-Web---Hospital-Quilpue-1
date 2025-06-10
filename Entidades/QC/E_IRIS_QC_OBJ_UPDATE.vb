Public Class E_IRIS_QC_OBJ_UPDATE
    Private EE_NUM As String
    Public Property NUM() As String
        Get
            Return EE_NUM
        End Get
        Set(ByVal value As String)
            EE_NUM = value
        End Set
    End Property
    Private EE_ID_REL As Integer
    Public Property ID_REL() As Integer
        Get
            Return EE_ID_REL
        End Get
        Set(ByVal value As Integer)
            EE_ID_REL = value
        End Set
    End Property
    Private EE_LI As String
    Public Property LI() As String
        Get
            Return EE_LI
        End Get
        Set(ByVal value As String)
            EE_LI = value
        End Set
    End Property
    Private EE_LS As String
    Public Property LS() As String
        Get
            Return EE_LS
        End Get
        Set(ByVal value As String)
            EE_LS = value
        End Set
    End Property
    Private EE_MEDIA As String
    Public Property MEDIA() As String
        Get
            Return EE_MEDIA
        End Get
        Set(ByVal value As String)
            EE_MEDIA = value
        End Set
    End Property
    Private EE_DESVIACION As String
    Public Property DESVIACION() As String
        Get
            Return EE_DESVIACION
        End Get
        Set(ByVal value As String)
            EE_DESVIACION = value
        End Set
    End Property
    Private EE_CV As String
    Public Property CV() As String
        Get
            Return EE_CV
        End Get
        Set(ByVal value As String)
            EE_CV = value
        End Set
    End Property
End Class
