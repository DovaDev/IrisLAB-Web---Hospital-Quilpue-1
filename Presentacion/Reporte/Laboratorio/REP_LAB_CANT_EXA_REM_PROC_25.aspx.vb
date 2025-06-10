Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.Office.CustomUI
Imports DocumentFormat.OpenXml.Office2010.PowerPoint
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Entidades
Imports Negocio

Public Class REP_LAB_CANT_EXA_REM_PROC_25
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_REM2(DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        Dim N_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES


        ' PARTE NUEVA
        ' Esta lista guarda los detalles de atención por fecha esto se ocupa
        Dim List_Det_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = N_REM.IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA(DESDE, HASTA)

        Dim List_Conteo As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CONTEO_RETICULO(DESDE, HASTA)

        ' Primero, agrupa la lista por ID_ATENCION
        Dim groupedList = List_Det_Ate.GroupBy(Function(item) item.ID_ATENCION)


        ' Definimos la lista de codigos fonasa que queremos excluir en este caso seria las prestaciones que pueden ser individuales
        Dim exc_hemograma As New List(Of Integer) From {26, 27, 32, 33, 34, 35, 36, 38, 39, 40, 45}
        ' Variable para contar las veces que hemograma ID_CODIGO_FONASA 30 se encuentra en la misma atención que los IDs de exc_hemograma
        Dim countHemograma30WithExclusions As Integer = 0

        ' Filtro para hemograma
        Dim filteredList = groupedList.SelectMany(Function(group)
                                                      ' Verifica si hay un ID_CODIGO_FONASA 30 en el grupo
                                                      Dim hasCodigoFonasa30 = group.Any(Function(item) item.ID_CODIGO_FONASA = 30)

                                                      ' Verifica si hay algún código de la lista exc_hemograma en el grupo
                                                      Dim hasExclusion = group.Any(Function(item) exc_hemograma.Contains(item.ID_CODIGO_FONASA))

                                                      ' Si hay un 30 y un código de la lista de exclusión, incrementa el contador
                                                      If hasCodigoFonasa30 AndAlso hasExclusion Then
                                                          countHemograma30WithExclusions += 1
                                                      End If

                                                      ' Si hay un 30, excluye los ítems con ID_CODIGO_FONASA en la exclusionList, de lo contrario incluye todos
                                                      If hasCodigoFonasa30 Then
                                                          Return group.Where(Function(item) Not exc_hemograma.Contains(item.ID_CODIGO_FONASA))
                                                      Else
                                                          Return group
                                                      End If
                                                  End Function).ToList()


        'Debug.WriteLine($"Contador hemograma: {countHemograma30WithExclusions}")

        ' Lista de tipo integer que priorizamos para cuando es un perfil bioquimico
        Dim priori_p_hepa_test As New List(Of Integer) From {57, 94, 97, 136, 137} ' 66, 130, 138, 140, 141
        Dim priori_p_bioq As New List(Of Integer) From {57, 66, 94, 97, 130, 136, 137, 138, 140, 141}
        Dim soloCodigo664Count As Integer = 0

        ' Variable para contar las ocurrencias del código 664
        Dim totalCodigo664Count As Integer = 0

#Region "TOTALES 664"

        Dim TOTAL664CAE As Integer = 0
        Dim TOTAL664USM_HDIURNO As Integer = 0
        Dim TOTAL664Personal As Integer = 0
        Dim TOTAL664TOTAL_ABIERTA As Integer = 0
        Dim TOTAL664MQ1 As Integer = 0
        Dim TOTAL664MQ2 As Integer = 0
        Dim TOTAL664MQ3 As Integer = 0
        Dim TOTAL664UAPQ_PABELLON As Integer = 0
        Dim TOTAL664PEDIATRIA As Integer = 0
        Dim TOTAL664NEONATOLOGIA As Integer = 0
        Dim TOTAL664UPC As Integer = 0
        Dim TOTAL664UCI_A As Integer = 0
        Dim TOTAL664UTI As Integer = 0
        Dim TOTAL664MATERNIDAD As Integer = 0
        Dim TOTAL664CMA As Integer = 0
        Dim TOTAL664HOSP_DOCIMI As Integer = 0
        Dim TOTAL664UEA_HOSP As Integer = 0
        Dim TOTAL664TOTAL_CERRADA As Integer = 0
        Dim TOTAL664UEA As Integer = 0
        Dim TOTAL664UEI As Integer = 0
        Dim TOTAL664SAUD As Integer = 0
        Dim TOTAL664TOTAL_UE As Integer = 0
        Dim TOTAL664UEGO As Integer = 0
        Dim TOTAL664ANATOMIA_PATO As Integer = 0
        Dim TOTAL664IMAGENOLOGIA As Integer = 0
        Dim TOTAL664TOTAL_UNIDAD_APOYO As Integer = 0
        Dim TOTAL664CESFAM_IVAN_MAN As Integer = 0
        Dim TOTAL664CESFAM_AV_AC As Integer = 0
        Dim TOTAL664CESFAM_QUILPUE As Integer = 0
        Dim TOTAL664CESFAM_BELLOTO As Integer = 0
        Dim TOTAL664CONS_POMPEYA As Integer = 0
        Dim TOTAL664CECOSF_RETIRO As Integer = 0
        Dim TOTAL664CONS_BELLOTO As Integer = 0
        Dim TOTAL664CESFAM_VILLA_AL As Integer = 0
        Dim TOTAL664CESFAM_AMERICAS As Integer = 0
        Dim TOTAL664CONS_EDUARDO_FREI As Integer = 0
        Dim TOTAL664CESFAM_JUAN_BT As Integer = 0
        Dim TOTAL664CONS_AGUILAS As Integer = 0
        Dim TOTAL664SAPU_FREI As Integer = 0
        Dim TOTAL664CESFAM_LIMACHE As Integer = 0
        Dim TOTAL664CESFAM_OLMUE As Integer = 0
        Dim TOTAL664APS_CABILDO As Integer = 0
        Dim TOTAL664APS_HIJUELAS As Integer = 0
        Dim TOTAL664APS_CALERA As Integer = 0
        Dim TOTAL664APS_LIGUA As Integer = 0
        Dim TOTAL664APS_NOGALES As Integer = 0
        Dim TOTAL664APS_PETORCA As Integer = 0
        Dim TOTAL664HOSP_LIMACHE As Integer = 0
        Dim TOTAL664HOSP_GERIATRICO_LMCHE As Integer = 0
        Dim TOTAL664HOSP_MODULAR_LMCHE As Integer = 0
        Dim TOTAL664HOSP_PENBLANCA As Integer = 0
        Dim TOTAL664HOSP_GUSTAVO_FRICKE As Integer = 0
        Dim TOTAL664HOSP_CALERA As Integer = 0
        Dim TOTAL664HOSP_PETORCA As Integer = 0
        Dim TOTAL664HOSP_QUILLOTA As Integer = 0
        Dim TOTAL664HOSP_CABILDO As Integer = 0
        Dim TOTAL664HOSP_LIGUA As Integer = 0
        Dim TOTAL664HOSP_QUINTERO As Integer = 0
        Dim TOTAL664OTROS As Integer = 0
        Dim TOTAL664TOTAL_EXTRA As Integer = 0

#End Region
        ' Filtro para Perfil Bioquimico
        Dim totalDupliPerfi As Integer = 0
        ' Filtro para Perfil Bioquímico
        Dim filteredList2 = groupedList.SelectMany(Function(group)
                                                       ' Verifica si hay algún ID_CODIGO_FONASA en prori_p_bioq en el grupo
                                                       Dim hasProriPBioq = group.Any(Function(item) priori_p_bioq.Contains(item.ID_CODIGO_FONASA))
                                                       ' Verifica si hay un ID_CODIGO_FONASA 664 en el grupo
                                                       Dim hasCodigoFonasa664 = group.Any(Function(item) item.ID_CODIGO_FONASA = 664 Or item.ID_CODIGO_FONASA = 941)
                                                       ' Verifica si hay un ID_CODIGO_FONASA 941 en el grupo
                                                       Dim hasCodigoFonasa941 = group.Any(Function(item) item.ID_CODIGO_FONASA = 941)


                                                       If (hasCodigoFonasa664) Then
#Region "TOTAL 664"

                                                           ' Atención abierta

                                                           TOTAL664CAE += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL664USM_HDIURNO += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209)
                                                           TOTAL664Personal += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217)
                                                           TOTAL664TOTAL_ABIERTA += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           ' Atencion cerrada
                                                           TOTAL664MQ1 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53)
                                                           TOTAL664MQ2 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52)
                                                           TOTAL664MQ3 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57)
                                                           TOTAL664UAPQ_PABELLON += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68)
                                                           TOTAL664PEDIATRIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55)
                                                           TOTAL664NEONATOLOGIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59)
                                                           TOTAL664UPC += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60)
                                                           TOTAL664UCI_A += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215)
                                                           TOTAL664UTI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214)
                                                           TOTAL664MATERNIDAD += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58)
                                                           TOTAL664CMA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54)
                                                           TOTAL664HOSP_DOCIMI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56)
                                                           TOTAL664UEA_HOSP += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221)
                                                           TOTAL664TOTAL_CERRADA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
                                                           item.ID_PROCEDENCIA = 60 Or
                                                           item.ID_PROCEDENCIA = 215 Or
                                                           item.ID_PROCEDENCIA = 214 Or
                                                           item.ID_PROCEDENCIA = 58 Or
                                                           item.ID_PROCEDENCIA = 54 Or
                                                           item.ID_PROCEDENCIA = 56 Or
                                                           item.ID_PROCEDENCIA = 221))
                                                           ' Atencion UE
                                                           TOTAL664UEA += group.Count(Function(item) item.ID_PROCEDENCIA = 66)
                                                           TOTAL664UEI += group.Count(Function(item) item.ID_PROCEDENCIA = 267)
                                                           TOTAL664SAUD += group.Count(Function(item) item.ID_PROCEDENCIA = 223)
                                                           TOTAL664TOTAL_UE += group.Count(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223)
                                                           ' Atención UEGO
                                                           TOTAL664UEGO += group.Count(Function(item) item.ID_PROCEDENCIA = 67)
                                                           ' Atención  Unidad de APOYO
                                                           TOTAL664ANATOMIA_PATO += group.Count(Function(item) item.ID_PROCEDENCIA = 164)
                                                           TOTAL664IMAGENOLOGIA += group.Count(Function(item) item.ID_PROCEDENCIA = 236)
                                                           TOTAL664TOTAL_UNIDAD_APOYO += group.Count(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236)
                                                           ' Atención EXTRA HOSPITALARIO
                                                           TOTAL664CESFAM_IVAN_MAN += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244)
                                                           TOTAL664CESFAM_AV_AC += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243)
                                                           TOTAL664CESFAM_QUILPUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207)
                                                           TOTAL664CESFAM_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245)
                                                           TOTAL664CONS_POMPEYA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212)
                                                           TOTAL664CECOSF_RETIRO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249)
                                                           TOTAL664CONS_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210)
                                                           TOTAL664CESFAM_VILLA_AL += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64)
                                                           TOTAL664CESFAM_AMERICAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62)
                                                           TOTAL664CONS_EDUARDO_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL664CESFAM_JUAN_BT += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61)
                                                           TOTAL664CONS_AGUILAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271)
                                                           TOTAL664SAPU_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL664CESFAM_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219)
                                                           TOTAL664CESFAM_OLMUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238)
                                                           TOTAL664APS_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254)
                                                           TOTAL664APS_HIJUELAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241)
                                                           TOTAL664APS_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239)
                                                           TOTAL664APS_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255)
                                                           TOTAL664APS_NOGALES += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240)
                                                           TOTAL664APS_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256)
                                                           TOTAL664HOSP_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228)
                                                           TOTAL664HOSP_GERIATRICO_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229)
                                                           TOTAL664HOSP_MODULAR_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232)
                                                           TOTAL664HOSP_PENBLANCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63)
                                                           TOTAL664HOSP_GUSTAVO_FRICKE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220)
                                                           TOTAL664HOSP_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233)
                                                           TOTAL664HOSP_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253)
                                                           TOTAL664HOSP_QUILLOTA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230)
                                                           TOTAL664HOSP_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252)
                                                           TOTAL664HOSP_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251)
                                                           TOTAL664HOSP_QUINTERO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227)
                                                           TOTAL664OTROS += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL664TOTAL_EXTRA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    item.ID_PROCEDENCIA = 244 Or
    item.ID_PROCEDENCIA = 243 Or
    item.ID_PROCEDENCIA = 207 Or
    item.ID_PROCEDENCIA = 245 Or
    item.ID_PROCEDENCIA = 212 Or
    item.ID_PROCEDENCIA = 249 Or
    item.ID_PROCEDENCIA = 210 Or
    item.ID_PROCEDENCIA = 64 Or
    item.ID_PROCEDENCIA = 62 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 61 Or
    item.ID_PROCEDENCIA = 271 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 219 Or
    item.ID_PROCEDENCIA = 238 Or
    item.ID_PROCEDENCIA = 254 Or
    item.ID_PROCEDENCIA = 241 Or
    item.ID_PROCEDENCIA = 239 Or
    item.ID_PROCEDENCIA = 255 Or
    item.ID_PROCEDENCIA = 240 Or
    item.ID_PROCEDENCIA = 256 Or
    item.ID_PROCEDENCIA = 228 Or
    item.ID_PROCEDENCIA = 229 Or
    item.ID_PROCEDENCIA = 232 Or
    item.ID_PROCEDENCIA = 63 Or
    item.ID_PROCEDENCIA = 220 Or
    item.ID_PROCEDENCIA = 233 Or
    item.ID_PROCEDENCIA = 253 Or
    item.ID_PROCEDENCIA = 230 Or
    item.ID_PROCEDENCIA = 252 Or
    item.ID_PROCEDENCIA = 251 Or
    item.ID_PROCEDENCIA = 227))
#End Region
                                                       End If

                                                       ' Si hay códigos en prori_p_bioq y también 664, excluye 664
                                                       If hasProriPBioq AndAlso hasCodigoFonasa664 Then
                                                           ' Cuenta las ocurrencias de 664 y acumúlalas en totalCodigo664Count
                                                           'totalCodigo664Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 664)
                                                           totalCodigo664Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 664)
                                                           Dim totalOtroCodigoCount As Integer = 0

                                                           ' Si no hay código 664, buscamos por otro ID_CODIGO_FONASA
                                                           If totalCodigo664Count = 0 Then
                                                               totalCodigo664Count = group.Count(Function(item) item.ID_CODIGO_FONASA = 941) ' Reemplaza 999 por el ID que necesites
                                                           Else
                                                               ' Si hay código 664, puedes hacer lo que necesites con ese dato
                                                               ' O realizar una búsqueda inversa si es necesario
                                                               totalCodigo664Count = 0 ' O lo que necesites hacer aquí
                                                           End If
                                                           ' Excluye 664 y 941, devolviendo solo los que están en prori_p_bioq
                                                           'If hasCodigoFonasa664 AndAlso hasCodigoFonasa941 Then
                                                           '    Dim uniqueInBioq As List(Of Integer) = priori_p_bioq.Except(priori_p_hepa_test).ToList()
                                                           '    Return group.Where(Function(item) uniqueInBioq.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 664 AndAlso item.ID_CODIGO_FONASA <> 941).ToList()
                                                           'End If
                                                           Return group.Where(Function(item) priori_p_bioq.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 664).ToList()

                                                       ElseIf hasCodigoFonasa664 AndAlso Not hasProriPBioq Then
                                                           totalCodigo664Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 664)
                                                           Return group.Where(Function(item) item.ID_CODIGO_FONASA = 664).ToList()

                                                           ' En otros casos, solo filtrar los códigos que están en priori_p_bioq
                                                       Else
                                                           Return group.Where(Function(item) priori_p_bioq.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                       End If
                                                   End Function).ToList()

#Region "PERFIL TIROIDEO"



        Dim priori_p_tiro As New List(Of Integer) From {182, 183, 527}
        Dim soloCodigo730Count As Integer = 0

        ' Variable para contar las ocurrencias del código 664
        Dim totalCodigo730Count As Integer = 0

#Region "TOTALES 730"

        Dim TOTAL730CAE As Integer = 0
        Dim TOTAL730USM_HDIURNO As Integer = 0
        Dim TOTAL730Personal As Integer = 0
        Dim TOTAL730TOTAL_ABIERTA As Integer = 0
        Dim TOTAL730MQ1 As Integer = 0
        Dim TOTAL730MQ2 As Integer = 0
        Dim TOTAL730MQ3 As Integer = 0
        Dim TOTAL730UAPQ_PABELLON As Integer = 0
        Dim TOTAL730PEDIATRIA As Integer = 0
        Dim TOTAL730NEONATOLOGIA As Integer = 0
        Dim TOTAL730UPC As Integer = 0
        Dim TOTAL730UCI_A As Integer = 0
        Dim TOTAL730UTI As Integer = 0
        Dim TOTAL730MATERNIDAD As Integer = 0
        Dim TOTAL730CMA As Integer = 0
        Dim TOTAL730HOSP_DOCIMI As Integer = 0
        Dim TOTAL730UEA_HOSP As Integer = 0
        Dim TOTAL730TOTAL_CERRADA As Integer = 0
        Dim TOTAL730UEA As Integer = 0
        Dim TOTAL730UEI As Integer = 0
        Dim TOTAL730SAUD As Integer = 0
        Dim TOTAL730TOTAL_UE As Integer = 0
        Dim TOTAL730UEGO As Integer = 0
        Dim TOTAL730ANATOMIA_PATO As Integer = 0
        Dim TOTAL730IMAGENOLOGIA As Integer = 0
        Dim TOTAL730TOTAL_UNIDAD_APOYO As Integer = 0
        Dim TOTAL730CESFAM_IVAN_MAN As Integer = 0
        Dim TOTAL730CESFAM_AV_AC As Integer = 0
        Dim TOTAL730CESFAM_QUILPUE As Integer = 0
        Dim TOTAL730CESFAM_BELLOTO As Integer = 0
        Dim TOTAL730CONS_POMPEYA As Integer = 0
        Dim TOTAL730CECOSF_RETIRO As Integer = 0
        Dim TOTAL730CONS_BELLOTO As Integer = 0
        Dim TOTAL730CESFAM_VILLA_AL As Integer = 0
        Dim TOTAL730CESFAM_AMERICAS As Integer = 0
        Dim TOTAL730CONS_EDUARDO_FREI As Integer = 0
        Dim TOTAL730CESFAM_JUAN_BT As Integer = 0
        Dim TOTAL730CONS_AGUILAS As Integer = 0
        Dim TOTAL730SAPU_FREI As Integer = 0
        Dim TOTAL730CESFAM_LIMACHE As Integer = 0
        Dim TOTAL730CESFAM_OLMUE As Integer = 0
        Dim TOTAL730APS_CABILDO As Integer = 0
        Dim TOTAL730APS_HIJUELAS As Integer = 0
        Dim TOTAL730APS_CALERA As Integer = 0
        Dim TOTAL730APS_LIGUA As Integer = 0
        Dim TOTAL730APS_NOGALES As Integer = 0
        Dim TOTAL730APS_PETORCA As Integer = 0
        Dim TOTAL730HOSP_LIMACHE As Integer = 0
        Dim TOTAL730HOSP_GERIATRICO_LMCHE As Integer = 0
        Dim TOTAL730HOSP_MODULAR_LMCHE As Integer = 0
        Dim TOTAL730HOSP_PENBLANCA As Integer = 0
        Dim TOTAL730HOSP_GUSTAVO_FRICKE As Integer = 0
        Dim TOTAL730HOSP_CALERA As Integer = 0
        Dim TOTAL730HOSP_PETORCA As Integer = 0
        Dim TOTAL730HOSP_QUILLOTA As Integer = 0
        Dim TOTAL730HOSP_CABILDO As Integer = 0
        Dim TOTAL730HOSP_LIGUA As Integer = 0
        Dim TOTAL730HOSP_QUINTERO As Integer = 0
        Dim TOTAL730OTROS As Integer = 0
        Dim TOTAL730TOTAL_EXTRA As Integer = 0

#End Region

        ' Filtro para Perfil Tiroideo
        Dim filteredList3 = groupedList.SelectMany(Function(group)
                                                       ' Verifica si hay algún ID_CODIGO_FONASA en prori_p_bioq en el grupo
                                                       Dim hasProriPTiro = group.Any(Function(item) priori_p_tiro.Contains(item.ID_CODIGO_FONASA))
                                                       ' Verifica si hay un ID_CODIGO_FONASA 664 en el grupo
                                                       Dim hasCodigoFonasa730 = group.Any(Function(item) item.ID_CODIGO_FONASA = 730)

                                                       If (hasCodigoFonasa730) Then
                                                           ' Atención abierta
                                                           TOTAL730CAE += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL730USM_HDIURNO += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209)
                                                           TOTAL730Personal += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217)
                                                           TOTAL730TOTAL_ABIERTA += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           ' Atencion cerrada
                                                           TOTAL730MQ1 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53)
                                                           TOTAL730MQ2 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52)
                                                           TOTAL730MQ3 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57)
                                                           TOTAL730UAPQ_PABELLON += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68)
                                                           TOTAL730PEDIATRIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55)
                                                           TOTAL730NEONATOLOGIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59)
                                                           TOTAL730UPC += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60)
                                                           TOTAL730UCI_A += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215)
                                                           TOTAL730UTI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214)
                                                           TOTAL730MATERNIDAD += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58)
                                                           TOTAL730CMA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54)
                                                           TOTAL730HOSP_DOCIMI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56)
                                                           TOTAL730UEA_HOSP += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221)
                                                           TOTAL730TOTAL_CERRADA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
                                                           item.ID_PROCEDENCIA = 60 Or
                                                           item.ID_PROCEDENCIA = 215 Or
                                                           item.ID_PROCEDENCIA = 214 Or
                                                           item.ID_PROCEDENCIA = 58 Or
                                                           item.ID_PROCEDENCIA = 54 Or
                                                           item.ID_PROCEDENCIA = 56 Or
                                                           item.ID_PROCEDENCIA = 221))
                                                           ' Atencion UE
                                                           TOTAL730UEA += group.Count(Function(item) item.ID_PROCEDENCIA = 66)
                                                           TOTAL730UEI += group.Count(Function(item) item.ID_PROCEDENCIA = 267)
                                                           TOTAL730SAUD += group.Count(Function(item) item.ID_PROCEDENCIA = 223)
                                                           TOTAL730TOTAL_UE += group.Count(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223)
                                                           ' Atención UEGO
                                                           TOTAL730UEGO += group.Count(Function(item) item.ID_PROCEDENCIA = 67)
                                                           ' Atención  Unidad de APOYO
                                                           TOTAL730ANATOMIA_PATO += group.Count(Function(item) item.ID_PROCEDENCIA = 164)
                                                           TOTAL730IMAGENOLOGIA += group.Count(Function(item) item.ID_PROCEDENCIA = 236)
                                                           TOTAL730TOTAL_UNIDAD_APOYO += group.Count(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236)
                                                           ' Atención EXTRA HOSPITALARIO
                                                           TOTAL730CESFAM_IVAN_MAN += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244)
                                                           TOTAL730CESFAM_AV_AC += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243)
                                                           TOTAL730CESFAM_QUILPUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207)
                                                           TOTAL730CESFAM_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245)
                                                           TOTAL730CONS_POMPEYA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212)
                                                           TOTAL730CECOSF_RETIRO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249)
                                                           TOTAL730CONS_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210)
                                                           TOTAL730CESFAM_VILLA_AL += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64)
                                                           TOTAL730CESFAM_AMERICAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62)
                                                           TOTAL730CONS_EDUARDO_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL730CESFAM_JUAN_BT += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61)
                                                           TOTAL730CONS_AGUILAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271)
                                                           TOTAL730SAPU_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL730CESFAM_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219)
                                                           TOTAL730CESFAM_OLMUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238)
                                                           TOTAL730APS_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254)
                                                           TOTAL730APS_HIJUELAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241)
                                                           TOTAL730APS_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239)
                                                           TOTAL730APS_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255)
                                                           TOTAL730APS_NOGALES += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240)
                                                           TOTAL730APS_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256)
                                                           TOTAL730HOSP_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228)
                                                           TOTAL730HOSP_GERIATRICO_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229)
                                                           TOTAL730HOSP_MODULAR_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232)
                                                           TOTAL730HOSP_PENBLANCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63)
                                                           TOTAL730HOSP_GUSTAVO_FRICKE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220)
                                                           TOTAL730HOSP_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233)
                                                           TOTAL730HOSP_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253)
                                                           TOTAL730HOSP_QUILLOTA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230)
                                                           TOTAL730HOSP_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252)
                                                           TOTAL730HOSP_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251)
                                                           TOTAL730HOSP_QUINTERO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227)
                                                           TOTAL730OTROS += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL730TOTAL_EXTRA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    item.ID_PROCEDENCIA = 244 Or
    item.ID_PROCEDENCIA = 243 Or
    item.ID_PROCEDENCIA = 207 Or
    item.ID_PROCEDENCIA = 245 Or
    item.ID_PROCEDENCIA = 212 Or
    item.ID_PROCEDENCIA = 249 Or
    item.ID_PROCEDENCIA = 210 Or
    item.ID_PROCEDENCIA = 64 Or
    item.ID_PROCEDENCIA = 62 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 61 Or
    item.ID_PROCEDENCIA = 271 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 219 Or
    item.ID_PROCEDENCIA = 238 Or
    item.ID_PROCEDENCIA = 254 Or
    item.ID_PROCEDENCIA = 241 Or
    item.ID_PROCEDENCIA = 239 Or
    item.ID_PROCEDENCIA = 255 Or
    item.ID_PROCEDENCIA = 240 Or
    item.ID_PROCEDENCIA = 256 Or
    item.ID_PROCEDENCIA = 228 Or
    item.ID_PROCEDENCIA = 229 Or
    item.ID_PROCEDENCIA = 232 Or
    item.ID_PROCEDENCIA = 63 Or
    item.ID_PROCEDENCIA = 220 Or
    item.ID_PROCEDENCIA = 233 Or
    item.ID_PROCEDENCIA = 253 Or
    item.ID_PROCEDENCIA = 230 Or
    item.ID_PROCEDENCIA = 252 Or
    item.ID_PROCEDENCIA = 251 Or
    item.ID_PROCEDENCIA = 227))
                                                       End If

                                                       ' Si hay códigos en prori_p_bioq y también 730, excluye 730
                                                       If hasProriPTiro AndAlso totalCodigo730Count Then
                                                           ' Cuenta las ocurrencias de 730 y acumúlalas en totalCodigo730Count
                                                           totalCodigo730Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 730)

                                                           ' Devuelve los elementos que están en prori_p_bioq excluyendo 730
                                                           Return group.Where(Function(item) priori_p_tiro.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 730).ToList()

                                                           ' Si solo existe 730 en la atención, contarlo y devolverlo
                                                       ElseIf hasCodigoFonasa730 AndAlso Not hasProriPTiro Then
                                                           totalCodigo730Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 730)
                                                           Return group.Where(Function(item) item.ID_CODIGO_FONASA = 730).ToList()

                                                           ' En otros casos, solo filtrar los códigos que están en priori_p_tiro
                                                       Else
                                                           Return group.Where(Function(item) priori_p_tiro.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                       End If
                                                   End Function).ToList()

