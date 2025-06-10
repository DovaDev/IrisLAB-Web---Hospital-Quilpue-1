'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    End Sub

    Shared Function Udpdate_Anatomico(SITIO_ANATO As String, ID_ATE_RES As Integer, ID_CODIGO_FONASA As Integer)
        Return D_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS.Update_Anatomico(SITIO_ANATO, ID_ATE_RES, ID_CODIGO_FONASA)
    End Function

    Shared Function Detalle_Atencion_Toma_De_Muestra(ID_ATENCION As Integer) As List(Of E_Detalle_Atencion_Toma_De_Muestra)
        Return D_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS.Detalle_Atencion_Toma_De_Muestra(ID_ATENCION)
    End Function
    Function IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ORD As Integer, ByVal ID_PROC As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS(DESDE, HASTA, ID_ORD, ID_PROC, ID_ESTADO)
    End Function
End Class
