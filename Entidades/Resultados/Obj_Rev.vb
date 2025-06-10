Public Class Obj_Rev
    Private E_ID_DET_ATE As Integer
    Private E_ID_ATE_RES As Integer

    Public Property ID_DET_ATE As Integer
    Get
            Return E_ID_DET_ATE
        End Get
        Set(value As Integer)
            E_ID_DET_ATE = value
        End Set
    End Property

    Public Property ID_ATE_RES As Integer
        Get
            Return E_ID_ATE_RES
        End Get
        Set(value As Integer)
            E_ID_ATE_RES = value
        End Set
    End Property
End Class
