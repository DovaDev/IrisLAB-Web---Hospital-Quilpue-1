'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_UPDATE_RELACION_PRE_PROCE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_RELACION_PRE_PROCE

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_RELACION_PRE_PROCE
    End Sub

    Function IRIS_WEBF_UPDATE_RELACION_PRE_PROCE(ByVal ID_PREVE As Integer,
                                                 ByVal ID_PROCEDENCIA As Integer,
                                                 ByVal ID_ESTADO As Integer) As Integer

        Return DD_Data.IRIS_WEBF_UPDATE_RELACION_PRE_PROCE(ID_PREVE,
                                                           ID_PROCEDENCIA,
                                                           ID_ESTADO)

    End Function
End Class