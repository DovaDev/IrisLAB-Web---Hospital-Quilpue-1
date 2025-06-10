'Datos generales del Paciente
Public Class E_Json_Result_Pac_Data
    Dim E_nAte As Long
    Dim E_ID_Pac As Long
    Dim E_fNac As String
    Dim E_Fecha As String
    Dim E_Nombre As String
    Dim E_Edad As String
    Dim E_Sexo As String
    Dim E_FUR As String

    Private EE_ID_ATE As Integer
    Public Property ID_ATE() As Integer
        Get
            Return EE_ID_ATE
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATE = value
        End Set
    End Property

    Public Property nAte As Long
        Get
            Return E_nAte
        End Get
        Set(value As Long)
            E_nAte = value
        End Set
    End Property

    Public Property ID_Pac As Long
        Get
            Return E_ID_Pac
        End Get
        Set(value As Long)
            E_ID_Pac = value
        End Set
    End Property

    Public Property fNac As String
        Get
            Return E_fNac
        End Get
        Set(value As String)
            E_fNac = value
        End Set
    End Property

    Public Property Fecha As String
        Get
            Return E_Fecha
        End Get
        Set(value As String)
            E_Fecha = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return E_Nombre
        End Get
        Set(value As String)
            E_Nombre = value
        End Set
    End Property

    Public Property Edad As String
        Get
            Return E_Edad
        End Get
        Set(value As String)
            E_Edad = value
        End Set
    End Property

    Public Property Sexo As String
        Get
            Return E_Sexo
        End Get
        Set(value As String)
            E_Sexo = value
        End Set
    End Property

    Public Property FUR As String
        Get
            Return E_FUR
        End Get
        Set(value As String)
            E_FUR = value
        End Set
    End Property

    Private E_NAME_MED As String
    Public Property NAME_MED() As String
        Get
            Return E_NAME_MED
        End Get
        Set(ByVal value As String)
            E_NAME_MED = value
        End Set
    End Property

    Private E_ORDEN As String
    Public Property ORDEN() As String
        Get
            Return E_ORDEN
        End Get
        Set(ByVal value As String)
            E_ORDEN = value
        End Set
    End Property

    Private E_OBSERV_ATE As String
    Public Property OBSERV_ATE() As String
        Get
            Return E_OBSERV_ATE
        End Get
        Set(ByVal value As String)
            E_OBSERV_ATE = value
        End Set
    End Property
End Class
'---------------------------------------------------------

'Datos usados para llenar 
Public Class E_Json_Result_DataTable
    Dim E_TT As E_Json_Result_DataTable_Type_Data
    Dim E_EE As E_Json_Result_DataTable_EstadValidac
    Dim E_Exam As E_Json_Result_DataTable_Examen
    Dim E_Desc As String
    Dim E_Res As E_Json_Result_DataTable_Values
    Dim E_Unit As String
    Dim E_Stat As String
    Dim E_Desd As String
    Dim E_Hast As String
    Dim E_ReHi As String
    Dim E_cDia As String
    Dim E_ID_DET_ATE As Integer

    Public Property TT As E_Json_Result_DataTable_Type_Data
        Get
            Return E_TT
        End Get
        Set(value As E_Json_Result_DataTable_Type_Data)
            E_TT = value
        End Set
    End Property

    Public Property EE As E_Json_Result_DataTable_EstadValidac
        Get
            Return E_EE
        End Get
        Set(value As E_Json_Result_DataTable_EstadValidac)
            E_EE = value
        End Set
    End Property

    Public Property Exam As E_Json_Result_DataTable_Examen
        Get
            Return E_Exam
        End Get
        Set(value As E_Json_Result_DataTable_Examen)
            E_Exam = value
        End Set
    End Property

    Public Property Desc As String
        Get
            Return E_Desc
        End Get
        Set(value As String)
            E_Desc = value
        End Set
    End Property

    Public Property Res As E_Json_Result_DataTable_Values
        Get
            Return E_Res
        End Get
        Set(value As E_Json_Result_DataTable_Values)
            E_Res = value
        End Set
    End Property

    Public Property Unit As String
        Get
            Return E_Unit
        End Get
        Set(value As String)
            E_Unit = value
        End Set
    End Property

    Public Property Stat As String
        Get
            Return E_Stat
        End Get
        Set(value As String)
            E_Stat = value
        End Set
    End Property

    Public Property Desd As String
        Get
            Return E_Desd
        End Get
        Set(value As String)
            E_Desd = value
        End Set
    End Property

    Public Property Hast As String
        Get
            Return E_Hast
        End Get
        Set(value As String)
            E_Hast = value
        End Set
    End Property

    Public Property ReHi As String
        Get
            Return E_ReHi
        End Get
        Set(value As String)
            E_ReHi = value
        End Set
    End Property
    Public cantidadDeHistoricos As Integer
    Public rechazado As Boolean

    Public recepcionado As Boolean
    Public Property cDia As String
        Get
            Return E_cDia
        End Get
        Set(value As String)
            E_cDia = value
        End Set
    End Property

    Public Property ID_DET_ATE As Integer
        Get
            Return E_ID_DET_ATE
        End Get
        Set(value As Integer)
            E_ID_DET_ATE = value
        End Set
    End Property
