Imports Entidades
Imports Negocio
Public Class C_Analizador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_SECCION_ACTIVO() As List(Of E_IRIS_QC_BUSCA_SECCION_ACTIVO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_SECCION_ACTIVO)

        Dim NN As N_IRIS_QC_BUSCA_SECCION_ACTIVO = New N_IRIS_QC_BUSCA_SECCION_ACTIVO
        datas = NN.IRIS_QC_BUSCA_SECCION_ACTIVO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_ANALIZADOR(ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer,
                                                   ByVal ID_SECCION As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_ANALIZADOR = New N_IRIS_GRABA_QC_ANALIZADOR
        datas = NN.IRIS_GRABA_QC_ANALIZADOR(AREA_COD, AREA_DES, ID_ESTADO, ID_SECCION)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_ANALIZADOR(ByVal ID_AREA As Long,
                                                   ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer,
                                                   ByVal ID_SECCION As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_ANALIZADOR = New N_IRIS_UPDATE_QC_ANALIZADOR
        datas = NN.IRIS_UPDATE_QC_ANALIZADOR(ID_AREA, AREA_COD, AREA_DES, ID_ESTADO, ID_SECCION)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_ANALIZADOR() As List(Of E_IRIS_QC_BUSCA_ANALIZADOR)

        Dim datas As List(Of E_IRIS_QC_BUSCA_ANALIZADOR)

        Dim NN As N_IRIS_QC_BUSCA_ANALIZADOR = New N_IRIS_QC_BUSCA_ANALIZADOR
        datas = NN.IRIS_QC_BUSCA_ANALIZADOR()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

End Class