'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_DOCUMENTOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DOCUMENTOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DOCUMENTOS
    End Sub

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_MANTENEDOR()

    End Function

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_PRESTACION()

    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS()

    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS2() As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS2()

    End Function

    Function IRIS_WEBF_GRABA_DOCUMENTO(ByVal DCTO_DESC As String,
                                        ByVal DCTO_TIPO As Integer,
                                        ByVal DCTO_FECHA As Date,
                                        ByVal DCTO_RUTA As String,
                                        ByVal DCTO_BITS As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DOCUMENTO(DCTO_DESC, DCTO_TIPO, DCTO_FECHA, DCTO_RUTA, DCTO_BITS)

    End Function

    Function IRIS_WEBF_GRABA_DOCUMENTO_2(ByVal DCTO_DESC As String,
                                        ByVal DCTO_TIPO As Integer,
                                        ByVal DCTO_FECHA As Date,
                                        ByVal DCTO_RUTA As String,
                                        ByVal DCTO_BITS As String,
                                         ByVal DCTO_COD As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DOCUMENTO_2(DCTO_DESC, DCTO_TIPO, DCTO_FECHA, DCTO_RUTA, DCTO_BITS, DCTO_COD)

    End Function
    Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ByVal ID_DCTO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ID_DCTO)

    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ByVal ID_DCTO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ID_DCTO)

    End Function

    Function IRIS_WEBF_BUSCA_DOCUMENTOS_SI_EXISTE(ByVal DCTO_RUTA As String) As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_SI_EXISTE(DCTO_RUTA)

    End Function

    Function IRIS_WEBF_UPDATE_DCTO_DESC(ByVal ID_DCTO As Integer,
                                    ByVal DCTO_DESC As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_DCTO_DESC(ID_DCTO, DCTO_DESC)

    End Function

    '----------------------------------------------------- TRAZABILIDAD PAP CAJAS -----------------------------------------------
    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ByVal ID_CAJA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ID_CAJA)

    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA(ByVal DESDE As Date, ByVal HASTA As Date, ByVal LUGARTM As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA(DESDE, HASTA, LUGARTM)

    End Function

    Function IRIS_WEBF_GRABA_CAJA_TRAZA_PAP(ByVal COMENTARIO As String, ByVal TIPO As String, ByVal ID_USUARIO As Integer, ByVal MATRIZ_NUM_AVIS As String, ByVal ID_PROC As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_CAJA_TRAZA_PAP(COMENTARIO, TIPO, ID_USUARIO, MATRIZ_NUM_AVIS, ID_PROC)

    End Function
    Function IRIS_WEBF_RECIBIR_CAJA(ByVal ID_USUARIO As Integer, ByVal NUM_TRAZA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_RECIBIR_CAJA(ID_USUARIO, NUM_TRAZA)

    End Function

    Function IRIS_WEBF_FINALIZAR_TRAZA_PAP(ByVal ID_CAJA As Integer, ByVal COMENATRIO As String) As Integer
        Return DD_Data.IRIS_WEBF_FINALIZAR_TRAZA_PAP(ID_CAJA, COMENATRIO)

    End Function
    Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS(ByVal ID_CAJA As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS(ID_CAJA)

    End Function
    Function IRIS_WEBF_ELIMINAR_TRAZA_PAP(ByVal ID_CAJA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_ELIMINAR_TRAZA_PAP(ID_CAJA)

    End Function
End Class
