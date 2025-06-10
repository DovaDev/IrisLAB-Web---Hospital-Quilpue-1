Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_Registrar
    Private DD_registrar As D_Registrar

    Public Sub New()
        DD_registrar = New D_Registrar

    End Sub

    Function IRIS_WEBF_GRABA_EXCEL(
                                ByVal num As String,
                                ByVal codBarra As String,
                                ByVal establecimientoContenedor As String,
                                ByVal cajaTrans As String,
                                ByVal fechaIngreso As String,
                                ByVal muesRecep As String,
                                ByVal MuesEnv As String,
                                ByVal folioHojaTrabajo As String,
                                ByVal FechaEnvio As String,
                                ByVal fechaRecepcion As String,
                                ByVal fechaValidacion As String) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_EXCEL(
                                num,
                                codBarra,
                                establecimientoContenedor,
                                cajaTrans,
                                fechaIngreso,
                                muesRecep,
                                MuesEnv,
                                folioHojaTrabajo,
                                FechaEnvio,
                                fechaRecepcion,
                                fechaValidacion)

    End Function
    Function IRIS_WEBF_GRABA_EXCEL_2(
                                ByVal num As String,
                                ByVal codBarra As String,
                                ByVal establecimientoContenedor As String,
                                ByVal cajaTrans As String,
                                ByVal fechaIngreso As String,
                                ByVal muesRecep As String,
                                ByVal MuesEnv As String,
                                ByVal folioHojaTrabajo As String,
                                ByVal FechaEnvio As String,
                                ByVal fechaRecepcion As String,
                                ByVal fechaValidacion As String,
                                ByVal nummm_avisssss As String) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_EXCEL_2(
                                num,
                                codBarra,
                                establecimientoContenedor,
                                cajaTrans,
                                fechaIngreso,
                                muesRecep,
                                MuesEnv,
                                folioHojaTrabajo,
                                FechaEnvio,
                                fechaRecepcion,
                                fechaValidacion,
                                nummm_avisssss)

    End Function

    Function IRIS_WEBF_GRABA_TRAZA_RESIDUOS(
                            ByVal FOLIO As String,
                                   ByVal FECHA As Date,
                                   ByVal ID_SECCION As Integer,
                                   ByVal ID_TP_RESIDUO As Integer,
                                   ByVal BOLSA_CONTENEDOR As String,
                                   ByVal KILOS_RESIDUO As String,
                                   ByVal RESPONSABLE As String,
                                   ByVal ID_PROCEDENCIA As Integer) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_TRAZA_RESIDUOS(
                                FOLIO,
                                    FECHA,
                                    ID_SECCION,
                                    ID_TP_RESIDUO,
                                    BOLSA_CONTENEDOR,
                                    KILOS_RESIDUO,
                                    RESPONSABLE,
                                    ID_PROCEDENCIA)

    End Function
    Function IRIS_WEBF_GRABA_TRAZA_RESIDUOS_2(
                            ByVal FOLIO As String,
                                   ByVal FECHA As Date,
                                   ByVal ID_SECCION As Integer,
                                   ByVal ID_TP_RESIDUO As Integer,
                                   ByVal BOLSA_CONTENEDOR As String,
                                   ByVal KILOS_RESIDUO As String,
                                   ByVal RESPONSABLE As String,
                                   ByVal ID_PROCEDENCIA As Integer,
                            ByVal SUPERVISOR As String) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_TRAZA_RESIDUOS_2(
                                FOLIO,
                                    FECHA,
                                    ID_SECCION,
                                    ID_TP_RESIDUO,
                                    BOLSA_CONTENEDOR,
                                    KILOS_RESIDUO,
                                    RESPONSABLE,
                                    ID_PROCEDENCIA,
                                SUPERVISOR)

    End Function

    Function IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS(ByVal ID_REG As Integer, ByVal NUM_AVIS As Integer) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS(ID_REG, NUM_AVIS)

    End Function
    Function IRIS_WEBF_GRABA_EXCEL_CONTENEDOR_ENVIO(
                            ByVal num As String,
                            ByVal codBarra As String,
                            ByVal establecimientoContenedor As String,
                            ByVal cajaTrans As String,
                            ByVal Contenedor_Envio As String,
                            ByVal fechaIngreso As String,
                            ByVal muesRecep As String,
                            ByVal MuesEnv As String,
                            ByVal folioHojaTrabajo As String,
                            ByVal FechaEnvio As String,
                            ByVal fechaRecepcion As String,
                            ByVal fechaValidacion As String) As Integer

        Return DD_registrar.IRIS_WEBF_GRABA_EXCEL_CONTENEDOR_ENVIO(
                                num,
                                codBarra,
                                establecimientoContenedor,
                                cajaTrans,
                                Contenedor_Envio,
                                fechaIngreso,
                                muesRecep,
                                MuesEnv,
                                folioHojaTrabajo,
                                FechaEnvio,
                                fechaRecepcion,
                                fechaValidacion)

    End Function
End Class
