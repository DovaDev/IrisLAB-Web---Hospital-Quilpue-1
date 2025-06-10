Public Class E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM
    Private E_ID_FONASA_REM_HOSP As Integer
    Private E_CF_COD_IRIS As String
    Private E_CF_DESC_HOSP As String
    Private E_ID_ESTADO As Integer
    Private E_ID_SECC_REM As Integer
    Private E_SECC_REM_DESC As String
    Private E_CF_COD_REM As String

    Public Property ID_FONASA_REM_HOSP As Integer
        Get
            Return E_ID_FONASA_REM_HOSP
        End Get
        Set(value As Integer)
            E_ID_FONASA_REM_HOSP = value
        End Set
    End Property

    Public Property CF_COD_IRIS As String
        Get
            Return E_CF_COD_IRIS
        End Get
        Set(value As String)
            E_CF_COD_IRIS = value
        End Set
    End Property

    Public Property CF_DESC_HOSP As String
        Get
            Return E_CF_DESC_HOSP
        End Get
        Set(value As String)
            E_CF_DESC_HOSP = value
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

    Public Property ID_SECC_REM As Integer
        Get
            Return E_ID_SECC_REM
        End Get
        Set(value As Integer)
            E_ID_SECC_REM = value
        End Set
    End Property

    Public Property SECC_REM_DESC As String
        Get
            Return E_SECC_REM_DESC
        End Get
        Set(value As String)
            E_SECC_REM_DESC = value
        End Set
    End Property

    Public Property CF_COD_REM As String
        Get
            Return E_CF_COD_REM
        End Get
        Set(value As String)
            E_CF_COD_REM = value
        End Set
    End Property
End Class