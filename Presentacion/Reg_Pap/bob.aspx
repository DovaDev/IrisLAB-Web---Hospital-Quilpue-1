﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="bob.aspx.vb" Inherits="Presentacion.bob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<title> Prueba bob </title>
<link rel="stylesheet" href="estilos.css" >
</head>
<body>
<div class="body">
<div class="ojos">
<div class="ojo">
<div class="pestanas">
<div class="pestana primera"></div>
<div class="pestana segunda"></div>
<div class="pestana tercera"></div>
</div>
<div class="ojo_externo">
<div class="ojo_interno"></div>
</div>
</div>
<div class="ojo">
<div class="pestanas">
<div class="pestana primera"></div>
<div class="pestana segunda"></div>
<div class="pestana tercera"></div>
</div>
<div class="ojo_externo">
<div class="ojo_interno"></div>
</div>
</div>
</div>
<div class="nariz"></div>
<div class="boca">
<div class="mejilla primera"></div>
<div class="dientes">
<div class="diente"></div>
<div class="diente"></div>
</div>
<div class="mejilla segunda"></div>
</div>
<div class="poro primero"></div>
<div class="poro segundo"></div>
<div class="poro tercero"></div>
<div class="poro cuarto"></div>
<div class="poro quinto"></div>
<div class="camisa">
<div class="cuello primero"></div>
<div class="corbata">
<div class="cuello_corbata"></div>
</div>
<div class="cuello segundo"></div>
</div>
<div class="cola_corbata"></div>
<div class="pantalones">
<div class="cinturon primero"></div>
<div class="cinturon segundo"></div>
<div class="cinturon tercero"></div>
<div class="cinturon cuarto"></div>
</div>
</div>
</body>
</html>

    <style>
        .body {
 background:#F5EE31;
 width: 300px;
 height:400px;
 border:5px solid #000;
 position: relative;
 margin:50px auto;
 overflow:hidden;
}
/*----- ----- ----- OJOS ----- ----- -----*/
.ojos {
 position: absolute;
 left:40px;
 top:40px;
 width:210px;
 z-index:10;
}

.ojo {
 background:#fff;
 position: relative;
 border:5px solid #000;
 width:100px;
 height:100px;
 margin-right:-17px;
 border-radius:50%;
 display: inline-block;
}

.ojo_externo {
 width: 50px;
 height:50px;
 border-radius:50%;
 position:absolute;
 top:20px;
 left:25px;
 background:#00AEEF;
 border:3px solid #000;
}

.ojo_interno {
 width:30px;
 height:30px;
 background:#000;
 border-radius:50%;
 position:relative;
 top:10px;
 left:10px;
}

.pestanas {
 position:relative;
 bottom:28px;
 left:12px;
}

.pestana {
 width:15px;
 height:5px;
 background:#000;
 transform:rotate(90deg);
 -moz-transform: rotate(90deg);
 -webkit-transform: rotate(90deg);
 -o-transform: rotate(90deg);
 -ms-transform: rotate(90deg);
 margin-right:10px;
 display:inline-block;
}

.pestana.primera {
 position:relative;
 top:10px;
 transform: rotate(45deg);
 -moz-transform: rotate(45deg);
 -webkit-transform: rotate(45deg);
 -o-transform: rotate(45deg);
 -ms-transform: rotate(45deg);
}

.pestana.tercera {
 position:relative;
 top:10px;
 transform: rotate(-45deg);
 -moz-transform: rotate(-45deg);
 -webkit-transform: rotate(-45deg);
 -o-transform: rotate(-45deg);
 -ms-transform: rotate(-45deg);
}
/*----- ----- ----- NARIZ ----- ----- -----*/
.nariz {
 width:20px;
 height:40px;
 background:#F5EE31;
 position: absolute;
 top:110px;
 left:130px;
 border:5px solid #000;
 border-bottom:5px solid transparent;
 border-radius:42.5%;
 z-index:10;
}
/*----- ----- ----- BOCA ----- ----- -----*/
.boca {
 width:200px;
 height:80px;
 background:transparent;
 position:absolute;
 top:120px;
 left:50px;
 border-radius:50%;
 border-bottom:5px solid #000;
 z-index:10;
}
.dientes {
 position:relative;
 top:80px;
 left:65px;

}
.diente {
 width:20px;
 height:20px;
 background:#fff;
 border:5px solid #000;
 display: inline-block;
}

