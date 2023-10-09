<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Gestor_De__Articulos_Web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Repeater ID="repDetalle" runat="server">
        <ItemTemplate>
            <div class="col-md-3 mb-4">
                <div class="card border border-dark font-weight-bold mx-auto h-100" style="width: 18rem;">
                    <img class="card-img-top " src='<%# Eval("Imagen") %>' alt="Card image cap" />
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <p class="card-text flex-grow-1"></p>
                        <p class="card-text">Precio: $ <%# string.Format("{0:0.00}", Eval("Precio")) %></p>
                        <div class="mt-auto">

                            
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>



</asp:Content>
