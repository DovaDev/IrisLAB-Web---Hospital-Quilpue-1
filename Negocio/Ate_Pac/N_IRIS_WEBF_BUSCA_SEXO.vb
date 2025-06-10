'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_SEXO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_SEXO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_SEXO
    End Sub
    Function IRIS_WEBF_BUSCA_SEXO() As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Return DD_Data.IRIS_WEBF_BUSCA_SEXO()
    End Function
End Class