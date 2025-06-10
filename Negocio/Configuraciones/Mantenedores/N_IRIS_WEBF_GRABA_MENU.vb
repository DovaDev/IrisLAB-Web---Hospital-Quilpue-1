Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_MENU
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_MENU
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_MENU
    End Sub
    Function IRIS_WEBF_GRABA_MENU(ByVal NOM As String, ByVal DESC As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_MENU(NOM, DESC)
    End Function
End Class
