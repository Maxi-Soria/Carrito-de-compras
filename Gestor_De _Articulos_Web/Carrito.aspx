﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Gestor_De__Articulos_Web.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <section class="body-def">

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
                        
            
        <div class="cocoPromo">
            <asp:Label runat="server" ID="lblTotalCarrito1" Text="Total del Carrito: $0.00" />
            <div>
                <label for="txtCodigo">Ingrese el código:</label>
                <asp:TextBox runat="server" ID="txtCodigo" ClientIDMode="Static"></asp:TextBox>
                <asp:Button runat="server" ID="btnValidar" Text="Validar" OnClick="btnValidar_Click" />
            </div>
            <asp:Label runat="server" ID="lblTotalCarrito" Text="Total del Carrito: $0.00" />

       </div>

            <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra" OnClick="btnConfirmarCompra_Click" CssClass="btn btn-success" />
            <asp:Label ID="lblMensajeAgradecimiento" runat="server" Text="" Visible="false"></asp:Label>
    </section>


















</asp:Content>