.mejilla {
 width:30px;
 height:20px;
 background:transparent;
 position:absolute;
 top:30px;
 border:3px solid #F1592A;
 border-bottom:5px transparent;
 border-radius:50% 50% 20% 20%;
}

.mejilla.primera {
 left:-15px;
}

.mejilla.segunda {
 left:175px;
}
/*----- ----- ----- CAMISA ----- ----- -----*/
.camisa {
 width:100%;
 height:50px;
 background:#fff;
 position: absolute;
 bottom:50px;
 border-top:5px solid #000;
 z-index:10;
 overflow:hidden;
}

.cuello {
 width:50px;
 height:30px;
 position: absolute;
 background:#fff;
 top:-25px;
 border:5px solid #000;
 -moz-transform: rotate(30deg);
 -webkit-transform: rotate(30deg);
 -o-transform: rotate(30deg);
 -ms-transform: rotate(30deg);
 transform: rotate(30deg);
}

.cuello.primero {
 left:60px;
}

.cuello.segundo {
 left:180px;
 -moz-transform: rotate(-30deg);
 -webkit-transform: rotate(-30deg);
 -o-transform: rotate(-30deg);
 -ms-transform: rotate(-30deg);
 transform: rotate(-30deg);
}

.corbata {
}

.cuello_corbata {
 width:40px;
 height:40px;
 background:#F00200;
 border:5px solid #000;
 position:absolute;
 left:130px;
 bottom:30px;
 z-index:50;
 -moz-transform: rotate(45deg);
 -webkit-transform: rotate(45deg);
 -o-transform: rotate(45deg);
 -ms-transform: rotate(45deg);
 transform: rotate(45deg);
}

.cola_corbata {
 width:55px;
 height:55px;
 background:#F00200;
 border:5px solid #000;
 position:absolute;
 left:123px;
 bottom:0px;
 z-index:50;
 -moz-transform: rotate(45deg);
 -webkit-transform: rotate(45deg);
 -o-transform: rotate(45deg);
 -ms-transform: rotate(45deg);
 transform: rotate(45deg);
}
/*----- ----- ----- PANTALONES ----- ----- -----*/
.pantalones {
 width:100%;
 height:50px;
 background:#6A3D13;
 position: absolute;
 bottom:0%;
 border-top:5px solid #000;
 z-index:10;
}

.cinturon {
 width:40px;
 height:15px;
 position:absolute;
 top:20px;
 background:#000;
}

.cinturon.primero {
 left:20px;
}

.cinturon.segundo {
 left:90px;
}

.cinturon.tercero {
 right:80px;
}

.cinturon.cuarto {
 right:20px;
}
/*----- ----- ----- POROS ----- ----- -----*/
.poro {
 background:#C0A402;
 height:40px;
 width:40px;
 position:absolute;
 border-radius:50%;
 z-index:1;
}

.poro.primero {
 top:230px;
 left:20px;
 height:50px;
 width:50px;
}

.poro.segundo {
 top:200px;
 left:280px;
}

.poro.tercero {
 top:50px;
 left:260px;
 height:15px;
 width:15px;
}

.poro.cuarto {
 top:300px;
 height:30px;
 width:30px;
 left:50px;
}

.poro.quinto {
 top:250px;
 left:200px;
}

.poro.sexto {
 top:;
 left:;
}

.poro.septimo {
 top:;
 left:;
}

.poro.octavo {
 top:;
 left:;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
</asp:Content>
