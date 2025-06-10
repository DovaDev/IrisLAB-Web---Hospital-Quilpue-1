Public Class E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO
    Private E_ID_REGISTRO As Integer
    Private E_ID_USUARIO As Integer
    Private E_USU_NIC As String
    Private E_CB_DESC As String
    Private E_T_MUESTRA_DESC As String
    Private E_ID_ATENCION As Integer
    Private E_ATE_NUM As String
    Private E_ATE_NUM_OMI As String
    Private E_ID_CODIGO_FONASA As Integer
    Private E_CF_DESC As String
    Private E_FECHA_PEND As String
    Private E_ID_PROC As Integer
    Private E_PAC_NOMBRE As String
    Private E_PAC_APELLIDO As String

    Public Property ID_REGISTRO As Integer
        Get
            Return E_ID_REGISTRO
        End Get
        Set(value As Integer)
            E_ID_REGISTRO = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return E_ID_USUARIO
        End Get
        Set(value As Integer)
            E_ID_USUARIO = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return E_USU_NIC
        End Get
        Set(value As String)
            E_USU_NIC = value
        End Set
    End Property

    Public Property CB_DESC As String
        Get
            Return E_CB_DESC
        End Get
        Set(value As String)
            E_CB_DESC = value
        End Set
    End Property

    Public Property ID_ATENCION As Integer
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Integer)
            E_ID_ATENCION = value
        End Set
    End Property

    Public Property ATE_NUM As String
        Get
            Return E_ATE_NUM
        End Get
        Set(value As String)
            E_ATE_NUM = value
        End Set
    End Property

    Public Property ATE_NUM_OMI As String
        Get
            Return E_ATE_NUM_OMI
        End Get
        Set(value As String)
            E_ATE_NUM_OMI = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            E_ID_CODIGO_FONASA = value
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

    Public Property FECHA_PEND As String
        Get
            Return E_FECHA_PEND
        End Get
        Set(value As String)
            E_FECHA_PEND = value
        End Set
    End Property

    Public Property ID_PROC As Integer
        Get
            Return E_ID_PROC
        End Get
        Set(value As Integer)
            E_ID_PROC = value
        End Set
    End Property

    Public Property PAC_NOMBRE As String
        Get
            Return E_PAC_NOMBRE
        End Get
        Set(value As String)
            E_PAC_NOMBRE = value
        End Set
    End Property

    Public Property PAC_APELLIDO As String
        Get
            Return E_PAC_APELLIDO
        End Get
        Set(value As String)
            E_PAC_APELLIDO = value
        End Set
    End Property

    Public Property T_MUESTRA_DESC As String
        Get
            Return E_T_MUESTRA_DESC
        End Get
        Set(value As String)
            E_T_MUESTRA_DESC = value
        End Set
    End Property
End Class
