<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_De__Articulos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="estilos.css" rel="stylesheet" />



        <div class="reflected-header">
            <h1>Llego la CocoSale, con el codigo 'loVoletea' 30% off</h1>
        </div>

        <div id="carouselExampleCaptions" class="carousel slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://cloudfront-eu-central-1.images.arcpublishing.com/diarioas/CRVDJETSJJMDHAVAPKSVACN2QA.jpg" class="d-block w-100" alt="...">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>First slide label</h5>
                        <p>Some representative placeholder content for the first slide.</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="https://s1.eestatic.com/2019/04/12/actualidad/actualidad_390473732_130516122_800x535.jpg" class="d-block w-100" alt="...">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Second slide label</h5>
                        <p>Some representative placeholder content for the second slide.</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="https://img.freepik.com/fotos-premium/mediados-mujer-adulta-su-hija-haciendo-compras-linea-casa-familia-feliz-comprando-casa-productos-internet-mujeres-ordenando-linea_136813-1224.jpg?w=2000" class="d-block w-100" alt="...">
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Third slide label</h5>
                        <p>Some representative placeholder content for the third slide.</p>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>


    <section class="body-def">

        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4">
                            <div class="card border border-dark font-weight-bold mx-auto h-100" style="width: 18rem;">
                                <img class="card-img-top" src='<%# Eval("Imagen") %>' alt="Card image cap" />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text">Precio: $ <%# string.Format("{0:0.00}", Eval("Precio")) %></p>
                                    <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="Agregar al carrito" OnClick="btnAgregarAlCarrito_Click" CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </section>
</asp:Content>
