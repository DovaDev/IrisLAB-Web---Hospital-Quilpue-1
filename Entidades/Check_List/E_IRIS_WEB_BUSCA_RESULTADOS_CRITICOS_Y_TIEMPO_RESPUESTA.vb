Public Class E_IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA
    Private E_ATE_NUM As Integer
    Private E_PAC_NOMBRE_COMPLETO As String
    Private E_PAC_RUT_DNI As String
    Private E_FECHA_INGRESO As String
    Private E_HORA_INGRESO As String
    Private E_FECHA_NOTIFICACION As String
    Private E_HORA_NOTIFICACION As String
    Private E_FECHA_VALIDACION As String
    Private E_HORA_VALIDACION As String
    Private E_HORAS_DIFERENCIA As String
    Private E_MEDIO_NOTIFICACION As String
    Private E_QUIEN_NOTIFICA As String
    Private E_CF_DESC As String
    Private E_PRU_DESC As String
    Private E_NOTIFICADO_A As String
    Private E_ATE_RESULTADO_ALT As String
    Private E_RESULTADO As String
    Private E_ATE_AÑO As Integer
    Private E_FECHA_RECEPCION As String
    Private E_HORA_RECEPCION As String
    Private E_PROC_DESC As String
    'Private E_NOTIFICADO As Boolean
    Private E_NOTIFICADO As Integer
    Private E_ID_ATE_RES As Integer
    Private E_APRUEBA_NORMAL As Boolean
    Private E_APRUEBA_SAPU As Boolean
    Private E_ES_SAPU As Boolean
    Private E_LLAMADA As Integer
    Private E_DET_CORREO As Integer
    Private E_ID_SEXO As Integer
    Private E_UM_COD As String
    Private E_RLS_LS_DESC As String
    Private E_USU_VALIDA As String
    Private E_ATE_EST_VALIDA As Integer



    Public Property ATE_NUM As Integer
        Get
            Return E_ATE_NUM
        End Get
        Set(value As Integer)
            E_ATE_NUM = value
        End Set
    End Property

    Public Property PAC_NOMBRE_COMPLETO As String
        Get
            Return E_PAC_NOMBRE_COMPLETO
        End Get
        Set(value As String)
            E_PAC_NOMBRE_COMPLETO = value
        End Set
    End Property

    Public Property PAC_RUT_DNI As String
        Get
            Return E_PAC_RUT_DNI
        End Get
        Set(value As String)
            E_PAC_RUT_DNI = value
        End Set
    End Property

    Public Property FECHA_INGRESO As String
        Get
            Return E_FECHA_INGRESO
        End Get
        Set(value As String)
            E_FECHA_INGRESO = value
        End Set
    End Property

    Public Property HORA_INGRESO As String
        Get
            Return E_HORA_INGRESO
        End Get
        Set(value As String)
            E_HORA_INGRESO = value
        End Set
    End Property

    Public Property FECHA_NOTIFICACION As String
        Get
            Return E_FECHA_NOTIFICACION
        End Get
        Set(value As String)
            E_FECHA_NOTIFICACION = value
        End Set
    End Property

    Public Property HORA_NOTIFICACION As String
        Get
            Return E_HORA_NOTIFICACION
        End Get
        Set(value As String)
            E_HORA_NOTIFICACION = value
        End Set
    End Property

    Public Property FECHA_VALIDACION As String
        Get
            Return E_FECHA_VALIDACION
        End Get
        Set(value As String)
            E_FECHA_VALIDACION = value
        End Set
    End Property

    Public Property HORA_VALIDACION As String
        Get
            Return E_HORA_VALIDACION
        End Get
        Set(value As String)
            E_HORA_VALIDACION = value
        End Set
    End Property

    Public Property HORAS_DIFERENCIA As String
        Get
            Return E_HORAS_DIFERENCIA
        End Get
        Set(value As String)
            E_HORAS_DIFERENCIA = value
        End Set
    End Property

    Public Property MEDIO_NOTIFICACION As String
        Get
            Return E_MEDIO_NOTIFICACION
        End Get
        Set(value As String)
            E_MEDIO_NOTIFICACION = value
        End Set
    End Property

    Public Property QUIEN_NOTIFICA As String
        Get
            Return E_QUIEN_NOTIFICA
        End Get
        Set(value As String)
            E_QUIEN_NOTIFICA = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property

    Public Property PRU_DESC As String
        Get
            Return E_PRU_DESC
        End Get
        Set(value As String)
            E_PRU_DESC = value
        End Set
    End Property

    Public Property NOTIFICADO_A As String
        Get
            Return E_NOTIFICADO_A
        End Get
        Set(value As String)
            E_NOTIFICADO_A = value
        End Set
    End Property

    Public Property ATE_RESULTADO_ALT As String
        Get
            Return E_ATE_RESULTADO_ALT
        End Get
        Set(value As String)
            E_ATE_RESULTADO_ALT = value
        End Set
    End Property

    Public Property RESULTADO As String
        Get
            Return E_RESULTADO
        End Get
        Set(value As String)
            E_RESULTADO = value
        End Set
    End Property

    Public Property ATE_AÑO As Integer
        Get
            Return E_ATE_AÑO
        End Get
        Set(value As Integer)
            E_ATE_AÑO = value
        End Set
    End Property

    Public Property FECHA_RECEPCION As String
        Get
            Return E_FECHA_RECEPCION
        End Get
        Set(value As String)
            E_FECHA_RECEPCION = value
        End Set
    End Property

    Public Property HORA_RECEPCION As String
        Get
            Return E_HORA_RECEPCION
        End Get
        Set(value As String)
            E_HORA_RECEPCION = value
        End Set
    End Property

    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property

    'Public Property NOTIFICADO As Boolean
    '    Get
    '        Return E_NOTIFICADO
    '    End Get
    '    Set(value As Boolean)
    '        E_NOTIFICADO = value
    '    End Set
    'End Property

    Public Property ID_ATE_RES As Integer
        Get
            Return E_ID_ATE_RES
        End Get
        Set(value As Integer)
            E_ID_ATE_RES = value
        End Set
    End Property

    Public Property APRUEBA_NORMAL As Boolean
        Get
            Return E_APRUEBA_NORMAL
        End Get
        Set(value As Boolean)
            E_APRUEBA_NORMAL = value
        End Set
    End Property

    Public Property APRUEBA_SAPU As Boolean
        Get
            Return E_APRUEBA_SAPU
        End Get
        Set(value As Boolean)
            E_APRUEBA_SAPU = value
        End Set
    End Property

    Public Property ES_SAPU As Boolean
        Get
            Return E_ES_SAPU
        End Get
        Set(value As Boolean)
            E_ES_SAPU = value
        End Set
    End Property

    Public Property LLAMADA As Integer
        Get
            Return E_LLAMADA
        End Get
        Set(value As Integer)
            E_LLAMADA = value
        End Set
    End Property

    Public Property NOTIFICADO As Integer
        Get
            Return E_NOTIFICADO
        End Get
        Set(value As Integer)
            E_NOTIFICADO = value
        End Set
    End Property

    Public Property DET_CORREO As Integer
        Get
            Return E_DET_CORREO
        End Get
        Set(value As Integer)
            E_DET_CORREO = value
        End Set
    End Property

    Public Property ID_SEXO As Integer
        Get
            Return E_ID_SEXO
        End Get
        Set(value As Integer)
            E_ID_SEXO = value
        End Set
    End Property

    Public Property UM_COD As String
        Get
            Return E_UM_COD
        End Get
        Set(value As String)
            E_UM_COD = value
        End Set
    End Property

    Public Property RLS_LS_DESC As String
        Get
            Return E_RLS_LS_DESC
        End Get
        Set(value As String)
            E_RLS_LS_DESC = value
        End Set
    End Property

    Public Property USU_VALIDA As String
        Get
            Return E_USU_VALIDA
        End Get
        Set(value As String)
            E_USU_VALIDA = value
        End Set
    End Property

    Public Property ATE_EST_VALIDA As Integer
        Get
            Return E_ATE_EST_VALIDA
        End Get
        Set(value As Integer)
            E_ATE_EST_VALIDA = value
        End Set
    End Property
End Class