#End Region


        Dim priori_p_hepa As New List(Of Integer) From {57, 94, 97, 136, 137}
        Dim soloCodigo941Count As Integer = 0

        ' Variable para contar las ocurrencias del código 664
        Dim totalCodigo941Count As Integer = 0


#Region "TOTALES 941"

        Dim TOTAL941CAE As Integer = 0
        Dim TOTAL941USM_HDIURNO As Integer = 0
        Dim TOTAL941Personal As Integer = 0
        Dim TOTAL941TOTAL_ABIERTA As Integer = 0
        Dim TOTAL941MQ1 As Integer = 0
        Dim TOTAL941MQ2 As Integer = 0
        Dim TOTAL941MQ3 As Integer = 0
        Dim TOTAL941UAPQ_PABELLON As Integer = 0
        Dim TOTAL941PEDIATRIA As Integer = 0
        Dim TOTAL941NEONATOLOGIA As Integer = 0
        Dim TOTAL941UPC As Integer = 0
        Dim TOTAL941UCI_A As Integer = 0
        Dim TOTAL941UTI As Integer = 0
        Dim TOTAL941MATERNIDAD As Integer = 0
        Dim TOTAL941CMA As Integer = 0
        Dim TOTAL941HOSP_DOCIMI As Integer = 0
        Dim TOTAL941UEA_HOSP As Integer = 0
        Dim TOTAL941TOTAL_CERRADA As Integer = 0
        Dim TOTAL941UEA As Integer = 0
        Dim TOTAL941UEI As Integer = 0
        Dim TOTAL941SAUD As Integer = 0
        Dim TOTAL941TOTAL_UE As Integer = 0
        Dim TOTAL941UEGO As Integer = 0
        Dim TOTAL941ANATOMIA_PATO As Integer = 0
        Dim TOTAL941IMAGENOLOGIA As Integer = 0
        Dim TOTAL941TOTAL_UNIDAD_APOYO As Integer = 0
        Dim TOTAL941CESFAM_IVAN_MAN As Integer = 0
        Dim TOTAL941CESFAM_AV_AC As Integer = 0
        Dim TOTAL941CESFAM_QUILPUE As Integer = 0
        Dim TOTAL941CESFAM_BELLOTO As Integer = 0
        Dim TOTAL941CONS_POMPEYA As Integer = 0
        Dim TOTAL941CECOSF_RETIRO As Integer = 0
        Dim TOTAL941CONS_BELLOTO As Integer = 0
        Dim TOTAL941CESFAM_VILLA_AL As Integer = 0
        Dim TOTAL941CESFAM_AMERICAS As Integer = 0
        Dim TOTAL941CONS_EDUARDO_FREI As Integer = 0
        Dim TOTAL941CESFAM_JUAN_BT As Integer = 0
        Dim TOTAL941CONS_AGUILAS As Integer = 0
        Dim TOTAL941SAPU_FREI As Integer = 0
        Dim TOTAL941CESFAM_LIMACHE As Integer = 0
        Dim TOTAL941CESFAM_OLMUE As Integer = 0
        Dim TOTAL941APS_CABILDO As Integer = 0
        Dim TOTAL941APS_HIJUELAS As Integer = 0
        Dim TOTAL941APS_CALERA As Integer = 0
        Dim TOTAL941APS_LIGUA As Integer = 0
        Dim TOTAL941APS_NOGALES As Integer = 0
        Dim TOTAL941APS_PETORCA As Integer = 0
        Dim TOTAL941HOSP_LIMACHE As Integer = 0
        Dim TOTAL941HOSP_GERIATRICO_LMCHE As Integer = 0
        Dim TOTAL941HOSP_MODULAR_LMCHE As Integer = 0
        Dim TOTAL941HOSP_PENBLANCA As Integer = 0
        Dim TOTAL941HOSP_GUSTAVO_FRICKE As Integer = 0
        Dim TOTAL941HOSP_CALERA As Integer = 0
        Dim TOTAL941HOSP_PETORCA As Integer = 0
        Dim TOTAL941HOSP_QUILLOTA As Integer = 0
        Dim TOTAL941HOSP_CABILDO As Integer = 0
        Dim TOTAL941HOSP_LIGUA As Integer = 0
        Dim TOTAL941HOSP_QUINTERO As Integer = 0
        Dim TOTAL941OTROS As Integer = 0
        Dim TOTAL941TOTAL_EXTRA As Integer = 0
#End Region

        Dim perfilesDuplicados As Integer = 0

        Dim filteredList4 = groupedList.SelectMany(Function(group)
                                                       ' Bandera para evitar contar más de una vez por grupo
                                                       Dim countedForHepa As Boolean = False
                                                       ' Verifica si hay algún ID_CODIGO_FONASA en priori_p_hepa en el grupo
                                                       Dim hasProriPHepa = group.Any(Function(item) priori_p_hepa.Contains(item.ID_CODIGO_FONASA))
                                                       ' Verifica si hay un ID_CODIGO_FONASA 664 en el grupo
                                                       Dim hasCodigoFonasa941 = group.Any(Function(item) item.ID_CODIGO_FONASA = 941)
                                                       Dim hasCodigoFonasa664 = group.Any(Function(item) item.ID_CODIGO_FONASA = 664)
                                                       If (hasCodigoFonasa941) Then
#Region "TOTAL 941"
                                                           ' Atención abierta
                                                           TOTAL941CAE += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL941USM_HDIURNO += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209)
                                                           TOTAL941Personal += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217)
                                                           TOTAL941TOTAL_ABIERTA += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           ' Atencion cerrada
                                                           TOTAL941MQ1 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53)
                                                           TOTAL941MQ2 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52)
                                                           TOTAL941MQ3 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57)
                                                           TOTAL941UAPQ_PABELLON += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68)
                                                           TOTAL941PEDIATRIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55)
                                                           TOTAL941NEONATOLOGIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59)
                                                           TOTAL941UPC += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60)
                                                           TOTAL941UCI_A += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215)
                                                           TOTAL941UTI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214)
                                                           TOTAL941MATERNIDAD += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58)
                                                           TOTAL941CMA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54)
                                                           TOTAL941HOSP_DOCIMI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56)
                                                           TOTAL941UEA_HOSP += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221)
                                                           TOTAL941TOTAL_CERRADA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
                                                           item.ID_PROCEDENCIA = 60 Or
                                                           item.ID_PROCEDENCIA = 215 Or
                                                           item.ID_PROCEDENCIA = 214 Or
                                                           item.ID_PROCEDENCIA = 58 Or
                                                           item.ID_PROCEDENCIA = 54 Or
                                                           item.ID_PROCEDENCIA = 56 Or
                                                           item.ID_PROCEDENCIA = 221))
                                                           ' Atencion UE
                                                           TOTAL941UEA += group.Count(Function(item) item.ID_PROCEDENCIA = 66)
                                                           TOTAL941UEI += group.Count(Function(item) item.ID_PROCEDENCIA = 267)
                                                           TOTAL941SAUD += group.Count(Function(item) item.ID_PROCEDENCIA = 223)
                                                           TOTAL941TOTAL_UE += group.Count(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223)
                                                           ' Atención UEGO
                                                           TOTAL941UEGO += group.Count(Function(item) item.ID_PROCEDENCIA = 67)
                                                           ' Atención  Unidad de APOYO
                                                           TOTAL941ANATOMIA_PATO += group.Count(Function(item) item.ID_PROCEDENCIA = 164)
                                                           TOTAL941IMAGENOLOGIA += group.Count(Function(item) item.ID_PROCEDENCIA = 236)
                                                           TOTAL941TOTAL_UNIDAD_APOYO += group.Count(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236)
                                                           ' Atención EXTRA HOSPITALARIO
                                                           TOTAL941CESFAM_IVAN_MAN += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244)
                                                           TOTAL941CESFAM_AV_AC += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243)
                                                           TOTAL941CESFAM_QUILPUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207)
                                                           TOTAL941CESFAM_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245)
                                                           TOTAL941CONS_POMPEYA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212)
                                                           TOTAL941CECOSF_RETIRO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249)
                                                           TOTAL941CONS_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210)
                                                           TOTAL941CESFAM_VILLA_AL += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64)
                                                           TOTAL941CESFAM_AMERICAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62)
                                                           TOTAL941CONS_EDUARDO_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL941CESFAM_JUAN_BT += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61)
                                                           TOTAL941CONS_AGUILAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271)
                                                           TOTAL941SAPU_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL941CESFAM_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219)
                                                           TOTAL941CESFAM_OLMUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238)
                                                           TOTAL941APS_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254)
                                                           TOTAL941APS_HIJUELAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241)
                                                           TOTAL941APS_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239)
                                                           TOTAL941APS_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255)
                                                           TOTAL941APS_NOGALES += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240)
                                                           TOTAL941APS_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256)
                                                           TOTAL941HOSP_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228)
                                                           TOTAL941HOSP_GERIATRICO_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229)
                                                           TOTAL941HOSP_MODULAR_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232)
                                                           TOTAL941HOSP_PENBLANCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63)
                                                           TOTAL941HOSP_GUSTAVO_FRICKE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220)
                                                           TOTAL941HOSP_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233)
                                                           TOTAL941HOSP_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253)
                                                           TOTAL941HOSP_QUILLOTA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230)
                                                           TOTAL941HOSP_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252)
                                                           TOTAL941HOSP_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251)
                                                           TOTAL941HOSP_QUINTERO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227)
                                                           TOTAL941OTROS += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL941TOTAL_EXTRA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    item.ID_PROCEDENCIA = 244 Or
    item.ID_PROCEDENCIA = 243 Or
    item.ID_PROCEDENCIA = 207 Or
    item.ID_PROCEDENCIA = 245 Or
    item.ID_PROCEDENCIA = 212 Or
    item.ID_PROCEDENCIA = 249 Or
    item.ID_PROCEDENCIA = 210 Or
    item.ID_PROCEDENCIA = 64 Or
    item.ID_PROCEDENCIA = 62 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 61 Or
    item.ID_PROCEDENCIA = 271 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 219 Or
    item.ID_PROCEDENCIA = 238 Or
    item.ID_PROCEDENCIA = 254 Or
    item.ID_PROCEDENCIA = 241 Or
    item.ID_PROCEDENCIA = 239 Or
    item.ID_PROCEDENCIA = 255 Or
    item.ID_PROCEDENCIA = 240 Or
    item.ID_PROCEDENCIA = 256 Or
    item.ID_PROCEDENCIA = 228 Or
    item.ID_PROCEDENCIA = 229 Or
    item.ID_PROCEDENCIA = 232 Or
    item.ID_PROCEDENCIA = 63 Or
    item.ID_PROCEDENCIA = 220 Or
    item.ID_PROCEDENCIA = 233 Or
    item.ID_PROCEDENCIA = 253 Or
    item.ID_PROCEDENCIA = 230 Or
    item.ID_PROCEDENCIA = 252 Or
    item.ID_PROCEDENCIA = 251 Or
    item.ID_PROCEDENCIA = 227))
#End Region
                                                       End If

                                                       ' Si hay códigos en priori_p_hepa y también hay 941, excluye 664
                                                       If hasProriPHepa AndAlso hasCodigoFonasa941 Then
                                                           ' Cuenta las ocurrencias de 941 y acumúlalas en totalCodigo941Count
                                                           totalCodigo941Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 941)

                                                           ' Excluye 664 y 941, devolviendo solo los que están en prori_p_bioq
                                                           'If hasCodigoFonasa664 AndAlso hasCodigoFonasa941 Then
                                                           '    Dim uniqueInBioq As List(Of Integer) = priori_p_bioq.Except(priori_p_hepa_test).ToList()
                                                           '    Return group.Where(Function(item) uniqueInBioq.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 664 AndAlso item.ID_CODIGO_FONASA <> 941).ToList()
                                                           'End If
                                                           ' Devuelve los elementos que están en priori_p_hepa excluyendo 664
                                                           Return group.Where(Function(item) priori_p_bioq.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 941).ToList()

                                                           ' Si solo existe 941 en la atención, contarlo y devolverlo
                                                       ElseIf hasCodigoFonasa941 AndAlso Not hasProriPHepa Then
                                                           totalCodigo941Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 941)
                                                           Return group.Where(Function(item) item.ID_CODIGO_FONASA = 941).ToList()

                                                           ' En otros casos, solo filtrar los códigos que están en priori_p_hepa
                                                       Else
                                                           Return group.Where(Function(item) priori_p_hepa.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                       End If
                                                   End Function).ToList()



        Dim priori_p_lipi As New List(Of Integer) From {138, 140, 141}
        Dim soloCodigo76Count As Integer = 0

        ' Variable para contar las ocurrencias del código 76
        Dim totalCodigo76Count As Integer = 0

#Region "TOTALES 76"

        Dim TOTAL76CAE As Integer = 0
        Dim TOTAL76USM_HDIURNO As Integer = 0
        Dim TOTAL76Personal As Integer = 0
        Dim TOTAL76TOTAL_ABIERTA As Integer = 0
        Dim TOTAL76MQ1 As Integer = 0
        Dim TOTAL76MQ2 As Integer = 0
        Dim TOTAL76MQ3 As Integer = 0
        Dim TOTAL76UAPQ_PABELLON As Integer = 0
        Dim TOTAL76PEDIATRIA As Integer = 0
        Dim TOTAL76NEONATOLOGIA As Integer = 0
        Dim TOTAL76UPC As Integer = 0
        Dim TOTAL76UCI_A As Integer = 0
        Dim TOTAL76UTI As Integer = 0
        Dim TOTAL76MATERNIDAD As Integer = 0
        Dim TOTAL76CMA As Integer = 0
        Dim TOTAL76HOSP_DOCIMI As Integer = 0
        Dim TOTAL76UEA_HOSP As Integer = 0
        Dim TOTAL76TOTAL_CERRADA As Integer = 0
        Dim TOTAL76UEA As Integer = 0
        Dim TOTAL76UEI As Integer = 0
        Dim TOTAL76SAUD As Integer = 0
        Dim TOTAL76TOTAL_UE As Integer = 0
        Dim TOTAL76UEGO As Integer = 0
        Dim TOTAL76ANATOMIA_PATO As Integer = 0
        Dim TOTAL76IMAGENOLOGIA As Integer = 0
        Dim TOTAL76TOTAL_UNIDAD_APOYO As Integer = 0
        Dim TOTAL76CESFAM_IVAN_MAN As Integer = 0
        Dim TOTAL76CESFAM_AV_AC As Integer = 0
        Dim TOTAL76CESFAM_QUILPUE As Integer = 0
        Dim TOTAL76CESFAM_BELLOTO As Integer = 0
        Dim TOTAL76CONS_POMPEYA As Integer = 0
        Dim TOTAL76CECOSF_RETIRO As Integer = 0
        Dim TOTAL76CONS_BELLOTO As Integer = 0
        Dim TOTAL76CESFAM_VILLA_AL As Integer = 0
        Dim TOTAL76CESFAM_AMERICAS As Integer = 0
        Dim TOTAL76CONS_EDUARDO_FREI As Integer = 0
        Dim TOTAL76CESFAM_JUAN_BT As Integer = 0
        Dim TOTAL76CONS_AGUILAS As Integer = 0
        Dim TOTAL76SAPU_FREI As Integer = 0
        Dim TOTAL76CESFAM_LIMACHE As Integer = 0
        Dim TOTAL76CESFAM_OLMUE As Integer = 0
        Dim TOTAL76APS_CABILDO As Integer = 0
        Dim TOTAL76APS_HIJUELAS As Integer = 0
        Dim TOTAL76APS_CALERA As Integer = 0
        Dim TOTAL76APS_LIGUA As Integer = 0
        Dim TOTAL76APS_NOGALES As Integer = 0
        Dim TOTAL76APS_PETORCA As Integer = 0
        Dim TOTAL76HOSP_LIMACHE As Integer = 0
        Dim TOTAL76HOSP_GERIATRICO_LMCHE As Integer = 0
        Dim TOTAL76HOSP_MODULAR_LMCHE As Integer = 0
        Dim TOTAL76HOSP_PENBLANCA As Integer = 0
        Dim TOTAL76HOSP_GUSTAVO_FRICKE As Integer = 0
        Dim TOTAL76HOSP_CALERA As Integer = 0
        Dim TOTAL76HOSP_PETORCA As Integer = 0
        Dim TOTAL76HOSP_QUILLOTA As Integer = 0
        Dim TOTAL76HOSP_CABILDO As Integer = 0
        Dim TOTAL76HOSP_LIGUA As Integer = 0
        Dim TOTAL76HOSP_QUINTERO As Integer = 0
        Dim TOTAL76OTROS As Integer = 0
        Dim TOTAL76TOTAL_EXTRA As Integer = 0
#End Region

        ' Filtro para Perfil Lipidico
        Dim filteredList5 = groupedList.SelectMany(Function(group)
                                                       ' Verifica si hay algún ID_CODIGO_FONASA en priori_p_lipi en el grupo
                                                       Dim hasProriPLipi = group.Any(Function(item) priori_p_lipi.Contains(item.ID_CODIGO_FONASA))
                                                       ' Verifica si hay un ID_CODIGO_FONASA 76 en el grupo
                                                       Dim hasCodigoFonasa76 = group.Any(Function(item) item.ID_CODIGO_FONASA = 76)

                                                       If (hasCodigoFonasa76) Then
                                                           ' Atención abierta
                                                           TOTAL76CAE += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL76USM_HDIURNO += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209)
                                                           TOTAL76Personal += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217)
                                                           TOTAL76TOTAL_ABIERTA += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           ' Atencion cerrada
                                                           TOTAL76MQ1 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53)
                                                           TOTAL76MQ2 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52)
                                                           TOTAL76MQ3 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57)
                                                           TOTAL76UAPQ_PABELLON += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68)
                                                           TOTAL76PEDIATRIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55)
                                                           TOTAL76NEONATOLOGIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59)
                                                           TOTAL76UPC += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60)
                                                           TOTAL76UCI_A += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215)
                                                           TOTAL76UTI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214)
                                                           TOTAL76MATERNIDAD += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58)
                                                           TOTAL76CMA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54)
                                                           TOTAL76HOSP_DOCIMI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56)
                                                           TOTAL76UEA_HOSP += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221)
                                                           TOTAL76TOTAL_CERRADA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
                                                           item.ID_PROCEDENCIA = 60 Or
                                                           item.ID_PROCEDENCIA = 215 Or
                                                           item.ID_PROCEDENCIA = 214 Or
                                                           item.ID_PROCEDENCIA = 58 Or
                                                           item.ID_PROCEDENCIA = 54 Or
                                                           item.ID_PROCEDENCIA = 56 Or
                                                           item.ID_PROCEDENCIA = 221))
                                                           ' Atencion UE
                                                           TOTAL76UEA += group.Count(Function(item) item.ID_PROCEDENCIA = 66)
                                                           TOTAL76UEI += group.Count(Function(item) item.ID_PROCEDENCIA = 267)
                                                           TOTAL76SAUD += group.Count(Function(item) item.ID_PROCEDENCIA = 223)
                                                           TOTAL76TOTAL_UE += group.Count(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223)
                                                           ' Atención UEGO
                                                           TOTAL76UEGO += group.Count(Function(item) item.ID_PROCEDENCIA = 67)
                                                           ' Atención  Unidad de APOYO
                                                           TOTAL76ANATOMIA_PATO += group.Count(Function(item) item.ID_PROCEDENCIA = 164)
                                                           TOTAL76IMAGENOLOGIA += group.Count(Function(item) item.ID_PROCEDENCIA = 236)
                                                           TOTAL76TOTAL_UNIDAD_APOYO += group.Count(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236)
                                                           ' Atención EXTRA HOSPITALARIO
                                                           TOTAL76CESFAM_IVAN_MAN += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244)
                                                           TOTAL76CESFAM_AV_AC += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243)
                                                           TOTAL76CESFAM_QUILPUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207)
                                                           TOTAL76CESFAM_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245)
                                                           TOTAL76CONS_POMPEYA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212)
                                                           TOTAL76CECOSF_RETIRO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249)
                                                           TOTAL76CONS_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210)
                                                           TOTAL76CESFAM_VILLA_AL += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64)
                                                           TOTAL76CESFAM_AMERICAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62)
                                                           TOTAL76CONS_EDUARDO_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL76CESFAM_JUAN_BT += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61)
                                                           TOTAL76CONS_AGUILAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271)
                                                           TOTAL76SAPU_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL76CESFAM_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219)
                                                           TOTAL76CESFAM_OLMUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238)
                                                           TOTAL76APS_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254)
                                                           TOTAL76APS_HIJUELAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241)
                                                           TOTAL76APS_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239)
                                                           TOTAL76APS_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255)
                                                           TOTAL76APS_NOGALES += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240)
                                                           TOTAL76APS_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256)
                                                           TOTAL76HOSP_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228)
                                                           TOTAL76HOSP_GERIATRICO_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229)
                                                           TOTAL76HOSP_MODULAR_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232)
                                                           TOTAL76HOSP_PENBLANCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63)
                                                           TOTAL76HOSP_GUSTAVO_FRICKE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220)
                                                           TOTAL76HOSP_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233)
                                                           TOTAL76HOSP_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253)
                                                           TOTAL76HOSP_QUILLOTA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230)
                                                           TOTAL76HOSP_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252)
                                                           TOTAL76HOSP_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251)
                                                           TOTAL76HOSP_QUINTERO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227)
                                                           TOTAL76OTROS += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL76TOTAL_EXTRA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    item.ID_PROCEDENCIA = 244 Or
    item.ID_PROCEDENCIA = 243 Or
    item.ID_PROCEDENCIA = 207 Or
    item.ID_PROCEDENCIA = 245 Or
    item.ID_PROCEDENCIA = 212 Or
    item.ID_PROCEDENCIA = 249 Or
    item.ID_PROCEDENCIA = 210 Or
    item.ID_PROCEDENCIA = 64 Or
    item.ID_PROCEDENCIA = 62 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 61 Or
    item.ID_PROCEDENCIA = 271 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 219 Or
    item.ID_PROCEDENCIA = 238 Or
    item.ID_PROCEDENCIA = 254 Or
    item.ID_PROCEDENCIA = 241 Or
    item.ID_PROCEDENCIA = 239 Or
    item.ID_PROCEDENCIA = 255 Or
    item.ID_PROCEDENCIA = 240 Or
    item.ID_PROCEDENCIA = 256 Or
    item.ID_PROCEDENCIA = 228 Or
    item.ID_PROCEDENCIA = 229 Or
    item.ID_PROCEDENCIA = 232 Or
    item.ID_PROCEDENCIA = 63 Or
    item.ID_PROCEDENCIA = 220 Or
    item.ID_PROCEDENCIA = 233 Or
    item.ID_PROCEDENCIA = 253 Or
    item.ID_PROCEDENCIA = 230 Or
    item.ID_PROCEDENCIA = 252 Or
    item.ID_PROCEDENCIA = 251 Or
    item.ID_PROCEDENCIA = 227))
                                                       End If
                                                       ' Si hay códigos en priori_p_lipi y también 76, excluye 76
                                                       If hasProriPLipi AndAlso totalCodigo76Count Then
                                                           ' Cuenta las ocurrencias de 76 y acumúlalas en totalCodigo76Count
                                                           totalCodigo76Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 76)

                                                           ' Devuelve los elementos que están en priori_p_lipi excluyendo 76
                                                           Return group.Where(Function(item) priori_p_hepa.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 76).ToList()

                                                           ' Si solo existe 76 en la atención, contarlo y devolverlo
                                                       ElseIf hasCodigoFonasa76 AndAlso Not hasProriPLipi Then
                                                           totalCodigo76Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 76)
                                                           Return group.Where(Function(item) item.ID_CODIGO_FONASA = 76).ToList()

                                                           ' En otros casos, solo filtrar los códigos que están en priori_p_hepa
                                                       Else
                                                           Return group.Where(Function(item) priori_p_hepa.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                       End If
                                                   End Function).ToList()


        Dim priori_p_basico As New List(Of Integer) From {66, 130}
        Dim soloCodigo731Count As Integer = 0

        ' Variable para contar las ocurrencias del código 731
        Dim totalCodigo731Count As Integer = 0
