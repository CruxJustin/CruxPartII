<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuilderProposal.aspx.cs" Inherits="LotBankingCrux_v_1.BuilderProposal" %>

<!DOCTYPE html>
<!-- This is something new added -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       @font-face {
        font-family: Eyeglass;
        src: url('/Content/Fonts/eyeglass-normal.ttf'),
        }
        html {
            margin: 0;
            padding: 0;
        }
         
       body {
            font-family:Eyeglass, sans-serif;
            margin:0;
            padding:0;    
            min-height:100%;
        } 
        
        hr {
            width: 90%;
        }
        
        #buildername {
            padding-top: 10px;
            margin-bottom: 0px;
        }
        
        .panel-parent {
            display: block;
            border: thin outset #C0C0C0;
            background-color: #D8D8D8;
            margin: 0 auto;
            height: 830px;
            width: 82%;
        }

        .panel-background {
            background-image: url('/Images/texture.png');
            background-repeat: repeat;
            height: 100%;
            width: 100%;
        }

        .panel-style {
            background-color: #F0F0F0;
            display: block;
            margin: 0 auto;
            margin-top: 5px;
            margin-bottom: 5px;
            height: 75%;
            width: 80%;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 32px;
            height: 32px;
        }
        #Text1 {
            height: 20px;
            width: 550px;
            display: block;
            margin: 0 auto; 
        }
        .textSize {
            height: 20px;
            width: 550px;
        }
        #calendar {
            margin:0 auto;
            display:inline-block;
        }
        .center {
            margin:0 auto;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <input id="Hidden2" type="hidden" />
        <input id="Hidden1" type="hidden" />
        <asp:Panel ID="Panel1" runat="server" CssClass="panel-background">
            <asp:Panel ID="Panel2" runat="server" CssClass="panel-parent">
                <div class="auto-style1">
                    <h1 id="buildername">
                        <img alt="builderLogo" class="auto-style2" src="Images/Sprites/builderLogo.png" />
                        FULTON HOMES </h1>
                    <hr />
                    <h2>New Project</h2>
                </div>
                <asp:Panel ID="Panel3" runat="server" CssClass="panel-style">
                    Name:<br />
                    <div id="text1"><input class="textSize" type="text" /> </div><br />
                    Location:<br />
                    <div id="text2"><input class="textSize" type="text" /> </div><br />
                    # of Lots:<br />
                    <div id="Div1"><input class="textSize" type="text" /> </div><br /><hr />
                    Acquistion Price:<br />
                    <div id="Div2"><input class="textSize" type="text" /> </div><br />
                    Improvement Costs:<br />
                    <div id="Div3"><input class="textSize" type="text" /> </div><br /><hr />
                    <div class="center">*ELT Schedule:<br />
                    Start Date:
                    <asp:Calendar class="calendar" runat="server"></asp:Calendar>
                    Finish Date:
                    <asp:Calendar class="calendar" runat="server"></asp:Calendar>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
