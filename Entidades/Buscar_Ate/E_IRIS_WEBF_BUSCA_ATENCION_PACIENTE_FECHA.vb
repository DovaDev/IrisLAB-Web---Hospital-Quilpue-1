
Public Class E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
    Private EE_ID_ATENCION As String
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As String
    Private EE_ID_PACIENTE As String
    Private EE_PAC_RUT As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_ATE_AÑO As String
    Private EE_PROC_DESC As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_SEXO_DESC As String
    Private EE_ID_SEXO As String
    Private EE_ENCRYPTED_ID As String
    Private EE_ID_PROCEDENCIA As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_PAC_FNAC As String
    Public Property PAC_FNAC() As String
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As String)
            EE_PAC_FNAC = value
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
    Public Property ID_PROCEDENCIA() As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property ID_ATENCION() As String
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As String)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ID_PACIENTE() As String
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As String)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property ATE_AÑO() As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As String)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO() As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property ID_SEXO() As String
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As String)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
End Class
