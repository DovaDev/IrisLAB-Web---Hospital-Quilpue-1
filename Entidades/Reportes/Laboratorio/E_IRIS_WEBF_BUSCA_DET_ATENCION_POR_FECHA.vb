Public Class E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA
    Private E_ID_ATENCION As Integer
    Private E_CF_COD As String
    Private E_ID_CODIGO_FONASA As Integer
    Private E_ID_PROCEDENCIA As Integer
    Private E_ID_TIPO_PAC As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Integer)
            E_ID_ATENCION = value
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

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            E_ID_PROCEDENCIA = value
        End Set
    End Property

    Public Property ID_TIPO_PAC As Integer
        Get
            Return E_ID_TIPO_PAC
        End Get
        Set(value As Integer)
            E_ID_TIPO_PAC = value
        End Set
    End Property
End Class
