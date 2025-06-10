Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER
    End Sub
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER(ByVal ID_USUARIO As Integer, IMG As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER(ID_USUARIO, IMG)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(ByVal IMG As String, ByVal ID_ATENCION As Integer, ByVal ID_USUARIO As Integer, ByVal ATE_NUM As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC(IMG, ID_ATENCION, ID_USUARIO, ATE_NUM)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF(ByVal IMG As String, ByVal ID_ATENCION As Integer, ByVal ID_USUARIO As Integer, ByVal ATE_NUM As Integer, fileType As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF(IMG, ID_ATENCION, ID_USUARIO, ATE_NUM, fileType)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF_PREI(ByVal IMG As String, ByVal ID_PREINGRESO As Integer, ByVal ID_USUARIO As Integer, ByVal ID_ATENCION As Integer, ByVal ATE_NUM As Integer, ByVal PREI_NUM As Integer, fileType As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_IMAGEN_SCANNER_ASOC_PDF_PREI(IMG, ID_PREINGRESO, ID_USUARIO, ID_ATENCION, ATE_NUM, PREI_NUM, fileType)
    End Function
End Class
