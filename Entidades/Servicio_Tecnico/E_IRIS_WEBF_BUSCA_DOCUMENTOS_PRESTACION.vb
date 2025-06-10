Public Class E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION
    Dim EE_ID_PRESTA_PRESTA As Integer
    Dim EE_DCTO_PRESTA_PRESTA_DESC As String
    Dim EE_PRESTA_PRESTA_LUGAR As String
    Dim EE_PRESTA_PRESTA_PLAZO As String
    Dim EE_PRESTA_PRESTA_DOCU As String
    Dim EE_PRESTA_PRESTA_SECCION As String

    Public Property PRESTA_PRESTA_SECCION As String
        Get
            Return EE_PRESTA_PRESTA_SECCION
        End Get
        Set(value As String)
            EE_PRESTA_PRESTA_SECCION = value
        End Set
    End Property

    Public Property PRESTA_PRESTA_DOCU As String
        Get
            Return EE_PRESTA_PRESTA_DOCU
        End Get
        Set(value As String)
            EE_PRESTA_PRESTA_DOCU = value
        End Set
    End Property

    Public Property PRESTA_PRESTA_PLAZO As String
        Get
            Return EE_PRESTA_PRESTA_PLAZO
        End Get
        Set(value As String)
            EE_PRESTA_PRESTA_PLAZO = value
        End Set
    End Property

    Public Property PRESTA_PRESTA_LUGAR As String
        Get
            Return EE_PRESTA_PRESTA_LUGAR
        End Get
        Set(value As String)
            EE_PRESTA_PRESTA_LUGAR = value
        End Set
    End Property

    Public Property DCTO_PRESTA_PRESTA_DESC As String
        Get
            Return EE_DCTO_PRESTA_PRESTA_DESC
        End Get
        Set(value As String)
            EE_DCTO_PRESTA_PRESTA_DESC = value
        End Set
    End Property

    Public Property ID_PRESTA_PRESTA As Integer
        Get
            Return EE_ID_PRESTA_PRESTA
        End Get
        Set(value As Integer)
            EE_ID_PRESTA_PRESTA = value
        End Set
    End Property

End Class
