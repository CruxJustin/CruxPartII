﻿<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CBHHome.aspx.cs" Inherits="LotBankingCrux_v_1.CBHHome" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="menubar">
        <div class="table">
            <ul id="horizontal-list">
                <li><asp:LinkButton runat="server" Style="text-decoration: none" OnClick="ProjectDashboard_OnClick" ForeColor="Black">Project Dashboard</asp:LinkButton>
                </li>
                <li><asp:LinkButton runat="server" Style="text-decoration: none" OnClick="NewBuilderProposal_OnClick" ForeColor="Black">New Builder Proposal</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>

</asp:Content>