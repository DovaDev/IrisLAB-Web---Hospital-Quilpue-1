Public Class E_Json_Result_DataTable_Values2
    Dim E_Value As Object
    Dim E_Decimal As Object
    Dim E_B2 As Object
    Dim E_B1 As Object
    Dim E_A1 As Object
    Dim E_A2 As Object
    Public Property value As Object
        Get
            Return E_Value
        End Get
        Set(ee_value As Object)
            E_Value = ee_value
        End Set
    End Property
    Public Property pruDecimal As Integer
        Get
            Return E_Decimal
        End Get
        Set(value As Integer)
            E_Decimal = value
        End Set
    End Property
    Public Property b2 As Object
        Get
            Return E_B2
        End Get
        Set(ee_value As Object)
            E_B2 = ee_value
        End Set
    End Property
    Public Property b1 As Object
        Get
            Return E_B1
        End Get
        Set(ee_value As Object)
            E_B1 = ee_value
        End Set
    End Property
    Public Property a1 As Object
        Get
            Return E_A1
        End Get
        Set(ee_value As Object)
            E_A1 = ee_value
        End Set
    End Property
    Public Property a2 As Object
        Get
            Return E_A2
        End Get
        Set(ee_value As Object)
            E_A2 = ee_value
        End Set
    End Property
End Class