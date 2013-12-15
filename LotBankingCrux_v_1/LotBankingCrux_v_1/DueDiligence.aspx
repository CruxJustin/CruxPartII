<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DueDiligence.aspx.cs" Inherits="LotBankingCrux_v_1.DueDiligence" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/diligencestyle.css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">

        <asp:Wizard ID="Wizard" runat="server" Height="300px" OnFinishButtonClick="Wizard1_FinishButtonClick" Width="600px" ActiveStepIndex="0" style="margin-right: 0px" CssClass="wizardText">
            <NavigationButtonStyle CssClass="nextButton" />
            <StepNextButtonStyle CssClass="nextButton" />
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Transaction Documentation">
                    <ol>
                        <li><asp:FileUpload ID="FileUpload1" runat="server" /></li>
                        <li><asp:FileUpload ID="FileUpload2" runat="server" /></li>
                        <li><asp:FileUpload ID="FileUpload3" runat="server" /></li>
                        <li><asp:FileUpload ID="FileUpload4" runat="server" /></li>
                    </ol>
                </asp:WizardStep>
                
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Property Materials">
                    <ol>
                       <li><asp:FileUpload ID="FileUpload5" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload6" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload7" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload8" runat="server" /></li>
                    </ol>
                </asp:WizardStep>

                <asp:WizardStep runat="server" Title="Market Materials">
                    <ol>
                       <li><asp:FileUpload ID="FileUpload9" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload10" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload11" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload12" runat="server" /></li>
                    </ol>
                </asp:WizardStep>
                
                <asp:WizardStep runat="server" Title="Builder Resume">
                    <ol>
                       <li><asp:FileUpload ID="FileUpload13" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload14" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload15" runat="server" /></li>
                       <li><asp:FileUpload ID="FileUpload16" runat="server" /></li>
                    </ol>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
    </form>
</body>
</html>
