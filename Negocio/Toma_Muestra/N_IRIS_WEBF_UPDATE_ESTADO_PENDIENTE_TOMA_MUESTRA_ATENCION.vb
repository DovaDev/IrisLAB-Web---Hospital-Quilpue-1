Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION
    End Sub
    Function IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer, ByVal ID_USER As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_PENDIENTE_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
    End Function
    Function IRIS_WEBF_GUARDAR_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer,
                                                                  ByVal ATE_NUM As Integer,
                                                                  ByVal DIP_CUP As Integer,
                                                                  ByVal DIP_CVC As Integer,
                                                                  ByVal DIP_PICCLINE As Integer,
                                                                  ByVal DIP_TET As Integer,
                                                                  ByVal DIP_TQT As Integer,
                                                                  ByVal DIP_AREpi As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GUARDAR_OBSERVACIONES_TOMA_MUESTRA_ATENCION(ID_ATE, ATE_NUM, DIP_CUP, DIP_CVC, DIP_PICCLINE, DIP_TET, DIP_TQT, DIP_AREpi)
    End Function
End Class
