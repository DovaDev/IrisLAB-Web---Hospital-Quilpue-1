'Importar Capas
Imports Datos
Imports Entidades
Public Class N_Atenciones
    'Declaraciones internas
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Atenc As D_Atenciones
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Atenc = New D_Atenciones
    End Sub
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Return DD_Gen_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS(ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS)
        Return DD_Atenc.IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS(Date_01, Date_02)
    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM(ByVal Date_01 As Date, ByVal Date_02 As Date, ByVal ID_TM As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM)
        Return DD_Atenc.IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM(Date_01, Date_02, ID_TM)
    End Function
End Class
