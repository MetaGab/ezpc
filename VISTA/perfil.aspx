<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="VISTA.perfil" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Mi perfil</h1>
					<nav class="d-flex align-items-center">
						<a href="index.html">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="category.html">Perfil</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

	<!--================Login Box Area =================-->
	<section class="login_box_area section_gap">
		<div class="container">
        <div class="row">
            <div class="col-12">
                <div class="card">

                    <div class="card-body"><!--
                        <div class="card-title mb-4">
                            <div class="d-flex justify-content-start">
                                <div class="image-container-profile" id="image-container-profile">
                                    <img src="http://placehold.it/150x150" id="imgProfile" style="width: 150px; height: 150px" class="img-thumbnail" />
                                    <div class="middle">
                                        <input type="button" class="btn btn-secondary" id="btnChangePicture" value="Change" />
                                        <input type="file" style="display: none;" id="profilePicture" name="file" />
                                    </div>
                                </div>
                                <div class="userData ml-3">
                                    <h2 class="d-block" style="font-size: 1.5rem; font-weight: bold"><a href="javascript:void(0);">Nombre</a></h2>
                                    
                                   

                                  
                                </div>
                                <div class="ml-auto">
                                    <input type="button" class="btn btn-primary d-none" id="btnDiscard" value="Descartar Cambios" />
                                </div>
                            </div>
                        </div>
						-->
                        <div class="row">
                            <div class="col-12">
                                <ul class="nav nav-tabs mb-4" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="basicInfo-tab" data-toggle="tab" href="#basicInfo" role="tab" aria-controls="basicInfo" aria-selected="true">Informacion de la cuenta</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="ordenesProfile-tab" data-toggle="tab" href="#ordenesProfile" role="tab" aria-controls="ordenesProfile" aria-selected="false">Ordenes</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="cuponesProfile-tab" data-toggle="tab" href="#cuponesProfile" role="tab" aria-controls="cuponesProfile" aria-selected="false">Cupones</a>
                                    </li>
                                </ul>
                                <div class="tab-content ml-1" id="myTabContent">
                                    <div class="tab-pane fade show active" id="basicInfo" role="tabpanel" aria-labelledby="basicInfo-tab">
                                        

                                        <div class="row">
                                            <div class="col-sm-3 col-md-2 col-5">
                                                <label style="font-weight:bold;">Nombre</label>
                                            </div>
                                            <div class="col-md-8 col-6">
                                                <asp:Literal ID="litNombre" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                        <hr />

                                        <div class="row">
                                            <div class="col-sm-3 col-md-2 col-5">
                                                <label style="font-weight:bold;">Correo</label>
                                            </div>
                                            <div class="col-md-8 col-6">
                                                <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                        <hr />
                                        
                                        
                                        <div class="row">
                                            <div class="col-sm-3 col-md-2 col-5">
                                                <label style="font-weight:bold;">Telefono</label>
                                            </div>
                                            <div class="col-md-8 col-6">
                                                <asp:Literal ID="litTelefono" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                        <hr />
										
                                    <a href="#editarPerfil" class="btn primary-btn btn-sm" data-toggle="modal"> <span>Editar perfil</span></a>
                                    </div>

                                    <div class="tab-pane fade" id="ordenesProfile" role="tabpanel" aria-labelledby="ordenesProfile-tab">
                                    	<div class="table-responsive">
						                    <table class="table">
						                        <thead>
						                            <tr>
						                                <th scope="col">Orden #</th>
						                                <th scope="col">Fecha</th>
						                                <th>Productos</th>
						                                <th scope="col">Total</th>
						                            </tr>
						                        </thead>
						                        <tbody>
                                                    <asp:ListView ID="lstOrdenes" runat="server">
														<ItemTemplate>
															
															<tr>
																<td>
																	<div class="media">
																		<div class="media-body">
																			<p><%# Eval("id") %></p>
																		</div>
																	</div>
																</td>
																<td>
																	<h5><%# Eval("fecha_compra") %></h5>
																</td>
																<td>
																	<div class="product_count">
																		<ul>
																			<asp:ListView runat="server" DataSource='<%# Eval("OrdenItem") %>'>
																				<ItemTemplate>
																					<li><%#Eval("Producto.nombre") %> (<%#Eval("cantidad")%>)</li>
																				</ItemTemplate>
																			</asp:ListView>
																			
																		</ul>
																	</div>
																</td>
																<td>
																	<h5>$ <%# Eval("costo_total") %></h5>
																</td>
															</tr>
														</ItemTemplate>
														

                                                    </asp:ListView>
						                       
						                        </tbody>
						                    </table>
                						</div>
                                    </div>
									<!--
                                    <div class="tab-pane fade" id="cuponesProfile" role="tabpanel" aria-labelledby="cuponesProfile-tab">
                                    	<div class="table-responsive">
						                    <table class="table">
						                        <thead>
						                            <tr>
						                                <th scope="col">Cupon #</th>
						                                <th scope="col">Categoria</th>
						                                <th scope="col">Fecha de expiracion</th>
						                                <th scope="col">Compra minima</th>
						                                <th scope="col"> Descuento</th>
						                            </tr>
						                        </thead>
						                        <tbody>
						                            <tr>
						                                <td>
						                                    <div class="media">
						                                        <div class="media-body">
						                                            <p>DSFSASDA-ASDASDASDA</p>
						                                        </div>
						                                    </div>
						                                </td>
						                                <td>
						                                    <h5>Categoria</h5>
						                                </td>
						                                <td>
						                                    <h5>08/06/1999</h5>
						                                </td>
						                                <td>
						                                    <h5>$100.00</h5>
						                                </td>
						                                <td>
						                                    <h5>$10.00</h5>
						                                </td>
						                            </tr>
						                       
						                        </tbody>
						                    </table>
                						</div>
                                    </div>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
	</section>

	<div id="editarPerfil" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
					<div class="modal-header">						
						<h4 class="modal-title">Editar Perfil</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<div class="form-group">
							<label>Nombre</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label>Primer Apellido</label>
                            <asp:TextBox ID="txtPrimerApellido" CssClass="form-control"  runat="server"></asp:TextBox>
						</div>
						
						<div class="form-group">
							<label>Segundo Apellido</label>
                            <asp:TextBox ID="txtSegundoApellido" CssClass="form-control"  runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label>Correo</label>
                            <asp:TextBox ID="txtCorreo" CssClass="form-control"  runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label>Telefono</label>
                            <asp:TextBox ID="txtTelefono" CssClass="form-control"  runat="server"></asp:TextBox>
						</div>			
					</div>
					<div class="modal-footer">
						<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancelar">
						<asp:Button ID="btnGuardar" OnClick="btnGuardar_Click"	 class="btn btn-info" runat="server" Text="Guardar" />
					</div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="js" ContentPlaceHolderID="jsContent" runat="server">
	<script src="Include/js/owl.carousel.min.js"></script>
	<script src="Include/js/jquery.nice-select.min.js"></script>
	<script src="Include/js/profile.js"></script>
</asp:Content>
