Public Class E_IRIS_WEBF_CMVM_BUSCA_ATE_PAC_DIA
    Private EE_ID_ATENCION As Long
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_ID_PACIENTE As Long
    Public Property ID_PACIENTE() As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Long)
            EE_ID_PACIENTE = value
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
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_FECHA = value
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
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
