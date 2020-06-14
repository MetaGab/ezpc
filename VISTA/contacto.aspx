<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="VISTA.contacto1" %>
<asp:Content ID="content" ContentPlaceHolderID="mainContent" runat="server">
    
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Contactanos</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Contactanos</a>
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
				<div class="col-lg-12">
					<div class=" pt-4 ">
						<div class="row">
							<div class="text-center formulario login_form col-lg-12 px-5">
								<h3>Contacto</h3>
								<div class="form-row ">
									<div class="form-group col-md-4">
										<asp:TextBox ID="txtNombre" class="form-control" runat="server" placeholder="Nombre"/>  
									</div>
                        
									<div class="form-group col-md-4">
										<asp:TextBox ID="txtApellido1" class="form-control" runat="server" placeholder="Primer Apellido"/>  
									</div>
                        
									<div class="form-group col-md-4">
										<asp:TextBox ID="txtApellido2" class="form-control" runat="server" placeholder="Segundo Apelldo" />  
									</div>
								</div>
								<div class="form-row">
									<div class="form-group col-md-8">
										<asp:TextBox class="form-control" ID="txtAddress" placeholder="Dirección" runat="server" />
									</div>
                        
									<div class="form-group col-md-4">
										<asp:TextBox class="form-control" ID="txtNumExterior" placeholder="Número exterior" runat="server" />
									</div>
								</div>
								<div class="form-row">
									<div class="form-group col-md-6">
										<asp:TextBox class="form-control" ID="txtCorreo" placeholder="Correo Electrónico" runat="server" />
									</div>
                        
									<div class="form-group col-md-6">
										<asp:TextBox class="form-control" ID="txtTelefono" placeholder="Teléfono" runat="server" />
									</div>
								</div>
								<div class="form-row">
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
										<asp:DropDownList CssClass="form-control"  ID="ddlCiudad" runat="server" AutoPostBack="True">
											   <asp:ListItem Value="0" Selected="True">Selecciona...</asp:ListItem>
										</asp:DropDownList>
									</div>
								</div>
								<div class="form-group">
									<label for="txtSugerencia">Sugerencia</label>
									<asp:TextBox class="form-control" ID="txtSugerencia" placeholder="Tu mensaje aqui..." runat="server" TextMode="MultiLine"/>
								</div>
								<asp:Button runat="server" Text="Enviar" ID="btnEnviar" class="primary-btn" OnClick="btnEnviar_Click"/>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- start footer Area -->
</asp:Content>

<asp:Content ContentPlaceHolderID="jsContent" ID="js" runat="server"></asp:Content>
