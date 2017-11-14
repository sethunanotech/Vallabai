<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ticketbooking.aspx.cs" Inherits="Modules_modules_ticketbooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" Runat="Server">
    <link href="../../assets/css/seat.css" rel="stylesheet" />
<div class="row">
    <div class="col-sm-10">
        <h4 class="page-title">Bus Booking</h4>
    </div>
	<div class="col-sm-2 form-group form-inline text-right">
        <asp:DropDownList runat="server" ID="ddlBus" CssClass="form-control col-md-4 text-right" AutoPostBack="true" OnSelectedIndexChanged="ddlBus_SelectedIndexChanged"></asp:DropDownList>
		<asp:Button runat="server" ID="btnExport" Text="Export" CssClass="btn btn-primary waves-light" OnClick="btnExport_Click" />
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
            <div class="col-sm-6">
                <div class="form-group">
                    <div class="input-group m-t-10">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="form-control col-md-2" TabIndex="1" placeholder="Code" MaxLength="150"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button runat="server" Text="Search" ID="btnSearch" CssClass="btn btn-primary waves-light" OnClick="btnSearch_Click" />
                        </span>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ID="RFV_txtCode" ControlToValidate="txtCode" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Code is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Name &nbsp;<span class="errorstring">*</span></label>
                    <asp:DropDownList runat="server" ID="ddlNames" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Bus Number &nbsp;<span class="errorstring">*</span></label>
                    <asp:DropDownList runat="server" ID="ddlBusNumber" CssClass="form-control" AutoPostBack="false" onchange="_LoadSeatLayout()" ></asp:DropDownList>
                </div>
                <div>&nbsp;</div>
                <div class="form-group" id="divSeatLayout">
                    
                </div>
                <div class="form-group text-center">
                    <input type="button" value="Book Now" class="btn btn-primary waves-light" onclick="_BookSeat()" />
                </div>
            </div>
            <div class="col-sm-6" style="margin-top:10px;">
				<asp:GridView  
					ID="gvSwamies"
					runat                       ="server"
					AutoGenerateColumns         ="false"                                                                                                                       
					Width                       ="100%"						       
					HeaderStyle-HorizontalAlign = "Center"
					CssClass                    ="table table-condensed table-striped table-hover table-bordered " 
					ClientIDMode                ="Static" 
					>
					<Columns>
						<asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"  ItemStyle-Width="80px">
							<ItemTemplate>
								<%# Container.DataItemIndex +1 %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="swamy_CODE"   HeaderText="Code"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="swamy_NAME"  HeaderText="Name"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="swamy_FATHER_SPOUSE_NAME"   HeaderText="Father / Spouse"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="swamy_MOBILE_NUMBER"  HeaderText="Mobile Number"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="swamy_PLACE"   HeaderText="Place"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="payanam_TITLE"   HeaderText="Set"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Bus Details" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <%# Eval("vehicle_TYPE") + " " + Eval("bus_NUMBER") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="seat_NUMBER"   HeaderText="Seat Number"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />

						<asp:TemplateField HeaderText="Cancel" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  ItemStyle-Width="80px">
							<ItemTemplate>
								<asp:Button runat="server" Text="Cancel"  CommandArgument='<%# Eval("seat_NUMBER") + "," + Eval("bus_NUMBER") %>'  CssClass="btn btn-primary waves-light btn-xs m-b-5" ID="gvEdit" OnClick="gvCancel_Click" />
							</ItemTemplate>
						</asp:TemplateField>                         
					</Columns>
				</asp:GridView>
            </div>
        </div>
    </div>
</div>
    <script src="<%=Page.ResolveUrl("~/management/assets/js/jquery.min.js") %>"></script>
     <script type="text/javascript">
         var SeatNumber = 0;
         function funShowMessage(sparam) {
             $("#SuccessMsg").text(sparam); $("#dSuccessMsg").show();
             setTimeout(function () {
                 $("#SuccessMsg").text(sparam); $("#dSuccessMsg").hide();
             }, 5000);
         }

         function _SelectSeat(seatNumber) {
             SeatNumber = seatNumber;
         }

         function _LoadSeatLayout()
         {
             console.log('sethu');
             var payanamID = <%=Request.QueryString["pid"] %>;
             var busID = $("#cph_ddlBusNumber option:selected").val();
             $.ajax({
                 type: 'GET',
                 url: '../common/process.aspx?pid=LS&paID=' + payanamID + '&bID=' + busID,
                 success: function (data) {
                     console.log(data);
                     $('#divSeatLayout').append(data);
                 }
             });
         }

         function _BookSeat() {
             var payanamID = <%=Request.QueryString["pid"] %>;
             var busID = $("#cph_ddlBusNumber option:selected").val();
             var userID = $("#cph_ddlNames option:selected").val();
             $.ajax({
                 type: 'GET',
                 url: '../common/process.aspx?pid=SB&paID=' + payanamID + '&bID=' + busID + '&uID=' + userID + '&sID=' + SeatNumber,
                 success: function (data) {
                   console.log('sethu : ' + data);
                 }
             });
         }

         $(document).ready(function () {
             $('#gvSwamies').dataTable();
         });
    </script>
</asp:Content>

