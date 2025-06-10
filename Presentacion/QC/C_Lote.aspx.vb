Imports Negocio
Imports Entidades
Public Class C_Lote
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_NIVEL_ACTIVO() As List(Of E_IRIS_QC_BUSCA_NIVEL_ACTIVO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_NIVEL_ACTIVO)

        Dim NN As N_IRIS_QC_BUSCA_NIVEL_ACTIVO = New N_IRIS_QC_BUSCA_NIVEL_ACTIVO
        datas = NN.IRIS_QC_BUSCA_NIVEL_ACTIVO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_ANALIZADOR_ACTIVO() As List(Of E_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO)

        Dim NN As N_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO = New N_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO
        datas = NN.IRIS_QC_BUSCA_ANALIZADOR_ACTIVO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC(ByVal LOTE_DESC As String) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC = New N_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC
        datas = NN.IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC(LOTE_DESC)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_LOTE_DE_MUESTRA(ByVal AREA_COD As String,
                                                  ByVal AREA_DES As String,
                                                  ByVal ID_ESTADO As Integer,
                                                  ByVal ID_ANA As Integer,
                                                  ByVal EXP As String,
                                                  ByVal CONTROL_ANA As String,
                                                  ByVal NIVEL As Long) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_LOTE_DE_MUESTRA = New N_IRIS_GRABA_QC_LOTE_DE_MUESTRA
        datas = NN.IRIS_GRABA_QC_LOTE_DE_MUESTRA_(AREA_COD, AREA_DES, ID_ESTADO, ID_ANA, EXP, CONTROL_ANA, NIVEL)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_LOTE(ByVal ID_LOTE As Long,
                                               ByVal LOTE_COD As String,
                                               ByVal LOTE_DES As String,
                                               ByVal ID_ESTADO As Integer,
                                               ByVal ID_ANA As Integer,
                                               ByVal ID_FECHA As String,
                                               ByVal CONTROL_ANA As String,
                                               ByVal NIVEL As Long) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_LOTE = New N_IRIS_UPDATE_QC_LOTE
        datas = NN.IRIS_UPDATE_QC_LOTE(ID_LOTE, LOTE_COD, LOTE_DES, ID_ESTADO, ID_ANA, ID_FECHA, CONTROL_ANA, NIVEL)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO() As List(Of E_IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO)

        Dim NN As N_IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO = New N_IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO
        datas = NN.IRIS_QC_BUSCA_LOTE_ACTIVO_DESACTIVO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

End Class