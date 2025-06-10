Public Class E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP
    Dim EE_HO_CC As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_ATE_FECHA As Date
    Dim EE_PROC_DESC As String
    Dim EE_PREVE_DESC As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_FNAC As Date
    Dim EE_ID_SEXO As Integer
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ENCRYPTED_ID As String
    Dim EE_ATE_OBS_FICHA As String
    Dim EE_ATE_AÑO As String

    Public Property ATE_AÑO As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As String)
            EE_ATE_AÑO = value
        End Set
    End Property

    Public Property ATE_OBS_FICHA As String
        Get
            Return EE_ATE_OBS_FICHA
        End Get
        Set(value As String)
            EE_ATE_OBS_FICHA = value
        End Set
    End Property

    Public Property ENCRYPTED_ID As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(value As String)
            EE_ENCRYPTED_ID = value
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

    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property

    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property

    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property

    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property

    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property

    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property HO_CC As String
        Get
            Return EE_HO_CC
        End Get
        Set(value As String)
            EE_HO_CC = value
        End Set
    End Property
End Class
