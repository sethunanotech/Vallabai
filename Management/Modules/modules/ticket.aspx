<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ticket.aspx.cs" Inherits="Modules_modules_ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" Runat="Server">
	<div class="row">
		<div class="col-sm-6">
			<h4 class="page-title"></h4>
		</div>
        <div class="col-sm-6 form-group" style="text-align:right;">
            <%--<asp:Button runat="server" ID="btnNewRegistration" Text="New Registration" CssClass="btn btn-primary waves-light" OnClick="btnNewRegistration_Click" />--%>
        </div>
	</div>
    <div class="row" style="padding-top:10px">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="checkbox checkbox-inline">
                    <asp:CheckBox runat="server" ID="chkRow_1" CssClass="checkbox checkbox-primary" Text="1" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_6" CssClass="checkbox checkbox-primary" Text="6" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_11" CssClass="checkbox checkbox-primary" Text="11" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_16" CssClass="checkbox checkbox-primary" Text="16" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_21" CssClass="checkbox checkbox-primary" Text="21" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_26" CssClass="checkbox checkbox-primary" Text="26" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_31" CssClass="checkbox checkbox-primary" Text="31" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_36" CssClass="checkbox checkbox-primary" Text="36" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_41" CssClass="checkbox checkbox-primary" Text="41" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_46" CssClass="checkbox checkbox-primary" Text="46" style="margin-bottom:15px;"/>
                </div>
                <div class="checkbox checkbox-inline">
                    <asp:CheckBox runat="server" ID="chkRow_2" CssClass="checkbox checkbox-primary" Text="2" style="margin-bottom:15px; margin-right:65px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_7" CssClass="checkbox checkbox-primary" Text="7" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_12" CssClass="checkbox checkbox-primary" Text="12" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_17" CssClass="checkbox checkbox-primary" Text="17" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_22" CssClass="checkbox checkbox-primary" Text="22" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_27" CssClass="checkbox checkbox-primary" Text="27" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_32" CssClass="checkbox checkbox-primary" Text="32" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_37" CssClass="checkbox checkbox-primary" Text="37" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_42" CssClass="checkbox checkbox-primary" Text="42" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_47" CssClass="checkbox checkbox-primary" Text="47" style="margin-bottom:15px;"/>
                </div>
                <div class="checkbox checkbox-inline">
                    <asp:CheckBox runat="server" ID="chkRow_3" CssClass="checkbox checkbox-primary" Text="3" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_8" CssClass="checkbox checkbox-primary" Text="8" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_13" CssClass="checkbox checkbox-primary" Text="13" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_18" CssClass="checkbox checkbox-primary" Text="18" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_23" CssClass="checkbox checkbox-primary" Text="23" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_28" CssClass="checkbox checkbox-primary" Text="28" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_33" CssClass="checkbox checkbox-primary" Text="33" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_38" CssClass="checkbox checkbox-primary" Text="38" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_43" CssClass="checkbox checkbox-primary" Text="43" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_48" CssClass="checkbox checkbox-primary" Text="48" style="margin-bottom:15px;"/>
                </div>
                <div class="checkbox checkbox-inline">
                    <asp:CheckBox runat="server" ID="chkRow_4" CssClass="checkbox checkbox-primary" Text="4" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_9" CssClass="checkbox checkbox-primary" Text="9" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_14" CssClass="checkbox checkbox-primary" Text="14" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_19" CssClass="checkbox checkbox-primary" Text="19" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_24" CssClass="checkbox checkbox-primary" Text="24" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_29" CssClass="checkbox checkbox-primary" Text="29" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_34" CssClass="checkbox checkbox-primary" Text="34" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_39" CssClass="checkbox checkbox-primary" Text="39" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_44" CssClass="checkbox checkbox-primary" Text="44" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_49" CssClass="checkbox checkbox-primary" Text="49" style="margin-bottom:15px;"/>
                </div>
                <div class="checkbox checkbox-inline">
                    <asp:CheckBox runat="server" ID="chkRow_5" CssClass="checkbox checkbox-primary" Text="5" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_10" CssClass="checkbox checkbox-primary" Text="10" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_15" CssClass="checkbox checkbox-primary" Text="15" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_20" CssClass="checkbox checkbox-primary" Text="20" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_25" CssClass="checkbox checkbox-primary" Text="25" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_30" CssClass="checkbox checkbox-primary" Text="30" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_35" CssClass="checkbox checkbox-primary" Text="35" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_40" CssClass="checkbox checkbox-primary" Text="40" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_45" CssClass="checkbox checkbox-primary" Text="45" style="margin-bottom:15px;"/>
                    <asp:CheckBox runat="server" ID="chkRow_50" CssClass="checkbox checkbox-primary" Text="50" style="margin-bottom:15px;"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

