<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="checkout.aspx.cs" Inherits="VISTA.checkout" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Checkout</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="#">Checkout</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================Checkout Area =================-->
    <section class="checkout_area section_gap">
        <div class="container">
            <div class="billing_details">
                <div class="row">
                    <div class="col-lg-8">
                        <h3>Informacion de Pago</h3>
                        <div class="row col-12 contact_form">
                            <div class="form-group col-md-12">
								<label for="ddlEstado">Métodos de Pago</label>
								
							</div>
                            <div class="col-md-12 form-group">
                                <asp:DropDownList CssClass="form-control"  ID="ddlMetodos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMetodos_SelectedIndexChanged"  >
									<asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
							    </asp:DropDownList>
                            </div>
                            <asp:Panel ID="pnlPayForm" runat="server" CssClass="row">
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtNombrePago" runat="server" placeholder="Nombre"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtApellidoPago" runat="server" placeholder="Apellido"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtTelefonoPago" runat="server" placeholder="Teléfono"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtCorreoPago" runat="server" placeholder="Correo Electrónico"></asp:TextBox>
                                </div>
                                <div class="form-row col-md-12">
								    <div class="form-group col-md-4">
									    <label for="ddlPais">Pais</label>
									    <asp:DropDownList CssClass="form-control"  ID="ddlPais" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
											    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
									    </asp:DropDownList>
								    </div>
								    <div class="form-group col-md-4">
									    <label for="ddlEstado">Estado</label>
									    <asp:DropDownList CssClass="form-control"  ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
											    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
									    </asp:DropDownList>
								    </div>
								    <div class="form-group col-md-4">
									    <label for="ddlCiudad">Ciudad</label>
									    <asp:DropDownList CssClass="form-control"  ID="ddlCiudad" runat="server">
											    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
									    </asp:DropDownList>
								    </div>
							    </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtDireccionPago" runat="server" placeholder="Dirección"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtCPPago" runat="server" placeholder="Código Postal"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox class="form-control" ID="txtTarjeta" runat="server" placeholder="Número de Tarjeta"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtNIP" runat="server" placeholder="Número de Seguridad"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtExpiracion" runat="server" placeholder="Expiración"></asp:TextBox>
                                </div>

                            </asp:Panel>
                            
                         </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="order_box">
                            <h2>Resumen de Orden</h2>
                            <ul class="list">
                                <li><a href="#">Producto <span>Total</span></a></li>
                                <asp:ListView ID="lstProductos" runat="server">
                                    <ItemTemplate>
                                    <li><a href="#">
                                        <asp:Literal ID="litName" runat="server" Text='<%#Eval("Producto.nombre")%> '></asp:Literal> 
                                        (<asp:Literal ID="litQty" runat="server" Text='<%#Eval("cantidad")%> '> </asp:Literal>)<span class="middle"></span> <span class="last">$ <asp:Literal ID="litPrecio" runat="server" Text='<%#Convert.ToDecimal(Eval("Producto.precio_real"))*Convert.ToDecimal(Eval("cantidad"))%>'></asp:Literal></span></a></li>
                                    </ItemTemplate>

                                </asp:ListView>
                            </ul>
                            <ul class="list list_2">
                                <li><a href="#">Subtotal <span>$ <asp:Literal ID="litSubtotal" runat="server"></asp:Literal></span></a></li>
                                <li><a href="#">Envio <span> $ 50.00</span></a></li>
                                <li><a href="#">Total <span>$ <asp:Literal ID="litTotal" runat="server"></asp:Literal></span></a></li>
                            </ul>
                           
                         
                            <asp:Button runat="server" Text="PAGAR" ID="btnPagar" class="primary-btn" OnClick="btnPagar_Click"  />
                        </div>
                    </div>
                    <div class="col-lg-8">
                        
							
                        <h3>Informacion de Envio</h3>
                        <div class="row col-12 contact_form" >
                            <div class="form-group col-md-12">
								<label for="ddlEstado">Direcciones Guardadas</label>
								<asp:DropDownList CssClass="form-control"  ID="ddlDirecciones" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDirecciones_SelectedIndexChanged">
										<asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
								</asp:DropDownList>
							</div>
                            <asp:Panel ID="pnlAddressForm" runat="server" CssClass="row">
                                <div class="col-md-12 mb-3">
                                    <asp:CheckBox runat="server" Text="&nbsp;&nbsp;Misma dirección que dirección de envio " ID="chkSame" AutoPostBack="true" OnCheckedChanged="chkSame_CheckedChanged"/>
                                </div>
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group">
                                    <asp:TextBox class="form-control" ID="txtApellido" runat="server" placeholder="Apellido"></asp:TextBox>
                                </div>
                           
							    <div class="form-group col-md-4">
								    <label for="ddlPais">Pais</label>
								    <asp:DropDownList CssClass="form-control"  ID="ddlPaisEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaisEnvio_SelectedIndexChanged">
										    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
								    </asp:DropDownList>
							    </div>
							    <div class="form-group col-md-4">
								    <label for="ddlEstado">Estado</label>
								    <asp:DropDownList CssClass="form-control"  ID="ddlEstadoEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoEnvio_SelectedIndexChanged">
										    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
								    </asp:DropDownList>
							    </div>
							    <div class="form-group col-md-4">
								    <label for="ddlCiudad">Ciudad</label>
								    <asp:DropDownList CssClass="form-control"  ID="ddlCiudadEnvio" runat="server">
										    <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
								    </asp:DropDownList>
							    </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtDireccion" runat="server" placeholder="Direccion"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group p_star">
                                    <asp:TextBox class="form-control" ID="txtCP" runat="server" placeholder="Código Postal"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--================End Checkout Area =================-->
</asp:Content>
<asp:Content ContentPlaceHolderID="jsContent" runat="server" ID="js"> 

</asp:Content>
