'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR
    End Sub
    Function IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR(ByVal ID_ATE As Integer,
                                                           ByVal ID_PROCE As Integer,
                                                           ByVal ID_TP_PACI As Integer,
                                                           ByVal ID_ORDEN As Integer,
                                                           ByVal ID_DOCTOR As Integer,
                                                           ByVal ID_PREVE As Integer,
                                                           ByVal ID_LOCAL As Integer,
                                                           ByVal ATE_CAMA As String,
                                                           ByVal ATE_OBS_FICHA As String,
                                                           ByVal ID_PROGRA As Integer,
                                                           ByVal EDAD As Integer,
                                                           ByVal MES As Integer,
                                                           ByVal DIA As Integer,
                                                           ByVal SECTOR As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR(ID_ATE, ID_PROCE, ID_TP_PACI, ID_ORDEN, ID_DOCTOR, ID_PREVE, ID_LOCAL, ATE_CAMA, ATE_OBS_FICHA, ID_PROGRA, EDAD, MES, DIA, SECTOR)
    End Function
End Class