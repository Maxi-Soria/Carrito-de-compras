<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_De__Articulos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <style>
        body {
            font-family: 'Mochiy Pop One', sans-serif;
        }
        .amarillo-pastel {
        background-color: #ffffcc;
        }
    </style>

    <h1>Bienvenido/a a Free Code Market</h1>

   <div class="row">
    <% foreach (var articulo in ListaArticulos) { %>
        <div class="col-md-2">
            <div class="card border border-dark font-weight-bold" style="width: 18rem;">
                <img class="card-img-top" src="<%= articulo.Imagen %>" alt="Card image cap" style="height: 200px; background-color: white;">
                <div class="card-body amarillo-pastel">
                    <h5 class="card-title"><%= articulo.Nombre %></h5>
                    <p class="card-text"><%= articulo.Descripcion %></p>
                    <p class="card-text">Precio: $ <%= string.Format("{0:0.00}", articulo.Precio) %></p>
                    <a href="#" class="btn btn-primary" style="font-family: 'Mochiy Pop One', sans-serif;">Agregar al carrito</a>
                </div>
            </div>
        </div>
    <% } %>
</div>
  





</asp:Content>
