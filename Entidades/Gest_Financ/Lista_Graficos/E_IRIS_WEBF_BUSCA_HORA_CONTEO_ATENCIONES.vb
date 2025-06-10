Public Class E_IRIS_WEBF_BUSCA_HORA_CONTEO_ATENCIONES
    Dim EE_FECHA As Date
    Dim EE_NUMERO As Long
    Public Property FECHA As Date
        Get
            Return EE_FECHA
        End Get
        Set(value As Date)
            EE_FECHA = value
        End Set
    End Property
    Public Property NUMERO As Long
        Get
            Return EE_NUMERO
        End Get
        Set(value As Long)
            EE_NUMERO = value
        End Set
    End Property
End Class