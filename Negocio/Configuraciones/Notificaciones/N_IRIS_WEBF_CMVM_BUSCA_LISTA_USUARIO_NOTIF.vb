Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF(ByVal ID_PREVE As Integer,
                                                      ByVal ID_PROCE As Integer,
                                                      ByVal ID_USUARIO As Long,
                                                      ByVal TIPO As Integer,
                                                      ByVal CONFIRMA As Integer,
                                                      ByVal ESTADO As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF(ID_PREVE, ID_PROCE, ID_USUARIO, TIPO, CONFIRMA, ESTADO)
    End Function
End Class
