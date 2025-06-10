Public Class E_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO
    Dim EE_ID_DERIV_PRO As Integer
    Dim EE_DERIV_NUM As Integer
    Dim EE_DERIV_PRO_FECHA As Date
    Dim EE_ID_USUARIO As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_DERIVADO As Integer
    Dim EE_DERI_DESC As String
    Dim EE_USU_NOMBRE As String
    Dim EE_USU_APELLIDO As String

    Public Property ID_DERIV_PRO As Integer
        Get
            Return EE_ID_DERIV_PRO
        End Get
        Set(value As Integer)
            EE_ID_DERIV_PRO = value
        End Set
    End Property

    Public Property DERIV_NUM As Integer
        Get
            Return EE_DERIV_NUM
        End Get
        Set(value As Integer)
            EE_DERIV_NUM = value
        End Set
    End Property

    Public Property DERIV_PRO_FECHA As Date
        Get
            Return EE_DERIV_PRO_FECHA
        End Get
        Set(value As Date)
            EE_DERIV_PRO_FECHA = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
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

    Public Property ID_DERIVADO As Integer
        Get
            Return EE_ID_DERIVADO
        End Get
        Set(value As Integer)
            EE_ID_DERIVADO = value
        End Set
    End Property

    Public Property DERI_DESC As String
        Get
            Return EE_DERI_DESC
        End Get
        Set(value As String)
            EE_DERI_DESC = value
        End Set
    End Property

    Public Property USU_NOMBRE As String
        Get
            Return EE_USU_NOMBRE
        End Get
        Set(value As String)
            EE_USU_NOMBRE = value
        End Set
    End Property

    Public Property USU_APELLIDO As String
        Get
            Return EE_USU_APELLIDO
        End Get
        Set(value As String)
            EE_USU_APELLIDO = value
        End Set
    End Property
End Class
