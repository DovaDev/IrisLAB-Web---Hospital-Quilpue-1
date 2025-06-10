Public Class E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
    Dim EE_ID_CF As Long
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_CANTIDAD As Long
    Dim EE_CF_PRECIO_AMB As Long
    Dim EE_COSTO_AMB As Long
    Dim EE_COSTO_DERIV As Long
    Dim EE_COSTO_TOTAL As Long
    Dim EE_PJE_CONV As Double
    Dim EE_PJE_LAB As Double
    Public Property ID_CF As Long
        Get
            Return EE_ID_CF
        End Get
        Set(value As Long)
            EE_ID_CF = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CANTIDAD As Long
        Get
            Return EE_CANTIDAD
        End Get
        Set(value As Long)
            EE_CANTIDAD = value
        End Set
    End Property
    Public Property CF_PRECIO_AMB As Long
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(value As Long)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property
    Public Property COSTO_AMB As Long
        Get
            Return EE_COSTO_AMB
        End Get
        Set(value As Long)
            EE_COSTO_AMB = value
        End Set
    End Property
    Public Property COSTO_DERIV As Long
        Get
            Return EE_COSTO_DERIV
        End Get
        Set(value As Long)
            EE_COSTO_DERIV = value
        End Set
    End Property
    Public Property COSTO_TOTAL As Long
        Get
            Return EE_COSTO_TOTAL
        End Get
        Set(value As Long)
            EE_COSTO_TOTAL = value
        End Set
    End Property
    Public Property PJE_CONV As Double
        Get
            Return EE_PJE_CONV
        End Get
        Set(value As Double)
            EE_PJE_CONV = value
        End Set
    End Property
    Public Property PJE_LAB As Double
        Get
            Return EE_PJE_LAB
        End Get
        Set(value As Double)
            EE_PJE_LAB = value
        End Set
    End Property
End Class
