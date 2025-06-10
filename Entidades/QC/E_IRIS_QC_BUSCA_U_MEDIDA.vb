Public Class E_IRIS_QC_BUSCA_U_MEDIDA
    Private EE_UM_DESC As String
    Public Property UM_DESC() As String
        Get
            Return EE_UM_DESC
        End Get
        Set(ByVal value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Private EE_ID_U_MEDIDA As Integer
    Public Property ID_U_MEDIDA() As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(ByVal value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property
End Class
