Public Class E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS


    Private EE_ID_COSTO As Integer
    Public Property ID_COSTO() As Integer
        Get
            Return EE_ID_COSTO
        End Get
        Set(ByVal value As Integer)
            EE_ID_COSTO = value
        End Set
    End Property
    Private EE_DET_CONT_COSTO_PRECIO As Integer
    Public Property DET_CONT_COSTO_PRECIO() As Integer
        Get
            Return EE_DET_CONT_COSTO_PRECIO
        End Get
        Set(ByVal value As Integer)
            EE_DET_CONT_COSTO_PRECIO = value
        End Set
    End Property

End Class