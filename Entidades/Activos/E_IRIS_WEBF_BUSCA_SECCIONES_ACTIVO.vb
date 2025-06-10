Public Class E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
    Dim EE_ID_SECCION As Long
    Dim EE_SECC_COD As String
    Dim EE_SECC_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_SECCION As Long
        Get
            Return EE_ID_SECCION
        End Get
        Set(value As Long)
            EE_ID_SECCION = value
        End Set
    End Property
    Public Property SECC_COD As String
        Get
            Return EE_SECC_COD
        End Get
        Set(value As String)
            EE_SECC_COD = value
        End Set
    End Property
    Public Property SECC_DESC As String
        Get
            Return EE_SECC_DESC
        End Get
        Set(value As String)
            EE_SECC_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class