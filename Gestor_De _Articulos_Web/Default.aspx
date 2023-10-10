<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_De__Articulos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="estilos.css" rel="stylesheet" />


    <div class="reflected-header" style="text-shadow: 2px 2px #a732da;">
        <h1>Llego la CocoSale, con el codigo 'GENTES' 30% off</h1>
    </div>

    <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
            <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://www.cronista.com/files/image/419/419139/61d3378d218ac.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Celulares</h5>
                    <p>¡Sólo por hoy descuentos increíbles!</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://mui.fitness/__export/1674270938846/sites/muifitness/img/2023/01/21/ropa-deportiva-mejora-rendimiento-2_1.jpg_759710130.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Indumentaria deportiva</h5>
                    <p>Ropa especializada para ciclismo y más</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://la100.cienradios.com/resizer/-Ezw3Tyqc1zkQvVF_O-VrnCPCsU=/arc-photo-radiomitre/arc2-prod/public/BIJPFXM3VFDRHOPOTYU2XDG7AA.png" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Fiambres</h5>
                    <p>Venta de longanizas, salames picado grueso y salchichones primavera</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only"></span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only"></span>
        </a>
    </div>


    <section class="body-def">
        <div class="container">
            <div class="row">

                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 article-card">
                            <div class="card border border-dark font-weight-bold mx-auto h-100" style="width: 18rem;">
                                <img class="card-img-top " src='<%# Eval("Imagen") %>' alt="Card image cap" />
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text flex-grow-1"></p>
                                    <p class="card-text">Precio: $ <%# string.Format("{0:0.00}", Eval("Precio")) %></p>
                                    <div class="mt-auto">
                                        <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="Agregar al carrito" OnClick="btnAgregarAlCarrito_Click" CssClass="btn btn-primary mb-2" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" OnClientClick="actualizarContador(); return true;" Style="background-color: #007bff; color: white;" onmouseover="this.style.backgroundColor = '#a732da';" onmouseout="this.style.backgroundColor = '#007bff';" />
                                        <button class="btn-Ver-Detalle">
                                            <a href='<%# "Detalle.aspx?id=" + Eval("Id") %>'>Detalle</a>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

    </section>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function actualizarContador() {
            $.ajax({
                url: 'Default.aspx/ObtenerCantidadCarrito',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {

                    contadorCarrito.textContent = data.d;
                },

            });
        }
    </script>

</asp:Content>
