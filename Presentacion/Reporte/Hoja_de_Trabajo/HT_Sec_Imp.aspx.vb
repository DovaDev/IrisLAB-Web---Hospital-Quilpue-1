Imports Negocio
Imports Entidades
Imports SpreadsheetLight
Public Class HT_Sec_Imp
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Seccion() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)

        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            Return Data_Prevision
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As Integer,
                                            ByVal HASTA As Integer,
                                            ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM(DESDE, HASTA, ID_REL)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable2(ByVal DESDE As Date,
                                            ByVal HASTA As Date,
                                            ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2(DESDE, HASTA, ID_REL)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If
    End Function
End Class