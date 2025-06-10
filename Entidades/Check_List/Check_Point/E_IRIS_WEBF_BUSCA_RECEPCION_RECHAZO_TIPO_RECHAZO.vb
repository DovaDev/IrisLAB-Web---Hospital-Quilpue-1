Public Class E_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO
    Dim EE_ID_ATENCION As Integer
    Dim EE_RECEP_ETI_RECHAZO_OBS As String
    Dim EE_RECEP_ETI_CURVA_RECHAZO As String
    Dim EE_TP_RECHA_DESC As String

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property RECEP_ETI_RECHAZO_OBS As String
        Get
            Return EE_RECEP_ETI_RECHAZO_OBS
        End Get
        Set(value As String)
            EE_RECEP_ETI_RECHAZO_OBS = value
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

    Public Property TP_RECHA_DESC As String
        Get
            Return EE_TP_RECHA_DESC
        End Get
        Set(value As String)
            EE_TP_RECHA_DESC = value
        End Set
    End Property
End Class
