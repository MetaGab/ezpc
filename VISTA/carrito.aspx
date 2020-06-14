<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"  CodeBehind="carrito.aspx.cs" Inherits="VISTA.carrito" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Carrito de Compras</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="#">Carrito</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================Cart Area =================-->
    <section class="cart_area">
        <div class="container">
            <div class="cart_inner">
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Producto</th>
                                <th scope="col">Precio</th>
                                <th scope="col">Cantidad</th>
                                <th scope="col">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lstCarrito" runat="server" ClientIDMode="Predictable">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="media">
                                                <div class="d-flex">
                                                    <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid" ImageUrl='<%# "~/Include/img/product/" + Eval("Producto.imagen") %>'/>
                                                </div>
                                                <div class="media-body">
                                                    <p><asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Producto.nombre") %>' /></p>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <h5>$ <asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("Producto.precio_real") %>' /></h5>
                                        </td>
                                        <td>
                                            <div class="product_count">
                                                <asp:TextBox ID='txtNumber' runat="server" class="input-text qty" Text='<%#Eval("cantidad")%>' OnTextChanged="txtNumber_TextChanged"  product_id='<%#Eval("id") %>' AutoPostBack="true"></asp:TextBox>
                                                <button runat="server" product_id='<%#Eval("id") %>' onserverclick="btnUp_Click" class="increase items-count" type="button"><i class="lnr lnr-chevron-up"></i></button>
							                    <button runat="server" product_id='<%#Eval("id") %>' onserverclick="btnDown_Click" class="reduced items-count" type="button"><i class="lnr lnr-chevron-down"></i></button>

                                            </div>
                                        </td>
                                        <td>
                                            <h5>$ <%#Convert.ToDecimal(Eval("Producto.precio_real"))*Convert.ToDecimal(Eval("cantidad")) %></h5>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            
                            <tr>
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>
                                    <h5>Total</h5>
                                </td>
                                <td>
                                
                                    <h5>$ <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h5>
                                </td>
                            </tr>
                            <tr class="out_button_area">
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>
                                    <div class="checkout_btn_inner d-flex align-items-center justify-content-end">
                                        <a class="gray_btn" href="tienda.aspx">Continuar comprando</a>
                                        <a class="primary-btn" href="checkout.aspx">Proceder a pagar</a>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
