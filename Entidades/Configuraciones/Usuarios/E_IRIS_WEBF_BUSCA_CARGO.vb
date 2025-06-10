Public Class E_IRIS_WEBF_BUSCA_CARGO
    Private EE_ID_CAR As Integer
    Private EE_CAR_COD As String
    Private EE_CAR_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CARD_DESC() As String
        Get
            Return EE_CAR_DESC
        End Get
        Set(ByVal value As String)
            EE_CAR_DESC = value
        End Set
    End Property
    Public Property CAR_COD() As String
        Get
            Return EE_CAR_COD
        End Get
        Set(ByVal value As String)
            EE_CAR_COD = value
        End Set
    End Property
    Public Property ID_CAR() As Integer
        Get
            Return EE_ID_CAR
        End Get
        Set(ByVal value As Integer)
            EE_ID_CAR = value
        End Set
    End Property
End Class
