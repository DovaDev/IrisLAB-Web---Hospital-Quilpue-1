Public Class E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
    Dim EE_ID_DIAGNOSTICO As Integer
    Dim EE_DIA_COD As String
    Dim EE_DIA_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_DIA_HOST_AVIS As Integer
    Public Property ID_DIAGNOSTICO As Integer
        Get
            Return EE_ID_DIAGNOSTICO
        End Get
        Set(value As Integer)
            EE_ID_DIAGNOSTICO = value
        End Set
    End Property
    Public Property DIA_COD As String
        Get
            Return EE_DIA_COD
        End Get
        Set(value As String)
            EE_DIA_COD = value
        End Set
    End Property
    Public Property DIA_DESC As String
        Get
            Return EE_DIA_DESC
        End Get
        Set(value As String)
            EE_DIA_DESC = value
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
    Public Property DIA_HOST_AVIS As Integer
        Get
            Return EE_DIA_HOST_AVIS
        End Get
        Set(value As Integer)
            EE_DIA_HOST_AVIS = value
        End Set
    End Property
End Class
