<% 
Set connBM3 = Server.CreateObject("ADODB.Connection")
'strconn3 = "Driver={SQL Server};Server=192.186.0.2;Database=ACLIN;Uid=sa;Pwd=1165;"
'strconn3 = "Driver={SQL Server};Server=164.77.130.91;Database=ACLIN;Uid=sa;Pwd=1165;"
'strconn3 = "Driver={SQL Server};Server=192.168.1.3;Database=IRISLAB_VILLA_16_04_2011;Uid=sa;Pwd=LAB;"
'strconn3 = "Driver={SQL Server};Server=186.10.138.104;Database=IRISLAB_VILLA_16_04_2011;Uid=sa;Pwd=LAB;"

'strconn3 = "Driver={SQL Server};Server=192.168.0.103;Database=IRIS_KRONOS;Uid=sa;Pwd=xlab;"
'strconn3 = "Driver={SQL Server};Server=192.168.1.121;Database=IRIS_KRONOS2;Uid=sa;Pwd=xlab;"
strconn3 = "Driver={SQL Server};Server=192.168.180.51,1433;Database=IRIS_CMV;Uid=sa;Pwd=Xlab1;"
'strconn3 ="Provider=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=****;Data Source=SERVIDOR"
connBM3.open strconn3
%>