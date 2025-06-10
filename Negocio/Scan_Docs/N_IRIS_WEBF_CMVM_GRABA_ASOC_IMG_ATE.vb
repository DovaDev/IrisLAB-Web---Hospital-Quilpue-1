Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE
    End Sub

    Function IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE(ByVal FECHA As String,
                                               ByVal ATE_FECHA As String,
                                               ByVal ID_USUARIO As Long,
                                                ByVal ID_ATENCION As Long,
                                                ByVal IMG As Integer,
                                               ByVal ATE_NUM As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_ASOC_IMG_ATE(FECHA, ATE_FECHA, ID_USUARIO, ID_ATENCION, IMG, ATE_NUM)

    End Function
End Class
