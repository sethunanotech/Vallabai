<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Regis.aspx.cs" Inherits="Modules_modules_Regis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" Runat="Server">
	<div class="row">
		<div class="col-sm-6">
			<h4 class="page-title">Vallabai Ayyappan Sabarimalai Payanam - Swamy Details</h4>
		</div>
        <div class="col-sm-6 form-group" style="text-align:right;">
            <asp:Button runat="server" ID="btnNewRegistration" Text="New Registration" CssClass="btn btn-primary waves-light" OnClick="btnNewRegistration_Click" />
            <asp:Button runat="server" ID="btnExport" Text="Export" CssClass="btn btn-primary waves-light" OnClick="btnExport_Click" />
        </div>
	</div>
	<div class="row" style="padding-top:10px">
		<div class="col-sm-12">
			<div class="card-box table-responsive">
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
						<asp:BoundField DataField="swamy_GENDER"   HeaderText="Gender"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:BoundField DataField="swamy_PLACE"   HeaderText="Place"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="swamy_MOBILE_NUMBER"   HeaderText="Mobile Number"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="swamy_ALTERNATE_MOBILE"   HeaderText="Alternate Mobile"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="swamy_MALAI_VISIT"   HeaderText="Sabari Visit"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
						<asp:TemplateField  HeaderText="Swamy" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<%# GetSwamyType(Convert.ToInt32(Eval("swamy_MALAI_VISIT"))) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="Membership" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<%# Eval("swamy_MEMBERSHIP_TYPE").ToString()== "Lifetime" ? "<label class='btn btn-success  waves-light btn-xs m-b-5' style='cursor:default'>Lifetime</label>" : "<label class='btn btn-danger waves-light btn-xs m-b-5'>Short Term</label>" %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  ItemStyle-Width="80px">
							<ItemTemplate>
								<asp:Button runat="server" Text="Edit"  CommandArgument='<%# Eval("swamy_ID") %>'  CssClass="btn btn-primary waves-light btn-xs m-b-5" ID="gvEdit" OnClick="gvEdit_Click" />
							</ItemTemplate>
						</asp:TemplateField> 
					</Columns>
				</asp:GridView>
			</div>
		</div>
	</div>
    <script src="<%=Page.ResolveUrl("~/management/assets/js/jquery.min.js") %>"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('#gvSwamies').dataTable();
         });
    </script>
</asp:Content>

