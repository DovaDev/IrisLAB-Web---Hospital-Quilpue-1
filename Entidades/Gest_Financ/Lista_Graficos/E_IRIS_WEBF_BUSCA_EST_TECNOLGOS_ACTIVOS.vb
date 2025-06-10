Public Class E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS
    Private E_USU_NOMBRE As String
    Private E_USU_APELLIDO As String
    Private E_ID_USUARIO As Integer
    Private E_PROFE_DESC As String
    Private E_ID_ESTADO As Integer
    Private E_ID_PROFESION As Integer
    Public Property USU_NOMBRE As String
        Get
            Return E_USU_NOMBRE
        End Get
        Set(value As String)
            E_USU_NOMBRE = value
        End Set
    End Property
    Public Property USU_APELLIDO As String
        Get
            Return E_USU_APELLIDO
        End Get
        Set(value As String)
            E_USU_APELLIDO = value
        End Set
    End Property
    Public Property ID_USUARIO As Integer
        Get
            Return E_ID_USUARIO
        End Get
        Set(value As Integer)
            E_ID_USUARIO = value
        End Set
    End Property
    Public Property PROFE_DESC As String
        Get
            Return E_PROFE_DESC
        End Get
        Set(value As String)
            E_PROFE_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_PROFESION As Integer
        Get
            Return E_ID_PROFESION
        End Get
        Set(value As Integer)
            E_ID_PROFESION = value
        End Set
    End Property
End Class
