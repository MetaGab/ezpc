<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="tienda.aspx.cs" Inherits="VISTA.tienda" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
		
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Catalogo de productos</h1>
					<nav class="d-flex align-items-center">
						<a href="index.html">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Tienda<span class="lnr lnr-arrow-right"></span></a>
						<a href="category.html">Catalogo de Productos</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
	<div class="container">
		<div class="row">
			<div class="col-xl-3 col-lg-4 col-md-5">
				<div class="sidebar-categories">
					<div class="head">Categorias</div>
					<ul class="main-categories">
						<asp:ListView ID="lstCategorias" runat="server">
							<ItemTemplate>

								<li class="main-nav-list">
											<a href='?cat=<%#Eval("nombre") %>'><span
								 class="lnr lnr-arrow-right"></span>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("nombre") %>'></asp:Label><span class="number"><asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("Producto.Count") %>'></asp:Label></span></a>
									</a>
								<li>
							</ItemTemplate>
						</asp:ListView>
					</ul>
				</div>
				<div class="sidebar-filter mt-50">
					
					<div class="common-filter">
                            <asp:HiddenField ID="hdnMin" ClientIDMode="Static" runat="server" value="0.00"/>
                            <asp:HiddenField ID="hdnMax" ClientIDMode="Static" runat="server" value="1000.00"/>
						<div class="head">Filtrar por Precio</div>
						<div class="price-range-area" id="price-range-area">
							<div id="price-range"></div>
							<div class="value-wrapper d-flex text-dark">
								<div class="price">Precio:</div>
								<span>$</span>
								<div id="lower-value"></div>
								<div class="to">to</div>
								<span>$</span>
								<div id="upper-value"></div>
							</div>
							
							<div class="form-group">	
							<asp:Button ID="btnFiltro" CssClass=" rounded-0 border-0	 primary-btn" runat="server" OnClick="btnFiltro_Click" Text="Filtrar" />
							</div>
						</div>
                            
					</div>
				</div>
			</div>
			<div class="col-xl-9 col-lg-8 col-md-7">
				<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center">
					<div class="sorting">
						<asp:DropDownList ID="ddlOrder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged">
							<asp:ListItem Value="0">Ordenar por...</asp:ListItem>
							<asp:ListItem Value="1">Alfabeticamente (A -> Z)</asp:ListItem>
							<asp:ListItem Value="2">Más caro</asp:ListItem>
							<asp:ListItem Value="3">Más barato</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
							<asp:ListItem Value="12">Mostrar 12</asp:ListItem>
							<asp:ListItem Value="24">Mostrar 24</asp:ListItem>
							<asp:ListItem Value="48">Mostrar 48</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="pagination border-left-0 text-right ">
                        <asp:DataPager ID="dpgTienda" PagedControlID="lstProductos" PageSize="12"  runat="server">
							<Fields>
								<asp:TemplatePagerField OnPagerCommand="tpfPage_PagerCommand">
									<PagerTemplate >
										<asp:LinkButton CssClass="prev-arrow" runat="server" Visible='<%# Container.StartRowIndex > 0 %>' CommandName="Prev"><i class="fa fa-long-arrow-left" aria-hidden="true"></i></asp:LinkButton>
										<asp:LinkButton CssClass="next-arrow" runat="server" Visible='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount %>' CommandName="Next"><i class="fa fa-long-arrow-right" aria-hidden="true"></i></asp:LinkButton>

									</PagerTemplate>
								</asp:TemplatePagerField>
							</Fields>
                        </asp:DataPager>
					</div>
				</div>
				<!-- End Filter Bar -->
				<!-- Start Best Seller -->
				<section class="lattest-product-area pb-40 category-list">
					<div class="row">
						<!-- single product -->
						<asp:ListView ID="lstProductos" runat="server" OnPagePropertiesChanged="lstProductos_PagePropertiesChanged"	>
							<ItemTemplate>
								<div class="col-lg-4 col-md-6">
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
						
				</section>
				<!-- End Best Seller -->
				<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center">
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ddlPage2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage2_SelectedIndexChanged">
							<asp:ListItem Value="12">Mostrar 12</asp:ListItem>
							<asp:ListItem Value="24">Mostrar 24</asp:ListItem>
							<asp:ListItem Value="48">Mostrar 48</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="pagination border-left-0 text-right ">
                        <asp:DataPager ID="dpgPage2" PagedControlID="lstProductos" PageSize="12"  runat="server">
							<Fields>
								<asp:TemplatePagerField OnPagerCommand="tpfPage_PagerCommand">
									<PagerTemplate >
										<asp:LinkButton CssClass="prev-arrow" runat="server" Visible='<%# Container.StartRowIndex > 0 %>' CommandName="Prev"><i class="fa fa-long-arrow-left" aria-hidden="true"></i></asp:LinkButton>
										<asp:LinkButton CssClass="next-arrow" runat="server" Visible='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount %>' CommandName="Next"><i class="fa fa-long-arrow-right" aria-hidden="true"></i></asp:LinkButton>

									</PagerTemplate>
								</asp:TemplatePagerField>
							</Fields>
                        </asp:DataPager>
					</div>
				</div>
				<!-- End Filter Bar -->
			</div>
		</div>
	</div>
</asp:Content>

<asp:Content ContentPlaceHolderID="jsContent" runat="server">
	<script src="Include/js/owl.carousel.min.js"></script>
	
	<script src="Include/js/jquery.nice-select.min.js"></script>
</asp:Content>