Public Class E_IRIS_WEBF_BUSCAR_RUTA_PDF_DER
    Private E_IRIS_ID_REL As Long
    Private E_IRIS_ID_CF As Long
    Private E_IRIS_ID_ATENCION As Long
    Private E_IRIS_RUTA_PDF As String
    Private E_IRIS_ID_USU_SUBE_EX As Integer
    Private E_IRIS_ID_PAC As Long
    Private E_IRIS_ESTADO As Integer
    Private E_IRIS_FECHA_REL As Date
    Public Property IRIS_ID_REL As Long
        Get
            Return E_IRIS_ID_REL
        End Get
        Set(value As Long)
            E_IRIS_ID_REL = value
        End Set
    End Property
    Public Property IRIS_ID_CF As Long
        Get
            Return E_IRIS_ID_CF
        End Get
        Set(value As Long)
            E_IRIS_ID_CF = value
        End Set
    End Property
    Public Property IRIS_ID_ATENCION As Long
        Get
            Return E_IRIS_ID_ATENCION
        End Get
        Set(value As Long)
            E_IRIS_ID_ATENCION = value
        End Set
    End Property
    Public Property IRIS_RUTA_PDF As String
        Get
            Return E_IRIS_RUTA_PDF
        End Get
        Set(value As String)
            E_IRIS_RUTA_PDF = value
        End Set
    End Property
    Public Property IRIS_ID_USU_SUBE_EX As Integer
        Get
            Return E_IRIS_ID_USU_SUBE_EX
        End Get
        Set(value As Integer)
            E_IRIS_ID_USU_SUBE_EX = value
        End Set
    End Property
    Public Property IRIS_ID_PAC As Long
        Get
            Return E_IRIS_ID_PAC
        End Get
        Set(value As Long)
            E_IRIS_ID_PAC = value
        End Set
    End Property
    Public Property IRIS_ESTADO As Integer
        Get
            Return E_IRIS_ESTADO
        End Get
        Set(value As Integer)
            E_IRIS_ESTADO = value
        End Set
    End Property
    Public Property IRIS_FECHA_REL As Date
        Get
            Return E_IRIS_FECHA_REL
        End Get
        Set(value As Date)
            E_IRIS_FECHA_REL = value
        End Set
    End Property
End Class