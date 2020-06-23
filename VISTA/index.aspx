<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VISTA.index1" %>

<asp:Content ID="content" ContentPlaceHolderID="mainContent" runat="server">
    
	<!-- start banner Area -->
	<section class="banner-area">
		<div class="container">
			<div class="row fullscreen align-items-center justify-content-start">
				<div class="col-lg-12">
					<!-- single-slide -->
					<div class="row single-slide align-items-center d-flex">
						<div class="col-lg-5 col-md-6">
							<div class="banner-content">
								<h1>¡Todo para tu computadora!</h1>
								<p class="text-white h2">En EZPC tenemos todos los componentes que 
								necesitas.</p>
									
							</div>
						</div>
						<div class="col-lg-7">
							<div class="banner-img">
								<img class="img-fluid" src="Include/img/banner/banner-img.png" alt=""/>
							</div>
						</div>
					</div>
					<!-- single-slide -->
				</div>
			</div>
		</div>
	</section>
	<!-- End banner Area -->

	<!-- start features Area -->
	<section class="features-area section_gap">
		<div class="container">
			<div class="row features-inner">
				<!-- single features -->
				<div class="col-lg-3 col-md-6 col-sm-6">
					<div class="single-features">
						<div class="f-icon">
							<img src="Include/img/features/f-icon1.png" alt="">
						</div>
						<h6>Envio Gratis</h6>
					</div>
				</div>
				<!-- single features -->
				<div class="col-lg-3 col-md-6 col-sm-6">
					<div class="single-features">
						<div class="f-icon">
							<img src="Include/img/features/f-icon2.png" alt="">
						</div>
						<h6>Reembolsos</h6>
					</div>
				</div>
				<!-- single features -->
				<div class="col-lg-3 col-md-6 col-sm-6">
					<div class="single-features">
						<div class="f-icon">
							<img src="Include/img/features/f-icon3.png" alt="">
						</div>
						<h6>Soporte 24/7</h6>
					</div>
				</div>
				<!-- single features -->
				<div class="col-lg-3 col-md-6 col-sm-6">
					<div class="single-features">
						<div class="f-icon">
							<img src="Include/img/features/f-icon4.png" alt="">
						</div>
						<h6>Pagos Seguros</h6>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- end features Area -->

	<!-- Start category Area -->
	<section class="category-area">
		<div class="container">
			<div class="row ">
				<div class="col-lg-8 col-md-12">
					<div class="row">
						<div class="col-lg-8 col-md-8">
							<div class="single-deal">
								<div class="overlay"></div>
								<img class="img-fluid w-100" src="Include/img/category/grafica.jpg" alt="">
								<a href="tienda.aspx?cat=Tarjetas%20de%20Video">
									<div class="deal-details">
										<h6 class="deal-title">Tarjetas Graficas</h6>
									</div>
								</a>
							</div>
						</div>
						<div class="col-lg-4 col-md-4">
							<div class="single-deal">
								<div class="overlay"></div>
								<img class="img-fluid w-100" src="Include/img/category/procesador.jpg" alt="">
								<a href="tienda.aspx?cat=Procesadores">
									<div class="deal-details">
										<h6 class="deal-title">Procesadores</h6>
									</div>
								</a>
							</div>
						</div>
						<div class="col-lg-4 col-md-4">
							<div class="single-deal">
								<div class="overlay"></div>
								<img class="img-fluid w-100" src="Include/img/category/ram.jpg" alt="">
								<a  href="tienda.aspx?cat=Memorias%20RAM">
									<div class="deal-details">
										<h6 class="deal-title">Memorias ram</h6>
									</div>
								</a>
							</div>
						</div>

						<div class="col-lg-8 col-md-8">
							<div class="single-deal">
								<div class="overlay"></div>
								<img class="img-fluid w-100" src="Include/img/category/componentes.jpg" alt="">
								<a href="tienda.aspx">
									<div class="deal-details">
										<h6 class="deal-title">Componentes</h6>
									</div>
								</a>
							</div>
						</div>
					</div>
				</div>
				<div class="col-lg-4 col-md-6">
					<div class="single-deal">
						<div class="overlay"></div>
						<img class="img-fluid w-100" src="Include/img/product/sale.png" alt="">
						<a href="tienda.aspx?ofertas=True">
							<div class="deal-details">
								<h6 class="deal-title">Ofertas</h6>
							</div>
						</a>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End category Area -->

	<!-- start product Area -->
	<section class="active-product-area section_gap">
		<!-- single product slide -->
		<div class="single-product-slider">
			<div class="container">
				<div class="row justify-content-center">
					<div class="col-lg-6 text-center">
						<div class="section-title">
							<h1>Nuevos Productos</h1>
							<p>Tenemos disponibles los ultimos productos del mercado.</p>
						</div>
					</div>
				</div>
				<div class="row">
					<!-- single product -->
					<asp:ListView ID="lstNewProd" runat="server">
						<ItemTemplate>
						<div class="col-lg-3 col-md-6">
							<div class="single-product">
								<asp:Image ID="imgProducto" runat="server" CssClass="img-fluid" ImageUrl='<%# "~/Include/img/product/" + Eval("imagen") %>'/>
								<div class="product-details">
									<h6><asp:Label ID="lblNombre" runat="server" Text='<%#Eval("nombre") %>' /></h6>
									<div class="price">
                                    <asp:Label ID="lblOriginal" class="h5 l-through" Visible='<%#(decimal)Eval("precio") != (decimal)Eval("precio_real")  %>' runat="server" Text='<%#"$"+Eval("precio").ToString() %>' /><br />
												
                                        <asp:Label class="text-success h6" ID="lblPrecio" runat="server" Text='<%#"$"+Eval("precio_real").ToString() %>' />
									</div>
									<div class="prd-bottom">
                                        <asp:LinkButton ID="lbtAñadir" CommandArgument='<%#Eval("id") %>' OnClick="lbtAñadir_Click" runat="server" class="social-info"><span class="ti-bag"></span>
											<p class="hover-text">Añadir</p></asp:LinkButton>
										<a href='producto.aspx?id=<%#Eval("id")%>' class="social-info">
											<span class="lnr lnr-move"></span>
											<p class="hover-text">Ver</p>
										</a>
									</div>
								</div>
							</div>
						</div>
						</ItemTemplate>
					</asp:ListView>
				</div>
			</div>
		</div>
		<!-- single product slide -->
	</section>
	<!-- end product Area -->

	<!-- Start exclusive deal Area -->
	<section class="exclusive-deal-area">
		<div class="container-fluid">
			<div class="row justify-content-center align-items-center">
				<div class="col-lg-6 no-padding exclusive-left">
					<div class="row clock_sec clockdiv" id="clockdiv">
						<div class="col-lg-12">
							<h1>Ofertas exclusivas</h1>
							<p>¡No las dejes pasar!</p>
						</div>
						<div class="col-lg-12">
							<div class="row clock-wrap">
								<div class="col clockinner clockinner1">
									<h1 class="days">1</h1>
									<span class="smalltext">Dias</span>
								</div>
								<div class="col clockinner clockinner1">
									<h1 class="hours">23</h1>
									<span class="smalltext">Horas</span>
								</div>
								<div class="col clockinner clockinner1">
									<h1 class="minutes">47</h1>
									<span class="smalltext">Minutos</span>
								</div>
								<div class="col clockinner clockinner1">
									<h1 class="seconds">59</h1>
									<span class="smalltext">Segundos</span>
								</div>
							</div>
						</div>
					</div>
					<a href="" class="primary-btn">Comprar</a>
				</div>
				<div class="col-lg-6 no-padding exclusive-right">
					<div class="active-exclusive-product-slider">
						<!-- single exclusive carousel -->
						<div class="single-exclusive-slider">
								<asp:Image ID="imgProducto" runat="server" CssClass="img-fluid" />
								<div class="product-details">
									<div class="price">
										<h2 class="l-through"><asp:Literal ID="lblOriginal"  runat="server"  />	</h2>
										<h2><asp:Literal ID="lblPrecio" runat="server"  /></h2>
									</div>
									<h4><asp:Literal ID="lblNombre" runat="server"  /></h4>
									<div class="add-bag d-flex align-items-center justify-content-center">
										<asp:LinkButton ID="lbtAñadir"  OnClick="lbtAñadir_Click" runat="server" class="add-btn">
											<span class="ti-bag"></span></asp:LinkButton>
										<span class="add-text text-uppercase">Añadir</span>
									</div>
								</div>
						</div>
						
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End exclusive deal Area -->

	<!-- Start brand Area -->
	<section class="brand-area section_gap">
		
	</section>
	<!-- End brand Area -->

	<!-- Start related-product Area -->
	<section class="related-product-area section_gap_bottom">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-lg-6 text-center">
					<div class="section-title">
						<h1>Ofertas disponibles</h1>
						<p>¡Las mejores ofertas de la web!</p>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-lg-9">
					<div class="row">
				<asp:ListView ID="lstOfertas" runat="server">
					<ItemTemplate>
						<div class="col-lg-4 col-md-4 col-sm-6 mb-20">
							<div class="single-related-product d-flex">
								<a href='producto.aspx?id=<%#Eval("id")%>'><asp:Image ID="imgProducto" runat="server" CssClass="img-fluid" ImageUrl='<%# "~/Include/img/product/" + Eval("imagen") %>'/>
									</a>
								<div class="desc">
									<a href="#" class="title"><asp:Label ID="lblNombre" runat="server" Text='<%#Eval("nombre") %>' /></a>
									<div class="price">
										<asp:Label ID="lblOriginal" class="h6 l-through" Visible='<%#(decimal)Eval("precio") != (decimal)Eval("precio_real")  %>' runat="server" Text='<%#"$"+Eval("precio").ToString() %>' /><br />
		
										<asp:Label class="text-success h6" ID="lblPrecio" runat="server" Text='<%#"$"+Eval("precio_real").ToString() %>' />
										
									</div>
								</div>
							</div>
						</div>
					</ItemTemplate>
				</asp:ListView>
					</div>
				</div>
				<div class="col-lg-3">
					<div class="ctg-right">
						<a href="#" target="_blank">
							<img class="img-fluid d-block mx-auto" src="Include/img/category/c5.jpg" alt="">
						</a>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End related-product Area -->
</asp:Content>

<asp:Content ContentPlaceHolderID="jsContent" runat="server">
	
        <script src="Include/js/jquery.nice-select.min.js"></script>
	<script>


        $(document).ready(function () {
            var deadline = new Date(<asp:Literal ID="litFecha" runat="server"></asp:Literal>);
            initializeClock('clockdiv', deadline);
        });
	</script>
</asp:Content>