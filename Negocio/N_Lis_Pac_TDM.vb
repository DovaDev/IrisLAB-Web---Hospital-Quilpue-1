Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Lis_Pac_TDM
    'Declaraciones Generales
    Dim DD_Data As D_Lis_Pac_TDM

    Sub New()
        DD_Data = New D_Lis_Pac_TDM
    End Sub

    Function IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR(ByVal ID_ATENCION As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR(ID_ATENCION)
    End Function
    Function IRIS_WEBF_BUSCA_SI_EXISTE_HO_CC(ByVal ID_ATENCION As String) As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        Return DD_Data.IRIS_WEBF_BUSCA_SI_EXISTE_HO_CC(ID_ATENCION)
    End Function


    Function IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE(
                                                          ByVal ATE_AVIS As String,
                                                          ByVal PAC_RUT As String,
                                                          ByVal PAC_NOMBRE As String,
                                                          ByVal PAC_APELLIDO As String,
                                                          ByVal PAC_APELLIDO_M As String,
                                                          ByVal ID_SEXO As String,
                                                          ByVal PAC_FNAC As String,
                                                          ByVal PAC_FONO1 As String,
                                                          ByVal PAC_EMAIL As String,
                                                          ByVal DOC_RUT As String,
                                                          ByVal DOC_NOMBRE As String,
                                                          ByVal DOC_APELLIDO As String,
                                                          ByVal CF_AVIS As String,
                                                          ByVal CF_DESC As String,
                                                          ByVal COD_AVIS_PROC As String,
                                                          ByVal ID_ATE As String,
                                                          ByVal ATE_FECHA As String) As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE(ATE_AVIS,
                                                                     PAC_RUT,
                                                                     PAC_NOMBRE,
                                                                     PAC_APELLIDO,
                                                                     PAC_APELLIDO_M,
                                                                     ID_SEXO,
                                                                     PAC_FNAC,
                                                                     PAC_FONO1,
                                                                     PAC_EMAIL,
                                                                     DOC_RUT,
                                                                     DOC_NOMBRE,
                                                                     DOC_APELLIDO,
                                                                     CF_AVIS,
                                                                     CF_DESC,
                                                                     COD_AVIS_PROC, ID_ATE, ATE_FECHA)
    End Function



End Class