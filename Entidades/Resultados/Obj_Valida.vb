Public Class Obj_Valida

    Private EE_HASTA As String
    Public Property HASTA() As String
        Get
            Return EE_HASTA
        End Get
        Set(ByVal value As String)
            EE_HASTA = value
        End Set
    End Property
    Private EE_DESDE As String
    Public Property DESDE() As String
        Get
            Return EE_DESDE
        End Get
        Set(ByVal value As String)
            EE_DESDE = value
        End Set
    End Property
    Private EE_ID_ATE_RES As Integer
    Public Property ID_ATE_RES() As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATE_RES = value
        End Set
    End Property
    Private EE_AB As String
    Public Property AB() As String
        Get
            Return EE_AB
        End Get
        Set(ByVal value As String)
            EE_AB = value
        End Set
    End Property
    Private EE_MUY_DESDE As String
    Public Property MUY_DESDE() As String
        Get
            Return EE_MUY_DESDE
        End Get
        Set(ByVal value As String)
            EE_MUY_DESDE = value
        End Set
    End Property
    Private EE_MUY_HASTA As String
    Public Property MUY_HASTA() As String
        Get
            Return EE_MUY_HASTA
        End Get
        Set(ByVal value As String)
            EE_MUY_HASTA = value
        End Set
    End Property
    Private EE_MUY_AB As String
    Public Property MUY_AB() As String
        Get
            Return EE_MUY_AB
        End Get
        Set(ByVal value As String)
            EE_MUY_AB = value
        End Set
    End Property
    Private EE_UNIDADES As String
    Public Property UNIDADES() As String
        Get
            Return EE_UNIDADES
        End Get
        Set(ByVal value As String)
            EE_UNIDADES = value
        End Set
    End Property
    Private EE_VALUE As String
    Public Property VALUE() As String
        Get
            Return EE_VALUE
        End Get
        Set(ByVal value As String)
            EE_VALUE = value
        End Set
    End Property
End Class

Public Class E_Unvalid_Params
    Private EE_ID_ATE_RES As Integer
    Public Property ID_ATE_RES() As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATE_RES = value
        End Set
    End Property
    Private EE_VALUE As String
    Public Property VALUE() As String
        Get
            Return EE_VALUE
        End Get
        Set(ByVal value As String)
            EE_VALUE = value
        End Set
    End Property
End Class

Public Class Resultados_Historicos_Por_Prueba
    Private E_ATE_RESULTADO As String
    Private E_FECHA As String

    Public Property ATE_RESULTADO As String
        Get
            Return E_ATE_RESULTADO
        End Get
        Set(value As String)
            E_ATE_RESULTADO = value
        End Set
    End Property

    Public Property FECHA As String
        Get
            Return E_FECHA
        End Get
        Set(value As String)
            E_FECHA = value
        End Set
    End Property
End Class