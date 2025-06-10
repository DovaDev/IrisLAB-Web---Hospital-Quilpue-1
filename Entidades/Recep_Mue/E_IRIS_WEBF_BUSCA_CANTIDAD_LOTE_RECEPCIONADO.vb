Public Class E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO
    Dim EE_LOTE_NUM As String
    Dim EE_ID_USUARIO As Integer
    Dim EE_LOTE_FECHA As String
    Dim EE_USU_NIC As String

    Public Property LOTE_NUM As String
        Get
            Return EE_LOTE_NUM
        End Get
        Set(value As String)
            EE_LOTE_NUM = value
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

    Public Property LOTE_FECHA As String
        Get
            Return EE_LOTE_FECHA
        End Get
        Set(value As String)
            EE_LOTE_FECHA = value
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
End Class