End Class

'datos del tipo de dato
Public Class E_Json_Result_DataTable_Type_Data
    Private E_ID_TD As Integer
    Public Property ID_TD() As Integer
        Get
            Return E_ID_TD
        End Get
        Set(ByVal value As Integer)
            E_ID_TD = value
        End Set
    End Property

    Private E_DESC_TD As String
    Public Property DESC_TD() As String
        Get
            Return E_DESC_TD
        End Get
        Set(ByVal value As String)
            E_DESC_TD = value
        End Set
    End Property
End Class

'Datos del exámen
Public Class E_Json_Result_DataTable_Examen
    Dim E_ID_EXA As Long
    Dim E_Descrp As String
    Dim E_EST_REV As Integer
    Public Property ID_EXA As Long
        Get
            Return E_ID_EXA
        End Get
        Set(value As Long)
            E_ID_EXA = value
        End Set
    End Property

    Public Property Descrp As String
        Get
            Return E_Descrp
        End Get
        Set(value As String)
            E_Descrp = value
        End Set
    End Property

    Private E_ID_CF As Integer
    Public Property ID_CF() As Integer
        Get
            Return E_ID_CF
        End Get
        Set(ByVal value As Integer)
            E_ID_CF = value
        End Set
    End Property

    Private E_ID_PER As Long
    Public Property ID_PER() As Long
        Get
            Return E_ID_PER
        End Get
        Set(ByVal value As Long)
            E_ID_PER = value
        End Set
    End Property

    Public Property EST_REV As Integer
        Get
            Return E_EST_REV
        End Get
        Set(value As Integer)
            E_EST_REV = value
        End Set
    End Property
End Class

'Datos del estado de Validación
Public Class E_Json_Result_DataTable_EstadValidac
    Dim E_Estado As String
    Dim E_Value As Integer

    Public Property estado As String
        Get
            Return E_Estado
        End Get
        Set(ee_value As String)
            E_Estado = ee_value
        End Set
    End Property

    Public Property value As Integer
        Get
            Return E_Value
        End Get
        Set(ee_value As Integer)
            E_Value = ee_value
        End Set
    End Property
End Class

'Datos de los Valores e Intervalos
Public Class E_Json_Result_DataTable_Values
    Dim E_ID_Res As Integer
    Dim E_Value As Object
    Dim E_Decimal As Object
    Dim E_B2 As Object
    Dim E_B1 As Object
    Dim E_A1 As Object
    Dim E_A2 As Object
    Dim E_VECTOR As Object
    Public rfT As String

    Dim E_ATE_REV_ID_ESTADO As Integer

    Public Property ID_RES As Integer
        Get
            Return E_ID_Res
        End Get
        Set(value As Integer)
            E_ID_Res = value
        End Set
    End Property

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

    Private EE_pruCero As Boolean
    Public Property pruCero() As Boolean
        Get
            Return EE_pruCero
        End Get
        Set(ByVal value As Boolean)
            EE_pruCero = value
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

    Public Property vector As String
        Get
            Return E_VECTOR
        End Get
        Set(value As String)
            E_VECTOR = value
        End Set
    End Property

    Private EE_PRU_COD As String
    Public Property PRU_COD() As String
        Get
            Return EE_PRU_COD
        End Get
        Set(ByVal value As String)
            EE_PRU_COD = value
        End Set
    End Property

    Private EE_NEED_VALIDATE As Boolean = False
    Public Property NEED_VALIDATE() As Boolean
        Get
            Return EE_NEED_VALIDATE
        End Get
        Set(ByVal value As Boolean)
            EE_NEED_VALIDATE = value
        End Set
    End Property

    Public Property ATE_REV_ID_ESTADO As Integer
        Get
            Return E_ATE_REV_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ATE_REV_ID_ESTADO = value
        End Set
    End Property
End Class