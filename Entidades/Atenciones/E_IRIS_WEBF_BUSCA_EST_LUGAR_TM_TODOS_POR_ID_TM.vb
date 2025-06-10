Public Class E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM
    Private E_ID_ATENCION As Long
    Private E_ATE_NUM As Long
    Private E_ATE_FECHA As Date
    Private E_ID_PACIENTE As Long
    Private E_PAC_RUT As String
    Private E_PAC_NOMBRE As String
    Private E_PAC_APELLIDO As String
    Private E_ATE_AÑO As Integer
    Private E_DOC_NOMBRE As String
    Private E_DOC_APELLIDO As String
    Private E_SEXO_DESC As String
    Private E_ID_SEXO As Integer
    Private E_ID_PROCEDENCIA As Integer
    Private E_ID_ESTADO As Integer
    Private E_PROC_DESC As String
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_NUM As Long
        Get
            Return E_ATE_NUM
        End Get
        Set(value As Long)
            E_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return E_ATE_FECHA
        End Get
        Set(value As Date)
            E_ATE_FECHA = value
        End Set
    End Property
    Public Property ID_PACIENTE As Long
        Get
            Return E_ID_PACIENTE
        End Get
        Set(value As Long)
            E_ID_PACIENTE = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return E_PAC_RUT
        End Get
        Set(value As String)
            E_PAC_RUT = value
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
    Public Property ATE_AÑO As Integer
        Get
            Return E_ATE_AÑO
        End Get
        Set(value As Integer)
            E_ATE_AÑO = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return E_DOC_NOMBRE
        End Get
        Set(value As String)
            E_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return E_DOC_APELLIDO
        End Get
        Set(value As String)
            E_DOC_APELLIDO = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return E_SEXO_DESC
        End Get
        Set(value As String)
            E_SEXO_DESC = value
        End Set
    End Property
    Public Property ID_SEXO As Integer
        Get
            Return E_ID_SEXO
        End Get
        Set(value As Integer)
            E_ID_SEXO = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA As Integer
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            E_ID_PROCEDENCIA = value
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
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
End Class
