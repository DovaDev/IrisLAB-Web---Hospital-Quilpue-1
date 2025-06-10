Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION
    End Sub

    Shared Function Update_Estado_Examen(ID_ATENCION As Integer, ID_ESTADO As Integer, ID_USUARIO As Integer, perfiles As List(Of Integer), codigosBarra As List(Of String)) As Object
        Return D_IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION.Update_Estado_Examen(ID_ATENCION, ID_ESTADO, ID_USUARIO, perfiles, codigosBarra)
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ByVal ID_ATE As Integer, ByVal ID_USER As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_ATENDIDO_TOMA_MUESTRA_ATENCION(ID_ATE, ID_USER)
    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_bos_vih(ByVal ID_ATE As Integer, ByVal OBS_VIH As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_bos_vih(ID_ATE, OBS_VIH)
    End Function
    Function IRIS_WEBF_UPDATE_OBS_ATENCION_NORMAL(ATE_NUM As String,
                                                  PESO As String,
                                                  TALLA As String,
                                                  HGT As String,
                                                  FECHA_HORA_ULTIMA_DOSIS As String,
                                                  OBSERVACION_TM As String,
                                                  ATE_OBS_ATE As String,
                                                  OBSERVACION_PER As String,
                                                  DIURESIS As String,
                                                  GRAMAJE As String, ID_PAC As Integer, ZONA_TM As String) As Integer
        'CONCENTRACION_MEDICAMENTO As String,
        'PERSONA As String) 
        Return DD_Data.IRIS_WEBF_UPDATE_OBS_ATENCION_NORMAL(ATE_NUM,
                                                            PESO,
                                                            TALLA,
                                                            HGT,
                                                            FECHA_HORA_ULTIMA_DOSIS,
                                                            OBSERVACION_TM,
                                                            ATE_OBS_ATE,
                                                            OBSERVACION_PER,
                                                            DIURESIS,
                                                            GRAMAJE,
                                                            ID_PAC,
                                                            ZONA_TM
                                                            )
        'OBS As String,'OBS,
        'CONCENTRACION_MEDICAMENTO,
        'PERSONA)
    End Function
End Class
