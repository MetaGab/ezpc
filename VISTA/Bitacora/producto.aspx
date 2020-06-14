<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="VISTA.Bitacora.producto" %>
<asp:Content ID="main" ContentPlaceHolderID="mainContent" runat="server">
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Bitacora de Producto</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table-export" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Campos</th>
                                        <th>Fecha</th>
                                        <th>Usuario</th>
                                        <th>Tipo de Operacion</th>
                                    </tr>
                                </thead>
                                <tbody>
                                        
                                    <asp:ListView ID="lstBitacora" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><asp:Literal Text='<%#Eval("campos") %>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal Text='<%#Eval("fecha") %>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal Text='<%#Eval("usuario") %>' runat="server"></asp:Literal></td>
                                                <td><asp:Literal Text='<%#Eval("tipo_operacion") %>' runat="server"></asp:Literal></td>
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
<asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
