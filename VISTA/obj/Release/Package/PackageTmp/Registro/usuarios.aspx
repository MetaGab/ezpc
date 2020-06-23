<%@ Page Title="" Language="C#" EnableEventValidation="false"  MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="VISTA.usuarios" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Usuarios</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table-export" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Email</th>
                                        <th>Telefono</th>
                                        <th>Tipo</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                        
                                    <asp:ListView ID="lstUsuarios" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><asp:Literal ID="litNombre" Text='<%#Eval("nombre")+" "+Eval("primer_apellido") + " "+ Eval("segundo_apellido")%>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal ID="litEmail" Text='<%#Eval("email") %>' runat="server"></asp:Literal></td>
                                                
                                                <td><asp:Literal ID="litTelefono" Text='<%#Eval("telefono") %>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal ID="litTipo" Text='<%#Eval("TipoUsuario.id") %>' runat="server"></asp:Literal></td>
                                                <td>
                                                    <asp:Button ID="btnTipo" obj='<%#Eval("id") %>' OnClick="btnTipo_Click"  CssClass='<%#"btn btn-"+ ((string)Eval("TipoUsuario.nombre") == "Cliente" ? "success" : "danger")%>' runat="server" Text='<%#(string)Eval("TipoUsuario.nombre") == "Cliente" ? "Dar Admin" : "Quitar Admin"%>'  />
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
    </div>
        </form>
</asp:Content>
