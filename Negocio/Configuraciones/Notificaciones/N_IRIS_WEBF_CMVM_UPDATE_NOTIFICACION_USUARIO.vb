Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO
    End Sub

    Function IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO(ByVal ID_REL_N_U As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_NOTIFICACION_USUARIO(ID_REL_N_U)

    End Function
End Class
