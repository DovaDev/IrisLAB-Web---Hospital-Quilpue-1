Public Class N_HTML
    Function Html_Get_CHK_value(ByVal Html_Input As String) As Boolean
        Dim Str_html As String
        Str_html = HttpContext.Current.Request(Html_Input)
        Select Case Str_html
            Case "on"
                Return True
            Case ""
                Return False
            Case Else
                Return False
        End Select
    End Function
    Function Html_Get_STR_value(ByVal Html_Input As String) As String
        Dim Str_html As String
        Str_html = HttpContext.Current.Request(Html_Input)
        Return Str_html
    End Function
    Function CSS_TD(ByVal Row As Long, Optional ByVal Highlight As Boolean = False) As String
        Select Case Highlight
            Case False
                If (Row Mod 2 = 0) Then
                    Return "tr_b"
                Else
                    Return "tr_a"
                End If
            Case Else
                If (Row Mod 2 = 0) Then
                    Return "td_bh"
                Else
                    Return "td_ah"
                End If
        End Select
    End Function
End Class