#Region "TOTAL 731"

        Dim TOTAL731CAE As Integer = 0
        Dim TOTAL731USM_HDIURNO As Integer = 0
        Dim TOTAL731Personal As Integer = 0
        Dim TOTAL731TOTAL_ABIERTA As Integer = 0
        Dim TOTAL731MQ1 As Integer = 0
        Dim TOTAL731MQ2 As Integer = 0
        Dim TOTAL731MQ3 As Integer = 0
        Dim TOTAL731UAPQ_PABELLON As Integer = 0
        Dim TOTAL731PEDIATRIA As Integer = 0
        Dim TOTAL731NEONATOLOGIA As Integer = 0
        Dim TOTAL731UPC As Integer = 0
        Dim TOTAL731UCI_A As Integer = 0
        Dim TOTAL731UTI As Integer = 0
        Dim TOTAL731MATERNIDAD As Integer = 0
        Dim TOTAL731CMA As Integer = 0
        Dim TOTAL731HOSP_DOCIMI As Integer = 0
        Dim TOTAL731UEA_HOSP As Integer = 0
        Dim TOTAL731TOTAL_CERRADA As Integer = 0
        Dim TOTAL731UEA As Integer = 0
        Dim TOTAL731UEI As Integer = 0
        Dim TOTAL731SAUD As Integer = 0
        Dim TOTAL731TOTAL_UE As Integer = 0
        Dim TOTAL731UEGO As Integer = 0
        Dim TOTAL731ANATOMIA_PATO As Integer = 0
        Dim TOTAL731IMAGENOLOGIA As Integer = 0
        Dim TOTAL731TOTAL_UNIDAD_APOYO As Integer = 0
        Dim TOTAL731CESFAM_IVAN_MAN As Integer = 0
        Dim TOTAL731CESFAM_AV_AC As Integer = 0
        Dim TOTAL731CESFAM_QUILPUE As Integer = 0
        Dim TOTAL731CESFAM_BELLOTO As Integer = 0
        Dim TOTAL731CONS_POMPEYA As Integer = 0
        Dim TOTAL731CECOSF_RETIRO As Integer = 0
        Dim TOTAL731CONS_BELLOTO As Integer = 0
        Dim TOTAL731CESFAM_VILLA_AL As Integer = 0
        Dim TOTAL731CESFAM_AMERICAS As Integer = 0
        Dim TOTAL731CONS_EDUARDO_FREI As Integer = 0
        Dim TOTAL731CESFAM_JUAN_BT As Integer = 0
        Dim TOTAL731CONS_AGUILAS As Integer = 0
        Dim TOTAL731SAPU_FREI As Integer = 0
        Dim TOTAL731CESFAM_LIMACHE As Integer = 0
        Dim TOTAL731CESFAM_OLMUE As Integer = 0
        Dim TOTAL731APS_CABILDO As Integer = 0
        Dim TOTAL731APS_HIJUELAS As Integer = 0
        Dim TOTAL731APS_CALERA As Integer = 0
        Dim TOTAL731APS_LIGUA As Integer = 0
        Dim TOTAL731APS_NOGALES As Integer = 0
        Dim TOTAL731APS_PETORCA As Integer = 0
        Dim TOTAL731HOSP_LIMACHE As Integer = 0
        Dim TOTAL731HOSP_GERIATRICO_LMCHE As Integer = 0
        Dim TOTAL731HOSP_MODULAR_LMCHE As Integer = 0
        Dim TOTAL731HOSP_PENBLANCA As Integer = 0
        Dim TOTAL731HOSP_GUSTAVO_FRICKE As Integer = 0
        Dim TOTAL731HOSP_CALERA As Integer = 0
        Dim TOTAL731HOSP_PETORCA As Integer = 0
        Dim TOTAL731HOSP_QUILLOTA As Integer = 0
        Dim TOTAL731HOSP_CABILDO As Integer = 0
        Dim TOTAL731HOSP_LIGUA As Integer = 0
        Dim TOTAL731HOSP_QUINTERO As Integer = 0
        Dim TOTAL731OTROS As Integer = 0
        Dim TOTAL731TOTAL_EXTRA As Integer = 0
#End Region

        ' Filtro para Perfil Basico
        Dim filteredList6 = groupedList.SelectMany(Function(group)
                                                       ' Verifica si hay algún ID_CODIGO_FONASA en priori_p_basico en el grupo
                                                       Dim hasProriPBasico = group.Any(Function(item) priori_p_basico.Contains(item.ID_CODIGO_FONASA))
                                                       ' Verifica si hay un ID_CODIGO_FONASA 76 en el grupo
                                                       Dim hasCodigoFonasa731 = group.Any(Function(item) item.ID_CODIGO_FONASA = 731)

                                                       If (hasCodigoFonasa731) Then
                                                           ' Atención abierta
                                                           TOTAL731CAE += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL731USM_HDIURNO += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209)
                                                           TOTAL731Personal += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217)
                                                           TOTAL731TOTAL_ABIERTA += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           ' Atencion cerrada
                                                           TOTAL731MQ1 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53)
                                                           TOTAL731MQ2 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52)
                                                           TOTAL731MQ3 += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57)
                                                           TOTAL731UAPQ_PABELLON += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68)
                                                           TOTAL731PEDIATRIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55)
                                                           TOTAL731NEONATOLOGIA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59)
                                                           TOTAL731UPC += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60)
                                                           TOTAL731UCI_A += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215)
                                                           TOTAL731UTI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214)
                                                           TOTAL731MATERNIDAD += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58)
                                                           TOTAL731CMA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54)
                                                           TOTAL731HOSP_DOCIMI += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56)
                                                           TOTAL731UEA_HOSP += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221)
                                                           TOTAL731TOTAL_CERRADA += group.Count(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
                                                           item.ID_PROCEDENCIA = 60 Or
                                                           item.ID_PROCEDENCIA = 215 Or
                                                           item.ID_PROCEDENCIA = 214 Or
                                                           item.ID_PROCEDENCIA = 58 Or
                                                           item.ID_PROCEDENCIA = 54 Or
                                                           item.ID_PROCEDENCIA = 56 Or
                                                           item.ID_PROCEDENCIA = 221))
                                                           ' Atencion UE
                                                           TOTAL731UEA += group.Count(Function(item) item.ID_PROCEDENCIA = 66)
                                                           TOTAL731UEI += group.Count(Function(item) item.ID_PROCEDENCIA = 267)
                                                           TOTAL731SAUD += group.Count(Function(item) item.ID_PROCEDENCIA = 223)
                                                           TOTAL731TOTAL_UE += group.Count(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223)
                                                           ' Atención UEGO
                                                           TOTAL731UEGO += group.Count(Function(item) item.ID_PROCEDENCIA = 67)
                                                           ' Atención  Unidad de APOYO
                                                           TOTAL731ANATOMIA_PATO += group.Count(Function(item) item.ID_PROCEDENCIA = 164)
                                                           TOTAL731IMAGENOLOGIA += group.Count(Function(item) item.ID_PROCEDENCIA = 236)
                                                           TOTAL731TOTAL_UNIDAD_APOYO += group.Count(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236)
                                                           ' Atención EXTRA HOSPITALARIO
                                                           TOTAL731CESFAM_IVAN_MAN += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244)
                                                           TOTAL731CESFAM_AV_AC += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243)
                                                           TOTAL731CESFAM_QUILPUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207)
                                                           TOTAL731CESFAM_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245)
                                                           TOTAL731CONS_POMPEYA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212)
                                                           TOTAL731CECOSF_RETIRO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249)
                                                           TOTAL731CONS_BELLOTO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210)
                                                           TOTAL731CESFAM_VILLA_AL += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64)
                                                           TOTAL731CESFAM_AMERICAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62)
                                                           TOTAL731CONS_EDUARDO_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL731CESFAM_JUAN_BT += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61)
                                                           TOTAL731CONS_AGUILAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271)
                                                           TOTAL731SAPU_FREI += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213)
                                                           TOTAL731CESFAM_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219)
                                                           TOTAL731CESFAM_OLMUE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238)
                                                           TOTAL731APS_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254)
                                                           TOTAL731APS_HIJUELAS += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241)
                                                           TOTAL731APS_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239)
                                                           TOTAL731APS_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255)
                                                           TOTAL731APS_NOGALES += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240)
                                                           TOTAL731APS_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256)
                                                           TOTAL731HOSP_LIMACHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228)
                                                           TOTAL731HOSP_GERIATRICO_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229)
                                                           TOTAL731HOSP_MODULAR_LMCHE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232)
                                                           TOTAL731HOSP_PENBLANCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63)
                                                           TOTAL731HOSP_GUSTAVO_FRICKE += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220)
                                                           TOTAL731HOSP_CALERA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233)
                                                           TOTAL731HOSP_PETORCA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253)
                                                           TOTAL731HOSP_QUILLOTA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230)
                                                           TOTAL731HOSP_CABILDO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252)
                                                           TOTAL731HOSP_LIGUA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251)
                                                           TOTAL731HOSP_QUINTERO += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227)
                                                           TOTAL731OTROS += group.Count(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216))
                                                           TOTAL731TOTAL_EXTRA += group.Count(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    item.ID_PROCEDENCIA = 244 Or
    item.ID_PROCEDENCIA = 243 Or
    item.ID_PROCEDENCIA = 207 Or
    item.ID_PROCEDENCIA = 245 Or
    item.ID_PROCEDENCIA = 212 Or
    item.ID_PROCEDENCIA = 249 Or
    item.ID_PROCEDENCIA = 210 Or
    item.ID_PROCEDENCIA = 64 Or
    item.ID_PROCEDENCIA = 62 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 61 Or
    item.ID_PROCEDENCIA = 271 Or
    item.ID_PROCEDENCIA = 213 Or
    item.ID_PROCEDENCIA = 219 Or
    item.ID_PROCEDENCIA = 238 Or
    item.ID_PROCEDENCIA = 254 Or
    item.ID_PROCEDENCIA = 241 Or
    item.ID_PROCEDENCIA = 239 Or
    item.ID_PROCEDENCIA = 255 Or
    item.ID_PROCEDENCIA = 240 Or
    item.ID_PROCEDENCIA = 256 Or
    item.ID_PROCEDENCIA = 228 Or
    item.ID_PROCEDENCIA = 229 Or
    item.ID_PROCEDENCIA = 232 Or
    item.ID_PROCEDENCIA = 63 Or
    item.ID_PROCEDENCIA = 220 Or
    item.ID_PROCEDENCIA = 233 Or
    item.ID_PROCEDENCIA = 253 Or
    item.ID_PROCEDENCIA = 230 Or
    item.ID_PROCEDENCIA = 252 Or
    item.ID_PROCEDENCIA = 251 Or
    item.ID_PROCEDENCIA = 227))
                                                       End If
                                                       ' Si hay códigos en priori_p_lipi y también 731, excluye 731
                                                       If hasProriPBasico AndAlso totalCodigo731Count Then
                                                           ' Cuenta las ocurrencias de 76 y acumúlalas en totalCodigo731Count
                                                           totalCodigo731Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 731)

                                                           ' Devuelve los elementos que están en priori_p_lipi excluyendo 731
                                                           Return group.Where(Function(item) priori_p_basico.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> 731).ToList()

                                                           ' Si solo existe 731 en la atención, contarlo y devolverlo
                                                       ElseIf hasCodigoFonasa731 AndAlso Not hasProriPBasico Then
                                                           totalCodigo731Count += group.Count(Function(item) item.ID_CODIGO_FONASA = 731)
                                                           Return group.Where(Function(item) item.ID_CODIGO_FONASA = 731).ToList()

                                                           ' En otros casos, solo filtrar los códigos que están en priori_p_basico
                                                       Else
                                                           Return group.Where(Function(item) priori_p_basico.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                       End If
                                                   End Function).ToList()

        Dim List_Rel_Rem As List(Of E_IRIS_WEBF_BUSCA_REL_PRU_REM) = N_REM.IRIS_WEBF_BUSCA_REL_PRU_REM()

        Dim List_Rem As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA)

        Dim groupedData = List_Rem.GroupBy(Function(item) New With {Key .CF_COD_IRIS = item.CF_COD_IRIS, Key .ID_SECC_REM = item.ID_SECC_REM})

        ' Crear una nueva lista para los resultados agrupados y sumados
        Dim result As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)()

        For Each group In groupedData

            ' Crear un nuevo objeto E_IRIS_WEBF_BUSCA_CANT_EXAMENES para almacenar los resultados sumados
            Dim summary As New E_IRIS_WEBF_BUSCA_CANT_EXAMENES() With {
                 .ID_FONASA_REM_HOSP = group.First().ID_FONASA_REM_HOSP,
                 .ID_CODIGO_FONASA = group.First().ID_CODIGO_FONASA,
                 .CF_DESC_HOSP = group.First().CF_DESC_HOSP,
                 .CF_COD_IRIS = group.Key.CF_COD_IRIS,
                 .ID_SECC_REM = group.Key.ID_SECC_REM,
                 .SECC_REM_DESC = group.First().SECC_REM_DESC,
                 .ID_AREA_REM = group.First().ID_AREA_REM,
                 .AREA_DESC = group.First().AREA_DESC,
                 .CANTIDAD = group.Sum(Function(item) item.CANTIDAD),
                 .CAE = group.Sum(Function(item) item.CAE),
                 .USM_HDIURNO = group.Sum(Function(item) item.USM_HDIURNO),
                 .PERSONAL = group.Sum(Function(item) item.PERSONAL),
                 .TOTAL_ABIERTA = group.Sum(Function(item) item.TOTAL_ABIERTA),
                 .MQ1 = group.Sum(Function(item) item.MQ1),
                 .MQ2 = group.Sum(Function(item) item.MQ2),
                 .MQ3 = group.Sum(Function(item) item.MQ3),
                 .UAPQ_PABELLON = group.Sum(Function(item) item.UAPQ_PABELLON),
                 .PEDIATRIA = group.Sum(Function(item) item.PEDIATRIA),
                 .NEONATOLOGIA = group.Sum(Function(item) item.NEONATOLOGIA),
                 .UPC = group.Sum(Function(item) item.UPC),
                 .UCI_A = group.Sum(Function(item) item.UCI_A),
                 .UTI = group.Sum(Function(item) item.UTI),
                 .MATERNIDAD = group.Sum(Function(item) item.MATERNIDAD),
                 .CMA = group.Sum(Function(item) item.CMA),
                 .HOSP_DOCIMI = group.Sum(Function(item) item.HOSP_DOCIMI),
                 .UEA_HOSP = group.Sum(Function(item) item.UEA_HOSP),
                 .TOTAL_CERRADA = group.Sum(Function(item) item.TOTAL_CERRADA),
                 .UEA = group.Sum(Function(item) item.UEA),
                 .UEI = group.Sum(Function(item) item.UEI),
                 .SAUD = group.Sum(Function(item) item.SAUD),
                 .TOTAL_UE = group.Sum(Function(item) item.TOTAL_UE),
                 .UEGO = group.Sum(Function(item) item.UEGO),
                 .ANATOMIA_PATO = group.Sum(Function(item) item.ANATOMIA_PATO),
                 .IMAGENOLOGIA = group.Sum(Function(item) item.IMAGENOLOGIA),
                 .TOTAL_UNIDAD_APOYO = group.Sum(Function(item) item.TOTAL_UNIDAD_APOYO),
                 .CESFAM_IVAN_MAN = group.Sum(Function(item) item.CESFAM_IVAN_MAN),
                 .CESFAM_AV_AC = group.Sum(Function(item) item.CESFAM_AV_AC),
                 .CESFAM_QUILPUE = group.Sum(Function(item) item.CESFAM_QUILPUE),
                 .CESFAM_BELLOTO = group.Sum(Function(item) item.CESFAM_BELLOTO),
                 .CONS_POMPEYA = group.Sum(Function(item) item.CONS_POMPEYA),
                 .CECOSF_RETIRO = group.Sum(Function(item) item.CECOSF_RETIRO),
                 .CONS_BELLOTO = group.Sum(Function(item) item.CONS_BELLOTO),
                 .CESFAM_VILLA_AL = group.Sum(Function(item) item.CESFAM_VILLA_AL),
                 .CESFAM_AMERICAS = group.Sum(Function(item) item.CESFAM_AMERICAS),
                 .CONS_EDUARDO_FREI = group.Sum(Function(item) item.CONS_EDUARDO_FREI),
                 .CESFAM_JUAN_BT = group.Sum(Function(item) item.CESFAM_JUAN_BT),
                 .CONS_AGUILAS = group.Sum(Function(item) item.CONS_AGUILAS),
                 .SAPU_FREI = group.Sum(Function(item) item.SAPU_FREI),
                 .CESFAM_LIMACHE = group.Sum(Function(item) item.CESFAM_LIMACHE),
                 .CESFAM_OLMUE = group.Sum(Function(item) item.CESFAM_OLMUE),
                 .APS_CABILDO = group.Sum(Function(item) item.APS_CABILDO),
                 .APS_HIJUELAS = group.Sum(Function(item) item.APS_HIJUELAS),
                 .APS_CALERA = group.Sum(Function(item) item.APS_CALERA),
                 .APS_LIGUA = group.Sum(Function(item) item.APS_LIGUA),
                 .APS_NOGALES = group.Sum(Function(item) item.APS_NOGALES),
                 .APS_PETORCA = group.Sum(Function(item) item.APS_PETORCA),
                 .HOSP_LIMACHE = group.Sum(Function(item) item.HOSP_LIMACHE),
                 .HOSP_GERIATRICO_LMCHE = group.Sum(Function(item) item.HOSP_GERIATRICO_LMCHE),
                 .HOSP_MODULAR_LMCHE = group.Sum(Function(item) item.HOSP_MODULAR_LMCHE),
                 .HOSP_PENBLANCA = group.Sum(Function(item) item.HOSP_PENBLANCA),
                 .HOSP_GUSTAVO_FRICKE = group.Sum(Function(item) item.HOSP_GUSTAVO_FRICKE),
                 .HOSP_CALERA = group.Sum(Function(item) item.HOSP_CALERA),
                 .HOSP_PETORCA = group.Sum(Function(item) item.HOSP_PETORCA),
                 .HOSP_QUILLOTA = group.Sum(Function(item) item.HOSP_QUILLOTA),
                 .HOSP_CABILDO = group.Sum(Function(item) item.HOSP_CABILDO),
                 .HOSP_LIGUA = group.Sum(Function(item) item.HOSP_LIGUA),
                 .HOSP_QUINTERO = group.Sum(Function(item) item.HOSP_QUINTERO),
                 .OTROS = group.Sum(Function(item) item.OTROS),
                 .TOTAL_EXTRA = group.Sum(Function(item) item.TOTAL_EXTRA)
            }

            result.Add(summary)

        Next


#Region "DICCIONARIO"

        ' Crear un diccionario para almacenar las listas filtradas por ID_CODIGO_FONASA
        Dim hemogramas As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
            {30, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 30)},
            {26, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 26)},
            {27, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 27)},
            {33, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 33)},
            {34, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 34)},
            {35, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 35)},
            {38, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 38)},
            {40, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 40)},
            {45, filteredList.Where(Function(item) item.ID_CODIGO_FONASA = 45)}
        }

        Dim perfil_bioq As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
        {664, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 664)},
        {57, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 57)},
        {66, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 66)},
        {94, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 94)},
        {97, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 97)},
        {130, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 130)},
        {136, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 136)},
        {137, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 137)},
        {138, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 138)},
        {140, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 140)},
        {141, filteredList2.Where(Function(item) item.ID_CODIGO_FONASA = 141)}
        }

        Dim perfil_tiro As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
          {730, filteredList3.Where(Function(item) item.ID_CODIGO_FONASA = 730)},
          {182, filteredList3.Where(Function(item) item.ID_CODIGO_FONASA = 182)},
          {183, filteredList3.Where(Function(item) item.ID_CODIGO_FONASA = 183)},
          {527, filteredList3.Where(Function(item) item.ID_CODIGO_FONASA = 527)}
        }

        Dim perfil_hepa As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
          {941, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 941)},
          {57, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 57)},
          {94, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 94)},
          {97, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 97)},
          {136, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 136)},
          {137, filteredList4.Where(Function(item) item.ID_CODIGO_FONASA = 137)}
        }

        Dim perfil_lipi As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
          {76, filteredList5.Where(Function(item) item.ID_CODIGO_FONASA = 76)},
          {138, filteredList5.Where(Function(item) item.ID_CODIGO_FONASA = 138)},
          {140, filteredList5.Where(Function(item) item.ID_CODIGO_FONASA = 140)},
          {141, filteredList5.Where(Function(item) item.ID_CODIGO_FONASA = 141)}
        }

        Dim perfil_basico As New Dictionary(Of Integer, IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)) From {
          {731, filteredList6.Where(Function(item) item.ID_CODIGO_FONASA = 731)},
          {66, filteredList6.Where(Function(item) item.ID_CODIGO_FONASA = 66)},
          {130, filteredList6.Where(Function(item) item.ID_CODIGO_FONASA = 130)}
        }

