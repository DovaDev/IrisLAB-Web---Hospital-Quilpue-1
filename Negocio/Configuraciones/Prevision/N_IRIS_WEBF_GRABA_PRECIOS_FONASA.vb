'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_PRECIOS_FONASA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PRECIOS_FONASA

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PRECIOS_FONASA
    End Sub

    Function IRIS_WEBF_GRABA_PRECIOS_FONASA(ByVal ID_PREVI As Integer, ByVal ID_CF As Integer, ByVal ID_ANO As Integer, ByVal ID_USUARO As Integer, ByVal V_AMB As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PRECIOS_FONASA(ID_PREVI, ID_CF, ID_ANO, ID_USUARO, V_AMB)

    End Function
End Class