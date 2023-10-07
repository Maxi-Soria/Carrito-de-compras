<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_De__Articulos_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido/a a Free Code Market</h1>

  
    <div class="row">
    <% foreach (var articulo in ListaArticulos) { %>
        <div class="col-md-4">
            <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="<%= articulo.Imagen %>" alt="Card image cap" style="height: 200px;">
                <div class="card-body">
                    <h5 class="card-title"><%= articulo.Nombre %></h5>
                    <p class="card-text"><%= articulo.Descripcion %></p>
                    <p class="card-text">Precio: <%= articulo.Precio %></p>
                    <a href="#" class="btn btn-primary">Agregar al carrito</a>
                </div>
            </div>
        </div>
    <% } %>
</div>


</asp:Content>
