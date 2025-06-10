Public Class E_IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2
    Dim EE_ID_PREV As Long
    Dim EE_ID_PRUEBA As Long
    Public Property ID_PREV As Long
        Get
            Return EE_ID_PREV
        End Get
        Set(value As Long)
            EE_ID_PREV = value
        End Set
    End Property
    Public Property ID_PRUEBA As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Long)
            EE_ID_PRUEBA = value
        End Set
    End Property
End Class
