Public Class E_IRIS_WEBF_BUSCA_ATENCIONES_PARA_LOG_POR_ID_ATE
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ATE_DET_FECHA As Date
    Dim EE_ID_ESTADO As Integer
    Dim EE_USU_NIC As String
    Dim EE_ID_DET_ATE As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
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

    Public Property ATE_DET_FECHA As Date
        Get
            Return EE_ATE_DET_FECHA
        End Get
        Set(value As Date)
            EE_ATE_DET_FECHA = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Public Property ID_DET_ATE As Integer
        Get
            Return EE_ID_DET_ATE
        End Get
        Set(value As Integer)
            EE_ID_DET_ATE = value
        End Set
    End Property
End Class
