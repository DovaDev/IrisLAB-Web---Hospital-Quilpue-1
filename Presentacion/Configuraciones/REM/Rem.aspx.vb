Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.HttpContext


Public Class _Rem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    <Services.WebMethod()>
    Public Shared Function Llenar_Codigos_REM(ByVal ID_DDL_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM)
        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim Data_REM As List(Of E_IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM) = NN_REM.IRIS_WEBF_BUSCA_CODIGOS_FORMATO_REM(ID_DDL_SECC)
        If (Data_REM.Count > 0) Then

            Return Data_REM
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Seccion_Rem() As List(Of E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM)
        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim Data_REM As List(Of E_IRIS_WEBF_BUSCA_SECCION_FORMATO_REM) = NN_REM.IRIS_WEBF_BUSCA_SECCION_FORMATO_REM()
        If (Data_REM.Count > 0) Then

            Return Data_REM
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Examenes() As List(Of E_IRIS_WEBF_BUSCA_TODOS_EXAMENES)

        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim Data_Exam As List(Of E_IRIS_WEBF_BUSCA_TODOS_EXAMENES) = NN_REM.IRIS_WEBF_BUSCA_TODOS_EXAMENES()
        If (Data_Exam.Count > 0) Then

            Return Data_Exam
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Examenes_Rel(ByVal ID_FONASA_REM_HOSP As Integer) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM)

        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim Data_Exam_Rel As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM) = NN_REM.IRIS_WEBF_BUSCA_EXAMENES_REL_PRU_REM(ID_FONASA_REM_HOSP)
        If (Data_Exam_Rel.Count > 0) Then

            Return Data_Exam_Rel
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Guarda_Panel_Codigo(ByVal Mx_Panel As List(Of E_IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO)) As Integer
        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Return NN_REM.IRIS_WEBF_GUARDA_QUITA_PANEL_CODIGO(Mx_Panel)
    End Function

    <Services.WebMethod()>
    Public Shared Function Actualizar_Ajuste(ID_FONASA_REM As Integer, ID_CF_EX As Integer, ByVal OPT As String) As Integer
        'Declaraciones internas
        Dim NN_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES
        Return NN_REM.IRIS_WEBF_ACTUALIZA_EXCL_PRIO_REM(ID_FONASA_REM, ID_CF_EX, OPT)
    End Function
End Class