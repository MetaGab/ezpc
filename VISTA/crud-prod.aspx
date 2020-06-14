<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="crud-prod.aspx.cs" Inherits="VISTA.Include.crud_prod" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
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
                                            <th>Imagen</th>
                                            <th>Nombre</th>
                                            <th>Descripción</th>
                                            <th>Categoría</th>
                                            <th>Precio</th>
                                            <th>Stock</th>
                                            <th>Activo</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                        <asp:ListView ID="lstProds" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><asp:Image ID="imgProducto" runat="server" CssClass="img-fluid" Height="50" Width="50" ImageUrl='<%# "~/Include/img/product/" + Eval("imagen") %>'/></td>
                                                    <td><asp:Literal ID="litNombre" Text='<%#Eval("nombre") %>' runat="server"></asp:Literal></td>
                                                    <td><asp:Literal ID="litDesc" Text='<%#Eval("descripcion") %>' runat="server"></asp:Literal></td>
                                                    <td><asp:Literal ID="litCat" Text='<%#Eval("Categoria.nombre") %>' runat="server"></asp:Literal></td>
                                                    <td>$<asp:Literal ID="litPrecio" Text='<%#Eval("precio") %>' runat="server"></asp:Literal></td>
                                                    <td><asp:Literal ID="litStock" Text='<%#Eval("stock") %>' runat="server"></asp:Literal></td>
                                                     <td><i class="fa fa-<asp:Literal ID="litActive" Text='<%#(bool)Eval("activo") ? "check" : "times"%>' runat="server"></asp:Literal>"></i></td>
                                                    
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
                                        <div class="col col-md-3"><label class=" form-control-label">Nombre</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Descripcion</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtDesc" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class="form-control-label">Categoria</label></div>
                                        <div class="col-12 col-md-9">
                                            <asp:DropDownList ID="ddlCat" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Precio</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Stock</label></div>
                                        <div class="col-12 col-md-9"><asp:TextBox ID="txtStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></div>
                                    </div>
                                    
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label  class=" form-control-label">Imagen</label></div>
                                        <div class="col-12 col-md-9"><asp:FileUpload ID="fupImagen" runat="server" /></div>
                                        <asp:Label CssClass="col-md-9 offset-md-3" runat="server" ID="lblImagen"></asp:Label>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label class=" form-control-label">Activo</label></div>
                                        <div class="col-12 col-md-9"><asp:Checkbox ID="chkActivo" runat="server"></asp:Checkbox></div>
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
<asp:Content ID="js" ContentPlaceHolderID="jsContent" runat="server">
    

    <script src="Include/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Include/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="Include/vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="Include/vendors/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js"></script>
    <script src="Include/vendors/jszip/dist/jszip.min.js"></script>
    <script src="Include/vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="Include/vendors/pdfmake/build/vfs_fonts.js"></script>
    <script src="Include/vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="Include/vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="Include/vendors/datatables.net-buttons/js/buttons.colVis.min.js"></script>
    <script src="Include/backoffice/js/init-scripts/data-table/datatables-init.js"></script>

</asp:Content>