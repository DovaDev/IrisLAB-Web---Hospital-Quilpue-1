Public Class E_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM
    Dim EE_DERIV_NUM As Integer
    Dim EE_ATE_FECHA As String
    Dim EE_CF_DESC As String
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_FNAC As Date
    Dim EE_SEXO_COD As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ORD_DESC As String
    Dim EE_ATE_NUM As Integer
    Dim EE_ID_DET_DERIV_PRO As Integer
    Dim EE_DERI_DESC As String
    Dim EE_DERIV_PRO_FECHA As Date
    Dim EE_ATE_OBS_FICHA As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_PROC_DESC As String

    Public Property DERIV_NUM As Integer
        Get
            Return EE_DERIV_NUM
        End Get
        Set(value As Integer)
            EE_DERIV_NUM = value
        End Set
    End Property

    Public Property ATE_FECHA As String
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As String)
            EE_ATE_FECHA = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property

    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
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

    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
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

    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
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

    Public Property ORD_DESC As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(value As String)
            EE_ORD_DESC = value
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

    Public Property ID_DET_DERIV_PRO As Integer
        Get
            Return EE_ID_DET_DERIV_PRO
        End Get
        Set(value As Integer)
            EE_ID_DET_DERIV_PRO = value
        End Set
    End Property

    Public Property DERI_DESC As String
        Get
            Return EE_DERI_DESC
        End Get
        Set(value As String)
            EE_DERI_DESC = value
        End Set
    End Property

    Public Property DERIV_PRO_FECHA As Date
        Get
            Return EE_DERIV_PRO_FECHA
        End Get
        Set(value As Date)
            EE_DERIV_PRO_FECHA = value
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

    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
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
End Class
