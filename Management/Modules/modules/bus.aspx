<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bus.aspx.cs" Inherits="Modules_modules_bus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="col-sm-6">
            <h4 class="page-title">Bus Details</h4>
        </div>
        <div class="col-sm-6" style="text-align: right;">
            <%--<asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary waves-light" OnClick="btnBack_Click" />--%>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="alert alert-success" id="dSuccessMsg" style="display: none; margin-top: 15px;">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong><i style="font-size: 18px" class="fa fa-1x fa-check-square-o "></i></strong>&nbsp;<span style="font-size: 18px; font-style: italic;" id="SuccessMsg"></span>
            </div>
            <div class="alert alert-danger" id="dErrorMsg" style="display: none; margin-top: 15px;">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong><i style="font-size: 18px" class="fa fa-1x fa-warning "></i></strong>&nbsp;<span style="font-size: 18px; font-style: italic;" id="ErrorMsg"></span>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">
                <div class="col-sm-4">
                    <div class="form-group">
                        <label>Vehicle Type. &nbsp;<span class="errorstring">*</span></label>
                        <asp:DropDownList runat="server" ID="ddlVehicleType" CssClass="form-control" TabIndex="1">
                            <asp:ListItem Text="Bus" Value="Bus"></asp:ListItem>
                            <asp:ListItem Text="Van" Value="Van"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Registration No. &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtRegistrationNumber" runat="server" CssClass="form-control" TabIndex="2" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Bus Number &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtBusNumber" runat="server" CssClass="form-control" TabIndex="3" MaxLength="150"></asp:TextBox>
                        
                    </div>
                    <div class="form-group">
                        <label>Total Seats &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtTotalSeats" runat="server" CssClass="form-control" TabIndex="4" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Driver Name<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control" TabIndex="5" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Driver MobileNo.<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtDriverMobileNumber" runat="server" CssClass="form-control" TabIndex="6" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Button runat="server" Text="Save" ID="btnSaveBusDetails" CssClass="btn btn-primary waves-light" OnClick="btnSaveBusDetails_Click"  />
                </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%=Page.ResolveUrl("~/management/assets/js/jquery.min.js") %>"></script>
    <script type="text/javascript">
        function funShowMessage(sparam) {
            $("#SuccessMsg").text(sparam); $("#dSuccessMsg").show();
            setTimeout(function () {
                $("#SuccessMsg").text(sparam); $("#dSuccessMsg").hide();
            }, 5000);
        }
    </script>
</asp:Content>

