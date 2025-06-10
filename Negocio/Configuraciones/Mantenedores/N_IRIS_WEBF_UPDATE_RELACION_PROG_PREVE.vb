'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE

    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE
    End Sub

    Function IRIS_WEBF_UPDATE_RELACION_PROG_PREVE(ByVal ID_PROGRA As Integer,
                                                  ByVal ID_PREVE As Integer,
                                                  ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_RELACION_PROG_PREVE(ID_PROGRA, ID_PREVE, ID_ESTADO)

    End Function
End Class