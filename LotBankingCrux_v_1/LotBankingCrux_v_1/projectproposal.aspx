<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectproposal.aspx.cs" Inherits="LotBankingCrux_v_1.projectproposal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/themes/projprop.css" />
    
    <script>
        $(document).ready(function () {
            $('.bool-slider .inset .control').click(function () {
                if (!$(this).parent().parent().hasClass('disabled')) {
                    if ($(this).parent().parent().hasClass('false')) {
                        $(this).parent().parent().addClass('true').removeClass('false');
                    } else {
                        $(this).parent().parent().addClass('false').removeClass('true');
                    }
                }
            });
        });
    </script>
   
     <title></title>
</head>
    <body>
        <form id="form1" runat="server">
            <div class="wrapper">
                <h2 class="create-a-project">Create a Project</h2>
                <ul>
                    <li class="name">
                        <h4>Name <asp:TextBox class="user-info" ID="TextBox1" runat="server"></asp:TextBox>
                        </h4>
                    </li>
                    <li class="location">
                        <h4 id="long">Longitude<asp:TextBox class="user-info" ID="TextBox2" runat="server"></asp:TextBox>
                        </h4>
                        <h4 id="lat">Latitude<asp:TextBox class="user-info" ID="TextBox3" runat="server"></asp:TextBox>
                        </h4>
                    </li>
                    <li class="num-lots">
                        <h4>Number of Lots<asp:DropDownList class="user-info" ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                        </h4>
                    </li>
                    <li class="acq-price">
                        <h4>Acquisition Price <span class="currency">$</span><asp:TextBox class="user-info" ID="TextBox4" runat="server"></asp:TextBox>
                        </h4>
                    </li>
                    <li class="imp-costs">
                        <h4>Improvement Costs <span class="currency">$</span><asp:TextBox class="user-info" ID="TextBox5" runat="server"></asp:TextBox>
                        </h4>
                    </li>
                </ul>
                <ul>
                    <li class="add-opts">
                        <h4>Additional Options </h4>
                          <div class="bool-slider false"> 
                            <div class="inset">
                              <div class="control">
                              </div>
                             </div>
                          </div>
                    </li>
                    <li class="cancelcreate-parent">
                        <asp:Button class="create" ID="Button1" runat="server" Text="Create Project" />
                        <asp:Button class="cancel" ID="Button2" runat="server" Text="Cancel" />
                        <!--
                        <div class="create">
                            <h4>Create Project</h4>
                        </div>
                        <div class="cancel">
                            <h4>Cancel</h4>
                        </div>
                            -->
                    </li>
                </ul>
    
            </div>
        </form>
    </body>
</html>
