Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO
    Dim EE_ID_RECEP_ETI As Integer
    Dim EE_RECEP_ETI_NUM_ATE As String
    Dim EE_RECEP_ETI_CURVA As Integer
    Dim EE_ID_ESTADO As Integer

    Public Property ID_RECEP_ETI As Integer
        Get
            Return EE_ID_RECEP_ETI
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI = value
        End Set
    End Property

    Public Property RECEP_ETI_NUM_ATE As String
        Get
            Return EE_RECEP_ETI_NUM_ATE
        End Get
        Set(value As String)
            EE_RECEP_ETI_NUM_ATE = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA As Integer
        Get
            Return EE_RECEP_ETI_CURVA
        End Get
        Set(value As Integer)
            EE_RECEP_ETI_CURVA = value
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
