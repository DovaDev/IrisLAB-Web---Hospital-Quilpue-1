dw<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Not_Found.aspx.vb" Inherits="Presentacion.Not_Found" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina no encontrada</title>

       <!-- Bootstrap core CSS -->
   <link href="/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
   <link href="/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
   <link href="/vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />
   <link href="/css/sb-admin.css" rel="stylesheet" />
   <link href="/css/Checkbox.css" rel="stylesheet" />
   <link href="/css/Load_Modal.css" rel="stylesheet" />
   <link href="/css/bootstrap-datetimepicker.css" rel="stylesheet" />
   <link href="/css/Iris_Css.css" rel="stylesheet" />
   <link href="css/Not_Found.css" rel="stylesheet" />

        <!-- Bootstrap core JavaScript -->
    <script src="/js/jquery-3.7.0.min.js"></script>
    <script src="/vendor/popper/popper.min.js"></script>
    <script src="/vendor/bootstrap/js/bootstrap.js"></script>
</head>


<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">

                <div class="col">
                    <img class="image" src="/Imagenes/logo_largo_irislab.png" alt="Página No Encontrada" width="500" height="200" />
                </div>
            </div>
            <div class="row">
                <div class="col-4 title d-flex justify-content-end">
                    <h1>404</h1>
                </div>
                <div class="col d-flex justify-content-start">
                    <h1>Página No Encontrada</h1>
                </div>
            </div>
            <div class="subtitle">Lo sentimos, pero la página que intentas acceder no existe.</div>
        </div>
    </form>
</body>
</html>
