Public Class E_Cobro_RUT
    Private EE_FOLIO As String
    Private EE_FECHA As Date
    Private EE_RUT As String
    Private EE_DNI As String
    Private EE_NOMBRE As String
    Private EE_APELLIDO As String
    Private EE_PROCEDENCIA As String
    Private EE_PREVISION As String
    Private EE_EXAMENES As List(Of E_EXA)
    Public Property EXAMENES() As List(Of E_EXA)
        Get
            Return EE_EXAMENES
        End Get
        Set(ByVal value As List(Of E_EXA))
            EE_EXAMENES = value
        End Set
    End Property
    Public Property PREVISION() As String
        Get
            Return EE_PREVISION
        End Get
        Set(ByVal value As String)
            EE_PREVISION = value
        End Set
    End Property
    Public Property PROCEDENCIA() As String
        Get
            Return EE_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_PROCEDENCIA = value
        End Set
    End Property
    Public Property APELLIDO() As String
        Get
            Return EE_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_APELLIDO = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return EE_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_NOMBRE = value
        End Set
    End Property
    Public Property DNI() As String
        Get
            Return EE_DNI
        End Get
        Set(ByVal value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return EE_RUT
        End Get
        Set(ByVal value As String)
            EE_RUT = value
        End Set
    End Property
    Public Property FECHA() As Date
        Get
            Return EE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_FECHA = value
        End Set
    End Property
    Public Property FOLIO() As String
        Get
            Return EE_FOLIO
        End Get
        Set(ByVal value As String)
            EE_FOLIO = value
        End Set
    End Property
End Class
Public Class E_EXA
    Private EE_CF_DESC As String
    Private EE_CF_COD As String
    Private EE_VALOR As Integer
    Public Property VALOR() As Integer
        Get
            Return EE_VALOR
        End Get
        Set(ByVal value As Integer)
            EE_VALOR = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
End Class