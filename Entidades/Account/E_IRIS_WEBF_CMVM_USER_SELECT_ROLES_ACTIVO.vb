Public Class E_IRIS_WEBF_CMVM_USER_SELECT_ROLES_ACTIVO
    Private EE_USU_ADMIN As Integer
    Public Property USU_ADMIN() As Integer
        Get
            Return EE_USU_ADMIN
        End Get
        Set(ByVal value As Integer)
            EE_USU_ADMIN = value
        End Set
    End Property

    Private EE_ADMIN_DESC As String
    Public Property ADMIN_DESC() As String
        Get
            Return EE_ADMIN_DESC
        End Get
        Set(ByVal value As String)
            EE_ADMIN_DESC = value
        End Set
    End Property
End Class