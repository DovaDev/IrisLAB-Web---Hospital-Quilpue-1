'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION
    End Sub

    Function IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION(ByVal ID_PREV As Integer,
                                                           ByVal ID_PROG As Integer,
                                                           ByVal ID_SUBP As Integer,
                                                           ByVal ID_STAT As Integer) As List(Of E_IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION)
        Return DD_Data.IRIS_WEBF_GRABA_PROGRAMA_SUBPROGRAMA_RELACION(ID_PREV, ID_PROG, ID_SUBP, ID_STAT)

    End Function
End Class