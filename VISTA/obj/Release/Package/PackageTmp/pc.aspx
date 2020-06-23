<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="pc.aspx.cs" Inherits="VISTA.pc" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Configurador de PC</h1>
					<nav class="d-flex align-items-center">
						<a href="index.html">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Tienda<span class="lnr lnr-arrow-right"></span></a>
						<a href="category.html">Configurador de PC</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
	<div class="container">
		<div class="row">
			<div class="col-12">
				<div class="sidebar-categories">
					<div class="head">Configuracion PC</div>
					<ul class="main-categories">
                        <asp:ListView ID="lstCategorias" runat="server">
							<ItemTemplate>
								<li class="main-nav-list"><a class="h2" data-toggle="collapse" href='<%# "#"+((string)Eval("nombre")).Replace(" ","-") %>' aria-expanded="false" aria-controls='<%#((string)Eval("nombre")).Replace(" ","-") %>'>
									<%#Eval("nombre") %><span class="number"><%#"("+Eval("Producto.Count")+")" %></span></a>
									<ul class="collapse" id='<%#((string)Eval("nombre")).Replace(" ","-")  %>' data-toggle="collapse" aria-expanded="false" aria-controls='<%#((string)Eval("nombre")).Replace(" ","-")  %>'>
										<section class="lattest-product-area pb-40 category-list">
											<div class="row">
												<!-- single product -->
													<asp:ListView runat="server" DataSource='<%# Eval("Producto") %>'> 
														<ItemTemplate>
															<a class="col-lg-2 col-md-3" id='<%#Eval("id") %>'>
																<div class="single-product">
																	<asp:Image CssClass="img-fluid" ImageUrl='<%#"~/Include/img/product/" + Eval("imagen")  %>' runat="server"/>
																		<div class="product-details">
																			<h6 id="nombreProducto"><%#Eval("nombre") %></h6>
																			<div class="price">
																				<h6 class="text-success">$ <%# Eval("precio")%></h6>
																			</div>
																	</div>
																</div>
															</a>
														</ItemTemplate>

													</asp:ListView>
											</div>
										</section>
									</ul>
								</li>
							</ItemTemplate>
                        </asp:ListView>
					</ul>
				</div>
				<br>
			</div>
			<div class="col-lg-8">
                
				
				<div class="sidebar-categories">
				<div class="head">Configuracion creada</div>
				</div>
            		<section class="cart_area2">
				        <div class="container">
				            <div class="cart_inner">
				                <div class="table-responsive">
				                    <table class="table">
				                        <tbody id="destino-carrito">
				                            <tr>
				                            </tr>
				                        </tbody>
				                    </table>
				                </div>
				            </div>
				        </div>
   					</section>
			</div>
			<div class="col-lg-4">
              <div class="order_box">
                            <h2>Equipo</h2>
                            <ul class="list list_2">
                                <li><a href="#">Subtotal <span id="subtotal">$0.00</span></a></li>
                                <li><a href="#">Envio <span> $50.00</span></a></li>
                                <li><a href="#">Total <span id="total">$50.00</span></a></li>
                            </ul>
							<asp:Button class="primary-btn" ID="btnCarrito" runat="server" Text="Agregar al carrito" OnClick="btnCarrito_Click"	 />
              </div>
            </div>
			<asp:HiddenField ID="hdnValues" ClientIDMode="Static" runat="server" />
		</div>
	</div>

</asp:Content>
<asp:Content ContentPlaceHolderID="jsContent" runat="server">
	<script>
        var pc = {};
			
        function renderTable() {
            var suma = 0;
            var ids = "";
            $("tbody").html("<tr></tr>");
            for (var k in pc) {
                var part = pc[k];
				ids += part["id"] +","
				suma += parseFloat(part["precio"].slice(2))
                $("#destino-carrito tr:last").after("<tr><td><img src='"+part["imagen"]+"' height=50 width=50/><h5>"+part["nombre"]+"</h5></td><td><h5>"+part["precio"]+"</h5></td></tr>");
            }
            $("#subtotal").text("$" + suma.toFixed(2));
            $("#total").text("$" + (suma + 50).toFixed(2));
            $("#hdnValues").val(ids.slice(0, -1));
        }

        $(".single-product").click(function () {
            var cat = $(this).closest("li").children("a").attr("aria-controls")
            if (cat in pc) {
                $(this).parent().siblings("#" + pc[cat]["id"]).css("border", "none");
                $(this).find(".img-fluid").css("filter", "none");
                delete pc[cat];
            }
            var nombre = $(this).find("#nombreProducto").text();
            var imagen = $(this).find(".img-fluid").attr("src");
            var precio = $(this).find(".text-success").text();
            $(this).parent().css("border", "solid 2px green")
            $(this).parent().siblings().find(".img-fluid").css("filter", "grayscale(100%)");
            pc[cat] = { "id": $(this).parent().attr("id"), "nombre": nombre, "precio": precio, "imagen": imagen };
            renderTable();
        });
	</script>
</asp:Content>