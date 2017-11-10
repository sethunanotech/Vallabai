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
            <div class="card-box table-responsive">
                <div class="col-sm-4">
                    <div class="form-group">
                        <label>Registration No. &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="regno" runat="server" CssClass="form-control" TabIndex="1" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Bus Number &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="BusNo" runat="server" CssClass="form-control" TabIndex="2" MaxLength="150"></asp:TextBox>
                        
                    </div>
                    <div class="form-group">
                        <label>Total Seats &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="totalseats" runat="server" CssClass="form-control" TabIndex="3" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Driver Name<span class="errorstring">*</span></label>
                        <asp:TextBox ID="drivername" runat="server" CssClass="form-control" TabIndex="4" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Driver MobileNo.<span class="errorstring">*</span></label>
                        <asp:TextBox ID="drivermobileno" runat="server" CssClass="form-control" TabIndex="5" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Button runat="server" Text="Save" ID="savebtn" CssClass="btn btn-primary waves-light"  />
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

