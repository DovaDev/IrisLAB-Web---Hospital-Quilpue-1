'Importar Capas
Imports System.Collections.Generic
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION
    Shared Function IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION(desde As Date,
                                                                             hasta As Date,
                                                                             idProcedencia As Integer,
                                                                             idPrevision As Integer,
                                                                             idCodigoFonasa As Integer,
                                                                             idDeterminacion As Integer) As List(Of E_ESTADISTICA_RESULTADOS_POR_DETERMINACION)
        Return D_IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION.IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION(desde, hasta, idProcedencia, idPrevision, idCodigoFonasa, idDeterminacion)
    End Function
End Class
