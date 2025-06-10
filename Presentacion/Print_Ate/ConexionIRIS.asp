<% 
Set connBM3 = Server.CreateObject("ADODB.Connection")
'strconn3 = "Driver={SQL Server};Server=192.168.0.47;Database=IRIS_HOSP_QUILPUE;Uid=sa;Pwd=xlab;"
strconn3 = "Driver={SQL Server};Server=10.5.170.19;Database=IRIS_HOSP_QUILPUE;Uid=sa;Pwd=xlab;"
connBM3.open strconn3
%>