'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO
    End Sub

    Function IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO(ByVal ANO As Integer, ByVal PREVE As Integer, ByVal FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO)
        Return DD_Data.IRIS_WEBF_BUSCA_PRECIO_CF_SI_EXISTE_ANO(ANO, PREVE, FONASA)

    End Function
End Class