<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="confirmacion.aspx.cs" Inherits="VISTA.confirmacion" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Confirmación</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Confirmación</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

	<!--================Order Details Area =================-->
	<section class="order_details section_gap">
		<div class="container">
			<h3 class="title_confirmation">Gracias. Tu orden ha sido recibida.</h3>
			<div class="row order_d_inner">
				<div class="col-lg-4">
					<div class="details_item">
						<h4>Información de la orden</h4>
						<ul class="list">
							<li><a href="#"><span>Número de orden</span>: <asp:Literal ID="litOrdenID" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Fecha</span>: <asp:Literal ID="litFecha" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Total</span>: <asp:Literal ID="litTotal1" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Metodo de Pago</span>: <asp:Literal ID="litPago" runat="server"></asp:Literal></a></li>
						</ul>
					</div>
				</div>
				<div class="col-lg-4">
					<div class="details_item">
						<h4>Información de Pago</h4>
						<ul class="list">
							<li><a href="#"><span>Dirección</span>: <asp:Literal ID="litDireccionPago" runat="server"></asp:Literal></a></li>
							<li><a href="#"><span>Ciudad</span>: <asp:Literal ID="litCiudadPago" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Pais</span>: <asp:Literal ID="litPaisPago" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Codigo Postal</span>: <asp:Literal ID="litCPPago" runat="server"></asp:Literal> </a></li>
						</ul>
					</div>
				</div>
				<div class="col-lg-4">
					<div class="details_item">
						<h4>Información de envio</h4>
						<ul class="list">
							<li><a href="#"><span>Direccion</span>: <asp:Literal ID="litDireccion" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Ciudad</span>: <asp:Literal ID="litCiudad" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Pais</span>: <asp:Literal ID="litPais" runat="server"></asp:Literal> </a></li>
							<li><a href="#"><span>Codigo Postal</span>: <asp:Literal ID="litCP" runat="server"></asp:Literal> </a></li>
						</ul>
					</div>
				</div>
			</div>
			<div class="order_details_table">
				<h2>Detalles de Orden</h2>
				<div class="table-responsive">
					<table class="table">
						<thead>
							<tr>
								<th scope="col" class="h3">Producto</th>
								<th scope="col" class="h3">Cantidad</th>
								<th scope="col" class="h3">Total</th>
							</tr>
						</thead>
						<tbody>
							<asp:ListView ID="lstItems" runat="server">
								<ItemTemplate>
									<tr>
										<td>
											<h5><asp:Literal ID="litProducto" runat="server" Text='<%#Eval("Producto.nombre") %>'></asp:Literal></h5>
										</td>
										<td>
											<h5><asp:Literal ID="litQty" runat="server" Text='<%#Eval("cantidad") %>'></asp:Literal></h5>
										</td>
										<td>
											<h5><asp:Literal ID="litPTotal" runat="server" Text='<%#Convert.ToDecimal(Eval("precio"))*Convert.ToDecimal(Eval("cantidad"))%>'></asp:Literal></h5>
										</td>
									</tr>

								</ItemTemplate>
							</asp:ListView>
							<tr>
								<td>
									<h4>Subtotal</h4>
								</td>
								<td>
									<h5></h5>
								</td>
								<td>
									<h5>$ <asp:Literal ID="litSubtotal" runat="server"></asp:Literal></h5>
								</td>
							</tr>
							<tr>
								<td>
									<h4>Envio</h4>
								</td>
								<td>
									<h5></h5>
								</td>
								<td>
									<h5>$ 50.00</h5>
								</td>
							</tr>
							<tr>
								<td>
									<h4>Total</h4>
								</td>
								<td>
									<h5></h5>
								</td>
								<td>
									<h4>$ <asp:Literal ID="litTotal" runat="server"></asp:Literal></h4>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</section>

</asp:Content>
