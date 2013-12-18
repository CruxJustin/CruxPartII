<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DueDiligence.aspx.cs" Inherits="LotBankingCrux_v_1.DueDiligence" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/diligencestyle.css" />

    <title>Due Diligence</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="wrapper">

            <div class="header">
                    <h1 id="CBH">CBH - Due Diligence
                    </h1><img id="logo" src="Images/CBH_whitelogo.png" alt="CBH Logo"/>
            </div>

            <div class="content">

                <div class="container">
                    <h2 class="topic">Transaction Documentation</h2>
                        <ul>
                            <li>
                                <h3>1.  Builder Purchase Agreement<asp:FileUpload ID="FileUpload1" runat="server" />
                                </h3><hr />
                            </li>
                            <li>
                                <h3>2.  Entity Formation Documents<asp:FileUpload ID="FileUpload2" runat="server" />
                                </h3><hr />
                            </li>
                        </ul>

                    <h2 class="topic">Property Due Diligence Materials</h2>
                        <ul>
                            <li>
                                <h3>3.  Maps & Aerial Photos<asp:FileUpload ID="FileUpload3" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>4.  Municipal Information</h3>
                                <ul class="nest">
                                    <li>
                                        <h4>a.  Country<asp:FileUpload ID="FileUpload4" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>b.  City<asp:FileUpload ID="FileUpload5" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>c.  School District<asp:FileUpload ID="FileUpload6" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>6.  ALTA Survey<asp:FileUpload ID="FileUpload7" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>7.  Subdivision Plat Maps</h3>
                                <ul class="nest">
                                    <li>
                                        <h4>a.  Preliminary Accepted<asp:FileUpload ID="FileUpload8" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Final Accepted<asp:FileUpload ID="FileUpload9" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  Subdivision Improvement Plans<asp:FileUpload ID="FileUpload10" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>d.  Tax Assessors Parcel Map<asp:FileUpload ID="FileUpload11" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li class="underline">
                                <h3>8.  Title Commitment</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  Schedule A<asp:FileUpload ID="FileUpload12" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Schedule B<asp:FileUpload ID="FileUpload13" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>c.  Legal Description<asp:FileUpload ID="FileUpload14" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li class="underline">
                                <h3>9.  Zoning & Entitlements</h3>
                                <ul class="nest">
                                    <li>
                                        <h4>a.  Zoning Change Submittal<asp:FileUpload ID="FileUpload15" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Stipulations<asp:FileUpload ID="FileUpload16" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  Development Agreements<asp:FileUpload ID="FileUpload17" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>d.  Vesting Status<asp:FileUpload ID="FileUpload18" runat="server" />
                                        </h4>
                                    </li>
                                     <li>
                                        <h4>e.  Other Entitlement Issues<asp:FileUpload ID="FileUpload19" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>f.  Subdivision Report<asp:FileUpload ID="FileUpload20" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>g.  Aircraft Overflight Items<asp:FileUpload ID="FileUpload21" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li class="underline">
                                <h3>10.  Other Developmental Issues</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  Streets Private/Public<asp:FileUpload ID="FileUpload22" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>b.  HOA Formation Docs<asp:FileUpload ID="FileUpload23" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  HOA Reserve Study Completed<asp:FileUpload ID="FileUpload24" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>d.  CCR's Completed<asp:FileUpload ID="FileUpload25" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>11. Subdivision Improvement Plans<asp:FileUpload ID="FileUpload26" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>12.  Enviromental</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  Phase I<asp:FileUpload ID="FileUpload27" runat="server" />
                                         </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>b.  Phase II (if applicable)<asp:FileUpload ID="FileUpload28" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>13.  Geotechnical Report<asp:FileUpload ID="FileUpload29" runat="server" />
                                </h3><hr />
                            </li>
                            <li>
                                <h3>14.  Developmental Budget<asp:FileUpload ID="FileUpload30" runat="server" />
                                </h3><hr />
                            </li>
                            <li>
                                <h3>15.  Developmental Schedule<asp:FileUpload ID="FileUpload31" runat="server" />
                                </h3><hr />
                            </li>
                            <li>
                                <h3>16.  Review of Plans<asp:FileUpload ID="FileUpload32" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>17.  Utility Availability/Providers</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  Water<asp:FileUpload ID="FileUpload33" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Sewer<asp:FileUpload ID="FileUpload34" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  Electricity<asp:FileUpload ID="FileUpload35" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>d.  Gas<asp:FileUpload ID="FileUpload36" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>e.  Cable<asp:FileUpload ID="FileUpload37" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>18.  Housing Proforma<asp:FileUpload ID="FileUpload38" runat="server" />
                                </h3><hr />
                            </li>
                        </ul>
                    <h2 class="topic">Market Due Diligence Materials</h2>
                        <ul>
                            <li>
                                <h3>19.  Third Party Study/Appraisals<asp:FileUpload ID="FileUpload39" runat="server" />
                                </h3><hr />
                            </li>
                            <li>
                                <h3>20.  Proposed Competitive Projects<asp:FileUpload ID="FileUpload40" runat="server" />
                                </h3><hr />
                            </li>
                        </ul>
                    <h2 class="topic">Builder Resume</h2>
                        <ul>
                            <li>
                                <h3>22.  Evidence of Insurance<asp:FileUpload ID="FileUpload41" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>23.  Builder Corporate Resume</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  History<asp:FileUpload ID="FileUpload42" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Active Projects<asp:FileUpload ID="FileUpload43" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  Two yrs historical financial statements<asp:FileUpload ID="FileUpload44" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>d.  Copy of Contractors License<asp:FileUpload ID="FileUpload45" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>e.  List of Trade References</h4>
                                        <ul class="nest">
                                            <li>
                                                <h4>Construction Lending<asp:FileUpload ID="FileUpload46" runat="server" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Grading<asp:FileUpload ID="FileUpload47" runat="server" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Concrete<asp:FileUpload ID="FileUpload48" runat="server" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Framing<asp:FileUpload ID="FileUpload49" runat="server" />
                                                </h4>
                                            </li>
                                            <li class="lastli">
                                                <h4>Plumbing<asp:FileUpload ID="FileUpload50" runat="server" />
                                                </h4>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>24.  Builder Project Proforma<asp:FileUpload ID="FileUpload51" runat="server" />
                                </h3><hr />
                            </li>
                            <li class="underline">
                                <h3>25.  Additional Information (Exisiting Projects Only)</h3>
                                <ul class="nest">
                                     <li>
                                        <h4>a.  Date Opened<asp:FileUpload ID="FileUpload52" runat="server" />
                                         </h4>
                                    </li>
                                    <li>
                                        <h4>b.  Monthly Traffic & Sales<asp:FileUpload ID="FileUpload53" runat="server" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c.  Final Development Costs<asp:FileUpload ID="FileUpload54" runat="server" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>d.  Existing Construction Agreement<asp:FileUpload ID="FileUpload55" runat="server" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>26.  Loan Terms<asp:FileUpload ID="FileUpload56" runat="server" />
                                </h3><hr />
                            </li>
                            <li id="finalli">
                                <h3>27.  Floor Plans<asp:FileUpload ID="FileUpload57" runat="server" />
                                </h3><hr />
                            </li>
                        </ul>
                </div>
            </div>
        
            <div class="footer">
                    <h2 id="crux">Team Crux &copy;</h2>
            </div>
       
        </div>
    </form>
</body>
</html>
