﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO
    End Sub

    Function IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO(ByVal ID_NOTIF As Integer, ByVal ID_USER As Integer) As Integer

        Return DD_Data.IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO(ID_NOTIF, ID_USER)

    End Function
End Class
