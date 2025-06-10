Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_RECHAZO
    Dim EE_ID_RECEP_ETI_RECHAZO As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_RECEP_ETI_NUM_ATE_RECHAZO As Integer
    Dim EE_RECEP_ETI_CURVA_RECHAZO As String
    Dim EE_ID_USUARIO As Integer

    Public Property ID_RECEP_ETI_RECHAZO As Integer
        Get
            Return EE_ID_RECEP_ETI_RECHAZO
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI_RECHAZO = value
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

    Public Property RECEP_ETI_NUM_ATE_RECHAZO As Integer
        Get
            Return EE_RECEP_ETI_NUM_ATE_RECHAZO
        End Get
        Set(value As Integer)
            EE_RECEP_ETI_NUM_ATE_RECHAZO = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA_RECHAZO As String
        Get
            Return EE_RECEP_ETI_CURVA_RECHAZO
        End Get
        Set(value As String)
            EE_RECEP_ETI_CURVA_RECHAZO = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property
End Class
