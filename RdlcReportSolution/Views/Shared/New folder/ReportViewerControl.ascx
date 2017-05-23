<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerControl.ascx.cs" Inherits="RdlcReportSolution.Views.Shared" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<form id="form1" runat="server">
    <div style="Height: 720px; Width: 800px">
        <asp:ScriptManager ID="scriptManager" runat="server" ScriptMode="Release" EnablePartialRendering="false" />
        <rsweb:ReportViewer Width="100%" Height="100%" ID="reportViewer" ShowPrintButton="true" KeepSessionAlive="true" runat="server" AsyncRendering="false">
        </rsweb:ReportViewer>
    </div>
</form>
