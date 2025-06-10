Public Class E_IRIS_WEBF_BUSCA_TP_RECIPIENTE
    Dim EE_ID_G_MUESTRA As Integer
    Dim EE_GMUE_COD As String
    Dim EE_GMUE_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_G_MUESTRA As Integer
        Get
            Return EE_ID_G_MUESTRA
        End Get
        Set(value As Integer)
            EE_ID_G_MUESTRA = value
        End Set
    End Property
    Public Property GMUE_COD As String
        Get
            Return EE_GMUE_COD
        End Get
        Set(value As String)
            EE_GMUE_COD = value
        End Set
    End Property
    Public Property GMUE_DESC As String
        Get
            Return EE_GMUE_DESC
        End Get
        Set(value As String)
            EE_GMUE_DESC = value
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
End Class
