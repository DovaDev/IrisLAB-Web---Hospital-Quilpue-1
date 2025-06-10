Public Class E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
    Private EE_Folio As String
    Private EE_Fecha_Ingreso As String
    Private EE_Hora_Ingreso As String
    Private EE_Rut As String
    Private EE_Nombre_Pac As String
    Private EE_Fecha_Valida As String
    Private EE_Hora_Valida As String
    Private EE_Usuario_Valida As String
    Private EE_Examen As String
    Private EE_Procedencia As String
    Private EE_PRU_DESC As String
    Private EE_ATE_RESULTADO As String
    Private EE_ATE_RESULTADO_NUM As String
    Private EE_PAC_FNAC As Date
    Private EE_ID_SEXO As String
    Private EE_ATE_OBS_FICHA As String
    Private EE_ATE_OBS_TM As String
    Public Property ATE_OBS_TM() As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_TM = value
        End Set
    End Property
    Public Property ATE_OBS_FICHA() As String
        Get
            Return EE_ATE_OBS_FICHA
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_FICHA = value
        End Set
    End Property
    Public Property ID_SEXO() As String
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As String)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property PAC_FNAC() As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property ATE_RESULTADO_NUM() As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property

    Public Property ATE_RESULTADO() As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
        End Set
    End Property
    Public Property Procedencia() As String
        Get
            Return EE_Procedencia
        End Get
        Set(ByVal value As String)
            EE_Procedencia = value
        End Set
    End Property
    Public Property Examen() As String
        Get
            Return EE_Examen
        End Get
        Set(ByVal value As String)
            EE_Examen = value
        End Set
    End Property
    Public Property Usuario_Valida() As String
        Get
            Return EE_Usuario_Valida
        End Get
        Set(ByVal value As String)
            EE_Usuario_Valida = value
        End Set
    End Property
    Public Property Hora_Valida() As String
        Get
            Return EE_Hora_Valida
        End Get
        Set(ByVal value As String)
            EE_Hora_Valida = value
        End Set
    End Property
    Public Property Fecha_Valida() As String
        Get
            Return EE_Fecha_Valida
        End Get
        Set(ByVal value As String)
            EE_Fecha_Valida = value
        End Set
    End Property
    Public Property Nombre_Pac() As String
        Get
            Return EE_Nombre_Pac
        End Get
        Set(ByVal value As String)
            EE_Nombre_Pac = value
        End Set
    End Property
    Public Property Rut() As String
        Get
            Return EE_Rut
        End Get
        Set(ByVal value As String)
            EE_Rut = value
        End Set
    End Property
    Public Property Hora_Ingreso() As String
        Get
            Return EE_Hora_Ingreso
        End Get
        Set(ByVal value As String)
            EE_Hora_Ingreso = value
        End Set
    End Property
    Public Property Fecha_Ingreso() As String
        Get
            Return EE_Fecha_Ingreso
        End Get
        Set(ByVal value As String)
            EE_Fecha_Ingreso = value
        End Set
    End Property
    Public Property Folio() As String
        Get
            Return EE_Folio
        End Get
        Set(ByVal value As String)
            EE_Folio = value
        End Set
    End Property
End Class
