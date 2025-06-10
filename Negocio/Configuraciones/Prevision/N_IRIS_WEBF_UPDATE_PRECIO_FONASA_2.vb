'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_UPDATE_PRECIO_FONASA_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PRECIO_FONASA_2

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PRECIO_FONASA_2
    End Sub

    Function IRIS_WEBF_UPDATE_PRECIO_FONASA_2(ByVal ID_PRECIO As Integer, ByVal AMB As Integer, ByVal HOSP As Integer, ByVal ID_USUARIO As Integer, ByVal FECHA As Date, ByVal ID_ESTADO As Integer, ByVal ID_P As Integer, ByVal ID_CF As Integer, ByVal ID_A As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PRECIO_FONASA_2(ID_PRECIO, AMB, HOSP, ID_USUARIO, FECHA, ID_ESTADO, ID_P, ID_CF, ID_A)

    End Function
End Class