#End Region

        Dim contador As Integer = 0

        'Debug.WriteLine($"Duplicados: {perfilesDuplicados} TOTAL HEPATICO: {TOTAL941CAE} TOTAL BIOQ: {TOTAL664CAE}")

        Dim finalResult = result.Select(Function(summary)
                                            ' Usar el diccionario para obtener la lista filtrada
                                            Dim listaFiltrada As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los hemogramas
                                            Dim listaFiltrada2 As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los perfiles bioquimicos
                                            Dim listaFiltrada3 As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los perfiles tiroideo
                                            Dim listaFiltrada4 As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los perfiles hepaticos
                                            Dim listaFiltrada5 As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los perfiles lipidicos
                                            Dim listaFiltrada6 As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = Nothing '<-- Lista para los perfiles basico

                                            ' HEMOGRAMA
                                            If hemogramas.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada) Then
                                                summary.CANTIDAD = If(listaFiltrada.Any(), listaFiltrada.Count(), 0)
                                                'Debug.WriteLine($"SUMMARY:  {summary.ID_CODIGO_FONASA}")
                                                'Contador_Proc(summary, totalCodigo664Count, listaFiltrada2)
                                                'If summary.ID_CODIGO_FONASA <> 30 Then
                                                '    If (countHemograma30WithExclusions > 0) Then
                                                '        RestarSiMayorACero(summary.CAE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.USM_HDIURNO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.PERSONAL, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.TOTAL_ABIERTA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.MQ1, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.MQ2, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.MQ3, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UAPQ_PABELLON, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.PEDIATRIA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.NEONATOLOGIA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UPC, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UCI_A, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UTI, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.MATERNIDAD, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CMA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_DOCIMI, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UEA_HOSP, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.TOTAL_CERRADA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UEA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UEI, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.SAUD, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.TOTAL_UE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.UEGO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.ANATOMIA_PATO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.IMAGENOLOGIA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.TOTAL_UNIDAD_APOYO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_IVAN_MAN, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_AV_AC, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_QUILPUE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_BELLOTO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CONS_POMPEYA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CECOSF_RETIRO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CONS_BELLOTO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_VILLA_AL, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_AMERICAS, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CONS_EDUARDO_FREI, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_JUAN_BT, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CONS_AGUILAS, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.SAPU_FREI, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_LIMACHE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.CESFAM_OLMUE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_CABILDO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_HIJUELAS, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_CALERA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_LIGUA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_NOGALES, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.APS_PETORCA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_LIMACHE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_GERIATRICO_LMCHE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_MODULAR_LMCHE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_PENBLANCA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_GUSTAVO_FRICKE, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_CALERA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_PETORCA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_QUILLOTA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_CABILDO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_LIGUA, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.HOSP_QUINTERO, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.OTROS, countHemograma30WithExclusions)
                                                '        RestarSiMayorACero(summary.TOTAL_EXTRA, countHemograma30WithExclusions)
                                                '    End If
                                                'End If
                                                If summary.ID_CODIGO_FONASA <> 30 Then
                                                    If countHemograma30WithExclusions > 0 Then
                                                        summary.CAE -= countHemograma30WithExclusions
                                                        summary.USM_HDIURNO -= countHemograma30WithExclusions
                                                        summary.PERSONAL -= countHemograma30WithExclusions
                                                        summary.TOTAL_ABIERTA -= countHemograma30WithExclusions
                                                        summary.MQ1 -= countHemograma30WithExclusions
                                                        summary.MQ2 -= countHemograma30WithExclusions
                                                        summary.MQ3 -= countHemograma30WithExclusions
                                                        summary.UAPQ_PABELLON -= countHemograma30WithExclusions
                                                        summary.PEDIATRIA -= countHemograma30WithExclusions
                                                        summary.NEONATOLOGIA -= countHemograma30WithExclusions
                                                        summary.UPC -= countHemograma30WithExclusions
                                                        summary.UCI_A -= countHemograma30WithExclusions
                                                        summary.UTI -= countHemograma30WithExclusions
                                                        summary.MATERNIDAD -= countHemograma30WithExclusions
                                                        summary.CMA -= countHemograma30WithExclusions
                                                        summary.HOSP_DOCIMI -= countHemograma30WithExclusions
                                                        summary.UEA_HOSP -= countHemograma30WithExclusions
                                                        summary.TOTAL_CERRADA -= countHemograma30WithExclusions
                                                        summary.UEA -= countHemograma30WithExclusions
                                                        summary.UEI -= countHemograma30WithExclusions
                                                        summary.SAUD -= countHemograma30WithExclusions
                                                        summary.TOTAL_UE -= countHemograma30WithExclusions
                                                        summary.UEGO -= countHemograma30WithExclusions
                                                        summary.ANATOMIA_PATO -= countHemograma30WithExclusions
                                                        summary.IMAGENOLOGIA -= countHemograma30WithExclusions
                                                        summary.TOTAL_UNIDAD_APOYO -= countHemograma30WithExclusions
                                                        summary.CESFAM_IVAN_MAN -= countHemograma30WithExclusions
                                                        summary.CESFAM_AV_AC -= countHemograma30WithExclusions
                                                        summary.CESFAM_QUILPUE -= countHemograma30WithExclusions
                                                        summary.CESFAM_BELLOTO -= countHemograma30WithExclusions
                                                        summary.CONS_POMPEYA -= countHemograma30WithExclusions
                                                        summary.CECOSF_RETIRO -= countHemograma30WithExclusions
                                                        summary.CONS_BELLOTO -= countHemograma30WithExclusions
                                                        summary.CESFAM_VILLA_AL -= countHemograma30WithExclusions
                                                        summary.CESFAM_AMERICAS -= countHemograma30WithExclusions
                                                        summary.CONS_EDUARDO_FREI -= countHemograma30WithExclusions
                                                        summary.CESFAM_JUAN_BT -= countHemograma30WithExclusions
                                                        summary.CONS_AGUILAS -= countHemograma30WithExclusions
                                                        summary.SAPU_FREI -= countHemograma30WithExclusions
                                                        summary.CESFAM_LIMACHE -= countHemograma30WithExclusions
                                                        summary.CESFAM_OLMUE -= countHemograma30WithExclusions
                                                        summary.APS_CABILDO -= countHemograma30WithExclusions
                                                        summary.APS_HIJUELAS -= countHemograma30WithExclusions
                                                        summary.APS_CALERA -= countHemograma30WithExclusions
                                                        summary.APS_LIGUA -= countHemograma30WithExclusions
                                                        summary.APS_NOGALES -= countHemograma30WithExclusions
                                                        summary.APS_PETORCA -= countHemograma30WithExclusions
                                                        summary.HOSP_LIMACHE -= countHemograma30WithExclusions
                                                        summary.HOSP_GERIATRICO_LMCHE -= countHemograma30WithExclusions
                                                        summary.HOSP_MODULAR_LMCHE -= countHemograma30WithExclusions
                                                        summary.HOSP_PENBLANCA -= countHemograma30WithExclusions
                                                        summary.HOSP_GUSTAVO_FRICKE -= countHemograma30WithExclusions
                                                        summary.HOSP_CALERA -= countHemograma30WithExclusions
                                                        summary.HOSP_PETORCA -= countHemograma30WithExclusions
                                                        summary.HOSP_QUILLOTA -= countHemograma30WithExclusions
                                                        summary.HOSP_CABILDO -= countHemograma30WithExclusions
                                                        summary.HOSP_LIGUA -= countHemograma30WithExclusions
                                                        summary.HOSP_QUINTERO -= countHemograma30WithExclusions
                                                        summary.OTROS -= countHemograma30WithExclusions
                                                        summary.TOTAL_EXTRA -= countHemograma30WithExclusions

                                                    End If
                                                End If
                                            End If

                                            ' PERFIL BIOQUIMICO
                                            If perfil_bioq.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada2) Then
                                                'Debug.WriteLine($"Contador: {listaFiltrada2.Count()}")
                                                If summary.ID_CODIGO_FONASA = 664 Then
                                                    summary.CANTIDAD = 0
                                                End If
                                                ' Sumar totalCodigos664Count si el ID_CODIGO_FONASA está en priori_p_bioq
                                                If priori_p_bioq.Contains(summary.ID_CODIGO_FONASA) Then
                                                    'Dim objet As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
                                                    Contador_Por_Proc_Exa(summary, listaFiltrada2, groupedList, 664)

                                                    'summary.CANTIDAD += totalCodigo664Count ' Total de codigos 664 que corresponde al perfil bioquimico
                                                    '' Atención abierta
                                                    'summary.CAE += TOTAL664CAE
                                                    'summary.USM_HDIURNO += TOTAL664USM_HDIURNO
                                                    'summary.PERSONAL += TOTAL664Personal
                                                    '' Atención cerrada
                                                    'summary.MQ1 += TOTAL664MQ1
                                                    'summary.MQ2 += TOTAL664MQ2
                                                    'summary.MQ3 += TOTAL664MQ3
                                                    'summary.UAPQ_PABELLON += TOTAL664UAPQ_PABELLON
                                                    'summary.PEDIATRIA += TOTAL664PEDIATRIA
                                                    'summary.NEONATOLOGIA += TOTAL664NEONATOLOGIA
                                                    'summary.UPC += TOTAL664UPC
                                                    'summary.UCI_A += TOTAL664UCI_A
                                                    'summary.UTI += TOTAL664UTI
                                                    'summary.MATERNIDAD += TOTAL664MATERNIDAD
                                                    'summary.CMA += TOTAL664CMA
                                                    'summary.HOSP_DOCIMI += TOTAL664HOSP_DOCIMI
                                                    'summary.UEA_HOSP += TOTAL664UEA_HOSP
                                                    '' Atención UE
                                                    'summary.UEA += TOTAL664UEA
                                                    'summary.UEI += TOTAL664UEI
                                                    'summary.SAUD += TOTAL664SAUD
                                                    '' Atención UEGO
                                                    'summary.UEGO += TOTAL664UEGO
                                                    'summary.ANATOMIA_PATO += TOTAL664ANATOMIA_PATO
                                                    'summary.IMAGENOLOGIA += TOTAL664IMAGENOLOGIA
                                                    '' Atención EXTRA HOSPITALARIO
                                                    'summary.CESFAM_IVAN_MAN += TOTAL664CESFAM_IVAN_MAN
                                                    'summary.CESFAM_AV_AC += TOTAL664CESFAM_AV_AC
                                                    'summary.CESFAM_QUILPUE += TOTAL664CESFAM_QUILPUE
                                                    'summary.CESFAM_BELLOTO += TOTAL664CESFAM_BELLOTO
                                                    'summary.CONS_POMPEYA += TOTAL664CONS_POMPEYA
                                                    'summary.CECOSF_RETIRO += TOTAL664CECOSF_RETIRO
                                                    'summary.CONS_BELLOTO += TOTAL664CONS_BELLOTO
                                                    'summary.CESFAM_VILLA_AL += TOTAL664CESFAM_VILLA_AL
                                                    'summary.CESFAM_AMERICAS += TOTAL664CESFAM_AMERICAS
                                                    'summary.CONS_EDUARDO_FREI += TOTAL664CONS_EDUARDO_FREI
                                                    'summary.CESFAM_JUAN_BT += TOTAL664CESFAM_JUAN_BT
                                                    'summary.CONS_AGUILAS += TOTAL664CONS_AGUILAS
                                                    'summary.SAPU_FREI += TOTAL664SAPU_FREI
                                                    'summary.CESFAM_LIMACHE += TOTAL664CESFAM_LIMACHE
                                                    'summary.CESFAM_OLMUE += TOTAL664CESFAM_OLMUE
                                                    'summary.APS_CABILDO += TOTAL664APS_CABILDO
                                                    'summary.APS_HIJUELAS += TOTAL664APS_HIJUELAS
                                                    'summary.APS_CALERA += TOTAL664APS_CALERA
                                                    'summary.APS_LIGUA += TOTAL664APS_LIGUA
                                                    'summary.APS_NOGALES += TOTAL664APS_NOGALES
                                                    'summary.APS_PETORCA += TOTAL664APS_PETORCA
                                                    'summary.HOSP_LIMACHE += TOTAL664HOSP_LIMACHE
                                                    'summary.HOSP_GERIATRICO_LMCHE += TOTAL664HOSP_GERIATRICO_LMCHE
                                                    'summary.HOSP_MODULAR_LMCHE += TOTAL664HOSP_MODULAR_LMCHE
                                                    'summary.HOSP_PENBLANCA += TOTAL664HOSP_PENBLANCA
                                                    'summary.HOSP_GUSTAVO_FRICKE += TOTAL664HOSP_GUSTAVO_FRICKE
                                                    'summary.HOSP_CALERA += TOTAL664HOSP_CALERA
                                                    'summary.HOSP_PETORCA += TOTAL664HOSP_PETORCA
                                                    'summary.HOSP_QUILLOTA += TOTAL664HOSP_QUILLOTA
                                                    'summary.HOSP_CABILDO += TOTAL664HOSP_CABILDO
                                                    'summary.HOSP_LIGUA += TOTAL664HOSP_LIGUA
                                                    'summary.HOSP_QUINTERO += TOTAL664HOSP_QUINTERO
                                                End If
                                            End If

                                            'PERFIL TIROIDEO
                                            If perfil_tiro.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada3) Then
                                                'Debug.WriteLine($"Contador: {listaFiltrada3.Count()}")
                                                If summary.ID_CODIGO_FONASA = 730 Then
                                                    summary.CANTIDAD = 0
                                                End If
                                                ' Sumar totalCodigos730Count si el ID_CODIGO_FONASA está en priori_p_tiro
                                                If priori_p_tiro.Contains(summary.ID_CODIGO_FONASA) Then
                                                    ' Contador_Por_Proc_Exa(summary, listaFiltrada3, groupedList, 730)
                                                    summary.CANTIDAD += totalCodigo730Count ' Total de codigos 730 que corresponde al perfil bioquimico
                                                    ' Atención abierta
                                                    summary.CAE += TOTAL730CAE
                                                    summary.USM_HDIURNO += TOTAL730USM_HDIURNO
                                                    summary.PERSONAL += TOTAL730Personal
                                                    ' Atención cerrada
                                                    summary.MQ1 += TOTAL730MQ1
                                                    summary.MQ2 += TOTAL730MQ2
                                                    summary.MQ3 += TOTAL730MQ3
                                                    summary.UAPQ_PABELLON += TOTAL730UAPQ_PABELLON
                                                    summary.PEDIATRIA += TOTAL730PEDIATRIA
                                                    summary.NEONATOLOGIA += TOTAL730NEONATOLOGIA
                                                    summary.UPC += TOTAL730UPC
                                                    summary.UCI_A += TOTAL730UCI_A
                                                    summary.UTI += TOTAL730UTI
                                                    summary.MATERNIDAD += TOTAL730MATERNIDAD
                                                    summary.CMA += TOTAL730CMA
                                                    summary.HOSP_DOCIMI += TOTAL730HOSP_DOCIMI
                                                    summary.UEA_HOSP += TOTAL730UEA_HOSP
                                                    ' Atención UE
                                                    summary.UEA += TOTAL730UEA
                                                    summary.UEI += TOTAL730UEI
                                                    summary.SAUD += TOTAL730SAUD
                                                    ' Atención UEGO
                                                    summary.UEGO += TOTAL730UEGO
                                                    ' Atención  Unidad de APOYO
                                                    summary.ANATOMIA_PATO += TOTAL730ANATOMIA_PATO
                                                    summary.IMAGENOLOGIA += TOTAL730IMAGENOLOGIA
                                                    ' Atención EXTRA HOSPITALARIO
                                                    summary.CESFAM_IVAN_MAN += TOTAL730CESFAM_IVAN_MAN
                                                    summary.CESFAM_AV_AC += TOTAL730CESFAM_AV_AC
                                                    summary.CESFAM_QUILPUE += TOTAL730CESFAM_QUILPUE
                                                    summary.CESFAM_BELLOTO += TOTAL730CESFAM_BELLOTO
                                                    summary.CONS_POMPEYA += TOTAL730CONS_POMPEYA
                                                    summary.CECOSF_RETIRO += TOTAL730CECOSF_RETIRO
                                                    summary.CONS_BELLOTO += TOTAL730CONS_BELLOTO
                                                    summary.CESFAM_VILLA_AL += TOTAL730CESFAM_VILLA_AL
                                                    summary.CESFAM_AMERICAS += TOTAL730CESFAM_AMERICAS
                                                    summary.CONS_EDUARDO_FREI += TOTAL730CONS_EDUARDO_FREI
                                                    summary.CESFAM_JUAN_BT += TOTAL730CESFAM_JUAN_BT
                                                    summary.CONS_AGUILAS += TOTAL730CONS_AGUILAS
                                                    summary.SAPU_FREI += TOTAL730SAPU_FREI
                                                    summary.CESFAM_LIMACHE += TOTAL730CESFAM_LIMACHE
                                                    summary.CESFAM_OLMUE += TOTAL730CESFAM_OLMUE
                                                    summary.APS_CABILDO += TOTAL730APS_CABILDO
                                                    summary.APS_HIJUELAS += TOTAL730APS_HIJUELAS
                                                    summary.APS_CALERA += TOTAL730APS_CALERA
                                                    summary.APS_LIGUA += TOTAL730APS_LIGUA
                                                    summary.APS_NOGALES += TOTAL730APS_NOGALES
                                                    summary.APS_PETORCA += TOTAL730APS_PETORCA
                                                    summary.HOSP_LIMACHE += TOTAL730HOSP_LIMACHE
                                                    summary.HOSP_GERIATRICO_LMCHE += TOTAL730HOSP_GERIATRICO_LMCHE
                                                    summary.HOSP_MODULAR_LMCHE += TOTAL730HOSP_MODULAR_LMCHE
                                                    summary.HOSP_PENBLANCA += TOTAL730HOSP_PENBLANCA
                                                    summary.HOSP_GUSTAVO_FRICKE += TOTAL730HOSP_GUSTAVO_FRICKE
                                                    summary.HOSP_CALERA += TOTAL730HOSP_CALERA
                                                    summary.HOSP_PETORCA += TOTAL730HOSP_PETORCA
                                                    summary.HOSP_QUILLOTA += TOTAL730HOSP_QUILLOTA
                                                    summary.HOSP_CABILDO += TOTAL730HOSP_CABILDO
                                                    summary.HOSP_LIGUA += TOTAL730HOSP_LIGUA
                                                    summary.HOSP_QUINTERO += TOTAL730HOSP_QUINTERO
                                                End If
                                            End If

                                            ' PERFIL HEPATICO
                                            If perfil_hepa.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada4) Then
                                                If summary.ID_CODIGO_FONASA = 941 Then
                                                    summary.CANTIDAD = 0
                                                End If
                                                ' Sumar totalCodigos941Count si el ID_CODIGO_FONASA está en priori_p_tiro
                                                'If priori_p_hepa.Contains(summary.ID_CODIGO_FONASA) Then
                                                '    summary = Contador_Por_Proc_Exa(summary, listaFiltrada4, groupedList, 941)
                                                '    summary.CANTIDAD += totalCodigo941Count ' Total de codigos 941 que corresponde al perfil bioquimico
                                                '    ' Atención abierta
                                                '    summary.CAE += TOTAL941CAE
                                                '    summary.USM_HDIURNO += TOTAL941USM_HDIURNO
                                                '    summary.PERSONAL += TOTAL941Personal
                                                '    ' Atención cerrada
                                                '    summary.MQ1 += TOTAL941MQ1
                                                '    summary.MQ2 += TOTAL941MQ2
                                                '    summary.MQ3 += TOTAL941MQ3
                                                '    summary.UAPQ_PABELLON += TOTAL941UAPQ_PABELLON
                                                '    summary.PEDIATRIA += TOTAL941PEDIATRIA
                                                '    summary.NEONATOLOGIA += TOTAL941NEONATOLOGIA
                                                '    summary.UPC += TOTAL941UPC
                                                '    summary.UCI_A += TOTAL941UCI_A
                                                '    summary.UTI += TOTAL941UTI
                                                '    summary.MATERNIDAD += TOTAL941MATERNIDAD
                                                '    summary.CMA += TOTAL941CMA
                                                '    summary.HOSP_DOCIMI += TOTAL941HOSP_DOCIMI
                                                '    summary.UEA_HOSP += TOTAL941UEA_HOSP
                                                '    ' Atención UE
                                                '    summary.UEA += TOTAL941UEA
                                                '    summary.UEI += TOTAL941UEI
                                                '    summary.SAUD += TOTAL941SAUD
                                                '    ' Atención UEGO
                                                '    summary.UEGO += TOTAL941UEGO
                                                '    ' Atención  Unidad de APOYO
                                                '    summary.ANATOMIA_PATO += TOTAL941ANATOMIA_PATO
                                                '    summary.IMAGENOLOGIA += TOTAL941IMAGENOLOGIA
                                                '    ' Atención EXTRA HOSPITALARIO
                                                '    summary.CESFAM_IVAN_MAN += TOTAL941CESFAM_IVAN_MAN
                                                '    summary.CESFAM_AV_AC += TOTAL941CESFAM_AV_AC
                                                '    summary.CESFAM_QUILPUE += TOTAL941CESFAM_QUILPUE
                                                '    summary.CESFAM_BELLOTO += TOTAL941CESFAM_BELLOTO
                                                '    summary.CONS_POMPEYA += TOTAL941CONS_POMPEYA
                                                '    summary.CECOSF_RETIRO += TOTAL941CECOSF_RETIRO
                                                '    summary.CONS_BELLOTO += TOTAL941CONS_BELLOTO
                                                '    summary.CESFAM_VILLA_AL += TOTAL941CESFAM_VILLA_AL
                                                '    summary.CESFAM_AMERICAS += TOTAL941CESFAM_AMERICAS
                                                '    summary.CONS_EDUARDO_FREI += TOTAL941CONS_EDUARDO_FREI
                                                '    summary.CESFAM_JUAN_BT += TOTAL941CESFAM_JUAN_BT
                                                '    summary.CONS_AGUILAS += TOTAL941CONS_AGUILAS
                                                '    summary.SAPU_FREI += TOTAL941SAPU_FREI
                                                '    summary.CESFAM_LIMACHE += TOTAL941CESFAM_LIMACHE
                                                '    summary.CESFAM_OLMUE += TOTAL941CESFAM_OLMUE
                                                '    summary.APS_CABILDO += TOTAL941APS_CABILDO
                                                '    summary.APS_HIJUELAS += TOTAL941APS_HIJUELAS
                                                '    summary.APS_CALERA += TOTAL941APS_CALERA
                                                '    summary.APS_LIGUA += TOTAL941APS_LIGUA
                                                '    summary.APS_NOGALES += TOTAL941APS_NOGALES
                                                '    summary.APS_PETORCA += TOTAL941APS_PETORCA
                                                '    summary.HOSP_LIMACHE += TOTAL941HOSP_LIMACHE
                                                '    summary.HOSP_GERIATRICO_LMCHE += TOTAL941HOSP_GERIATRICO_LMCHE
                                                '    summary.HOSP_MODULAR_LMCHE += TOTAL941HOSP_MODULAR_LMCHE
                                                '    summary.HOSP_PENBLANCA += TOTAL941HOSP_PENBLANCA
                                                '    summary.HOSP_GUSTAVO_FRICKE += TOTAL941HOSP_GUSTAVO_FRICKE
                                                '    summary.HOSP_CALERA += TOTAL941HOSP_CALERA
                                                '    summary.HOSP_PETORCA += TOTAL941HOSP_PETORCA
                                                '    summary.HOSP_QUILLOTA += TOTAL941HOSP_QUILLOTA
                                                '    summary.HOSP_CABILDO += TOTAL941HOSP_CABILDO
                                                '    summary.HOSP_LIGUA += TOTAL941HOSP_LIGUA
                                                '    summary.HOSP_QUINTERO += TOTAL941HOSP_QUINTERO
                                                'End If
                                            End If

                                            ' PERIL LIPIDICO
                                            If perfil_lipi.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada5) Then
                                                'Debug.WriteLine($"Contador: {listaFiltrada5.Count()}")
                                                If summary.ID_CODIGO_FONASA = 76 Then
                                                    summary.CANTIDAD = 0
                                                End If
                                                ' Sumar totalCodigos76Count si el ID_CODIGO_FONASA está en priori_p_lipi
                                                If priori_p_lipi.Contains(summary.ID_CODIGO_FONASA) Then

                                                    ' Contador_Por_Proc_Exa(summary, listaFiltrada5, groupedList, 76)
                                                    summary.CANTIDAD += totalCodigo76Count ' Total de codigos 76 que corresponde al perfil bioquimico
                                                    ' Atención abierta
                                                    summary.CAE += TOTAL76CAE
                                                    summary.USM_HDIURNO += TOTAL76USM_HDIURNO
                                                    summary.PERSONAL += TOTAL76Personal
                                                    ' Atención cerrada
                                                    summary.MQ1 += TOTAL76MQ1
                                                    summary.MQ2 += TOTAL76MQ2
                                                    summary.MQ3 += TOTAL76MQ3
                                                    summary.UAPQ_PABELLON += TOTAL76UAPQ_PABELLON
                                                    summary.PEDIATRIA += TOTAL76PEDIATRIA
                                                    summary.NEONATOLOGIA += TOTAL76NEONATOLOGIA
                                                    summary.UPC += TOTAL76UPC
                                                    summary.UCI_A += TOTAL76UCI_A
                                                    summary.UTI += TOTAL76UTI
                                                    summary.MATERNIDAD += TOTAL76MATERNIDAD
                                                    summary.CMA += TOTAL76CMA
                                                    summary.HOSP_DOCIMI += TOTAL76HOSP_DOCIMI
                                                    summary.UEA_HOSP += TOTAL76UEA_HOSP
                                                    ' Atención UE
                                                    summary.UEA += TOTAL76UEA
                                                    summary.UEI += TOTAL76UEI
                                                    summary.SAUD += TOTAL76SAUD
                                                    ' Atención UEGO
                                                    summary.UEGO += TOTAL76UEGO
                                                    ' Atención  Unidad de APOYO
                                                    summary.ANATOMIA_PATO += TOTAL76ANATOMIA_PATO
                                                    summary.IMAGENOLOGIA += TOTAL76IMAGENOLOGIA
                                                    ' Atención EXTRA HOSPITALARIO
                                                    summary.CESFAM_IVAN_MAN += TOTAL76CESFAM_IVAN_MAN
                                                    summary.CESFAM_AV_AC += TOTAL76CESFAM_AV_AC
                                                    summary.CESFAM_QUILPUE += TOTAL76CESFAM_QUILPUE
                                                    summary.CESFAM_BELLOTO += TOTAL76CESFAM_BELLOTO
                                                    summary.CONS_POMPEYA += TOTAL76CONS_POMPEYA
                                                    summary.CECOSF_RETIRO += TOTAL76CECOSF_RETIRO
                                                    summary.CONS_BELLOTO += TOTAL76CONS_BELLOTO
                                                    summary.CESFAM_VILLA_AL += TOTAL76CESFAM_VILLA_AL
                                                    summary.CESFAM_AMERICAS += TOTAL76CESFAM_AMERICAS
                                                    summary.CONS_EDUARDO_FREI += TOTAL76CONS_EDUARDO_FREI
                                                    summary.CESFAM_JUAN_BT += TOTAL76CESFAM_JUAN_BT
                                                    summary.CONS_AGUILAS += TOTAL76CONS_AGUILAS
                                                    summary.SAPU_FREI += TOTAL76SAPU_FREI
                                                    summary.CESFAM_LIMACHE += TOTAL76CESFAM_LIMACHE
                                                    summary.CESFAM_OLMUE += TOTAL76CESFAM_OLMUE
                                                    summary.APS_CABILDO += TOTAL76APS_CABILDO
                                                    summary.APS_HIJUELAS += TOTAL76APS_HIJUELAS
                                                    summary.APS_CALERA += TOTAL76APS_CALERA
                                                    summary.APS_LIGUA += TOTAL76APS_LIGUA
                                                    summary.APS_NOGALES += TOTAL76APS_NOGALES
                                                    summary.APS_PETORCA += TOTAL76APS_PETORCA
                                                    summary.HOSP_LIMACHE += TOTAL76HOSP_LIMACHE
                                                    summary.HOSP_GERIATRICO_LMCHE += TOTAL76HOSP_GERIATRICO_LMCHE
                                                    summary.HOSP_MODULAR_LMCHE += TOTAL76HOSP_MODULAR_LMCHE
                                                    summary.HOSP_PENBLANCA += TOTAL76HOSP_PENBLANCA
                                                    summary.HOSP_GUSTAVO_FRICKE += TOTAL76HOSP_GUSTAVO_FRICKE
                                                    summary.HOSP_CALERA += TOTAL76HOSP_CALERA
                                                    summary.HOSP_PETORCA += TOTAL76HOSP_PETORCA
                                                    summary.HOSP_QUILLOTA += TOTAL76HOSP_QUILLOTA
                                                    summary.HOSP_CABILDO += TOTAL76HOSP_CABILDO
                                                    summary.HOSP_LIGUA += TOTAL76HOSP_LIGUA
                                                    summary.HOSP_QUINTERO += TOTAL76HOSP_QUINTERO
                                                End If
                                            End If

                                            ' PERFIL BASICO
                                            If perfil_basico.TryGetValue(summary.ID_CODIGO_FONASA, listaFiltrada6) Then
                                                'Debug.WriteLine($"Contador: {listaFiltrada5.Count()}")
                                                If summary.ID_CODIGO_FONASA = 731 Then
                                                    summary.CANTIDAD = 0
                                                End If
                                                ' Sumar totalCodigos731Count si el ID_CODIGO_FONASA está en priori_p_basico
                                                If priori_p_basico.Contains(summary.ID_CODIGO_FONASA) Then

                                                    'Contador_Por_Proc_Exa(summary, listaFiltrada6, groupedList, 731)
                                                    summary.CANTIDAD += totalCodigo731Count ' Total de codigos 731 que corresponde al perfil bioquimico
                                                    ' Atención abierta
                                                    summary.CAE += TOTAL731CAE
                                                    summary.USM_HDIURNO += TOTAL731USM_HDIURNO
                                                    summary.PERSONAL += TOTAL731Personal
                                                    ' Atención cerrada
                                                    summary.MQ1 += TOTAL731MQ1
                                                    summary.MQ2 += TOTAL731MQ2
                                                    summary.MQ3 += TOTAL731MQ3
                                                    summary.UAPQ_PABELLON += TOTAL731UAPQ_PABELLON
                                                    summary.PEDIATRIA += TOTAL731PEDIATRIA
                                                    summary.NEONATOLOGIA += TOTAL731NEONATOLOGIA
                                                    summary.UPC += TOTAL731UPC
                                                    summary.UCI_A += TOTAL731UCI_A
                                                    summary.UTI += TOTAL731UTI
                                                    summary.MATERNIDAD += TOTAL731MATERNIDAD
                                                    summary.CMA += TOTAL731CMA
                                                    summary.HOSP_DOCIMI += TOTAL731HOSP_DOCIMI
                                                    summary.UEA_HOSP += TOTAL731UEA_HOSP

                                                    ' Atención UE
                                                    summary.UEA += TOTAL731UEA
                                                    summary.UEI += TOTAL731UEI
                                                    summary.SAUD += TOTAL731SAUD
                                                    ' Atención UEGO
                                                    summary.UEGO += TOTAL731UEGO
                                                    ' Atención  Unidad de APOYO
                                                    summary.ANATOMIA_PATO += TOTAL731ANATOMIA_PATO
                                                    summary.IMAGENOLOGIA += TOTAL731IMAGENOLOGIA
                                                    ' Atención EXTRA HOSPITALARIO
                                                    summary.CESFAM_IVAN_MAN += TOTAL731CESFAM_IVAN_MAN
                                                    summary.CESFAM_AV_AC += TOTAL731CESFAM_AV_AC
                                                    summary.CESFAM_QUILPUE += TOTAL731CESFAM_QUILPUE
                                                    summary.CESFAM_BELLOTO += TOTAL731CESFAM_BELLOTO
                                                    summary.CONS_POMPEYA += TOTAL731CONS_POMPEYA
                                                    summary.CECOSF_RETIRO += TOTAL731CECOSF_RETIRO
                                                    summary.CONS_BELLOTO += TOTAL731CONS_BELLOTO
                                                    summary.CESFAM_VILLA_AL += TOTAL731CESFAM_VILLA_AL
                                                    summary.CESFAM_AMERICAS += TOTAL731CESFAM_AMERICAS
                                                    summary.CONS_EDUARDO_FREI += TOTAL731CONS_EDUARDO_FREI
                                                    summary.CESFAM_JUAN_BT += TOTAL731CESFAM_JUAN_BT
                                                    summary.CONS_AGUILAS += TOTAL731CONS_AGUILAS
                                                    summary.SAPU_FREI += TOTAL731SAPU_FREI
                                                    summary.CESFAM_LIMACHE += TOTAL731CESFAM_LIMACHE
                                                    summary.CESFAM_OLMUE += TOTAL731CESFAM_OLMUE
                                                    summary.APS_CABILDO += TOTAL731APS_CABILDO
                                                    summary.APS_HIJUELAS += TOTAL731APS_HIJUELAS
                                                    summary.APS_CALERA += TOTAL731APS_CALERA
                                                    summary.APS_LIGUA += TOTAL731APS_LIGUA
                                                    summary.APS_NOGALES += TOTAL731APS_NOGALES
                                                    summary.APS_PETORCA += TOTAL731APS_PETORCA
                                                    summary.HOSP_LIMACHE += TOTAL731HOSP_LIMACHE
                                                    summary.HOSP_GERIATRICO_LMCHE += TOTAL731HOSP_GERIATRICO_LMCHE
                                                    summary.HOSP_MODULAR_LMCHE += TOTAL731HOSP_MODULAR_LMCHE
                                                    summary.HOSP_PENBLANCA += TOTAL731HOSP_PENBLANCA
                                                    summary.HOSP_GUSTAVO_FRICKE += TOTAL731HOSP_GUSTAVO_FRICKE
                                                    summary.HOSP_CALERA += TOTAL731HOSP_CALERA
                                                    summary.HOSP_PETORCA += TOTAL731HOSP_PETORCA
                                                    summary.HOSP_QUILLOTA += TOTAL731HOSP_QUILLOTA
                                                    summary.HOSP_CABILDO += TOTAL731HOSP_CABILDO
                                                    summary.HOSP_LIGUA += TOTAL731HOSP_LIGUA
                                                    summary.HOSP_QUINTERO += TOTAL731HOSP_QUINTERO
                                                End If
                                            End If

                                            Return summary
                                        End Function).ToList()

        hemogramas.Clear()
        perfil_bioq.Clear()
        perfil_tiro.Clear()
        perfil_hepa.Clear()
        perfil_lipi.Clear()
        perfil_basico.Clear()

        'finalResult = finalResult.Where(Function(item)
        '                                    If item.ID_CODIGO_FONASA = 664 Then
        '                                        item.CANTIDAD
        '                                    End If
        '                                End Function)
        ' Filtrar los elementos que tienen los ID_CODIGO_FONASA deseados
        Dim codigosFonasa As Integer() = {76, 664, 941}

        ' Filtra los elementos en la lista finalResult y resetea sus valores
        For Each item In finalResult.Where(Function(items) codigosFonasa.Contains(items.ID_CODIGO_FONASA)).ToList()
            item.CANTIDAD = 0
            item.CAE = 0
            item.USM_HDIURNO = 0
            item.PERSONAL = 0
            item.TOTAL_ABIERTA = 0
            item.MQ1 = 0
            item.MQ2 = 0
            item.MQ3 = 0
            item.UAPQ_PABELLON = 0
            item.PEDIATRIA = 0
            item.NEONATOLOGIA = 0
            item.UPC = 0
            item.UCI_A = 0
            item.UTI = 0
            item.MATERNIDAD = 0
            item.CMA = 0
            item.HOSP_DOCIMI = 0
            item.UEA_HOSP = 0
            item.TOTAL_CERRADA = 0
            item.UEA = 0
            item.UEI = 0
            item.SAUD = 0
            item.TOTAL_UE = 0
            item.UEGO = 0
            item.ANATOMIA_PATO = 0
            item.IMAGENOLOGIA = 0
            item.TOTAL_UNIDAD_APOYO = 0
            item.CESFAM_IVAN_MAN = 0
            item.CESFAM_AV_AC = 0
            item.CESFAM_QUILPUE = 0
            item.CESFAM_BELLOTO = 0
            item.CONS_POMPEYA = 0
            item.CECOSF_RETIRO = 0
            item.CONS_BELLOTO = 0
            item.CESFAM_VILLA_AL = 0
            item.CESFAM_AMERICAS = 0
            item.CONS_EDUARDO_FREI = 0
            item.CESFAM_JUAN_BT = 0
            item.CONS_AGUILAS = 0
            item.SAPU_FREI = 0
            item.CESFAM_LIMACHE = 0
            item.CESFAM_OLMUE = 0
            item.APS_CABILDO = 0
            item.APS_HIJUELAS = 0
            item.APS_CALERA = 0
            item.APS_LIGUA = 0
            item.APS_NOGALES = 0
            item.APS_PETORCA = 0
            item.HOSP_LIMACHE = 0
            item.HOSP_GERIATRICO_LMCHE = 0
            item.HOSP_MODULAR_LMCHE = 0
            item.HOSP_PENBLANCA = 0
            item.HOSP_GUSTAVO_FRICKE = 0
            item.HOSP_CALERA = 0
            item.HOSP_PETORCA = 0
            item.HOSP_QUILLOTA = 0
            item.HOSP_CABILDO = 0
            item.HOSP_LIGUA = 0
            item.HOSP_QUINTERO = 0
            item.OTROS = 0
            item.TOTAL_EXTRA = 0
        Next


        Dim object_count = finalResult.Find(Function(item) item.ID_CODIGO_FONASA = 39) ' id reticulocitos
        Dim object_count_2 = finalResult.Find(Function(item) item.ID_CODIGO_FONASA = 292) ' id reticulocitos

        If object_count IsNot Nothing Then

            object_count.CAE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CAE)
            object_count.USM_HDIURNO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.USM_HDIURNO)
            object_count.PERSONAL = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.PERSONAL)
            object_count.MQ1 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.MQ1)
            object_count.MQ2 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.MQ2)
            object_count.MQ3 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.MQ3)
            object_count.UAPQ_PABELLON = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UAPQ_PABELLON)
            object_count.PEDIATRIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.PEDIATRIA)
            object_count.NEONATOLOGIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.NEONATOLOGIA)
            object_count.UPC = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UPC)
            object_count.UCI_A = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UCI_A)
            object_count.UTI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UTI)
            object_count.MATERNIDAD = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.MATERNIDAD)
            object_count.CMA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CMA)
            object_count.HOSP_DOCIMI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_DOCIMI)
            object_count.UEA_HOSP = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UEA_HOSP)
            object_count.UEA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UEA)
            object_count.UEI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UEI)
            object_count.SAUD = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.SAUD)
            object_count.UEGO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.UEGO)
            object_count.ANATOMIA_PATO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.ANATOMIA_PATO)
            object_count.IMAGENOLOGIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.IMAGENOLOGIA)
            object_count.CESFAM_IVAN_MAN = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_IVAN_MAN)
            object_count.CESFAM_AV_AC = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_AV_AC)
            object_count.CESFAM_QUILPUE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_QUILPUE)
            object_count.CESFAM_BELLOTO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_BELLOTO)
            object_count.CONS_POMPEYA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CONS_POMPEYA)
            object_count.CECOSF_RETIRO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CECOSF_RETIRO)
            object_count.CONS_BELLOTO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CONS_BELLOTO)
            object_count.CESFAM_VILLA_AL = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_VILLA_AL)
            object_count.CESFAM_AMERICAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_AMERICAS)
            object_count.CONS_EDUARDO_FREI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CONS_EDUARDO_FREI)
            object_count.CESFAM_JUAN_BT = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_JUAN_BT)
            object_count.CONS_AGUILAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CONS_AGUILAS)
            object_count.SAPU_FREI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.SAPU_FREI)
            object_count.CESFAM_LIMACHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_LIMACHE)
            object_count.CESFAM_OLMUE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.CESFAM_OLMUE)
            object_count.APS_CABILDO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_CABILDO)
            object_count.APS_HIJUELAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_HIJUELAS)
            object_count.APS_CALERA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_CALERA)
            object_count.APS_LIGUA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_LIGUA)
            object_count.APS_NOGALES = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_NOGALES)
            object_count.APS_PETORCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.APS_PETORCA)
            object_count.HOSP_LIMACHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_LIMACHE)
            object_count.HOSP_GERIATRICO_LMCHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_GERIATRICO_LMCHE)
            object_count.HOSP_MODULAR_LMCHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_MODULAR_LMCHE)
            object_count.HOSP_PENBLANCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_PENBLANCA)
            object_count.HOSP_GUSTAVO_FRICKE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_GUSTAVO_FRICKE)
            object_count.HOSP_CALERA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_CALERA)
            object_count.HOSP_PETORCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_PETORCA)
            object_count.HOSP_QUILLOTA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_QUILLOTA)
            object_count.HOSP_CABILDO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_CABILDO)
            object_count.HOSP_LIGUA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_LIGUA)
            object_count.HOSP_QUINTERO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.HOSP_QUINTERO)
            object_count.OTROS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 301 OrElse item.ID_PRUEBA = 341).Sum(Function(item) item.OTROS)

        End If

        If object_count_2 IsNot Nothing Then

            object_count_2.CAE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CAE)
            object_count_2.USM_HDIURNO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.USM_HDIURNO)
            object_count_2.PERSONAL = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.PERSONAL)
            object_count_2.MQ1 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.MQ1)
            object_count_2.MQ2 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.MQ2)
            object_count_2.MQ3 = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.MQ3)
            object_count_2.UAPQ_PABELLON = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UAPQ_PABELLON)
            object_count_2.PEDIATRIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.PEDIATRIA)
            object_count_2.NEONATOLOGIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.NEONATOLOGIA)
            object_count_2.UPC = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UPC)
            object_count_2.UCI_A = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UCI_A)
            object_count_2.UTI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UTI)
            object_count_2.MATERNIDAD = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.MATERNIDAD)
            object_count_2.CMA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CMA)
            object_count_2.HOSP_DOCIMI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_DOCIMI)
            object_count_2.UEA_HOSP = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UEA_HOSP)
            object_count_2.UEA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UEA)
            object_count_2.UEI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UEI)
            object_count_2.SAUD = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.SAUD)
            object_count_2.UEGO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.UEGO)
            object_count_2.ANATOMIA_PATO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.ANATOMIA_PATO)
            object_count_2.IMAGENOLOGIA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.IMAGENOLOGIA)
            object_count_2.CESFAM_IVAN_MAN = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_IVAN_MAN)
            object_count_2.CESFAM_AV_AC = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_AV_AC)
            object_count_2.CESFAM_QUILPUE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_QUILPUE)
            object_count_2.CESFAM_BELLOTO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_BELLOTO)
            object_count_2.CONS_POMPEYA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CONS_POMPEYA)
            object_count_2.CECOSF_RETIRO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CECOSF_RETIRO)
            object_count_2.CONS_BELLOTO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CONS_BELLOTO)
            object_count_2.CESFAM_VILLA_AL = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_VILLA_AL)
            object_count_2.CESFAM_AMERICAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_AMERICAS)
            object_count_2.CONS_EDUARDO_FREI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CONS_EDUARDO_FREI)
            object_count_2.CESFAM_JUAN_BT = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_JUAN_BT)
            object_count_2.CONS_AGUILAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CONS_AGUILAS)
            object_count_2.SAPU_FREI = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.SAPU_FREI)
            object_count_2.CESFAM_LIMACHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_LIMACHE)
            object_count_2.CESFAM_OLMUE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.CESFAM_OLMUE)
            object_count_2.APS_CABILDO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_CABILDO)
            object_count_2.APS_HIJUELAS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_HIJUELAS)
            object_count_2.APS_CALERA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_CALERA)
            object_count_2.APS_LIGUA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_LIGUA)
            object_count_2.APS_NOGALES = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_NOGALES)
            object_count_2.APS_PETORCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.APS_PETORCA)
            object_count_2.HOSP_LIMACHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_LIMACHE)
            object_count_2.HOSP_GERIATRICO_LMCHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_GERIATRICO_LMCHE)
            object_count_2.HOSP_MODULAR_LMCHE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_MODULAR_LMCHE)
            object_count_2.HOSP_PENBLANCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_PENBLANCA)
            object_count_2.HOSP_GUSTAVO_FRICKE = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_GUSTAVO_FRICKE)
            object_count_2.HOSP_CALERA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_CALERA)
            object_count_2.HOSP_PETORCA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_PETORCA)
            object_count_2.HOSP_QUILLOTA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_QUILLOTA)
            object_count_2.HOSP_CABILDO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_CABILDO)
            object_count_2.HOSP_LIGUA = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_LIGUA)
            object_count_2.HOSP_QUINTERO = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.HOSP_QUINTERO)
            object_count_2.OTROS = List_Conteo.Where(Function(item) item.ID_PRUEBA = 1887).Sum(Function(item) item.OTROS)

        End If

        'Debug.WriteLine($"REATI {object_count.ID_CODIGO_FONASA}")
        Return finalResult
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_REM(ByVal DESDE As String, ByVal HASTA As String)

        Dim N_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim List_Rem As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA)

        Dim groupedData = List_Rem.GroupBy(Function(item) New With {Key .CF_COD_IRIS = item.CF_COD_IRIS, Key .ID_SECC_REM = item.ID_SECC_REM})

        ' Esta lista guarda los detalles de atención por fecha esto se ocupa
        Dim List_Det_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA) = N_REM.IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA(DESDE, HASTA)

        ' Crear una nueva lista para los resultados agrupados y sumados
        Dim result As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)()

