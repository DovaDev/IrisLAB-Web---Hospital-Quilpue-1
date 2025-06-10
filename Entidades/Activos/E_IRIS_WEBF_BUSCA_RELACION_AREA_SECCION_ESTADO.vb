Public Class E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
    Private E_ID_RLS_LS As Long
    Private E_ID_LABO As Long
    Private E_ID_SECCION As Long
    Private E_RLS_LS_DESC As String
    Private E_ID_ESTADO As Integer
    Public Property ID_RLS_LS As Long
        Get
            Return E_ID_RLS_LS
        End Get
        Set(value As Long)
            E_ID_RLS_LS = value
        End Set
    End Property
    Public Property ID_LABO As Long
        Get
            Return E_ID_LABO
        End Get
        Set(value As Long)
            E_ID_LABO = value
        End Set
    End Property
    Public Property ID_SECCION As Long
        Get
            Return E_ID_SECCION
        End Get
        Set(value As Long)
            E_ID_SECCION = value
        End Set
    End Property
    Public Property RLS_LS_DESC As String
        Get
            Return E_RLS_LS_DESC
        End Get
        Set(value As String)
            E_RLS_LS_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
End Class
