Public Class E_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD
    Dim EE_ID_ESPECIALIDAD As Integer
    Dim EE_ESP_COD As String
    Dim EE_ESP_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_ESPECIALIDAD As Integer
        Get
            Return EE_ID_ESPECIALIDAD
        End Get
        Set(value As Integer)
            EE_ID_ESPECIALIDAD = value
        End Set
    End Property
    Public Property ESP_COD As String
        Get
            Return EE_ESP_COD
        End Get
        Set(value As String)
            EE_ESP_COD = value
        End Set
    End Property
    Public Property ESP_DESC As String
        Get
            Return EE_ESP_DESC
        End Get
        Set(value As String)
            EE_ESP_DESC = value
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
