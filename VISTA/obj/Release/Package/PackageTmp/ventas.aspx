<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="VISTA.ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="mb-3">Ordenes</h4>
                                <canvas id="sales-chart"></canvas>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="mb-3">Ventas</h4>
                                <canvas id="money-chart"></canvas>
                            </div>
                        </div>
                    </div>


</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="server">
    
    <script src="/Include/vendors/chart.js/dist/Chart.bundle.min.js"></script>
    <script>
        var ctx = document.getElementById("sales-chart");
        ctx.height = 150;
        var myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: [<asp:ListView ID="lstLabels" runat="server">
                    <ItemTemplate>
                        "<asp:Literal runat="server" Text='<%#Eval("Date")%>'></asp:Literal>",
                    </ItemTemplate>
                    </asp:ListView>
                ],
                type: 'line',
                defaultFontFamily: 'Montserrat',
                datasets: [{
                    data: [<asp:ListView ID="lstData" runat="server">
                        <ItemTemplate>
                            <asp:Literal runat="server" Text='<%#Eval("Count")%>'></asp:Literal>,
                    </ItemTemplate>
                    </asp:ListView >
                    ],
                    label: "Expense",
                    backgroundColor: 'rgba(0,103,255,.15)',
                    borderColor: 'rgba(0,103,255,0.5)',
                    borderWidth: 3.5,
                    pointStyle: 'circle',
                    pointRadius: 5,
                    pointBorderColor: 'transparent',
                    pointBackgroundColor: 'rgba(0,103,255,0.5)',
                },]
            },
            options: {
                responsive: true,
                tooltips: {
                    mode: 'index',
                    titleFontSize: 12,
                    titleFontColor: '#000',
                    bodyFontColor: '#000',
                    backgroundColor: '#fff',
                    titleFontFamily: 'Montserrat',
                    bodyFontFamily: 'Montserrat',
                    cornerRadius: 3,
                    intersect: false,
                },
                legend: {
                    display: false,
                    position: 'top',
                    labels: {
                        usePointStyle: true,
                        fontFamily: 'Montserrat',
                    },


                },
                scales: {
                    xAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        scaleLabel: {
                            display: false,
                            labelString: 'Month'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        }
                    }]
                },
                title: {
                    display: false,
                }
            }
        });
        var ctx = document.getElementById("money-chart");
        ctx.height = 150;
        var myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: [ <asp:ListView ID="lstLabels2" runat="server">
                    <ItemTemplate>
                        "<asp:Literal runat="server" Text='<%#Eval("Date")%>'></asp:Literal>",
                    </ItemTemplate>
                    </asp:ListView >
                ],
        type: 'line',
            defaultFontFamily: 'Montserrat',
                datasets: [{
                    data: [<asp:ListView ID="lstData2" runat="server">
                        <ItemTemplate>
                            <asp:Literal runat="server" Text='<%#Eval("Sum")%>'></asp:Literal>,
                    </ItemTemplate>
                    </asp:ListView>],
            label: "Expense",
            backgroundColor: 'rgba(255,103,0,.15)',
            borderColor: 'rgba(255,103,0,0.5)',
            borderWidth: 3.5,
            pointStyle: 'circle',
            pointRadius: 5,
            pointBorderColor: 'transparent',
            pointBackgroundColor: 'rgba(255,103,0,0.5)',
        },]
            },
        options: {
            responsive: true,
                tooltips: {
                mode: 'index',
                    titleFontSize: 12,
                        titleFontColor: '#000',
                            bodyFontColor: '#000',
                                backgroundColor: '#fff',
                                    titleFontFamily: 'Montserrat',
                                        bodyFontFamily: 'Montserrat',
                                            cornerRadius: 3,
                                                intersect: false,
                },
            legend: {
                display: false,
                    position: 'top',
                        labels: {
                    usePointStyle: true,
                        fontFamily: 'Montserrat',
                    },


            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: false
                    },
                    scaleLabel: {
                        display: false,
                        labelString: 'Month'
                    }
                }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        }
                    }]
            },
            title: {
                display: false,
                }
        }
        });
    </script>
</asp:Content>
