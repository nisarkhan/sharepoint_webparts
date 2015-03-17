<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentSyndPageViewUserControl.ascx.cs" Inherits="SharePointWebParts.ContentSyndPageView.ContentSyndPageViewUserControl" %>


 
<asp:HiddenField runat="server" ID="hiddenFieldDetectRequest" Value="0" />
<div >
    <table  >
        <tr>
            <td >
                <fieldset title="Configured Tabs">
                    <legend>Configured Tabs</legend>
                    <asp:Panel ID="panelConfiguredTabs" runat="server">
                        <table>
                            <tr>
                                <td>
                                    Topic
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlTopic" runat="server" EnableViewState="true"
                                        AutoPostBack="true" Height="25px" Width="250px" 
                                        onselectedindexchanged="ddlTopic_SelectedIndexChanged">
                                        <asp:ListItem Text="Select one" Value="Select one"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Title
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlTitle" runat="server" EnableViewState="true" 
                                        AutoPostBack="true" Height="25px" Width="250px">
                                        <asp:ListItem Text="Select one" Value="Select one"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Panel ID="panelTabItem" runat="server" Visible="false">
                    <fieldset title="Tab Data" runat="server" id="fieldSetTitle">
                        <legend runat="server" id="legendTitle">Tab Data</legend>
                    </fieldset>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
