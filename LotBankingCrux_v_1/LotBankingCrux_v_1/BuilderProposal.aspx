<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuilderProposal.aspx.cs" Inherits="LotBankingCrux_v_1.BuilderProposal" %>

<!DOCTYPE html>
<!-- This is something new added -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .panel-parent {
            display: block;
            border: thin outset #C0C0C0;
            background-color: #EEEEEE;
            margin: 0 auto;
            height: 830px;
            width: 82%;
        }

        .panel-background {
            background-color: #FFFFFF;
            height: 930px;
            width: 100%;
        }

        .panel-style {
            background-color: #CCCCCC;
            display: block;
            margin: 0 auto;
            margin-top: 5px;
            margin-bottom: 5px;
            height: 250px;
            width: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" CssClass="panel-background">
            PANEL 1 Background<asp:Panel ID="Panel2" runat="server" CssClass="panel-parent">
                PANEL 2
                <asp:Panel ID="Panel3" runat="server" CssClass="panel-style">
                    DETAILS
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="panel-style">
                    PROJECT OVERVIEW</asp:Panel>
                <asp:Panel ID="Panel5" runat="server" CssClass="panel-style">
                    COMMENTS</asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
