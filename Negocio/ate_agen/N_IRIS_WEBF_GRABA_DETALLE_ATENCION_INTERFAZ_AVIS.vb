'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
    End Sub
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS_3(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal ATE_CF_MULTIPLICADOS As String, ByVal ATE_CODIGO_TEST As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS_3(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, ATE_CF_MULTIPLICADOS, ATE_CODIGO_TEST)
    End Function
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal SITIO_ANATO As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, SITIO_ANATO)
    End Function

    'Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String) As Integer
    '    Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ)
    'End Function
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal ATE_CF_MULTIPLICADOS As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, ATE_CF_MULTIPLICADOS)
    End Function
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_2(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal ATE_CF_MULTIPLICADOS As String, ByVal ATE_CODIGO_TEST As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_2(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, ATE_CF_MULTIPLICADOS, ATE_CODIGO_TEST)
    End Function
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX_01(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal ATE_CF_MULTIPLICADOS As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_saydex_01(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, ATE_CF_MULTIPLICADOS)
    End Function
    Function IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SIDRA(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SIDRA(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW(ByVal ID_ATE As Integer,
                                                     ByVal ID_USUARIO As Integer,
                                                     ByVal ID_CF As Integer,
                                                     ByVal ID_PER As Integer,
                                                     ByVal ID_TP_PAGO As Integer,
                                                     ByVal ATE_DET_DOC As String,
                                                     ByVal ATE_DET_V_PREVI As Integer,
                                                     ByVal ATE_DET_V_PAGADO As Integer,
                                                     ByVal ATE_DET_V_CCOPAGO As Integer,
                                                     ByVal ATE_NUM_INTERFAZ As String,
                                                      ByVal ATE_TP_PREVE As String,
                                                       ByVal ATE_TP_PAGO As String,
                                                     ByVal ATE_DET_VALOR_BENEF As Integer,             '1
                                                     ByVal ATE_DET_VALOR_CS As Integer,                '2
                                                     ByVal ATE_DET_TP_1 As Integer,                    '3
                                                     ByVal ATE_DET_TP_OBS As String,                  '4
                                                     ByVal ATE_DET_NUM_BOL As Integer,                 '5
                                                     ByVal ATE_DET_NUM_BONO As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW(ID_ATE,
                                                                               ID_USUARIO,
                                                                               ID_CF, ID_PER,
                                                                               ID_TP_PAGO,
                                                                               ATE_DET_DOC,
                                                                               ATE_DET_V_PREVI,
                                                                               ATE_DET_V_PAGADO,
                                                                               ATE_DET_V_CCOPAGO,
                                                                               ATE_NUM_INTERFAZ,
                                                                               ATE_TP_PREVE,
                                                                               ATE_TP_PAGO,
                                                                               ATE_DET_VALOR_BENEF,
                                                                               ATE_DET_VALOR_CS,
                                                                               ATE_DET_TP_1,
                                                                               ATE_DET_TP_OBS, ATE_DET_NUM_BOL,                 '5
                                                                                ATE_DET_NUM_BONO)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_NEW_TP_PAGO(ByVal ID_ATENCION As Integer,
                                                                                 ByVal ID_CODIGO_FONASA As Integer,
                                                                                 ByVal ID_TP_PAGO As Integer,
                                                                                 ByVal ATE_DET_V_PREVI As Integer,
                                                                                 ByVal ATE_DET_V_PAGADO As Integer,
                                                                                 ByVal ATE_DET_V_COPAGO As Integer,
                                                                                 ByVal ATE_DET_VALOR_BENEF As Integer,
                                                                                 ByVal ATE_DET_VALOR_CS As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_NEW_TP_PAGO(ID_ATENCION,
                                                                                 ID_CODIGO_FONASA,
                                                                                 ID_TP_PAGO,
                                                                                 ATE_DET_V_PREVI,
                                                                                 ATE_DET_V_PAGADO,
                                                                                 ATE_DET_V_COPAGO,
                                                                                 ATE_DET_VALOR_BENEF,
                                                                                 ATE_DET_VALOR_CS)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO_ID_DET_PREVE(ByVal ID_ATENCION As Integer,
                                                                                 ByVal ID_CODIGO_FONASA As Integer,
                                                                                 ByVal ID_TP_PAGO As Integer,
                                                                                 ByVal ATE_DET_V_PREVI As Integer,
                                                                                 ByVal ATE_DET_V_PAGADO As Integer,
                                                                                 ByVal ATE_DET_V_COPAGO As Integer,
                                                                                 ByVal ATE_DET_VALOR_BENEF As Integer,
                                                                                 ByVal ATE_DET_VALOR_CS As Integer,
                                                                                 ByVal ID_DET_PREVE As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO_ID_DET_PREVE(ID_ATENCION,
                                                                                 ID_CODIGO_FONASA,
                                                                                 ID_TP_PAGO,
                                                                                 ATE_DET_V_PREVI,
                                                                                 ATE_DET_V_PAGADO,
                                                                                 ATE_DET_V_COPAGO,
                                                                                 ATE_DET_VALOR_BENEF,
                                                                                 ATE_DET_VALOR_CS,
                                                                                    ID_DET_PREVE)
    End Function

    Function IRIS_WEBF_CMVM_GRABA_AUDITORIA_CAMBIO_TP_PAGO(ByVal TIPO As String,
                                                           ByVal LOG As String,
                                                           ByVal FECHA As Date,
                                                           ByVal S_Id_User As String,
                                                           ByVal ID_ATENCION As Integer,
                                                           ByVal ID_PACIENTE As String) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_AUDITORIA_CAMBIO_TP_PAGO(TIPO, LOG, FECHA, S_Id_User, ID_ATENCION, ID_PACIENTE)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_ATE_DET_PREVE(ByVal ID_ATE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ID_CF As Integer,
                                                 ByVal ID_PER As Integer,
                                                 ByVal ID_TP_PAGO As Integer,
                                                 ByVal ATE_DET_DOC As String,
                                                 ByVal ATE_DET_V_PREVI As Integer,
                                                 ByVal ATE_DET_V_PAGADO As Integer,
                                                 ByVal ATE_DET_V_CCOPAGO As Integer,
                                                 ByVal ATE_NUM_INTERFAZ As String,
                                                  ByVal ATE_TP_PREVE As String,
                                                   ByVal ATE_TP_PAGO As String,
                                                 ByVal ATE_DET_VALOR_BENEF As Integer,             '1
                                                 ByVal ATE_DET_VALOR_CS As Integer,                '2
                                                 ByVal ATE_DET_TP_1 As Integer,                    '3
                                                 ByVal ATE_DET_TP_OBS As String,                  '4
                                                 ByVal ATE_DET_NUM_BOL As Integer,                 '5
                                                 ByVal ATE_DET_NUM_BONO As String,
                                                ByVal ATE_PREV_WEB As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_ATE_DET_PREVE(ID_ATE,
                                                                               ID_USUARIO,
                                                                               ID_CF, ID_PER,
                                                                               ID_TP_PAGO,
                                                                               ATE_DET_DOC,
                                                                               ATE_DET_V_PREVI,
                                                                               ATE_DET_V_PAGADO,
                                                                               ATE_DET_V_CCOPAGO,
                                                                               ATE_NUM_INTERFAZ,
                                                                               ATE_TP_PREVE,
                                                                               ATE_TP_PAGO,
                                                                               ATE_DET_VALOR_BENEF,
                                                                               ATE_DET_VALOR_CS,
                                                                               ATE_DET_TP_1,
                                                                               ATE_DET_TP_OBS, ATE_DET_NUM_BOL,                 '5
                                                                                ATE_DET_NUM_BONO,
                                                                                ATE_PREV_WEB)
    End Function
    Function IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3_NEW_AGREGA_EXAM(ByVal ID_ATE As Integer, ByVal ID_USUARIO As Integer, ByVal ID_CF As Integer, ByVal ID_PER As Integer, ByVal ID_TP_PAGO As Integer, ByVal ATE_DET_DOC As String, ByVal ATE_DET_V_PREVI As Integer, ByVal ATE_DET_V_PAGADO As Integer, ByVal ATE_DET_V_CCOPAGO As Integer, ByVal ATE_NUM_INTERFAZ As String, ByVal ATE_CF_MULTIPLICADOS As String, ByVal ATE_CODIGO_TEST As String, ByVal ATE_DET_VALOR_BENEF As Integer, ByVal ATE_DET_VALOR_CS As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3_NEW_AGREGA_EXAM(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, ATE_NUM_INTERFAZ, ATE_CF_MULTIPLICADOS, ATE_CODIGO_TEST, ATE_DET_VALOR_BENEF, ATE_DET_VALOR_CS)
    End Function
End Class