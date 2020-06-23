<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="VISTA.signup1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Registrarse</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Registrarse</a>
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
				<div class="col-lg-6">
					<div class="login_box_img">
						<img class="img-fluid" src="Include/img/login.jpg" alt="" />
						<div class="hover">
							<h4>¿No tienes cuenta?</h4>
							<p>Crea una cuenta con nosotros para no perderte de nuestras ofertas
							exclusivas</p>
						</div>
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner pt-4">
						<h3>Crear cuenta</h3>
						<div class="row login_form">
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtNombre"  placeholder="Nombre" />
							</div>
							<div class="col-md-6 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtPrimerApellido" placeholder="Primer Apellido" />
							</div>
							<div class="col-md-6 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtSegundoApellido" placeholder="Segundo Apellido" />
							</div>
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtEmail" placeholder="Correo Electrónico" />
							</div>
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtTelefono" placeholder="Telefono" />
							</div>
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtContraseña" placeholder="Contraseña" TextMode="Password" />
							</div>
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtContraseñaConfirmar" placeholder="Confirmar Contraseña" TextMode="Password" />
							</div>
							<div class="col-md-12 form-group">
								<div class="create_account">
								</div>
							</div>
							<div class="col-md-12 form-group">
								<asp:Button runat="server" Text="Crear Cuenta" ID="btnCrear" class="primary-btn" OnClick="btnCrear_Click" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>