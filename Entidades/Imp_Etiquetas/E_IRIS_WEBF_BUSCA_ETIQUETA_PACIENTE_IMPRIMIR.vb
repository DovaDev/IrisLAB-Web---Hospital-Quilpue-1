Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_PACIENTE_IMPRIMIR
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_AÑO As Integer
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_SEXO As Integer
    Dim EE_SEXO_COD As String
    Dim EE_PROC_DESC As String
    Dim EE_PROC_COD As String
    Dim EE_PAC_FNAC As Date
    Dim EE_PROC_ID As Integer


    Public Property PROC_ID As Integer
        Get
            Return EE_PROC_ID
        End Get
        Set(value As Integer)
            EE_PROC_ID = value
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
    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
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
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
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
    Public Property SEXO_COD As String
        Get
            Return EE_SEXO_COD
        End Get
        Set(value As String)
            EE_SEXO_COD = value
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
    Public Property PROC_COD As String
        Get
            Return EE_PROC_COD
        End Get
        Set(value As String)
            EE_PROC_COD = value
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
End Class
