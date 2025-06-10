Public Class E_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_USU_NIC As String
    Dim EE_PREI_DET_V_FECHA As Date
    Dim EE_ID_DET_PREI As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Public Property PREI_DET_V_FECHA As Date
        Get
            Return EE_PREI_DET_V_FECHA
        End Get
        Set(value As Date)
            EE_PREI_DET_V_FECHA = value
        End Set
    End Property

    Public Property ID_DET_PREI As Integer
        Get
            Return EE_ID_DET_PREI
        End Get
        Set(value As Integer)
            EE_ID_DET_PREI = value
        End Set
    End Property
End Class
