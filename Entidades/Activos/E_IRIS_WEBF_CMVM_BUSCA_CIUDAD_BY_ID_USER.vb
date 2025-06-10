Public Class E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER
    Private EE_ID_CIUDAD As Integer
    Public Property ID_CIUDAD() As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(ByVal value As Integer)
            EE_ID_CIUDAD = value
        End Set
    End Property

    Private EE_CIU_COD As String
    Public Property CIU_COD() As String
        Get
            Return EE_CIU_COD
        End Get
        Set(ByVal value As String)
            EE_CIU_COD = value
        End Set
    End Property

    Private EE_CIU_DESC As String
    Public Property CIU_DESC() As String
        Get
            Return EE_CIU_DESC
        End Get
        Set(ByVal value As String)
            EE_CIU_DESC = value
        End Set
    End Property
End Class
