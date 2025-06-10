Public Class E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_PAC_RUT As String
    Private EE_PAC_DNI As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_SEXO As String
    Private EE_PAC_EDAD As String
    Private EE_PROC_DESC As String
    Private EE_PAC_FONO As String
    Private EE_PAC_MOVIL As String
    Private EE_PAC_DIR As String
    Private EE_CF_DESC As String
    Private EE_EST_VALIDA As Integer
    Private EE_FECHA_VALIDA As DateTime
    Public Property FECHA_VALIDA() As DateTime
        Get
            Return EE_FECHA_VALIDA
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_VALIDA = value
        End Set
    End Property
    Public Property EST_VALIDA() As Integer
        Get
            Return EE_EST_VALIDA
        End Get
        Set(ByVal value As Integer)
            EE_EST_VALIDA = value
        End Set
    End Property

    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_FECHA = value
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
    Public Property PAC_DIR() As String
        Get
            Return EE_PAC_DIR
        End Get
        Set(ByVal value As String)
            EE_PAC_DIR = value
        End Set
    End Property
    Public Property PAC_MOVIL() As String
        Get
            Return EE_PAC_MOVIL
        End Get
        Set(ByVal value As String)
            EE_PAC_MOVIL = value
        End Set
    End Property
    Public Property PAC_FONO() As String
        Get
            Return EE_PAC_FONO
        End Get
        Set(ByVal value As String)
            EE_PAC_FONO = value
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
    Public Property PAC_EDAD() As String
        Get
            Return EE_PAC_EDAD
        End Get
        Set(ByVal value As String)
            EE_PAC_EDAD = value
        End Set
    End Property
    Public Property PAC_SEXO() As String
        Get
            Return EE_PAC_SEXO
        End Get
        Set(ByVal value As String)
            EE_PAC_SEXO = value
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
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_DNI() As String
        Get
            Return EE_PAC_DNI
        End Get
        Set(ByVal value As String)
            EE_PAC_DNI = value
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
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
End Class
