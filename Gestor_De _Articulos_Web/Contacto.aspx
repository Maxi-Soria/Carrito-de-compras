<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Gestor_De__Articulos_Web.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Web desarrollada por Maximiliano Soria y Gonzalo Ligero</h1>
    <asp:Panel ID="ContactForm" runat="server" CssClass="contact-form">
    <h2 class="text-center">Contacto</h2>
    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblMensaje" runat="server" AssociatedControlID="txtMensaje" Text="Mensaje:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblMensajeConfirmacion" runat="server" CssClass="mensaje-confirmacion"></asp:Label>
    </div>
</asp:Panel>
        
       
    
</asp:Content>
