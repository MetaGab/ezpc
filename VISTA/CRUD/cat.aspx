<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="cat.aspx.cs" Inherits="VISTA.crud_cat" %>

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
                                <div>
                                    <div class="row">
                                    
                                        <div class="col-md-6 input-group">
                                            <asp:RadioButtonList CssClass="py-4" AutoPostBack="true" runat="server" ID="rbtEstado">
                                                <asp:ListItem Selected="True">Activo</asp:ListItem>
                                                <asp:ListItem>Inactivo</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-6 text-right">
                                            <asp:Button runat="server" CssClass="btn btn-success" Text="Agregar" ID="btnAgregar" CausesValidation="false" OnClick="btnAgregar_Click"/>
                                        </div>
                                    </div>
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
                    </div>
                </div>
                
            </div><!-- .content -->
        </div>
            <div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="lblModal" runat="server">Agregar</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
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
                            <div class="modal-footer">
                                    
                                <asp:LinkButton ID="lbtGuardar" OnClick="lbtGuardar_Click" CssClass="btn btn-primary" runat="server">
                                <i class="fa fa-dot-circle-o"></i> Guardar
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
        </form>
</asp:Content>

<asp:Content ID="js" ContentPlaceHolderID="jsContent" runat="server">
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