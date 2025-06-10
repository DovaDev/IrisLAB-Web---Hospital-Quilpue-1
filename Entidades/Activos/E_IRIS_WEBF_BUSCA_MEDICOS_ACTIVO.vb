Public Class E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
    Dim EE_ID_DOCTOR As Integer
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_ESP_DESC As String
    Dim EE_DOC_FONO1 As String
    Dim EE_DOC_MOVIL1 As String
    Public Property ID_DOCTOR As Integer
        Get
            Return EE_ID_DOCTOR
        End Get
        Set(value As Integer)
            EE_ID_DOCTOR = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
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
    Public Property ESP_DESC As String
        Get
            Return EE_ESP_DESC
        End Get
        Set(value As String)
            EE_ESP_DESC = value
        End Set
    End Property
    Public Property DOC_FONO1 As String
        Get
            Return EE_DOC_FONO1
        End Get
        Set(value As String)
            EE_DOC_FONO1 = value
        End Set
    End Property
    Public Property DOC_MOVIL1 As String
        Get
            Return EE_DOC_MOVIL1
        End Get
        Set(value As String)
            EE_DOC_MOVIL1 = value
        End Set
    End Property
End Class
