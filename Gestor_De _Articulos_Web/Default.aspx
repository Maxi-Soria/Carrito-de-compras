<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_De__Articulos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="estilos.css" rel="stylesheet" />



    <section class="body-def">
        <div class="reflected-header">
            <h1>Llego la CocoSale, con el codigo 'loVoletea' 30% off</h1>
        </div>
        
        <div class="container">
            <div class="row">
                <% foreach (var articulo in ListaArticulos)
                    { %>
                <div class="col-md-3 mb-4">
                    <div class="card border border-dark font-weight-bold mx-auto h-100" style="width: 18rem;">
                        <img class="card-img-top" src="<%= articulo.Imagen %>" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title"><%= articulo.Nombre %></h5>
                            <p class="card-text"><%= articulo.Descripcion %></p>
                            <p class="card-text">Precio: $ <%= string.Format("{0:0.00}", articulo.Precio) %></p>
                            <a href="?id=<%: articulo.Id %>" class="btn btn-primary">Agregar al carrito</a>
                        </div>
                    </div>
                </div>
                <% } %>
            </div>
        </div>
    </section>



</asp:Content>
