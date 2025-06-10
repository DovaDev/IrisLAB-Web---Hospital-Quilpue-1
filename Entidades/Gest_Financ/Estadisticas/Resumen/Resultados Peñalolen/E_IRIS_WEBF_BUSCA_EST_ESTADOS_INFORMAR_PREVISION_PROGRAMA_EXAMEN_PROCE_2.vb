﻿Public Class E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2
    Dim EE_ATE_NUM As Long
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_DET_V_ID_ESTADO As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As Long
    Dim EE_ID_ATENCION As Long
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PROC_DESC As String
    Dim EE_ID_PROCEDENCIA As Long
    Dim EE_ATE_AÑO As Integer
    Dim EE_SEXO_DESC As String
    Dim EE_ID_PACIENTE As Long
    Dim EE_ID_SEXO As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PAC_FNAC As Date
    Dim EE_ATE_DET_V_PREVI As String
    Dim EE_ATE_MES As Integer
    Dim EE_ATE_DIA As Integer
    Dim EE_TP_PAGO_DESC As String
    Dim EE_PREVE_DESC As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_PROGRA_DESC As String
    Dim EE_SUBP_DESC As String
    Dim EE_Data_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA)
    Public Property Data_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA)
        Get
            Return EE_Data_Ate
        End Get
        Set(value As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA))
            EE_Data_Ate = value
        End Set
    End Property
    Public Property ATE_NUM As Long
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Long)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
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
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA As Long
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property ID_PACIENTE As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Long)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property ATE_DET_V_PREVI As String
        Get
            Return EE_ATE_DET_V_PREVI
        End Get
        Set(value As String)
            EE_ATE_DET_V_PREVI = value
        End Set
    End Property
    Public Property ATE_MES As Integer
        Get
            Return EE_ATE_MES
        End Get
        Set(value As Integer)
            EE_ATE_MES = value
        End Set
    End Property
    Public Property ATE_DIA As Integer
        Get
            Return EE_ATE_DIA
        End Get
        Set(value As Integer)
            EE_ATE_DIA = value
        End Set
    End Property
    Public Property TP_PAGO_DESC As String
        Get
            Return EE_TP_PAGO_DESC
        End Get
        Set(value As String)
            EE_TP_PAGO_DESC = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property SUBP_DESC As String
        Get
            Return EE_SUBP_DESC
        End Get
        Set(value As String)
            EE_SUBP_DESC = value
        End Set
    End Property
End Class