#Region "Listas de codigos fonasa prioritario REM"

        ' Examenes

        Dim priori_e_hema As New List(Of Integer) From {26, 27, 32, 33, 34, 35, 36, 38, 39, 40, 45}
        Dim exc_e_hema As New List(Of Integer) From {30}

        Dim priori_e_homa As New List(Of Integer) From {103, 167}
        Dim exc_e_homa As New List(Of Integer) From {441}

        'Perfiles

        Dim priori_p_hepa As New List(Of Integer) From {58, 94, 97, 136, 137}
        Dim exc_p_hepa As New List(Of Integer) From {941}


        Dim priori_p_lipi As New List(Of Integer) From {138, 140, 141}
        Dim exc_p_lipi As New List(Of Integer) From {76}

        Dim priori_p_bioq As New List(Of Integer) From {58, 66, 94, 97, 130, 136, 137, 138, 140, 141}
        Dim exc_p_bioq As New List(Of Integer) From {664}

        Dim priori_p_basico As New List(Of Integer) From {66, 130}
        Dim exc_p_basico As New List(Of Integer) From {731}

        Dim priori_p_tiro As New List(Of Integer) From {182, 183, 527}
        Dim exc_p_tiro As New List(Of Integer) From {730}

        Dim priori_ptgo As New List(Of Integer) From {103}

        ' Lista que contiene los id cf de ambos perfiles hep. bioq.
        Dim p_hep_bioq As New List(Of Integer) From {58, 66, 94, 97, 130, 136, 137, 138, 140, 141}

        Dim p_lipi_bioq As New List(Of Integer) From {57, 66, 94, 97, 130, 136, 137, 138, 140, 141}

#End Region

        'Bucle para agrupar la data y sumar conteos en caso de duplicacion
        For Each group In groupedData

            ' Crear un nuevo objeto E_IRIS_WEBF_BUSCA_CANT_EXAMENES para almacenar los resultados sumados
            Dim summary As New E_IRIS_WEBF_BUSCA_CANT_EXAMENES() With {
                 .ID_FONASA_REM_HOSP = group.First().ID_FONASA_REM_HOSP,
                 .ID_CODIGO_FONASA = group.First().ID_CODIGO_FONASA,
                 .CF_DESC_HOSP = group.First().CF_DESC_HOSP,
                 .CF_COD_IRIS = group.Key.CF_COD_IRIS,
                 .ID_SECC_REM = group.Key.ID_SECC_REM,
                 .SECC_REM_DESC = group.First().SECC_REM_DESC,
                 .ID_AREA_REM = group.First().ID_AREA_REM,
                 .AREA_DESC = group.First().AREA_DESC,
                 .CANTIDAD = group.Sum(Function(item) item.CANTIDAD),
                 .CAE = group.Sum(Function(item) item.CAE),
                 .USM_HDIURNO = group.Sum(Function(item) item.USM_HDIURNO),
                 .PERSONAL = group.Sum(Function(item) item.PERSONAL),
                 .TOTAL_ABIERTA = group.Sum(Function(item) item.TOTAL_ABIERTA),
                 .MQ1 = group.Sum(Function(item) item.MQ1),
                 .MQ2 = group.Sum(Function(item) item.MQ2),
                 .MQ3 = group.Sum(Function(item) item.MQ3),
                 .UAPQ_PABELLON = group.Sum(Function(item) item.UAPQ_PABELLON),
                 .PEDIATRIA = group.Sum(Function(item) item.PEDIATRIA),
                 .NEONATOLOGIA = group.Sum(Function(item) item.NEONATOLOGIA),
                 .UPC = group.Sum(Function(item) item.UPC),
                 .UCI_A = group.Sum(Function(item) item.UCI_A),
                 .UTI = group.Sum(Function(item) item.UTI),
                 .MATERNIDAD = group.Sum(Function(item) item.MATERNIDAD),
                 .CMA = group.Sum(Function(item) item.CMA),
                 .HOSP_DOCIMI = group.Sum(Function(item) item.HOSP_DOCIMI),
                 .UEA_HOSP = group.Sum(Function(item) item.UEA_HOSP),
                 .TOTAL_CERRADA = group.Sum(Function(item) item.TOTAL_CERRADA),
                 .UEA = group.Sum(Function(item) item.UEA),
                 .UEI = group.Sum(Function(item) item.UEI),
                 .SAUD = group.Sum(Function(item) item.SAUD),
                 .TOTAL_UE = group.Sum(Function(item) item.TOTAL_UE),
                 .UEGO = group.Sum(Function(item) item.UEGO),
                 .ANATOMIA_PATO = group.Sum(Function(item) item.ANATOMIA_PATO),
                 .IMAGENOLOGIA = group.Sum(Function(item) item.IMAGENOLOGIA),
                 .TOTAL_UNIDAD_APOYO = group.Sum(Function(item) item.TOTAL_UNIDAD_APOYO),
                 .CESFAM_IVAN_MAN = group.Sum(Function(item) item.CESFAM_IVAN_MAN),
                 .CESFAM_AV_AC = group.Sum(Function(item) item.CESFAM_AV_AC),
                 .CESFAM_QUILPUE = group.Sum(Function(item) item.CESFAM_QUILPUE),
                 .CESFAM_BELLOTO = group.Sum(Function(item) item.CESFAM_BELLOTO),
                 .CONS_POMPEYA = group.Sum(Function(item) item.CONS_POMPEYA),
                 .CECOSF_RETIRO = group.Sum(Function(item) item.CECOSF_RETIRO),
                 .CONS_BELLOTO = group.Sum(Function(item) item.CONS_BELLOTO),
                 .CESFAM_VILLA_AL = group.Sum(Function(item) item.CESFAM_VILLA_AL),
                 .CESFAM_AMERICAS = group.Sum(Function(item) item.CESFAM_AMERICAS),
                 .CONS_EDUARDO_FREI = group.Sum(Function(item) item.CONS_EDUARDO_FREI),
                 .CESFAM_JUAN_BT = group.Sum(Function(item) item.CESFAM_JUAN_BT),
                 .CONS_AGUILAS = group.Sum(Function(item) item.CONS_AGUILAS),
                 .SAPU_FREI = group.Sum(Function(item) item.SAPU_FREI),
                 .CESFAM_LIMACHE = group.Sum(Function(item) item.CESFAM_LIMACHE),
                 .CESFAM_OLMUE = group.Sum(Function(item) item.CESFAM_OLMUE),
                 .APS_CABILDO = group.Sum(Function(item) item.APS_CABILDO),
                 .APS_HIJUELAS = group.Sum(Function(item) item.APS_HIJUELAS),
                 .APS_CALERA = group.Sum(Function(item) item.APS_CALERA),
                 .APS_LIGUA = group.Sum(Function(item) item.APS_LIGUA),
                 .APS_NOGALES = group.Sum(Function(item) item.APS_NOGALES),
                 .APS_PETORCA = group.Sum(Function(item) item.APS_PETORCA),
                 .HOSP_LIMACHE = group.Sum(Function(item) item.HOSP_LIMACHE),
                 .HOSP_GERIATRICO_LMCHE = group.Sum(Function(item) item.HOSP_GERIATRICO_LMCHE),
                 .HOSP_MODULAR_LMCHE = group.Sum(Function(item) item.HOSP_MODULAR_LMCHE),
                 .HOSP_PENBLANCA = group.Sum(Function(item) item.HOSP_PENBLANCA),
                 .HOSP_GUSTAVO_FRICKE = group.Sum(Function(item) item.HOSP_GUSTAVO_FRICKE),
                 .HOSP_CALERA = group.Sum(Function(item) item.HOSP_CALERA),
                 .HOSP_PETORCA = group.Sum(Function(item) item.HOSP_PETORCA),
                 .HOSP_QUILLOTA = group.Sum(Function(item) item.HOSP_QUILLOTA),
                 .HOSP_CABILDO = group.Sum(Function(item) item.HOSP_CABILDO),
                 .HOSP_LIGUA = group.Sum(Function(item) item.HOSP_LIGUA),
                 .HOSP_QUINTERO = group.Sum(Function(item) item.HOSP_QUINTERO),
                 .OTROS = group.Sum(Function(item) item.OTROS),
                 .TOTAL_EXTRA = group.Sum(Function(item) item.TOTAL_EXTRA)
            }

            result.Add(summary)

        Next


#Region "PERFILES INDIVIDUALES CON EXAMEN"

        If List_Det_Ate.Count > 0 Then
            ' Perfil Bioquimico
            'Condicionar_Cont_Perfil(664, List_Det_Ate, priori_p_bioq, exc_p_bioq, result)
            Condi_Cont_Perfil(priori_p_bioq, result, exc_p_bioq, List_Det_Ate, 664)

            ' Perfil Hepatico
            'Condicionar_Cont_Perfil(941, List_Det_Ate, priori_p_hepa, exc_p_hepa, result)
            Condi_Cont_Perfil(priori_p_hepa, result, exc_p_hepa, List_Det_Ate, 941)

            ' Perfil  Lipidico
            'Condicionar_Cont_Perfil(76, List_Det_Ate, priori_p_lipi, exc_p_lipi, result)
            Condi_Cont_Perfil(priori_p_lipi, result, exc_p_lipi, List_Det_Ate, 76)

            ' Perfil basico
            'Condicionar_Cont_Perfil(731, List_Det_Ate, priori_p_basico, exc_p_basico, result)
            Condi_Cont_Perfil(priori_p_basico, result, exc_p_basico, List_Det_Ate, 731)

            'Perfil tiroideo
            'Condicionar_Cont_Perfil(730, List_Det_Ate, priori_p_tiro, exc_p_tiro, result)
            Condi_Cont_Perfil(priori_p_tiro, result, exc_p_tiro, List_Det_Ate, 730)

            ' Debug.WriteLine($"Contador Hep: {count_p_hep}")
        End If
#End Region

#Region "PERFILES DUPLICADOS"

        'Integer que guarda un contador de dupllicados de perfiles de dos coincidencias
        Dim count_ate_bioq_hepa = Contar_Doble_Perfiles(List_Det_Ate, 664, 941)
        Dim list_proc_bioq_hep = Obtener_Proc_Dup(List_Det_Ate, 664, 941)

        'if para comprobar el contador de duplicados
        If count_ate_bioq_hepa > 0 Then
            For Each item In list_proc_bioq_hep
                'Debug.WriteLine($" dato: {id_proc_bioq_hep}")
                Debug.WriteLine($"item proc {item}")
                'Agregar_Contador_Dup(p_hep_bioq, result, item.Conteo_Duplicados, item.ID_PROCEDENCIA) ' Perfiles duplicados bioq. hep.
                'Quitar_Contador_Dup(p_hep_bioq, result, count_ate_bioq_hepa, item.ID_PROCEDENCIA)

                Quitar_Contador_Dup(New List(Of Integer) From {
                   664, 941
                                    }, result, item.Conteo_Duplicados, item.ID_PROCEDENCIA)
            Next
        End If

        'Dim count_ate_bioq_lipi = Contar_Doble_Perfiles(List_Det_Ate, 664, 76)
        'Dim list_proc_bioq_lip = Obtener_Procedencia_Dup(List_Det_Ate, 664, 76)

        'If count_ate_bioq_lipi > 0 Then
        '    For Each id_proc_bioq_lip In list_proc_bioq_lip
        '        'Debug.WriteLine($" dato: {id_proc_bioq_lip}")
        '        Agregar_Contador_Dup(p_hep_bioq, result, count_ate_bioq_lipi, id_proc_bioq_lip)
        '    Next
        'End If

#End Region

#Region "PTGO"
        If List_Det_Ate.Count > 0 Then
            Dim count_ptgo = Contar_Un_Perfil(priori_ptgo, List_Det_Ate, 110)
            Dim list_proc_ptgo = Obtener_Procedencia(priori_ptgo, List_Det_Ate, 110)
            If count_ptgo > 0 Then
                For Each id_proc_ptgo In list_proc_ptgo
                    Agregar_Contador_Dup(priori_ptgo, result, count_ptgo, id_proc_ptgo)
                Next
            End If
        End If
#End Region

#Region "Hemograma"
        ' Definimos la lista de codigos fonasa que queremos excluir en este caso seria las prestaciones que pueden ser individuales

        If List_Det_Ate.Count > 0 Then

            Condi_Cont_Perfil(priori_e_hema, result, exc_e_hema, List_Det_Ate, 30)

            'Dim count_hemo = Contar_Un_Perfil_2(priori_e_hema, List_Det_Ate, 30)
            '' if para obtener la procedencia de la atencion asociada
            'Dim list_proc_hem = Obtener_Procedencia(priori_e_hema, List_Det_Ate, 30)

            'If count_hemo > 0 Then
            '    For Each id_proc_hem In list_proc_hem
            '        'Quitar_Contador_Dup(priori_e_hema, result, count_hemo, id_proc_hem)
            '        'Agregar_Contador_Dup(priori_p_bioq, result, count_p_bioq, id_proc_bioq) 
            '        Agregar_Contador_Perf(exc_e_hema, result, count_hemo, id_proc_hem)
            '    Next
            'End If
        End If

#End Region

#Region "Transaminasas"

        If (List_Det_Ate.Count > 0) Then

            Dim count_transa = Contar_Por_Codigo(List_Det_Ate, "0302063-1", "0302063-2")
            For Each d In count_transa
                Agregar_Contador_Por_Codigo("0302063", result, d.Conteo_Examen, d.ID_PROCEDENCIA)
            Next
        End If
#End Region

#Region "ANTICUERPOS ENA ..."

        If (List_Det_Ate.Count > 0) Then

            Dim count_anti_ena = Contar_Por_Codigo(List_Det_Ate, "0305108", "")
            For Each d In count_anti_ena
                Agregar_Contador_Por_Codigo("0305004", result, d.Conteo_Examen, d.ID_PROCEDENCIA)
            Next
        End If
#End Region

#Region "Antigeno"
        If List_Det_Ate.Count > 0 Then
            Dim count_anti = Contar_Por_Codigo(List_Det_Ate, "0305170-2", "0305170-1")

            If Not count_anti.Any() Then
                Setear_Cero(result, New List(Of String) From {"0305170"})
            Else
                For Each d In count_anti
                    Agregar_Contador_Por_Codigo("0305170", result, d.Conteo_Examen, d.ID_PROCEDENCIA)
                Next
            End If
        End If


#End Region

#Region "HOMA"
        If List_Det_Ate.Count > 0 Then
            Dim count_homa = Contar_Un_Perfil_2(exc_e_homa, List_Det_Ate, 441)
            ' if para obtener la procedencia de la atencion asociada
            Dim list_proc_homa = Obtener_Procedencia(exc_e_homa, List_Det_Ate, 441)

            If count_homa > 0 Then
                For Each id_proc_homa In list_proc_homa
                    'Quitar_Contador_Dup(priori_e_homa, result, count_homa, id_proc_homa)
                    'Agregar_Contador_Dup(priori_p_bioq, result, count_p_bioq, id_proc_bioq) 
                    Agregar_Contador_Perf(priori_e_homa, result, count_homa, id_proc_homa)
                Next
            End If
        End If
