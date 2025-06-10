Public Class E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
    Dim EE_COM_DESC As String
    Dim EE_ID_COMUNA As Integer
    Dim EE_ID_ESTADO As String
    Dim EE_ID_CIUDAD As Integer
    Dim EE_ID_REL_CIU_COM As Integer
    Public Property COM_DESC As String
        Get
            Return EE_COM_DESC
        End Get
        Set(value As String)
            EE_COM_DESC = value
        End Set
    End Property
    Public Property ID_COMUNA As Integer
        Get
            Return EE_ID_COMUNA
        End Get
        Set(value As Integer)
            EE_ID_COMUNA = value
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
    Public Property ID_CIUDAD As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(value As Integer)
            EE_ID_CIUDAD = value
        End Set
    End Property
    Public Property ID_REL_CIU_COM As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(value As Integer)
            EE_ID_REL_CIU_COM = value
        End Set
    End Property
End Class
