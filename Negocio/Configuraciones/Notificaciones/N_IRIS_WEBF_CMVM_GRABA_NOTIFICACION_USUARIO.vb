Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO
    End Sub

    Function IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO(ByVal TIPO_MENSAJE As Integer,
                                                ByVal MENSAJE As String,
                                                ByVal FECHA_D As String,
                                                ByVal FECHA_H As String,
                                                ByVal PERMANENTE As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO(TIPO_MENSAJE, MENSAJE, FECHA_D, FECHA_H, PERMANENTE)

    End Function
End Class
