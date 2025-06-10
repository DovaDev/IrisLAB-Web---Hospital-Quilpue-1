Public Class E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
    Private E_ID_PAC As Long
    Public Property ID_PAC() As Long
        Get
            Return E_ID_PAC
        End Get
        Set(ByVal value As Long)
            E_ID_PAC = value
        End Set
    End Property

    Private E_CANT_ATE As Long
    Public Property CANT_ATE() As Long
        Get
            Return E_CANT_ATE
        End Get
        Set(ByVal value As Long)
            E_CANT_ATE = value
        End Set
    End Property

    Private E_CANT_EXA As Long
    Public Property CANT_EXA() As Long
        Get
            Return E_CANT_EXA
        End Get
        Set(ByVal value As Long)
            E_CANT_EXA = value
        End Set
    End Property
End Class
