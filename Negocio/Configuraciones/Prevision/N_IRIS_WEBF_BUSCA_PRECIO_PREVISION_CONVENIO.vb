﻿Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO
    End Sub
    Function IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO(ByVal ID_AÑO As String, ByVal ID_PREVI As String) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        Return DD_Data.IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO(ID_AÑO, ID_PREVI)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION_Y_PARTICULAR(ByVal ID_AÑO As String, ByVal ID_PREVI As String) As List(Of E_IRIS_WEBF_BUSCA_PRECIO_PREVISION_CONVENIO)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_PRECIO_PREVISION_CONVENIO_BONIFICACION_Y_PARTICULAR(ID_AÑO, ID_PREVI)
    End Function
End Class
