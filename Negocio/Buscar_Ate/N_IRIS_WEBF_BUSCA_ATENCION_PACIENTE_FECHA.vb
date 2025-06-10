Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
    End Sub
    Function IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(ByVal FECHA1 As String, ByVal FECHA2 As String, ByVal LUGARTM As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)
        Dim N_Date As New N_Date_Operat
        Dim arDate01 As String() = FECHA1.Split("-")
        Dim arDate02 As String() = FECHA2.Split("-")

        Dim xDate01 As Date = N_Date.strToDate(arDate01(2), arDate01(1), arDate01(0))
        Dim xDate02 As Date = N_Date.strToDate(arDate02(2), arDate02(1), arDate02(0))

        Dim EEE As N_Encrypt = New N_Encrypt
        Dim List_in As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)
        List_in = DD_Data.D_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(xDate01, xDate02, LUGARTM)

        For y = 0 To (List_in.Count - 1)
            List_in(y).ENCRYPTED_ID = EEE.Encode(List_in(y).ID_ATENCION)
        Next y
        Return List_in
    End Function
End Class

