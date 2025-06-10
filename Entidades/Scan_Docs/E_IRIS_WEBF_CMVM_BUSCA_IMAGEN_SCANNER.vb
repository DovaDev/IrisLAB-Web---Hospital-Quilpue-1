Public Class E_IRIS_WEBF_CMVM_BUSCA_IMAGEN_SCANNER
    Private EE_ID_FOTO_ATE As Integer
    Private EE_IMG As String
    Private EE_NOMBRE_DOC As String
    Private EE_TIPO As String
    Private EE_NO_ASOC_NUM As String
    Private EE_USU_NIC As String
    Private EE_FECHA_ASOC As DateTime
    Private EE_FECHA_LOG As DateTime
    Private EE_FOTO_ATE_PLATAFORMA As Integer
    Public Property FOTO_ATE_PLATAFORMA() As Integer
        Get
            Return EE_FOTO_ATE_PLATAFORMA
        End Get
        Set(ByVal value As Integer)
            EE_FOTO_ATE_PLATAFORMA = value
        End Set
    End Property
    Public Property FECHA_LOG() As DateTime
        Get
            Return EE_FECHA_LOG
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_LOG = value
        End Set
    End Property
    Public Property FECHA_ASOC() As DateTime
        Get
            Return EE_FECHA_ASOC
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_ASOC = value
        End Set
    End Property
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property NO_ASOC_NUM() As String
        Get
            Return EE_NO_ASOC_NUM
        End Get
        Set(ByVal value As String)
            EE_NO_ASOC_NUM = value
        End Set
    End Property
    Public Property TIPO() As String
        Get
            Return EE_TIPO
        End Get
        Set(ByVal value As String)
            EE_TIPO = value
        End Set
    End Property
    Public Property NOMBRE_DOC() As String
        Get
            Return EE_NOMBRE_DOC
        End Get
        Set(ByVal value As String)
            EE_NOMBRE_DOC = value
        End Set
    End Property
    Public Property IMG() As String
        Get
            Return EE_IMG
        End Get
        Set(ByVal value As String)
            EE_IMG = value
        End Set
    End Property
    Public Property ID_FOTO_ATE() As Integer
        Get
            Return EE_ID_FOTO_ATE
        End Get
        Set(ByVal value As Integer)
            EE_ID_FOTO_ATE = value
        End Set
    End Property
End Class
