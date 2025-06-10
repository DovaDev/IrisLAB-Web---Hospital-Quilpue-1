Public Class E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM
    Private E_ID_SECC_REM As Integer
    Private E_SECC_REM_DESC As String
    Private E_ID_ESTADO As Integer

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

    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
End Class
