Public Class E_IRIS_WEBF_BUSCA_CIUDAD
    Dim EE_ID_CIUDAD As Integer
    Dim EE_CIU_COD As String
    Dim EE_CIU_DESC As String
    Dim EE_ID_ESTADO As String
    Public Property ID_CIUDAD As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(value As Integer)
            EE_ID_CIUDAD = value
        End Set
    End Property
    Public Property CIU_COD As String
        Get
            Return EE_CIU_COD
        End Get
        Set(value As String)
            EE_CIU_COD = value
        End Set
    End Property
    Public Property CIU_DESC As String
        Get
            Return EE_CIU_DESC
        End Get
        Set(value As String)
            EE_CIU_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