#End Region

#Region "Conteo Analitos"

        Dim List_Conteo As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CONTEO_RETICULO(DESDE, HASTA)

        Dim list_pru_reticulo As New List(Of Integer) From {301, 341} ' id que representan ambos reticulocitos

        Dim list_pru_urocul As New List(Of Integer) From {1887} ' id representa el urocultivo

        Dim list_pru_orina As New List(Of Integer) From {2046} ' id representa la orina completa

        ' Busqueda en lista de cantidad de examens para conteo de reticulocitos
        Dim object_reticulo = result.Find(Function(item) item.ID_CODIGO_FONASA = 39 OrElse item.ID_CODIGO_FONASA = 30)

        ' Busqueda en lista de cantidad de examens para conteo de reticulocitos
        Dim object_urocul = result.Find(Function(item) item.ID_CODIGO_FONASA = 292)

        ' Busqueda en lista de cantidad de examens para conteo de Orina Completa
        Dim object_orina = result.Find(Function(item) item.ID_CODIGO_FONASA = 426)

        If object_reticulo IsNot Nothing Then

            Dim List_Conteo_Reti As List(Of E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA) = N_REM.IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA(DESDE, HASTA)
            Dim filter_List As List(Of E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA) = List_Conteo_Reti.
                  Where(Function(item)
                            ' Verificamos que ATE_RESULTADO_NUM no sea null ni vacío
                            If Not String.IsNullOrEmpty(item.ATE_RESULTADO_NUM) Then
                                Dim valor As Double
                                ' Intentamos convertir ATE_RESULTADO_NUM a número
                                If Double.TryParse(item.ATE_RESULTADO_NUM, valor) Then
                                    ' Solo devolvemos el item si el valor es mayor o igual a 1
                                    Return valor > 0
                                End If
                            End If
                            Return False
                        End Function).
    ToList()
            ' Filtra el item que tenga ID_CODIGO_FONASA = 45
            Dim item_update_reti = result.FirstOrDefault(Function(item) item.ID_CODIGO_FONASA = 39)

            'Si existe un item con ID_CODIGO_FONASA = 39
            If item_update_reti IsNot Nothing Then
                item_update_reti.CANTIDAD = filter_List.Count()
                item_update_reti.CAE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 51 OrElse items.ID_PROCEDENCIA = 216).Count()
                item_update_reti.USM_HDIURNO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 209).Count()
                item_update_reti.PERSONAL += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 217).Count()
                item_update_reti.MQ1 += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 53).Count()
                item_update_reti.MQ2 += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 52).Count()
                item_update_reti.MQ3 += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 57).Count()
                item_update_reti.UAPQ_PABELLON += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 68).Count()
                item_update_reti.PEDIATRIA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 55).Count()
                item_update_reti.NEONATOLOGIA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 59).Count()
                item_update_reti.UPC += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 60).Count()
                item_update_reti.UCI_A += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 215).Count()
                item_update_reti.UTI += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 214).Count()
                item_update_reti.MATERNIDAD += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 58).Count()
                item_update_reti.CMA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 54).Count()
                item_update_reti.HOSP_DOCIMI += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 56).Count()
                item_update_reti.UEA_HOSP += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 221).Count()
                item_update_reti.UEA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 66).Count()
                item_update_reti.UEI += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 267).Count()
                item_update_reti.SAUD += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 223).Count()
                item_update_reti.UEGO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 67).Count()
                item_update_reti.ANATOMIA_PATO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 164).Count()
                item_update_reti.IMAGENOLOGIA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 236).Count()
                item_update_reti.CESFAM_IVAN_MAN += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 244).Count()
                item_update_reti.CESFAM_AV_AC += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 243).Count()
                item_update_reti.CESFAM_QUILPUE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 207).Count()
                item_update_reti.CESFAM_BELLOTO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 245).Count()
                item_update_reti.CONS_POMPEYA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 212).Count()
                item_update_reti.CECOSF_RETIRO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 249).Count()
                item_update_reti.CONS_BELLOTO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 210).Count()
                item_update_reti.CESFAM_VILLA_AL += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 64).Count()
                item_update_reti.CESFAM_AMERICAS += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 62).Count()
                item_update_reti.CONS_EDUARDO_FREI += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 213).Count()
                item_update_reti.CESFAM_JUAN_BT += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 61).Count()
                item_update_reti.CONS_AGUILAS += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 271).Count()
                item_update_reti.SAPU_FREI += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 213).Count()
                item_update_reti.CESFAM_LIMACHE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 219).Count()
                item_update_reti.CESFAM_OLMUE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 238).Count()
                item_update_reti.APS_CABILDO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 254).Count()
                item_update_reti.APS_HIJUELAS += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 241).Count()
                item_update_reti.APS_CALERA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 239).Count()
                item_update_reti.APS_LIGUA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 255).Count()
                item_update_reti.APS_NOGALES += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 240).Count()
                item_update_reti.APS_PETORCA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 256).Count()
                item_update_reti.HOSP_LIMACHE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 228).Count()
                item_update_reti.HOSP_GERIATRICO_LMCHE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 229).Count()
                item_update_reti.HOSP_MODULAR_LMCHE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 232).Count()
                item_update_reti.HOSP_PENBLANCA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 63).Count()
                item_update_reti.HOSP_GUSTAVO_FRICKE += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 220).Count()
                item_update_reti.HOSP_CALERA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 233).Count()
                item_update_reti.HOSP_PETORCA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 253).Count()
                item_update_reti.HOSP_QUILLOTA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 230).Count()
                item_update_reti.HOSP_CABILDO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 252).Count()
                item_update_reti.HOSP_LIGUA += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 251).Count()
                item_update_reti.HOSP_QUINTERO += filter_List.Where(Function(items) items.ID_PROCEDENCIA = 227).Count()
            End If
        End If

        'If object_urocul IsNot Nothing Then
        '    'Agregar conteo para orina urocultivo
        '    Agregar_Conteo_Analito(list_pru_urocul, List_Conteo, object_urocul)
        'End If

        If object_orina IsNot Nothing Then
            'Agregar conteo para orina completa
            Agregar_Conteo_Analito(list_pru_orina, List_Conteo, object_orina)
        End If


        'conteo PARA VHS
        Dim list_proc As List(Of E_IRIS_WEBF_BUSCA_VHS_POR_FECHA) = N_REM.IRIS_WEBF_BUSCA_VHS_POR_FECHA(DESDE, HASTA)

        ' Primero, filtramos los elementos donde ATE_RESULTADO_NUM no es null y es mayor a 1
        Dim filteredList As List(Of E_IRIS_WEBF_BUSCA_VHS_POR_FECHA) = list_proc.
    Where(Function(item)
              ' Verificamos que ATE_RESULTADO_NUM no sea null ni vacío
              If Not String.IsNullOrEmpty(item.ATE_RESULTADO_NUM) Then
                  Dim valor As Double
                  ' Intentamos convertir ATE_RESULTADO_NUM a número
                  If Double.TryParse(item.ATE_RESULTADO_NUM, valor) Then
                      ' Solo devolvemos el item si el valor es mayor o igual a 1
                      Return valor > 0
                  End If
              End If
              Return False
          End Function).
    ToList()

        ' Filtra el item que tenga ID_CODIGO_FONASA = 45
        Dim itemToUpdate = result.FirstOrDefault(Function(item) item.ID_CODIGO_FONASA = 45)

        'Si existe un item con ID_CODIGO_FONASA = 45
        If itemToUpdate IsNot Nothing Then
            itemToUpdate.CANTIDAD = filteredList.Count()
            itemToUpdate.CAE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 51 OrElse items.ID_PROCEDENCIA = 216).Count()
            itemToUpdate.USM_HDIURNO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 209).Count()
            itemToUpdate.PERSONAL += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 217).Count()
            itemToUpdate.MQ1 += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 53).Count()
            itemToUpdate.MQ2 += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 52).Count()
            itemToUpdate.MQ3 += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 57).Count()
            itemToUpdate.UAPQ_PABELLON += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 68).Count()
            itemToUpdate.PEDIATRIA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 55).Count()
            itemToUpdate.NEONATOLOGIA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 59).Count()
            itemToUpdate.UPC += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 60).Count()
            itemToUpdate.UCI_A += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 215).Count()
            itemToUpdate.UTI += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 214).Count()
            itemToUpdate.MATERNIDAD += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 58).Count()
            itemToUpdate.CMA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 54).Count()
            itemToUpdate.HOSP_DOCIMI += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 56).Count()
            itemToUpdate.UEA_HOSP += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 221).Count()
            itemToUpdate.UEA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 66).Count()
            itemToUpdate.UEI += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 267).Count()
            itemToUpdate.SAUD += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 223).Count()
            itemToUpdate.UEGO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 67).Count()
            itemToUpdate.ANATOMIA_PATO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 164).Count()
            itemToUpdate.IMAGENOLOGIA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 236).Count()
            itemToUpdate.CESFAM_IVAN_MAN += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 244).Count()
            itemToUpdate.CESFAM_AV_AC += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 243).Count()
            itemToUpdate.CESFAM_QUILPUE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 207).Count()
            itemToUpdate.CESFAM_BELLOTO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 245).Count()
            itemToUpdate.CONS_POMPEYA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 212).Count()
            itemToUpdate.CECOSF_RETIRO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 249).Count()
            itemToUpdate.CONS_BELLOTO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 210).Count()
            itemToUpdate.CESFAM_VILLA_AL += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 64).Count()
            itemToUpdate.CESFAM_AMERICAS += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 62).Count()
            itemToUpdate.CONS_EDUARDO_FREI += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 213).Count()
            itemToUpdate.CESFAM_JUAN_BT += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 61).Count()
            itemToUpdate.CONS_AGUILAS += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 271).Count()
            itemToUpdate.SAPU_FREI += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 213).Count()
            itemToUpdate.CESFAM_LIMACHE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 219).Count()
            itemToUpdate.CESFAM_OLMUE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 238).Count()
            itemToUpdate.APS_CABILDO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 254).Count()
            itemToUpdate.APS_HIJUELAS += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 241).Count()
            itemToUpdate.APS_CALERA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 239).Count()
            itemToUpdate.APS_LIGUA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 255).Count()
            itemToUpdate.APS_NOGALES += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 240).Count()
            itemToUpdate.APS_PETORCA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 256).Count()
            itemToUpdate.HOSP_LIMACHE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 228).Count()
            itemToUpdate.HOSP_GERIATRICO_LMCHE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 229).Count()
            itemToUpdate.HOSP_MODULAR_LMCHE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 232).Count()
            itemToUpdate.HOSP_PENBLANCA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 63).Count()
            itemToUpdate.HOSP_GUSTAVO_FRICKE += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 220).Count()
            itemToUpdate.HOSP_CALERA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 233).Count()
            itemToUpdate.HOSP_PETORCA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 253).Count()
            itemToUpdate.HOSP_QUILLOTA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 230).Count()
            itemToUpdate.HOSP_CABILDO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 252).Count()
            itemToUpdate.HOSP_LIGUA += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 251).Count()
            itemToUpdate.HOSP_QUINTERO += filteredList.Where(Function(items) items.ID_PROCEDENCIA = 227).Count()
        End If


#End Region

#Region "Multilicador Conteo Examen"

        'Conteo Electrolitos
        Multiplicador_Conteo(74, "", result, 3, True)

        ' Lista para conteo Electrolitos en Orina
        Dim list_cf_elec As New List(Of Integer) From {408, 410}
        'Conteo Electrolitos en Orina
        Dim totalItems As Integer = list_cf_elec.Count
        Dim currentIndex As Integer = 0
        'Conteo Electrolitos en Orina
        For Each id_cf In list_cf_elec
            currentIndex += 1
            Dim num_multi As Integer = If(currentIndex = totalItems, 3, 1)
            Multiplicador_Conteo(id_cf, "0309012", result, num_multi, False)
        Next

#End Region

#Region "SETEAR A 0"
        'Dim list_codigos_setear As New List(Of Integer) From {731, 76, 941, 730, 664}
        'Setear_Cero(result, list_codigos_setear)
#End Region

        Return result
    End Function


