<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VISTA.login1" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    
	
	<!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Iniciar Sesión</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="#">Iniciar Sesión</a>
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
						<img class="img-fluid" src="Include/img/login.jpg" alt="">
						<div class="hover">
							<h4>¿No tienes cuenta?</h4>
							<p>Crea una cuenta con nosotros para no perderte de nuestras ofertas
							exclusivas</p>
							<a class="primary-btn" href="signup.aspx">Crear cuenta</a>
						</div>
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner">
						<h3>Log in</h3>
						<div class="row login_form">
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtEmail" placeholder="Correo Electrónico" />
							</div>
							<div class="col-md-12 form-group">
								<asp:TextBox runat="server" class="form-control" ID="txtContraseña" placeholder="Contraseña" TextMode="Password" />
							</div>
							<div class="col-md-12 form-group">
								<div class="creat_account">
									<asp:CheckBox runat="server" ID="chkMantenerLog"  Text="Mantener Sesión"/>
								</div>
							</div>
							<div class="col-md-12 form-group">								
								<asp:Button runat="server" Text="Iniciar Sesión" ID="btnInicio" class="primary-btn" OnClick="btnInicio_Click"  />
								<a href="#">¿Olvidaste tu contraseña? </a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
