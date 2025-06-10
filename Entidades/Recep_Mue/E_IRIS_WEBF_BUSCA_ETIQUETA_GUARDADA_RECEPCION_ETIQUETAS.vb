Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS
    Dim EE_ID_RECEP_ETI As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_RECEP_ETI_NUM_ATE As String
    Dim EE_RECEP_ETI_CURVA As String
    Dim EE_ID_USUARIO As Integer

    Public Property ID_RECEP_ETI As Integer
        Get
            Return EE_ID_RECEP_ETI
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI = value
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

    Public Property RECEP_ETI_NUM_ATE As String
        Get
            Return EE_RECEP_ETI_NUM_ATE
        End Get
        Set(value As String)
            EE_RECEP_ETI_NUM_ATE = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA As String
        Get
            Return EE_RECEP_ETI_CURVA
        End Get
        Set(value As String)
            EE_RECEP_ETI_CURVA = value
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
