﻿Public Class E_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_PREI_NUM As Integer
    Dim EE_PREI_FECHA As Date
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PREI_AÑO As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_SEXO_DESC As String
    Dim EE_ID_SEXO As Integer
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_PROC_DESC As String
    Dim EE_PREI_FECHA_PRE As Date
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_PREI_IID_ESTADO As Integer
    Dim EE_USU_AGE As String
    Dim EE_ATE_NUM As String
    Dim EE_USU_ATE As String
    Dim EE_USU_NICK As String

    Public Property USU_NICK As Integer
        Get
            Return EE_USU_NICK
        End Get
        Set(value As Integer)
            EE_USU_NICK = value
        End Set
    End Property

    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
        End Set
    End Property

    Public Property PREI_NUM As Integer
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As Integer)
            EE_PREI_NUM = value
        End Set
    End Property

    Public Property PREI_FECHA As Date
        Get
            Return EE_PREI_FECHA
        End Get
        Set(value As Date)
            EE_PREI_FECHA = value
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

    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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

    Public Property PREI_AÑO As String
        Get
            Return EE_PREI_AÑO
        End Get
        Set(value As String)
            EE_PREI_AÑO = value
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

    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
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

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
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

    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property PREI_FECHA_PRE As Date
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(value As Date)
            EE_PREI_FECHA_PRE = value
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

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property PREI_IID_ESTADO As Integer
        Get
            Return EE_PREI_IID_ESTADO
        End Get
        Set(value As Integer)
            EE_PREI_IID_ESTADO = value
        End Set
    End Property

    Public Property USU_AGE As String
        Get
            Return EE_USU_AGE
        End Get
        Set(value As String)
            EE_USU_AGE = value
        End Set
    End Property

    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property USU_ATE As String
        Get
            Return EE_USU_ATE
        End Get
        Set(value As String)
            EE_USU_ATE = value
        End Set
    End Property
End Class
