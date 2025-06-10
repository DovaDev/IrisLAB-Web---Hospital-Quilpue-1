
Public Class E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM
    Private E_ID_REL_PRU_REM As Integer
    Private E_ID_FONASA_REM_HOSP As Integer
    Private E_CF_COD_IRIS As String
    Private E_CF_COD_REM As String
    Private E_CF_DESC_HOSP As String
    Private E_ID_CF_EX As Integer
    Private E_CF_COD As String
    Private E_CF_DESC As String
    Private E_EXCLUIR As Integer
    Private E_PRIORI As Integer

    Public Property ID_REL_PRU_REM As Integer
        Get
            Return E_ID_REL_PRU_REM
        End Get
        Set(value As Integer)
            E_ID_REL_PRU_REM = value
        End Set
    End Property

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

    Public Property CF_COD_REM As String
        Get
            Return E_CF_COD_REM
        End Get
        Set(value As String)
            E_CF_COD_REM = value
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

    Public Property ID_CF_EX As Integer
        Get
            Return E_ID_CF_EX
        End Get
        Set(value As Integer)
            E_ID_CF_EX = value
        End Set
    End Property

    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
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

    Public Property EXCLUIR As Integer
        Get
            Return E_EXCLUIR
        End Get
        Set(value As Integer)
            E_EXCLUIR = value
        End Set
    End Property

    Public Property PRIORI As Integer
        Get
            Return E_PRIORI
        End Get
        Set(value As Integer)
            E_PRIORI = value
        End Set
    End Property
End Class
