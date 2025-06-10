'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_UPDATE_PREVISION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PREVISION

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PREVISION
    End Sub

    Function IRIS_WEBF_UPDATE_PREVISION(ByVal ID_PREVE As Integer,
                                        ByVal PREVE_COD As String,
                                        ByVal PREVE_DES As String,
                                        ByVal PREVE_ARH As String,
                                        ByVal PREVE_FACTORH As String,
                                        ByVal PREVE_ARHA As String,
                                        ByVal PREVE_FACTORHA As String,
                                        ByVal PREVE_HOST As String,
                                        ByVal ID_ESTADO As Integer) As Integer

        Return DD_Data.IRIS_WEBF_UPDATE_PREVISION(ID_PREVE,
                                                  PREVE_COD,
                                                  PREVE_DES,
                                                  PREVE_ARH,
                                                  PREVE_FACTORH,
                                                  PREVE_ARHA,
                                                  PREVE_FACTORHA,
                                                  PREVE_HOST,
                                                  ID_ESTADO)

    End Function
End Class