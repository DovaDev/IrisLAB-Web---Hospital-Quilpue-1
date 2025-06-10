Public Class E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO
    Dim EE_ID_U_MEDIDA As Integer
    Dim EE_UM_COD As String
    Dim EE_UM_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_U_MEDIDA As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property
    Public Property UM_COD As String
        Get
            Return EE_UM_COD
        End Get
        Set(value As String)
            EE_UM_COD = value
        End Set
    End Property
    Public Property UM_DESC As String
        Get
            Return EE_UM_DESC
        End Get
        Set(value As String)
            EE_UM_DESC = value
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
