<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="payanam.aspx.cs" Inherits="Modules_modules_payanam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" Runat="Server">
	<div class="row">
		<div class="col-sm-6">
			<h4 class="page-title">Payanam - Swamy Details</h4>
		</div>
		<div class="col-sm-6 form-group" style="text-align:right;">
			<%--<asp:Button runat="server" ID="btnNewRegistration" Text="New Registration" CssClass="btn btn-primary waves-light" OnClick="btnNewRegistration_Click" />--%>
		</div>
	</div>
	<div class="row" style="padding-top:10px">
		<div class="col-sm-12">
			<div class="card-box table-responsive">
				<asp:GridView  
					ID="gvPayanam"
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
						<asp:BoundField DataField="payanam_TITLE"   HeaderText="Title"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="year"   HeaderText="Year"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="payanam_STARTDATE"  HeaderText="Start Date"  DataFormatString="{0:dd-MMM-yyyy}"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="payanam_ENDATE"   HeaderText="End Date"  DataFormatString="{0:dd-MMM-yyyy}"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:TemplateField HeaderText="Add New" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
							<ItemTemplate>
								<a href="../../modules/modules/bus.aspx?pid=<%#Eval("payanam_ID") %>" class="btn btn-warning waves-light btn-xs m-b-5">Add Bus</a>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Book For Bus" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
							<ItemTemplate>
								<a href="../../Modules/modules/ticketbooking.aspx?pid=<%#Eval("payanam_ID") %>" class="btn btn-pink waves-light btn-xs m-b-5" >Book for Seat</a>
							</ItemTemplate>
						</asp:TemplateField> 
					</Columns>
                    <EmptyDataTemplate>
                        <div>
                            <span>No Records Found</span>
                        </div>
                    </EmptyDataTemplate>
				</asp:GridView>
			</div>
		</div>
	</div>
</asp:Content>

