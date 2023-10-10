<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Gestor_De__Articulos_Web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label CssClass="contador" ID="cont" runat="server" Text="">0</asp:Label>

    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server"  Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblDescripcion" runat="server"  Text="Descripcion:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    </div>   
    <div class="form-group">
        <asp:Label ID="lblImporte" runat="server"  Text="Importe:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtImporte" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Repeater ID="repDetalle" runat="server">
        <ItemTemplate>

            <img src='<%# Container.DataItem %>' alt="Imagen" />

        </ItemTemplate>
    </asp:Repeater>




</asp:Content>
