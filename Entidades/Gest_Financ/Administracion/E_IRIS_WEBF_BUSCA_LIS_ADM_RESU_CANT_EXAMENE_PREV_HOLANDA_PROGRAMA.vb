﻿Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA
    Private E_TOTAL_ATE As Long
    Private E_TOTAL_PREVE As Long
    Private E_TOT_FONASA As Long
    Private E_TOTA_SIS As Long
    Private E_TOTA_USU As Long
    Private E_TOTA_COPA As Long
    Private E_CF_DESC As String
    Private E_ID_CODIGO_FONASA As Long
    Private E_ID_ESTADO As Long
    Private E_CF_COD As String
    Private E_ID_PROGRA As Long
    Private E_PROGRA_DESC As String
    Public Property TOTAL_ATE As Long
        Get
            Return E_TOTAL_ATE
        End Get
        Set(value As Long)
            E_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Long
        Get
            Return E_TOTAL_PREVE
        End Get
        Set(value As Long)
            E_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Long
        Get
            Return E_TOT_FONASA
        End Get
        Set(value As Long)
            E_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return E_TOTA_SIS
        End Get
        Set(value As Long)
            E_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Long
        Get
            Return E_TOTA_USU
        End Get
        Set(value As Long)
            E_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Long
        Get
            Return E_TOTA_COPA
        End Get
        Set(value As Long)
            E_TOTA_COPA = value
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
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Long)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property
    Public Property ID_PROGRA As Long
        Get
            Return E_ID_PROGRA
        End Get
        Set(value As Long)
            E_ID_PROGRA = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return E_PROGRA_DESC
        End Get
        Set(value As String)
            E_PROGRA_DESC = value
        End Set
    End Property
End Class