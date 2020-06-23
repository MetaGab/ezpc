<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="ordenes.aspx.cs" Inherits="VISTA.ordenes" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Ordenes</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table-export" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Cliente</th>
                                        <th>Destino</th>
                                        <th>Fecha</th>
                                        <th>Productos</th>
                                        <th>Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                        
                                    <asp:ListView ID="lstOrdenes" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><asp:Literal ID="litID" Text='<%#Eval("id") %>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal ID="litNombre" Text='<%#Eval("Usuario.nombre")+" "+Eval("Usuario.primer_apellido")%>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal ID="litDireccion" Text='<%#Eval("Direccion.Ciudad.nombre")+", "+Eval("Direccion.Ciudad.Estado.Pais.nombre") %>' runat="server"></asp:Literal></td>
                                                
                                                <td><asp:Literal ID="Literal1" Text='<%#Eval("fecha_compra") %>' runat="server"></asp:Literal></td>
                                                <td class="pl-5">
                                                    <ul >
                                                    <asp:ListView runat="server" ID="lstProd" DataSource='<%#Eval("OrdenItem") %>'> 
                                                        <ItemTemplate>
                                                            <li><asp:Literal ID="litProd" Text='<%# Eval("Producto.nombre") + " ("+Eval("cantidad")+")" %>' runat="server"></asp:Literal></li>
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                    </ul>
                                                </td>
                                                <td>$<asp:Literal ID="litPrecio" Text='<%#Eval("costo_total") %>' runat="server"></asp:Literal></td>
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
</asp:Content>
