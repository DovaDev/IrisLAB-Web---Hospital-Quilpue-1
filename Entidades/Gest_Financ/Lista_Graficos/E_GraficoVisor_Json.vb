Public Class E_GraficoVisor_Json
    Private Fecha As Date
    Private Cantidad As Integer
    Private Dias As String
    Private E_MES As String
    Private E_CANT_ATE As Long
    Private E_CANT_EXA As Long
    Private E_PREVI As Long
    Private E_PAGADO As Long
    Private E_COPAGO As Long
    Public Property MES As String
        Get
            Return E_MES
        End Get
        Set(value As String)
            E_MES = value
        End Set
    End Property
    Public Property CANT_ATE As Long
        Get
            Return E_CANT_ATE
        End Get
        Set(value As Long)
            E_CANT_ATE = value
        End Set
    End Property
    Public Property CANT_EXA As Long
        Get
            Return E_CANT_EXA
        End Get
        Set(value As Long)
            E_CANT_EXA = value
        End Set
    End Property
    Public Property PREVI As Long
        Get
            Return E_PREVI
        End Get
        Set(value As Long)
            E_PREVI = value
        End Set
    End Property
    Public Property PAGADO As Long
        Get
            Return E_PAGADO
        End Get
        Set(value As Long)
            E_PAGADO = value
        End Set
    End Property
    Public Property COPAGO As Long
        Get
            Return E_COPAGO
        End Get
        Set(value As Long)
            E_COPAGO = value
        End Set
    End Property
    Public Property E_Fecha As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property
    Public Property E_Cantidad As Integer
        Get
            Return Cantidad
        End Get
        Set(value As Integer)
            Cantidad = value
        End Set
    End Property
    Public Property E_Dias As String
        Get
            Return Dias
        End Get
        Set(value As String)
            Dias = value
        End Set
    End Property
End Class
