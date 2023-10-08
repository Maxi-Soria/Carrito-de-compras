<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Gestor_De__Articulos_Web.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <section class="body-def">
        <div class="reflected-header">
            <h1>Llego la CocoSale, con el codigo 'loVoletea' 30% off</h1>
        </div>

        <asp:Repeater runat="server" ID="repEliminar">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-3 mb-4">
                        <div class="card border border-dark font-weight-bold mx-auto h-100" style="width: 18rem;">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class="card-text">Precio: $ <%# string.Format("{0:0.00}", Eval("Precio")) %></p>
                                <asp:Button  ID="btnEliminarDelCarrito" runat="server" Text="Eliminar" OnClick="btnEliminarDelCarrito_Click" CssClass="btn btn-danger" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </section>


















</asp:Content>
