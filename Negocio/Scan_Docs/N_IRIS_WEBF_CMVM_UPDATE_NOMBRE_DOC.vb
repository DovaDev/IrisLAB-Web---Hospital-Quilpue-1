﻿Imports Datos
Public Class N_IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC
    Dim DD_Data As D_IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC
    End Sub
    Function IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC_MOBILE(ByVal ID As Long, ByVal NOMBRE_DOC As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_NOMBRE_DOC_MOBILE(ID, NOMBRE_DOC)
    End Function
End Class
