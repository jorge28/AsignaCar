<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RangoFechas.ascx.vb" Inherits="Controles_RangoFechas" ClassName="RangoFechas" %>

<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Del" CssClass="Label"></asp:Label>
        </td>
        <td>
            <telerik:RadDatePicker ID="Fecha1" runat="server" CssClass="Fecha">
            </telerik:RadDatePicker>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Al" CssClass="Label"></asp:Label>
        </td>
        <td>
            <telerik:RadDatePicker ID="Fecha2" runat="server" CssClass="Fecha" >
            </telerik:RadDatePicker>
        </td>
        <td>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" 
                CssClass="ValidacionError" ControlToCompare="Fecha1" ControlToValidate="Fecha2" 
                Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
        </td>
    </tr>
</table>