<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="oferta.aspx.cs" Inherits="VISTA.crud_oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
     <form runat="server" id="form1">
        <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-title">Productos</strong>
                            </div>
                            <div class="card-body">
                                <table id="bootstrap-data-table-export" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Producto</th>
                                            <th>Descuento</th>
                                            <th>Expiracion</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                        <asp:ListView ID="lstOff" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                   
                                                    <td><asp:Literal ID="litNombre" Text='<%#Eval("Producto.nombre") %>' runat="server"></asp:Literal></td>
                                                    <td><asp:Literal ID="litDesc" Text='<%#Eval("descuento") %>' runat="server"></asp:Literal></td>
                                                    <td><asp:Literal ID="litExp" Text='<%#Eval("expiracion") %>' runat="server"></asp:Literal></td>
                                                    <td>
                                                    <asp:Button ID="btnEditar" obj='<%#Eval("id") %>' OnClick="btnEditar_Click"  CssClass="btn btn-warning" runat="server" Text="Editar" />
                                                    <asp:Button ID="btnBorrar" obj='<%#Eval("id") %>' OnClick="btnBorrar_Click"  CssClass="btn btn-danger" runat="server" Text="Borrar" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                            </div>
                            <div class="card-body card-block">
                                <div class="form-horizontal">
                                    <asp:HiddenField ID="hdnProdId" runat="server" Value="0"/>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class="form-control-label">Producto</label></div>
                                        <div class="col-12 col-md-9">
                                            <asp:DropDownList ID="ddlProd" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Descuento</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtDesc" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Expiracion</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtExp"  CssClass="form-control" runat="server" TextMode="DateTimeLocal"></asp:TextBox></div>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="card-footer">
                                 <asp:LinkButton ID="lbtGuardar" OnClick="lbtGuardar_Click" CssClass="btn btn-primary" runat="server">
                                    <i class="fa fa-dot-circle-o"></i> Guardar
                                 </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </div>
            </div><!-- .animated -->
        </div><!-- .content -->
        </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="server">
    

    <script src="/Include/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="/Include/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="/Include/vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="/Include/vendors/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js"></script>
    <script src="/Include/vendors/jszip/dist/jszip.min.js"></script>
    <script src="/Include/vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="/Include/vendors/pdfmake/build/vfs_fonts.js"></script>
    <script src="/Include/vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="/Include/vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="/Include/vendors/datatables.net-buttons/js/buttons.colVis.min.js"></script>
    <script src="/Include/backoffice/js/init-scripts/data-table/datatables-init.js"></script>
</asp:Content>