#Region "HELPER"

    Public Shared Function Agregar_Contador_Por_Codigo(ByVal cod_cf As String, ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        For Each item In result.Where(Function(items) cod_cf = items.CF_COD_IRIS).ToList()
            'item.CANTIDAD += count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE += count_ate
                Case 209
                    item.USM_HDIURNO += count_ate
                Case 217
                    item.PERSONAL += count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 += count_ate
                Case 52
                    item.MQ2 += count_ate
                Case 57
                    item.MQ3 += count_ate
                Case 68
                    item.UAPQ_PABELLON += count_ate
                Case 55
                    item.PEDIATRIA += count_ate
                Case 59
                    item.NEONATOLOGIA += count_ate
                Case 60
                    item.UPC += count_ate
                Case 215
                    item.UCI_A += count_ate
                Case 214
                    item.UTI += count_ate
                Case 58
                    item.MATERNIDAD += count_ate
                Case 54
                    item.CMA += count_ate
                Case 56
                    item.HOSP_DOCIMI += count_ate
                Case 221
                    item.UEA_HOSP += count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA += count_ate
                Case 267
                    item.UEI += count_ate
                Case 223
                    item.SAUD += count_ate
                    ' UEGO
                Case 67
                    item.UEGO += count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO += count_ate
                Case 236
                    item.IMAGENOLOGIA += count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN += count_ate
                Case 243
                    item.CESFAM_AV_AC += count_ate
                Case 207
                    item.CESFAM_QUILPUE += count_ate
                Case 245
                    item.CESFAM_BELLOTO += count_ate
                Case 212
                    item.CONS_POMPEYA += count_ate
                Case 249
                    item.CECOSF_RETIRO += count_ate
                Case 210
                    item.CONS_BELLOTO += count_ate
                Case 64
                    item.CESFAM_VILLA_AL += count_ate
                Case 62
                    item.CESFAM_AMERICAS += count_ate
                Case 213
                    item.CONS_EDUARDO_FREI += count_ate
                Case 61
                    item.CESFAM_JUAN_BT += count_ate
                Case 271
                    item.CONS_AGUILAS += count_ate
                Case 213
                    item.SAPU_FREI += count_ate
                Case 219
                    item.CESFAM_LIMACHE += count_ate
                Case 238
                    item.CESFAM_OLMUE += count_ate
                Case 254
                    item.APS_CABILDO += count_ate
                Case 241
                    item.APS_HIJUELAS += count_ate
                Case 239
                    item.APS_CALERA += count_ate
                Case 255
                    item.APS_LIGUA += count_ate
                Case 240
                    item.APS_NOGALES += count_ate
                Case 256
                    item.APS_PETORCA += count_ate
                Case 228
                    item.HOSP_LIMACHE += count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE += count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE += count_ate
                Case 63
                    item.HOSP_PENBLANCA += count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE += count_ate
                Case 233
                    item.HOSP_CALERA += count_ate
                Case 253
                    item.HOSP_PETORCA += count_ate
                Case 230
                    item.HOSP_QUILLOTA += count_ate
                Case 252
                    item.HOSP_CABILDO += count_ate
                Case 251
                    item.HOSP_LIGUA += count_ate
                Case 227
                    item.HOSP_QUINTERO += count_ate
                Case 227
                    item.OTROS += count_ate
            End Select
        Next
    End Function

    Public Shared Function Agregar_Contador_Dup(ByVal ids_perfiles As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        ' Filtra los elementos en la lista finalResult y resetea sus valores
        ' Filtra todos los elementos en result que tengan un ID_CODIGO_FONASA incluido en ids_perfiles
        Dim itemsToUpdate = result.Where(Function(items) ids_perfiles.Contains(items.ID_CODIGO_FONASA)).ToList()

        ' Itera sobre cada item filtrado para actualizar valores individuales
        For Each item In itemsToUpdate
            'item.CANTIDAD += count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE = count_ate
                Case 209
                    item.USM_HDIURNO = count_ate
                Case 217
                    item.PERSONAL = count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 = count_ate
                Case 52
                    item.MQ2 = count_ate
                Case 57
                    item.MQ3 = count_ate
                Case 68
                    item.UAPQ_PABELLON = count_ate
                Case 55
                    item.PEDIATRIA = count_ate
                Case 59
                    item.NEONATOLOGIA = count_ate
                Case 60
                    item.UPC = count_ate
                Case 215
                    item.UCI_A = count_ate
                Case 214
                    item.UTI = count_ate
                Case 58
                    item.MATERNIDAD = count_ate
                Case 54
                    item.CMA = count_ate
                Case 56
                    item.HOSP_DOCIMI = count_ate
                Case 221
                    item.UEA_HOSP = count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA = count_ate
                Case 267
                    item.UEI = count_ate
                Case 223
                    item.SAUD = count_ate
                    ' UEGO
                Case 67
                    item.UEGO = count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO = count_ate
                Case 236
                    item.IMAGENOLOGIA = count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN = count_ate
                Case 243
                    item.CESFAM_AV_AC = count_ate
                Case 207
                    item.CESFAM_QUILPUE = count_ate
                Case 245
                    item.CESFAM_BELLOTO += count_ate
                Case 212
                    item.CONS_POMPEYA = count_ate
                Case 249
                    item.CECOSF_RETIRO = count_ate
                Case 210
                    item.CONS_BELLOTO = count_ate
                Case 64
                    item.CESFAM_VILLA_AL = count_ate
                Case 62
                    item.CESFAM_AMERICAS = count_ate
                Case 213
                    item.CONS_EDUARDO_FREI = count_ate
                Case 61
                    item.CESFAM_JUAN_BT = count_ate
                Case 271
                    item.CONS_AGUILAS = count_ate
                Case 213
                    item.SAPU_FREI = count_ate
                Case 219
                    item.CESFAM_LIMACHE = count_ate
                Case 238
                    item.CESFAM_OLMUE = count_ate
                Case 254
                    item.APS_CABILDO = count_ate
                Case 241
                    item.APS_HIJUELAS = count_ate
                Case 239
                    item.APS_CALERA = count_ate
                Case 255
                    item.APS_LIGUA = count_ate
                Case 240
                    item.APS_NOGALES = count_ate
                Case 256
                    item.APS_PETORCA = count_ate
                Case 228
                    item.HOSP_LIMACHE = count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE = count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE = count_ate
                Case 63
                    item.HOSP_PENBLANCA = count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE = count_ate
                Case 233
                    item.HOSP_CALERA = count_ate
                Case 253
                    item.HOSP_PETORCA = count_ate
                Case 230
                    item.HOSP_QUILLOTA = count_ate
                Case 252
                    item.HOSP_CABILDO = count_ate
                Case 251
                    item.HOSP_LIGUA = count_ate
                Case 227
                    item.HOSP_QUINTERO = count_ate
                Case 227
                    item.OTROS = count_ate
                Case Else
                    Debug.WriteLine("ID_PROC no coincide: " & id_proc)
            End Select

        Next
    End Function

    Public Shared Function Multiplicador_Conteo(ByVal id_cf As Integer, ByVal cf_cod As String, ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal num_multi As Integer, ByVal search_id_cf As Boolean)
        For Each item In result.Where(Function(items) If(search_id_cf, items.ID_CODIGO_FONASA = id_cf, items.CF_COD_IRIS = cf_cod)).ToList()
            item.CANTIDAD *= num_multi
            ' ATENCION ABIERTA
            item.CAE *= num_multi
            item.USM_HDIURNO *= num_multi
            item.PERSONAL *= num_multi
            ' ATENCION CERRADA
            item.MQ1 *= num_multi
            item.MQ2 *= num_multi
            item.MQ3 *= num_multi
            item.UAPQ_PABELLON *= num_multi
            item.PEDIATRIA *= num_multi
            item.NEONATOLOGIA *= num_multi
            item.UPC *= num_multi
            item.UCI_A *= num_multi
            item.UTI *= num_multi
            item.MATERNIDAD *= num_multi
            item.CMA *= num_multi
            item.HOSP_DOCIMI *= num_multi
            item.UEA_HOSP *= num_multi
            ' ATENCION UEA
            item.UEA *= num_multi
            item.UEI *= num_multi
            item.SAUD *= num_multi
            ' UEGO
            item.UEGO *= num_multi
            ' Unidad de apoyo
            item.ANATOMIA_PATO *= num_multi
            item.IMAGENOLOGIA *= num_multi
            'EXTRAHOSPITALARIO
            item.CESFAM_IVAN_MAN *= num_multi
            item.CESFAM_AV_AC *= num_multi
            item.CESFAM_QUILPUE *= num_multi
            item.CESFAM_BELLOTO *= num_multi
            item.CONS_POMPEYA *= num_multi
            item.CECOSF_RETIRO *= num_multi
            item.CONS_BELLOTO *= num_multi
            item.CESFAM_VILLA_AL *= num_multi
            item.CESFAM_AMERICAS *= num_multi
            item.CONS_EDUARDO_FREI *= num_multi
            item.CESFAM_JUAN_BT *= num_multi
            item.CONS_AGUILAS *= num_multi
            item.SAPU_FREI *= num_multi
            item.CESFAM_LIMACHE *= num_multi
            item.CESFAM_OLMUE *= num_multi
            item.APS_CABILDO *= num_multi
            item.APS_HIJUELAS *= num_multi
            item.APS_CALERA *= num_multi
            item.APS_LIGUA *= num_multi
            item.APS_NOGALES *= num_multi
            item.APS_PETORCA *= num_multi
            item.HOSP_LIMACHE *= num_multi
            item.HOSP_GERIATRICO_LMCHE *= num_multi
            item.HOSP_MODULAR_LMCHE *= num_multi
            item.HOSP_PENBLANCA *= num_multi
            item.HOSP_GUSTAVO_FRICKE *= num_multi
            item.HOSP_CALERA *= num_multi
            item.HOSP_PETORCA *= num_multi
            item.HOSP_QUILLOTA *= num_multi
            item.HOSP_CABILDO *= num_multi
            item.HOSP_LIGUA *= num_multi
            item.HOSP_QUINTERO *= num_multi
            item.OTROS *= num_multi
        Next

    End Function

    Public Shared Sub Condi_Cont_Perfil(ByVal priori_exa As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal exc_exa As List(Of Integer), ByVal List_Det_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal id_cf_ex As Integer)
        Dim ate_filtered = Contar_Perfil_Examen(priori_exa, List_Det_Ate, id_cf_ex)
        Dim list_proc_ex = Obtener_Procedencia_Ex(priori_exa, List_Det_Ate, id_cf_ex)
        Dim count_ex = list_proc_ex.Count
        If ate_filtered.Count() > 0 Then

            For Each item In ate_filtered
                Debug.WriteLine($"Item: {item}")

                Agrupar_VHS_Proc(exc_exa, result, 1, item.ID_PROCEDENCIA)
                Quitar_Contador_Dup(New List(Of Integer) From {
    item.ID_CODIGO_FONASA
}, result, 1, item.ID_PROCEDENCIA)
                Agregar_Contador(New List(Of Integer) From {
    item.ID_CODIGO_FONASA
}, result, 1, item.ID_PROCEDENCIA)
            Next

        End If
        'If (count_dup > 0) Then
        '    For Each id_proc_exa In list_proc_ex
        '        Quitar_Contador_Dup(priori_exa, result, count_dup, id_proc_exa)
        '        'Agregar_Contador_Dup(exc_exa, result, count_ex, id_proc_exa)
        '    Next
        'End If

    End Sub

    Public Shared Function Condicionar_Cont_Perfil(
                                          ByVal id_cf_perfil As Integer,
                                          ByVal List_Det_Ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA),
                                          ByVal priori_perfil As List(Of Integer), exc_perfil As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES))
        ' If para contar en caso de que esten examenes individuales en la misma atencion que el perfil bioq
        Dim count_perfil = Contar_Un_Perfil(priori_perfil, List_Det_Ate, id_cf_perfil)


        Dim priori_only_perfil = New List(Of Integer) From {id_cf_perfil}

        'count_perfil += Contar_Un_Perfil_Sin_Analitos(priori_perfil, List_Det_Ate, id_cf_perfil)
        Dim resultado = Contar_Un_Perfil_Sin_Analitos(priori_perfil, List_Det_Ate, id_cf_perfil)


        Dim count_prof_solo = Contar_Un_Perfil(exc_perfil, List_Det_Ate, id_cf_perfil)

        ' Esta llamada va a buscar los id que esten junto al perfil para que no haga la sumatoria ya que genera redundancia en el conteo
        Dim ids_next_perf = Buscar_Id_Junto_Perf(priori_perfil, List_Det_Ate, id_cf_perfil)

        ' if para obtener la procedencia de la atencion asociada
        Dim list_proc_prof = Obtener_Procedencia(priori_perfil, List_Det_Ate, id_cf_perfil)

        If list_proc_prof.Count = 0 Then
            ' Cambiar el parámetro priori_perfil a una nueva lista con id_cf_perfil
            Dim priori_only_proc = New List(Of Integer) From {id_cf_perfil}
            list_proc_prof = Obtener_Procedencia(priori_only_proc, List_Det_Ate, id_cf_perfil)
        End If

        ' Determinar cuál usar, si count_p_bioq o count_p_bio, basado en la condición
        Dim count_to_use As Integer = If(count_perfil > 0, count_perfil, count_prof_solo)

        ' Determinar cuál es el valor a agregar al contador (biogénico o bioquímico)
        Dim priori_to_use As List(Of Integer) = If(count_perfil > 0, priori_perfil, exc_perfil)

        ' Realizar la operación en base a la condición de count_p_bioq
        For Each item In resultado

            'Debug.WriteLine($" ITEM: {item}")
            If (id_cf_perfil = item.ID_CODIGO_FONASA) Then
                'Quitar_Contador_Dup(ids_next_perf, result, item.Conteo_Atenciones, item.ID_PROCEDENCIA)
                Agregar_Contador_Dup(priori_perfil, result, item.Conteo_Atenciones, item.ID_PROCEDENCIA)
            End If

            ' En caso contrario, solo se agregan los contadores
            'Agregar_Contador_Dup(priori_to_use, result, count_to_use, id_proc_prof)

        Next
    End Function
    Public Class ResultadoConteo
        Public Property ID_PROCEDENCIA As Integer
        Public Property Conteo_Examen As Integer
    End Class

    Public Shared Function Setear_Cero(Of T)(ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal list_codigos As IEnumerable(Of T))

        Dim itemsFiltrados As IEnumerable(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)

        If GetType(T) = GetType(Integer) Then
            Dim listInt = list_codigos.Cast(Of Integer)().ToList()
            itemsFiltrados = result.Where(Function(items) listInt.Contains(items.ID_CODIGO_FONASA))
        ElseIf GetType(T) = GetType(String) Then
            Dim listStr = list_codigos.Cast(Of String)().ToList()
            itemsFiltrados = result.Where(Function(items) listStr.Contains(items.CF_COD_IRIS.ToString()))
        End If


        For Each item In itemsFiltrados
            item.CANTIDAD = 0
            ' ATENCION ABIERTA
            item.CAE = 0
            item.USM_HDIURNO = 0
            item.PERSONAL = 0
            ' ATENCION CERRADA
            item.MQ1 = 0
            item.MQ2 = 0
            item.MQ3 = 0
            item.UAPQ_PABELLON = 0
            item.PEDIATRIA = 0
            item.NEONATOLOGIA = 0
            item.UPC = 0
            item.UCI_A = 0
            item.UTI = 0
            item.MATERNIDAD = 0
            item.CMA = 0
            item.HOSP_DOCIMI = 0
            item.UEA_HOSP = 0
            ' ATENCION UEA
            item.UEA = 0
            item.UEI = 0
            item.SAUD = 0
            ' UEGO
            item.UEGO = 0
            ' Unidad de apoyo
            item.ANATOMIA_PATO = 0
            item.IMAGENOLOGIA = 0
            'EXTRAHOSPITALARIO
            item.CESFAM_IVAN_MAN = 0
            item.CESFAM_AV_AC = 0
            item.CESFAM_QUILPUE = 0
            item.CESFAM_BELLOTO = 0
            item.CONS_POMPEYA = 0
            item.CECOSF_RETIRO = 0
            item.CONS_BELLOTO = 0
            item.CESFAM_VILLA_AL = 0
            item.CESFAM_AMERICAS = 0
            item.CONS_EDUARDO_FREI = 0
            item.CESFAM_JUAN_BT = 0
            item.CONS_AGUILAS = 0
            item.SAPU_FREI = 0
            item.CESFAM_LIMACHE = 0
            item.CESFAM_OLMUE = 0
            item.APS_CABILDO = 0
            item.APS_HIJUELAS = 0
            item.APS_CALERA = 0
            item.APS_LIGUA = 0
            item.APS_NOGALES = 0
            item.APS_PETORCA = 0
            item.HOSP_LIMACHE = 0
            item.HOSP_GERIATRICO_LMCHE = 0
            item.HOSP_MODULAR_LMCHE = 0
            item.HOSP_PENBLANCA = 0
            item.HOSP_GUSTAVO_FRICKE = 0
            item.HOSP_CALERA = 0
            item.HOSP_PETORCA = 0
            item.HOSP_QUILLOTA = 0
            item.HOSP_CABILDO = 0
            item.HOSP_LIGUA = 0
            item.HOSP_QUINTERO = 0
            item.OTROS = 0
        Next


    End Function

    Public Shared Function Agregar_Conteo_Analito(ByVal list_analitos As List(Of Integer), List_Conteo As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByRef object_exam As E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        For Each item In List_Conteo.Where(Function(items) list_analitos.Contains(items.ID_PRUEBA)).ToList()
            'object_exam.CANTIDAD = item.CANTIDAD
            object_exam.CAE = item.CAE
            object_exam.USM_HDIURNO = item.USM_HDIURNO
            object_exam.PERSONAL = item.PERSONAL
            object_exam.MQ1 = item.MQ1
            object_exam.MQ2 = item.MQ2
            object_exam.MQ3 = item.MQ3
            object_exam.UAPQ_PABELLON = item.UAPQ_PABELLON
            object_exam.PEDIATRIA = item.PEDIATRIA
            object_exam.NEONATOLOGIA = item.NEONATOLOGIA
            object_exam.UPC = item.UPC
            object_exam.UCI_A = item.UCI_A
            object_exam.UTI = item.UTI
            object_exam.MATERNIDAD = item.MATERNIDAD
            object_exam.CMA = item.CMA
            object_exam.HOSP_DOCIMI = item.HOSP_DOCIMI
            object_exam.UEA_HOSP = item.UEA_HOSP
            object_exam.UEA = item.UEA
            object_exam.UEI = item.UEI
            object_exam.SAUD = item.SAUD
            object_exam.UEGO = item.UEGO
            object_exam.ANATOMIA_PATO = item.ANATOMIA_PATO
            object_exam.IMAGENOLOGIA = item.IMAGENOLOGIA
            object_exam.CESFAM_IVAN_MAN = item.CESFAM_IVAN_MAN
            object_exam.CESFAM_AV_AC = item.CESFAM_AV_AC
            object_exam.CESFAM_QUILPUE = item.CESFAM_QUILPUE
            object_exam.CESFAM_BELLOTO = item.CESFAM_BELLOTO
            object_exam.CONS_POMPEYA = item.CONS_POMPEYA
            object_exam.CECOSF_RETIRO = item.CECOSF_RETIRO
            object_exam.CONS_BELLOTO = item.CONS_BELLOTO
            object_exam.CESFAM_VILLA_AL = item.CESFAM_VILLA_AL
            object_exam.CESFAM_AMERICAS = item.CESFAM_AMERICAS
            object_exam.CONS_EDUARDO_FREI = item.CONS_EDUARDO_FREI
            object_exam.CESFAM_JUAN_BT = item.CESFAM_JUAN_BT
            object_exam.CONS_AGUILAS = item.CONS_AGUILAS
            object_exam.SAPU_FREI = item.SAPU_FREI
            object_exam.CESFAM_LIMACHE = item.CESFAM_LIMACHE
            object_exam.CESFAM_OLMUE = item.CESFAM_OLMUE
            object_exam.APS_CABILDO = item.APS_CABILDO
            object_exam.APS_HIJUELAS = item.APS_HIJUELAS
            object_exam.APS_CALERA = item.APS_CALERA
            object_exam.APS_LIGUA = item.APS_LIGUA
            object_exam.APS_NOGALES = item.APS_NOGALES
            object_exam.APS_PETORCA = item.APS_PETORCA
            object_exam.HOSP_LIMACHE = item.HOSP_LIMACHE
            object_exam.HOSP_GERIATRICO_LMCHE = item.HOSP_GERIATRICO_LMCHE
            object_exam.HOSP_MODULAR_LMCHE = item.HOSP_MODULAR_LMCHE
            object_exam.HOSP_PENBLANCA = item.HOSP_PENBLANCA
            object_exam.HOSP_GUSTAVO_FRICKE = item.HOSP_GUSTAVO_FRICKE
            object_exam.HOSP_CALERA = item.HOSP_CALERA
            object_exam.HOSP_PETORCA = item.HOSP_PETORCA
            object_exam.HOSP_QUILLOTA = item.HOSP_QUILLOTA
            object_exam.HOSP_CABILDO = item.HOSP_CABILDO
            object_exam.HOSP_LIGUA = item.HOSP_LIGUA
            object_exam.HOSP_QUINTERO = item.HOSP_QUINTERO
            object_exam.OTROS = item.OTROS
        Next

    End Function

    Public Shared Function Agrupar_VHS_Proc(ByVal ids_perfiles As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        ' Filtra los elementos en la lista finalResult y resetea sus valores
        For Each item In result.Where(Function(items) ids_perfiles.Contains(items.ID_CODIGO_FONASA)).ToList()
            item.CANTIDAD += count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE += count_ate
                Case 209
                    item.USM_HDIURNO += count_ate
                Case 217
                    item.PERSONAL += count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 += count_ate
                Case 52
                    item.MQ2 += count_ate
                Case 57
                    item.MQ3 += count_ate
                Case 68
                    item.UAPQ_PABELLON += count_ate
                Case 55
                    item.PEDIATRIA += count_ate
                Case 59
                    item.NEONATOLOGIA += count_ate
                Case 60
                    item.UPC += count_ate
                Case 215
                    item.UCI_A += count_ate
                Case 214
                    item.UTI += count_ate
                Case 58
                    item.MATERNIDAD += count_ate
                Case 54
                    item.CMA += count_ate
                Case 56
                    item.HOSP_DOCIMI += count_ate
                Case 221
                    item.UEA_HOSP += count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA += count_ate
                Case 267
                    item.UEI += count_ate
                Case 223
                    item.SAUD += count_ate
                    ' UEGO
                Case 67
                    item.UEGO += count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO += count_ate
                Case 236
                    item.IMAGENOLOGIA += count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN += count_ate
                Case 243
                    item.CESFAM_AV_AC += count_ate
                Case 207
                    item.CESFAM_QUILPUE += count_ate
                Case 245
                    item.CESFAM_BELLOTO += count_ate
                Case 212
                    item.CONS_POMPEYA += count_ate
                Case 249
                    item.CECOSF_RETIRO += count_ate
                Case 210
                    item.CONS_BELLOTO += count_ate
                Case 64
                    item.CESFAM_VILLA_AL += count_ate
                Case 62
                    item.CESFAM_AMERICAS += count_ate
                Case 213
                    item.CONS_EDUARDO_FREI += count_ate
                Case 61
                    item.CESFAM_JUAN_BT += count_ate
                Case 271
                    item.CONS_AGUILAS += count_ate
                Case 213
                    item.SAPU_FREI += count_ate
                Case 219
                    item.CESFAM_LIMACHE += count_ate
                Case 238
                    item.CESFAM_OLMUE += count_ate
                Case 254
                    item.APS_CABILDO += count_ate
                Case 241
                    item.APS_HIJUELAS += count_ate
                Case 239
                    item.APS_CALERA += count_ate
                Case 255
                    item.APS_LIGUA += count_ate
                Case 240
                    item.APS_NOGALES += count_ate
                Case 256
                    item.APS_PETORCA += count_ate
                Case 228
                    item.HOSP_LIMACHE += count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE += count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE += count_ate
                Case 63
                    item.HOSP_PENBLANCA += count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE += count_ate
                Case 233
                    item.HOSP_CALERA += count_ate
                Case 253
                    item.HOSP_PETORCA += count_ate
                Case 230
                    item.HOSP_QUILLOTA += count_ate
                Case 252
                    item.HOSP_CABILDO += count_ate
                Case 251
                    item.HOSP_LIGUA += count_ate
                Case 227
                    item.HOSP_QUINTERO += count_ate
                Case 227
                    item.OTROS += count_ate
            End Select

        Next
    End Function

    Public Shared Function Quitar_Contador_Dup(ByVal ids_perfiles As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        ' Filtra los elementos en la lista finalResult y resetea sus valores
        For Each item In result.Where(Function(items) ids_perfiles.Contains(items.ID_CODIGO_FONASA)).ToList()
            'item.CANTIDAD -= count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE -= count_ate
                Case 209
                    item.USM_HDIURNO -= count_ate
                Case 217
                    item.PERSONAL -= count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 -= count_ate
                Case 52
                    item.MQ2 -= count_ate
                Case 57
                    item.MQ3 -= count_ate
                Case 68
                    item.UAPQ_PABELLON -= count_ate
                Case 55
                    item.PEDIATRIA -= count_ate
                Case 59
                    item.NEONATOLOGIA -= count_ate
                Case 60
                    item.UPC -= count_ate
                Case 215
                    item.UCI_A -= count_ate
                Case 214
                    item.UTI -= count_ate
                Case 58
                    item.MATERNIDAD -= count_ate
                Case 54
                    item.CMA -= count_ate
                Case 56
                    item.HOSP_DOCIMI -= count_ate
                Case 221
                    item.UEA_HOSP -= count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA -= count_ate
                Case 267
                    item.UEI -= count_ate
                Case 223
                    item.SAUD -= count_ate
                    ' UEGO
                Case 67
                    item.UEGO -= count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO -= count_ate
                Case 236
                    item.IMAGENOLOGIA -= count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN -= count_ate
                Case 243
                    item.CESFAM_AV_AC -= count_ate
                Case 207
                    item.CESFAM_QUILPUE -= count_ate
                Case 245
                    item.CESFAM_BELLOTO -= count_ate
                Case 212
                    item.CONS_POMPEYA -= count_ate
                Case 249
                    item.CECOSF_RETIRO -= count_ate
                Case 210
                    item.CONS_BELLOTO -= count_ate
                Case 64
                    item.CESFAM_VILLA_AL -= count_ate
                Case 62
                    item.CESFAM_AMERICAS -= count_ate
                Case 213
                    item.CONS_EDUARDO_FREI -= count_ate
                Case 61
                    item.CESFAM_JUAN_BT -= count_ate
                Case 271
                    item.CONS_AGUILAS -= count_ate
                Case 213
                    item.SAPU_FREI -= count_ate
                Case 219
                    item.CESFAM_LIMACHE -= count_ate
                Case 238
                    item.CESFAM_OLMUE -= count_ate
                Case 254
                    item.APS_CABILDO -= count_ate
                Case 241
                    item.APS_HIJUELAS -= count_ate
                Case 239
                    item.APS_CALERA -= count_ate
                Case 255
                    item.APS_LIGUA -= count_ate
                Case 240
                    item.APS_NOGALES -= count_ate
                Case 256
                    item.APS_PETORCA -= count_ate
                Case 228
                    item.HOSP_LIMACHE -= count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE -= count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE -= count_ate
                Case 63
                    item.HOSP_PENBLANCA -= count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE -= count_ate
                Case 233
                    item.HOSP_CALERA -= count_ate
                Case 253
                    item.HOSP_PETORCA -= count_ate
                Case 230
                    item.HOSP_QUILLOTA -= count_ate
                Case 252
                    item.HOSP_CABILDO -= count_ate
                Case 251
                    item.HOSP_LIGUA -= count_ate
                Case 227
                    item.HOSP_QUINTERO -= count_ate
                Case 227
                    item.OTROS -= count_ate
            End Select

        Next
    End Function

    Public Shared Function Agregar_Contador(ByVal ids_perfiles As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        ' Filtra los elementos en la lista finalResult y resetea sus valores
        For Each item In result.Where(Function(items) ids_perfiles.Contains(items.ID_CODIGO_FONASA)).ToList()
            'item.CANTIDAD += count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE += count_ate
                Case 209
                    item.USM_HDIURNO += count_ate
                Case 217
                    item.PERSONAL += count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 += count_ate
                Case 52
                    item.MQ2 += count_ate
                Case 57
                    item.MQ3 += count_ate
                Case 68
                    item.UAPQ_PABELLON += count_ate
                Case 55
                    item.PEDIATRIA += count_ate
                Case 59
                    item.NEONATOLOGIA += count_ate
                Case 60
                    item.UPC += count_ate
                Case 215
                    item.UCI_A += count_ate
                Case 214
                    item.UTI += count_ate
                Case 58
                    item.MATERNIDAD += count_ate
                Case 54
                    item.CMA += count_ate
                Case 56
                    item.HOSP_DOCIMI += count_ate
                Case 221
                    item.UEA_HOSP += count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA += count_ate
                Case 267
                    item.UEI += count_ate
                Case 223
                    item.SAUD += count_ate
                    ' UEGO
                Case 67
                    item.UEGO += count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO += count_ate
                Case 236
                    item.IMAGENOLOGIA += count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN += count_ate
                Case 243
                    item.CESFAM_AV_AC += count_ate
                Case 207
                    item.CESFAM_QUILPUE += count_ate
                Case 245
                    item.CESFAM_BELLOTO += count_ate
                Case 212
                    item.CONS_POMPEYA += count_ate
                Case 249
                    item.CECOSF_RETIRO += count_ate
                Case 210
                    item.CONS_BELLOTO += count_ate
                Case 64
                    item.CESFAM_VILLA_AL += count_ate
                Case 62
                    item.CESFAM_AMERICAS += count_ate
                Case 213
                    item.CONS_EDUARDO_FREI += count_ate
                Case 61
                    item.CESFAM_JUAN_BT += count_ate
                Case 271
                    item.CONS_AGUILAS += count_ate
                Case 213
                    item.SAPU_FREI += count_ate
                Case 219
                    item.CESFAM_LIMACHE += count_ate
                Case 238
                    item.CESFAM_OLMUE += count_ate
                Case 254
                    item.APS_CABILDO += count_ate
                Case 241
                    item.APS_HIJUELAS += count_ate
                Case 239
                    item.APS_CALERA += count_ate
                Case 255
                    item.APS_LIGUA += count_ate
                Case 240
                    item.APS_NOGALES += count_ate
                Case 256
                    item.APS_PETORCA += count_ate
                Case 228
                    item.HOSP_LIMACHE += count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE += count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE += count_ate
                Case 63
                    item.HOSP_PENBLANCA += count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE += count_ate
                Case 233
                    item.HOSP_CALERA += count_ate
                Case 253
                    item.HOSP_PETORCA += count_ate
                Case 230
                    item.HOSP_QUILLOTA += count_ate
                Case 252
                    item.HOSP_CABILDO += count_ate
                Case 251
                    item.HOSP_LIGUA += count_ate
                Case 227
                    item.HOSP_QUINTERO += count_ate
                Case 227
                    item.OTROS += count_ate
            End Select

        Next
    End Function

    Public Shared Function Agregar_Contador_Perf(ByVal ids_perfiles As List(Of Integer), ByRef result As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES), ByVal count_ate As Integer, ByVal id_proc As Integer)
        ' Filtra los elementos en la lista finalResult y resetea sus valores
        For Each item In result.Where(Function(items) ids_perfiles.Contains(items.ID_CODIGO_FONASA)).ToList()
            'item.CANTIDAD += count_ate
            Select Case id_proc
                ' ATENCION ABIERTA
                Case 51, 216
                    item.CAE += count_ate
                Case 209
                    item.USM_HDIURNO += count_ate
                Case 217
                    item.PERSONAL += count_ate
                    ' ATENCION CERRADA
                Case 53
                    item.MQ1 += count_ate
                Case 52
                    item.MQ2 += count_ate
                Case 57
                    item.MQ3 += count_ate
                Case 68
                    item.UAPQ_PABELLON += count_ate
                Case 55
                    item.PEDIATRIA += count_ate
                Case 59
                    item.NEONATOLOGIA += count_ate
                Case 60
                    item.UPC += count_ate
                Case 215
                    item.UCI_A += count_ate
                Case 214
                    item.UTI += count_ate
                Case 58
                    item.MATERNIDAD += count_ate
                Case 54
                    item.CMA += count_ate
                Case 56
                    item.HOSP_DOCIMI += count_ate
                Case 221
                    item.UEA_HOSP += count_ate
                    ' ATENCION UEA
                Case 66
                    item.UEA += count_ate
                Case 267
                    item.UEI += count_ate
                Case 223
                    item.SAUD += count_ate
                    ' UEGO
                Case 67
                    item.UEGO += count_ate
                    ' Unidad de apoyo
                Case 164
                    item.ANATOMIA_PATO += count_ate
                Case 236
                    item.IMAGENOLOGIA += count_ate
                    'EXTRAHOSPITALARIO
                Case 244
                    item.CESFAM_IVAN_MAN += count_ate
                Case 243
                    item.CESFAM_AV_AC += count_ate
                Case 207
                    item.CESFAM_QUILPUE += count_ate
                Case 245
                    item.CESFAM_BELLOTO += count_ate
                Case 212
                    item.CONS_POMPEYA += count_ate
                Case 249
                    item.CECOSF_RETIRO += count_ate
                Case 210
                    item.CONS_BELLOTO += count_ate
                Case 64
                    item.CESFAM_VILLA_AL += count_ate
                Case 62
                    item.CESFAM_AMERICAS += count_ate
                Case 213
                    item.CONS_EDUARDO_FREI += count_ate
                Case 61
                    item.CESFAM_JUAN_BT += count_ate
                Case 271
                    item.CONS_AGUILAS += count_ate
                Case 213
                    item.SAPU_FREI += count_ate
                Case 219
                    item.CESFAM_LIMACHE += count_ate
                Case 238
                    item.CESFAM_OLMUE += count_ate
                Case 254
                    item.APS_CABILDO += count_ate
                Case 241
                    item.APS_HIJUELAS += count_ate
                Case 239
                    item.APS_CALERA += count_ate
                Case 255
                    item.APS_LIGUA += count_ate
                Case 240
                    item.APS_NOGALES += count_ate
                Case 256
                    item.APS_PETORCA += count_ate
                Case 228
                    item.HOSP_LIMACHE += count_ate
                Case 229
                    item.HOSP_GERIATRICO_LMCHE += count_ate
                Case 232
                    item.HOSP_MODULAR_LMCHE += count_ate
                Case 63
                    item.HOSP_PENBLANCA += count_ate
                Case 220
                    item.HOSP_GUSTAVO_FRICKE += count_ate
                Case 233
                    item.HOSP_CALERA += count_ate
                Case 253
                    item.HOSP_PETORCA += count_ate
                Case 230
                    item.HOSP_QUILLOTA += count_ate
                Case 252
                    item.HOSP_CABILDO += count_ate
                Case 251
                    item.HOSP_LIGUA += count_ate
                Case 227
                    item.HOSP_QUINTERO += count_ate
                Case 227
                    item.OTROS += count_ate
            End Select
        Next
    End Function

    Public Shared Function Contar_Doble_Perfiles(ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer, ByVal ID_COD_B As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_ATENCION Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_B)
                         Select ID_ATENCION

        Return ate_codigo.Count()
    End Function

    Public Shared Function Contar_Un_Perfil(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_ATENCION Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Group.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
                         Select ID_ATENCION
        Return ate_codigo.Count()
    End Function

    Public Shared Function Contar_Perfil_Examen(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer)
        ' Filtrar primero las atenciones que contienen ID_COD_A
        Dim atencionesConID_COD_A = list_det_ate.Where(Function(d) d.ID_CODIGO_FONASA = ID_COD_A).Select(Function(d) d.ID_ATENCION).Distinct()

        ' Buscar las atenciones que también contienen un ID de priori_p y crear los objetos DetalleAtencion
        Dim resultados = From atencion In atencionesConID_COD_A
                         From detalle In list_det_ate
                         Where detalle.ID_ATENCION = atencion AndAlso priori_p.Contains(detalle.ID_CODIGO_FONASA)
                         Select New With {
                         .ID_ATENCION = detalle.ID_ATENCION,
                         .ID_CODIGO_FONASA = detalle.ID_CODIGO_FONASA,
                         .ID_PROCEDENCIA = detalle.ID_PROCEDENCIA
                     }

        Return resultados.Distinct().ToList()
    End Function

    Public Shared Function Contar_Un_Perfil_Sin_Analitos(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer) As IEnumerable(Of Object)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_agrupada = From dato In list_det_ate
                           Group By dato.ID_PROCEDENCIA, dato.ID_CODIGO_FONASA Into Grupo = Group
                           Where Grupo.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Not Grupo.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
                           Select New With {
                             ID_PROCEDENCIA,
                             .Conteo_Atenciones = Grupo.Select(Function(g) g.ID_ATENCION).Distinct().Count(),
                             .ID_CODIGO_FONASA = ID_CODIGO_FONASA
                               }
        Return ate_agrupada
    End Function

    Public Shared Function Buscar_Id_Junto_Perf(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer) As List(Of Integer)
        ' Uso de LINQ para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_ATENCION Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                           Group.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
                         Select New With {
                         .ID_ATENCION = ID_ATENCION,
                         .ID_CODIGO_FONASA = (From d In Group
                                              Where d.ID_CODIGO_FONASA <> ID_COD_A
                                              Select d.ID_CODIGO_FONASA).Distinct().ToList()
                     }

        ' Filtrar solo aquellos códigos de Fonasa que están junto al código 664 en la misma atención
        Dim resultados = ate_codigo.SelectMany(Function(x) x.ID_CODIGO_FONASA).
                              Where(Function(cod) priori_p.Contains(cod)).ToList()

        Return resultados
    End Function

    Public Shared Function Contar_Un_Perfil_2(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_CODIGO_FONASA Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Group.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
                         Select ID_CODIGO_FONASA

        Return ate_codigo.Count()
    End Function

    Public Shared Function Contar_Por_Codigo(ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal COD_A As String, ByVal COD_B As String) As IEnumerable(Of ResultadoConteo)
        Dim atenciones = From dato In list_det_ate
                         Group By dato.ID_PROCEDENCIA Into Grupo = Group
                         Let Conteo_Examen = Grupo.Count(Function(d) d.CF_COD = COD_A OrElse d.CF_COD = COD_B)
                         Where Conteo_Examen > 0
                         Select New ResultadoConteo With {
                         .ID_PROCEDENCIA = ID_PROCEDENCIA,
                         .Conteo_Examen = Conteo_Examen
                     }
        Return atenciones
    End Function

    Public Shared Function Obtener_Procedencia_Dup(ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer, ByVal ID_COD_B As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_PROCEDENCIA Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_B)
                         Select ID_PROCEDENCIA

        Return ate_codigo.ToList()
    End Function

    Public Shared Function Obtener_Proc_Dup(ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer, ByVal ID_COD_B As Integer) As IEnumerable(Of Object)
        ' Uso de LINQ para agrupar la lista de atenciones
        Dim agrupado = From dato In list_det_ate
                       Group By dato.ID_PROCEDENCIA Into Grupo = Group
                       Let AtencionesDuplicadas = (From d In Grupo
                                                   Where d.ID_CODIGO_FONASA = ID_COD_A OrElse d.ID_CODIGO_FONASA = ID_COD_B
                                                   Group By d.ID_ATENCION Into g = Group
                                                   Where g.Count() > 1 ' Asegura que ambos códigos estén presentes en la misma atención
                                                   Select g.FirstOrDefault().ID_ATENCION) ' Selecciona directamente el ID_ATENCION
                       Where AtencionesDuplicadas.Any() ' Solo incluir grupos con atenciones duplicadas
                       Select New With {
                       .ID_PROCEDENCIA = ID_PROCEDENCIA,
                       .Conteo_Duplicados = AtencionesDuplicadas.Count()
                   }

        Return agrupado
    End Function

    Public Shared Function Obtener_Procedencia(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_PROCEDENCIA Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
                             Group.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
                         Select ID_PROCEDENCIA
        'Debug.WriteLine($" Proc: {ate_codigo(0)}")
        Return ate_codigo.ToList()
    End Function

    Public Shared Function Obtener_Procedencia_Ex(ByVal priori_p As List(Of Integer), ByVal list_det_ate As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), ByVal ID_COD_A As Integer)
        ' Uso de linq para agrupar la lista de atenciones
        Dim ate_codigo = From dato In list_det_ate
                         Group By dato.ID_PROCEDENCIA Into Group
                         Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A)
                         Select ID_PROCEDENCIA
        '                 Where Group.Any(Function(d) d.ID_CODIGO_FONASA = ID_COD_A) AndAlso
        '                     Group.Any(Function(d) priori_p.Contains(d.ID_CODIGO_FONASA))
        '                Select ID_PROCEDENCIA  
        ''Debug.WriteLine($" Proc: {ate_codigo(0)}")
        Return ate_codigo.ToList()
    End Function

    Public Shared Sub RestarSiMayorACero(ByRef valor As Integer, ByVal cantidad As Integer)
        If valor > 0 Then
            valor -= cantidad
            If valor < 0 Then
                valor = 0
            End If
        End If
    End Sub

    ' Este codigo se puede utilizar para optimizar el proceso de exclusion de cada perfil para eliminar la redundancia de codigo.
    Public Shared Function Filtrar_Perfiles(grouped_list As IEnumerable(Of IGrouping(Of Integer, E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)), lista_priori As List(Of Integer), id_cf_exc As Integer)
        Dim total_codigo As Integer = 0

        Dim lista_filtrada = grouped_list.SelectMany(Function(group)
                                                         Dim tiene_priori = group.Any(Function(item) lista_priori.Contains(item.ID_CODIGO_FONASA))

                                                         Dim tiene_cf = group.Any(Function(item) item.ID_CODIGO_FONASA = id_cf_exc)
                                                         If tiene_priori AndAlso tiene_cf Then
                                                             total_codigo += group.Count(Function(item) item.ID_CODIGO_FONASA = id_cf_exc)

                                                             Return group.Where(Function(item) lista_priori.Contains(item.ID_CODIGO_FONASA) AndAlso item.ID_CODIGO_FONASA <> id_cf_exc).ToList()
                                                         ElseIf tiene_cf AndAlso Not tiene_priori Then
                                                             total_codigo += group.Count(Function(item) item.ID_CODIGO_FONASA = id_cf_exc)
                                                             Return group.Where(Function(item) item.ID_CODIGO_FONASA = id_cf_exc).ToList()
                                                         Else
                                                             Return group.Where(Function(item) lista_priori.Contains(item.ID_CODIGO_FONASA)).ToList()
                                                         End If
                                                     End Function).ToList()
    End Function

    '' Funcion para reuni
    'Public Shared Function Reset_Contador(ByRef examen As E_IRIS_WEBF_BUSCA_CANT_EXAMENES) As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
    '    examen.CANTIDAD = 0
    '    examen.CAE = 0
    '    examen.USM_HDIURNO = 0
    '    examen.PERSONAL = 0
    '    examen.TOTAL_ABIERTA = 0
    '    examen.MQ1 = 0
    '    examen.MQ2 = 0
    '    examen.MQ3 = 0
    '    examen.UAPQ_PABELLON = 0
    '    examen.PEDIATRIA = 0
    '    examen.NEONATOLOGIA = 0
    '    examen.UPC = 0
    '    examen.UCI_A = 0
    '    examen.UTI = 0
    '    examen.MATERNIDAD = 0
    '    examen.CMA = 0
    '    examen.HOSP_DOCIMI = 0
    '    examen.UEA_HOSP = 0
    '    examen.TOTAL_CERRADA = 0
    '    examen.UEA = 0
    '    examen.UEI = 0
    '    examen.SAUD = 0
    '    examen.TOTAL_UE = 0
    '    examen.UEGO = 0
    '    examen.ANATOMIA_PATO = 0
    '    examen.IMAGENOLOGIA = 0
    '    examen.TOTAL_UNIDAD_APOYO = 0
    '    examen.CESFAM_IVAN_MAN = 0
    '    examen.CESFAM_AV_AC = 0
    '    examen.CESFAM_QUILPUE = 0
    '    examen.CESFAM_BELLOTO = 0
    '    examen.CONS_POMPEYA = 0
    '    examen.CECOSF_RETIRO = 0
    '    examen.CONS_BELLOTO = 0
    '    examen.CESFAM_VILLA_AL = 0
    '    examen.CESFAM_AMERICAS = 0
    '    examen.CONS_EDUARDO_FREI = 0
    '    examen.CESFAM_JUAN_BT = 0
    '    examen.CONS_AGUILAS = 0
    '    examen.SAPU_FREI = 0
    '    examen.CESFAM_LIMACHE = 0
    '    examen.CESFAM_OLMUE = 0
    '    examen.APS_CABILDO = 0
    '    examen.APS_HIJUELAS = 0
    '    examen.APS_CALERA = 0
    '    examen.APS_LIGUA = 0
    '    examen.APS_NOGALES = 0
    '    examen.APS_PETORCA = 0
    '    examen.HOSP_LIMACHE = 0
    '    examen.HOSP_GERIATRICO_LMCHE = 0
    '    examen.HOSP_MODULAR_LMCHE = 0
    '    examen.HOSP_PENBLANCA = 0
    '    examen.HOSP_GUSTAVO_FRICKE = 0
    '    examen.HOSP_CALERA = 0
    '    examen.HOSP_PETORCA = 0
    '    examen.HOSP_QUILLOTA = 0
    '    examen.HOSP_CABILDO = 0
    '    examen.HOSP_LIGUA = 0
    '    examen.HOSP_QUINTERO = 0
    '    examen.OTROS = 0
    '    examen.TOTAL_EXTRA = 0

    '    Return examen
    'End Function

    'Public Shared Function Contador_Proc(examen As E_IRIS_WEBF_BUSCA_CANT_EXAMENES, totalCodigo As Integer, listaFiltrada As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), grouped_list As IEnumerable(Of IGrouping(Of Integer, E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)), id_cf As Integer) As E_IRIS_WEBF_BUSCA_CANT_EXAMENES


    '    'examen.CANTIDAD = totalCodigo

    '    ' Atencion abierta
    '    Dim cae As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 216)).Count()
    '    Dim usm As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 209).Count()
    '    Dim personal As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 1 AndAlso item.ID_PROCEDENCIA = 217).Count()
    '    Dim total_abierta As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 1 AndAlso (item.ID_PROCEDENCIA = 51 Or item.ID_PROCEDENCIA = 209 Or item.ID_PROCEDENCIA = 217)).Count()
    '    ' Atencion cerrada
    '    Dim mq1 As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 53).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim mq2 As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 52).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim mq3 As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 57).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim uapq As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 68).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim pediatria As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 55).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim neonato As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 59).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim upc As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 60).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim uci As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 215).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim uti As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 214).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim maternidad As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 58).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cma As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 54).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_docimi As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 56).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim uea_hosp As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso item.ID_PROCEDENCIA = 221).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim total_cerrada As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 2 AndAlso (item.ID_PROCEDENCIA = 53 Or item.ID_PROCEDENCIA = 52 Or item.ID_PROCEDENCIA = 57 Or item.ID_PROCEDENCIA = 68 Or item.ID_PROCEDENCIA = 55 Or item.ID_PROCEDENCIA = 59 Or
    '                                                       item.ID_PROCEDENCIA = 60 Or
    '                                                       item.ID_PROCEDENCIA = 215 Or
    '                                                       item.ID_PROCEDENCIA = 214 Or
    '                                                       item.ID_PROCEDENCIA = 58 Or
    '                                                       item.ID_PROCEDENCIA = 54 Or
    '                                                       item.ID_PROCEDENCIA = 56 Or
    '                                                       item.ID_PROCEDENCIA = 221)).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 53 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    ' Atencion UE
    '    Dim uea As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 66).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 66 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim uei As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 267).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 267 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim saud As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 223).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 223 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim total_ue As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 66 Or item.ID_PROCEDENCIA = 267 Or item.ID_PROCEDENCIA = 223).Count()
    '    ' Atencion UEGO
    '    Dim uego As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 67).Count() + +grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 67 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    ' Atencion UNIDAD DE APOYO
    '    Dim ana_pato As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 164).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 164 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim imageno As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 236).Count() + +grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 236 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim total_uni_a As Integer = listaFiltrada.Where(Function(item) item.ID_PROCEDENCIA = 164 Or item.ID_PROCEDENCIA = 236).Count()


    '    ' Atencion EXTRA HOSPITALARIO

    '    Dim cesfam_ivan_man As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 244).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 244 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_av_ac As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 243).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 243 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_quilpue As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 207).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 207 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_belloto As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 245).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 245 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cons_pompeya As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 212).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 212 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cecosf_retiro As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 249).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 249 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cons_belloto As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 210).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 210 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_villa_al As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 64).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 64 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_americas As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 62).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 62 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cons_eduardo_frei As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 213 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_juan_bt As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 61).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 61 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cons_aguilas As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 271).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 271 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim sapu_frei As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 213).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 213 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_limache As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 219).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 219 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim cesfam_olmue As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 238).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 238 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_cabildo As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 254).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 254 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_hijuelas As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 241).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 241 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_calera As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 239).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 239 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_ligua As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 255).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 255 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_nogales As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 240).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 240 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim aps_petorca As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 256).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 256 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_limache As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 228).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 228 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_geriatrico_lmche As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 229).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 229 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_modular_lmche As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 232).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 232 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_penblanca As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 63).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 63 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_gustavo_fricke As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 220).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 220 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_calera As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 233).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 233 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_petorca As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 253).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 253 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_quillota As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 230).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 230 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_cabildo As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 252).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 252 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_ligua As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 251).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 251 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim hosp_quintero As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 227 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()
    '    Dim otros As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso item.ID_PROCEDENCIA = 227).Count() + grouped_list.Where(Function(item) item.Where(Function(ite) ite.ID_PROCEDENCIA = 227 AndAlso ite.ID_TIPO_PAC = 2 AndAlso ite.ID_CODIGO_FONASA = id_cf).Count()).Count()

    '    Dim total_extra As Integer = listaFiltrada.Where(Function(item) item.ID_TIPO_PAC = 3 AndAlso (
    'item.ID_PROCEDENCIA = 244 Or
    'item.ID_PROCEDENCIA = 243 Or
    'item.ID_PROCEDENCIA = 207 Or
    'item.ID_PROCEDENCIA = 245 Or
    'item.ID_PROCEDENCIA = 212 Or
    'item.ID_PROCEDENCIA = 249 Or
    'item.ID_PROCEDENCIA = 210 Or
    'item.ID_PROCEDENCIA = 64 Or
    'item.ID_PROCEDENCIA = 62 Or
    'item.ID_PROCEDENCIA = 213 Or
    'item.ID_PROCEDENCIA = 61 Or
    'item.ID_PROCEDENCIA = 271 Or
    'item.ID_PROCEDENCIA = 213 Or
    'item.ID_PROCEDENCIA = 219 Or
    'item.ID_PROCEDENCIA = 238 Or
    'item.ID_PROCEDENCIA = 254 Or
    'item.ID_PROCEDENCIA = 241 Or
    'item.ID_PROCEDENCIA = 239 Or
    'item.ID_PROCEDENCIA = 255 Or
    'item.ID_PROCEDENCIA = 240 Or
    'item.ID_PROCEDENCIA = 256 Or
    'item.ID_PROCEDENCIA = 228 Or
    'item.ID_PROCEDENCIA = 229 Or
    'item.ID_PROCEDENCIA = 232 Or
    'item.ID_PROCEDENCIA = 63 Or
    'item.ID_PROCEDENCIA = 220 Or
    'item.ID_PROCEDENCIA = 233 Or
    'item.ID_PROCEDENCIA = 253 Or
    'item.ID_PROCEDENCIA = 230 Or
    'item.ID_PROCEDENCIA = 252 Or
    'item.ID_PROCEDENCIA = 251 Or
    'item.ID_PROCEDENCIA = 227
    '    )).Count()

    '    If (cae > 0) Then
    '        examen.CAE = cae
    '        'examen.CAE -= totalCodigo
    '    End If

    '    If usm > 0 Then
    '        examen.USM_HDIURNO = usm
    '    End If
    '    If personal > 0 Then

    '        examen.PERSONAL = personal
    '    End If

    '    If total_abierta Then
    '        examen.TOTAL_ABIERTA = total_abierta
    '    End If

    '    If (mq1 > 0) Then
    '        examen.MQ1 = mq1
    '    End If

    '    If (mq2 > 0) Then
    '        examen.MQ2 = mq2
    '    End If

    '    If (mq3 > 0) Then
    '        examen.MQ3 = mq3
    '    End If

    '    If (uapq > 0) Then
    '        examen.UAPQ_PABELLON = uapq
    '    End If

    '    If (pediatria > 0) Then
    '        examen.PEDIATRIA = pediatria
    '    End If

    '    If (neonato > 0) Then
    '        examen.NEONATOLOGIA = neonato
    '    End If

    '    If (upc > 0) Then
    '        examen.UPC = upc
    '    End If

    '    If (uci > 0) Then
    '        examen.UCI_A = uci
    '    End If

    '    If (uti > 0) Then
    '        examen.UTI = uti
    '    End If

    '    If (maternidad > 0) Then
    '        examen.MATERNIDAD = maternidad
    '    End If

    '    If (cma > 0) Then
    '        examen.CMA = cma
    '    End If

    '    If (hosp_docimi > 0) Then
    '        examen.HOSP_DOCIMI = hosp_docimi
    '    End If

    '    If (uea_hosp > 0) Then
    '        examen.UEA_HOSP = uea_hosp
    '    End If

    '    If (total_cerrada > 0) Then
    '        examen.TOTAL_CERRADA = total_cerrada
    '    End If

    '    If (uea > 0) Then
    '        examen.UEA = uea
    '    End If

    '    If (uei > 0) Then
    '        examen.UEI = uei
    '    End If

    '    If (saud > 0) Then
    '        examen.SAUD = saud
    '    End If

    '    If (total_ue > 0) Then
    '        examen.TOTAL_UE = total_ue
    '    End If

    '    If (uego > 0) Then
    '        examen.UEGO = uego
    '    End If

    '    If (ana_pato > 0) Then
    '        examen.ANATOMIA_PATO = ana_pato
    '    End If

    '    If (imageno > 0) Then
    '        examen.IMAGENOLOGIA = imageno
    '    End If

    '    If (total_uni_a > 0) Then
    '        examen.TOTAL_UNIDAD_APOYO = total_uni_a
    '    End If

    '    If (cesfam_ivan_man > 0) Then
    '        examen.CESFAM_IVAN_MAN = cesfam_ivan_man
    '    End If

    '    If (cesfam_quilpue > 0) Then
    '        examen.CESFAM_QUILPUE = cesfam_quilpue
    '    End If

    '    If (cesfam_belloto > 0) Then
    '        examen.CESFAM_BELLOTO = cesfam_belloto
    '    End If

    '    If (cons_pompeya > 0) Then
    '        examen.CONS_POMPEYA = cons_pompeya
    '    End If

    '    If (cecosf_retiro > 0) Then
    '        examen.CECOSF_RETIRO = cecosf_retiro
    '    End If

    '    If (cons_belloto > 0) Then
    '        examen.CONS_BELLOTO = cons_belloto
    '    End If

    '    If (cesfam_villa_al > 0) Then
    '        examen.CESFAM_VILLA_AL = cesfam_villa_al
    '    End If

    '    If (cesfam_americas > 0) Then
    '        examen.CESFAM_AMERICAS = cesfam_americas
    '    End If

    '    If (cons_eduardo_frei > 0) Then
    '        examen.CONS_EDUARDO_FREI = cons_eduardo_frei
    '    End If

    '    If (cesfam_juan_bt > 0) Then
    '        examen.CESFAM_JUAN_BT = cesfam_juan_bt
    '    End If

    '    If (cons_aguilas > 0) Then
    '        examen.CONS_AGUILAS = cons_aguilas
    '    End If

    '    If (sapu_frei > 0) Then
    '        examen.SAPU_FREI = sapu_frei
    '    End If

    '    If (cesfam_limache > 0) Then
    '        examen.CESFAM_LIMACHE = cesfam_limache
    '    End If

    '    If (cesfam_olmue > 0) Then
    '        examen.CESFAM_OLMUE = cesfam_olmue
    '    End If

    '    If (aps_cabildo > 0) Then
    '        examen.APS_CABILDO = aps_cabildo
    '    End If

    '    If (aps_hijuelas > 0) Then
    '        examen.APS_HIJUELAS = aps_hijuelas
    '    End If

    '    If (aps_calera > 0) Then
    '        examen.APS_CALERA = aps_calera
    '    End If

    '    If (aps_ligua > 0) Then
    '        examen.APS_LIGUA = aps_ligua
    '    End If

    '    If (aps_nogales > 0) Then
    '        examen.APS_NOGALES = aps_nogales
    '    End If

    '    If (aps_petorca > 0) Then
    '        examen.APS_PETORCA = aps_petorca
    '    End If

    '    If (hosp_limache > 0) Then
    '        examen.HOSP_LIMACHE = hosp_limache
    '    End If

    '    If (hosp_geriatrico_lmche > 0) Then
    '        examen.HOSP_GERIATRICO_LMCHE = hosp_geriatrico_lmche
    '    End If

    '    If (hosp_modular_lmche > 0) Then
    '        examen.HOSP_MODULAR_LMCHE = hosp_modular_lmche
    '    End If

    '    If (hosp_penblanca > 0) Then
    '        examen.HOSP_PENBLANCA = hosp_penblanca
    '    End If

    '    If (hosp_gustavo_fricke > 0) Then
    '        examen.HOSP_GUSTAVO_FRICKE = hosp_gustavo_fricke
    '    End If

    '    If (hosp_calera > 0) Then
    '        examen.HOSP_CALERA = hosp_calera
    '    End If

    '    If (hosp_petorca > 0) Then
    '        examen.HOSP_PETORCA = hosp_petorca
    '    End If

    '    If (hosp_quillota > 0) Then
    '        examen.HOSP_QUILLOTA = hosp_quillota
    '    End If

    '    If (hosp_cabildo > 0) Then
    '        examen.HOSP_CABILDO = hosp_cabildo
    '    End If

    '    If (hosp_ligua > 0) Then
    '        examen.HOSP_LIGUA = hosp_ligua
    '    End If

    '    If (hosp_quintero > 0) Then
    '        examen.HOSP_QUINTERO = hosp_quintero
    '    End If

    '    If (otros > 0) Then
    '        examen.OTROS = otros
    '    End If

    '    If (total_extra > 0) Then
    '        examen.TOTAL_EXTRA = total_extra
    '    End If

    '    Return examen
    'End Function

    ' Esta funcion de aqui es la que se usa para asignar a cada propiedad del objeto el contador segun corresponda
    Public Shared Function Contador_Por_Proc_Exa(examen As E_IRIS_WEBF_BUSCA_CANT_EXAMENES, listaFiltrada As IEnumerable(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA), grouped_list As IEnumerable(Of IGrouping(Of Integer, E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_FECHA)), id_cf As Integer) As E_IRIS_WEBF_BUSCA_CANT_EXAMENES
        ' Función auxiliar para contar registros filtrados
        Dim CountByCriteria As Func(Of Integer, Integer, Integer) =
        Function(idTipoPac, idProcedencia) listaFiltrada.Count(Function(item) item.ID_TIPO_PAC = idTipoPac AndAlso item.ID_PROCEDENCIA = idProcedencia) +
            grouped_list.Count(Function(group) group.Count(Function(item) item.ID_PROCEDENCIA = idProcedencia AndAlso item.ID_TIPO_PAC = idTipoPac AndAlso item.ID_CODIGO_FONASA = id_cf))

        examen = New E_IRIS_WEBF_BUSCA_CANT_EXAMENES

        ' Atencion abierta
        examen.CAE = CountByCriteria(1, 51) + CountByCriteria(1, 216)
        examen.USM_HDIURNO = CountByCriteria(1, 209)
        examen.PERSONAL = CountByCriteria(1, 217)
        examen.TOTAL_ABIERTA = examen.CAE + examen.USM_HDIURNO + examen.PERSONAL

        ' Atencion cerrada
        examen.MQ1 = CountByCriteria(2, 53)
        examen.MQ2 = CountByCriteria(2, 52)
        examen.MQ3 = CountByCriteria(2, 57)
        examen.UAPQ_PABELLON = CountByCriteria(2, 68)
        examen.PEDIATRIA = CountByCriteria(2, 55)
        examen.NEONATOLOGIA = CountByCriteria(2, 59)
        examen.UPC = CountByCriteria(2, 60)
        examen.UCI_A = CountByCriteria(2, 215)
        examen.UTI = CountByCriteria(2, 214)
        examen.MATERNIDAD = CountByCriteria(2, 58)
        examen.CMA = CountByCriteria(2, 54)
        examen.HOSP_DOCIMI = CountByCriteria(2, 56)
        examen.UEA_HOSP = CountByCriteria(2, 221)
        examen.TOTAL_CERRADA = examen.MQ1 + examen.MQ2 + examen.MQ3 + examen.UAPQ_PABELLON + examen.PEDIATRIA + examen.NEONATOLOGIA + examen.UPC + examen.UCI_A + examen.UTI + examen.MATERNIDAD + examen.CMA + examen.HOSP_DOCIMI + examen.UEA_HOSP

        ' Atencion UE
        examen.UEA = CountByCriteria(2, 66)
        examen.UEI = CountByCriteria(2, 267)
        examen.SAUD = CountByCriteria(2, 223)
        examen.TOTAL_UE = examen.UEA + examen.UEI + examen.SAUD

        ' Atencion UEGO
        examen.UEGO = CountByCriteria(2, 67)

        ' Atencion UNIDAD DE APOYO
        examen.ANATOMIA_PATO = CountByCriteria(2, 164)
        examen.IMAGENOLOGIA = CountByCriteria(2, 236)
        examen.TOTAL_UNIDAD_APOYO = examen.ANATOMIA_PATO + examen.IMAGENOLOGIA

        ' Atencion EXTRA HOSPITALARIO
        examen.CESFAM_IVAN_MAN = CountByCriteria(3, 244)
        examen.CESFAM_AV_AC = CountByCriteria(3, 243)
        examen.CESFAM_QUILPUE = CountByCriteria(3, 207)
        examen.CESFAM_BELLOTO = CountByCriteria(3, 245)
        examen.CONS_POMPEYA = CountByCriteria(3, 212)
        examen.CECOSF_RETIRO = CountByCriteria(3, 249)
        examen.CONS_BELLOTO = CountByCriteria(3, 210)
        examen.CESFAM_VILLA_AL = CountByCriteria(3, 64)
        examen.CESFAM_AMERICAS = CountByCriteria(3, 62)
        examen.CONS_EDUARDO_FREI = CountByCriteria(3, 213)
        examen.CESFAM_JUAN_BT = CountByCriteria(3, 61)
        examen.CONS_AGUILAS = CountByCriteria(3, 271)
        examen.SAPU_FREI = CountByCriteria(3, 213)
        examen.CESFAM_LIMACHE = CountByCriteria(3, 219)
        examen.CESFAM_OLMUE = CountByCriteria(3, 238)
        examen.APS_CABILDO = CountByCriteria(3, 254)
        examen.APS_HIJUELAS = CountByCriteria(3, 241)
        examen.APS_CALERA = CountByCriteria(3, 239)
        examen.APS_LIGUA = CountByCriteria(3, 255)
        examen.APS_NOGALES = CountByCriteria(3, 240)
        examen.APS_PETORCA = CountByCriteria(3, 256)
        examen.HOSP_LIMACHE = CountByCriteria(3, 228)
        examen.HOSP_GERIATRICO_LMCHE = CountByCriteria(3, 229)
        examen.HOSP_MODULAR_LMCHE = CountByCriteria(3, 232)
        examen.HOSP_PENBLANCA = CountByCriteria(3, 63)
        examen.HOSP_GUSTAVO_FRICKE = CountByCriteria(3, 220)
        examen.HOSP_CALERA = CountByCriteria(3, 233)
        examen.HOSP_PETORCA = CountByCriteria(3, 253)
        examen.HOSP_QUILLOTA = CountByCriteria(3, 230)
        examen.HOSP_CABILDO = CountByCriteria(3, 252)
        examen.HOSP_LIGUA = CountByCriteria(3, 251)
        examen.HOSP_QUINTERO = CountByCriteria(3, 227)
        examen.OTROS = CountByCriteria(3, 227)
        examen.TOTAL_EXTRA = examen.CESFAM_IVAN_MAN + examen.CESFAM_AV_AC + examen.CESFAM_QUILPUE + examen.CESFAM_BELLOTO + examen.CONS_POMPEYA + examen.CECOSF_RETIRO + examen.CONS_BELLOTO + examen.CESFAM_VILLA_AL

        ' Retornar el objeto examen con las cantidades actualizadas
        Return examen
    End Function


#End Region

    <Services.WebMethod()>
    Public Shared Function Call_Frotis(ByVal DESDE As String, ByVal HASTA As String)
        Dim N_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim List_Conteo As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CONTEO_RETICULO(DESDE, HASTA)

        Dim List_Filtered As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = List_Conteo.Where(Function(c) c.ID_PRUEBA = 316).ToList()

        If List_Filtered.Count > 0 Then
            Return List_Filtered
        End If

        Return Nothing

    End Function

    <Services.WebMethod()>
    Public Shared Function Gen_Excel_Desagrupado(DOMAIN_URL As String, DESDE As String, HASTA As String, List_Data As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES))
        Dim N_EXAM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim List_Rem As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = Llenar_DataTable_REM(DESDE, HASTA)

        Return N_EXAM.Gen_Excel_Desagrupado(DOMAIN_URL, DESDE, HASTA, List_Rem)

    End Function

    <Services.WebMethod()>
    Public Shared Sub Gen_Excel_Async(ByVal DOMAIN_URL As String,
                                  ByVal DESDE As String,
                                  ByVal HASTA As String,
                                  ByVal ID_CODIGO_FONASA As Integer,
                                  ByVal EMAIL As String)

        Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim URL_Base As String = HttpContext.Current.Request.Url.Authority

        ' Dim NN_Gen As New N_LugarTM_Det_Async(strLocal, URL_Base, N_Date.toDate(DESDE), N_Date.toDate(HASTA), ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, EMAIL)
        Dim NN_Gen As New N_LugarTM_Det_Async_REM(strLocal, URL_Base, DESDE, HASTA, ID_CODIGO_FONASA, EMAIL)

        Dim N_EXAM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Dim List_Rem As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = Llenar_DataTable_REM(DESDE, HASTA)

        N_EXAM.Gen_Excel_Desagrupado(DOMAIN_URL, DESDE, HASTA, List_Rem)

        ' Usa una lambda para pasar los parámetros necesarios al método asincrónico
        Dim Hilo As Threading.Thread = New Threading.Thread(
        Sub() NN_Gen.Gen_Excel_Desagrupado_Async(List_Rem)
    )
        Hilo.Start()

    End Sub

End Class