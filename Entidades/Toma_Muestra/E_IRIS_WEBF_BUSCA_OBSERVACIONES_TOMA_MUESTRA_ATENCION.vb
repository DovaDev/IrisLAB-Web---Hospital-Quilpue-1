Public Class E_IRIS_WEBF_BUSCA_OBSERVACIONES_TOMA_MUESTRA_ATENCION
    Private EE_CUP As Integer
    Private EE_CVC As Integer
    Private EE_PICCLINE As Integer
    Private EE_TET As Integer
    Private EE_TQT As Integer
    Private EE_AREpi As Integer

    Public Property CUP As Integer
        Get
            Return EE_CUP
        End Get
        Set(value As Integer)
            EE_CUP = value
        End Set
    End Property

    Public Property CVC As Integer
        Get
            Return EE_CVC
        End Get
        Set(value As Integer)
            EE_CVC = value
        End Set
    End Property

    Public Property PICCLINE As Integer
        Get
            Return EE_PICCLINE
        End Get
        Set(value As Integer)
            EE_PICCLINE = value
        End Set
    End Property

    Public Property TET As Integer
        Get
            Return EE_TET
        End Get
        Set(value As Integer)
            EE_TET = value
        End Set
    End Property

    Public Property TQT As Integer
        Get
            Return EE_TQT
        End Get
        Set(value As Integer)
            EE_TQT = value
        End Set
    End Property

    Public Property AREpi As Integer
        Get
            Return EE_AREpi
        End Get
        Set(value As Integer)
            EE_AREpi = value
        End Set
    End Property
End Class
