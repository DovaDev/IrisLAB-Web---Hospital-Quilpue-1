'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_PREVISION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PREVISION

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PREVISION
    End Sub

    Function IRIS_WEBF_GRABA_PREVISION(ByVal PREVE_COD As String,
                                       ByVal PREVE_DES As String,
                                       ByVal PREVE_ARH As String,
                                       ByVal PREVE_F_ARH As String,
                                       ByVal PREVE_ARHA As String,
                                       ByVal PREVE_F_ARHA As String,
                                       ByVal PREVE_HOST As String,
                                       ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREVISION(PREVE_COD, PREVE_DES, PREVE_ARH, PREVE_F_ARH, PREVE_ARHA, PREVE_F_ARHA, PREVE_HOST, ID_ESTADO)

    End Function
End Class