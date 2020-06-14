<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="crud-cat.aspx.cs" Inherits="VISTA.crud_cat" %>

<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
        <form runat="server" id="form1">
        <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-title">Categorías</strong>
                            </div>
                            <div class="card-body">
                                <table id="bootstrap-data-table-export" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Nombre</th>
                                            <th>Activo</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                        <asp:ListView ID="lstCats" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><asp:Literal ID="litNombre" Text='<%#Eval("nombre") %>' runat="server"></asp:Literal></td>
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
    <script src="vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="vendors/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js"></script>
    <script src="vendors/jszip/dist/jszip.min.js"></script>
    <script src="vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="vendors/pdfmake/build/vfs_fonts.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.colVis.min.js"></script>
    <script src="assets/js/init-scripts/data-table/datatables-init.js"></script>
</asp:Content>