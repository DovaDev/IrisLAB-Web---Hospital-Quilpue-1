﻿Public Class E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Long
    Dim EE_ATE_FECHA As Date
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_AÑO As Long
    Dim EE_SEXO_DESC As String
    Dim EE_PAC_RUT As String
    Dim EE_ID_SEXO As Integer
    Dim EE_ID_PROCEDENCIA As Long
    Dim EE_ID_ESTADO As Long
    Dim EE_PROC_DESC As String
    Dim EE_ID_NACIONALIDAD As Long
    Dim EE_ID_ORDEN As Long
    Dim EE_ID_TP_PACI As Long
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As Long
    Dim EE_ID_RLS_LS As Long
    Dim EE_RLS_LS_DESC As String
    Dim EE_AREA_DESC As String
    Private EE_DOCS_CANT As Integer
    Public Property DOCS_CANT As Integer
        Get
            Return EE_DOCS_CANT
        End Get
        Set(ByVal value As Integer)
            EE_DOCS_CANT = value
        End Set
    End Property
    Public Property AREA_DESC As String
        Get
            Return EE_AREA_DESC
        End Get
        Set(value As String)
            EE_AREA_DESC = value
        End Set
    End Property
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
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
    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
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
    Public Property ATE_AÑO As Long
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Long)
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
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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
    Public Property ID_PROCEDENCIA As Long
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Long)
            EE_ID_ESTADO = value
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
    Public Property ID_NACIONALIDAD As Long
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(value As Long)
            EE_ID_NACIONALIDAD = value
        End Set
    End Property
    Public Property ID_ORDEN As Long
        Get
            Return EE_ID_ORDEN
        End Get
        Set(value As Long)
            EE_ID_ORDEN = value
        End Set
    End Property
    Public Property ID_TP_PACI As Long
        Get
            Return EE_ID_TP_PACI
        End Get
        Set(value As Long)
            EE_ID_TP_PACI = value
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
    Public Property ID_RLS_LS As Long
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As Long)
            EE_ID_RLS_LS = value
        End Set
    End Property
    Public Property RLS_LS_DESC As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property
End Class
