<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Modules_modules_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="col-sm-6">
            <h4 class="page-title">Registration</h4>
        </div>
        <div class="col-sm-6" style="text-align:right;">
            <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary waves-light" OnClick="btnBack_Click" />
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
                        <label>Name &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" TabIndex="1" MaxLength="150"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtName" ControlToValidate="txtName" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Name is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Father/Spouse  &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" TabIndex="2" MaxLength="150"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtFatherName" ControlToValidate="txtFatherName" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Father or Spouse Name is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <div class="card-box">
                            <label>Gender</label><br />
                            <div class="radio radio-primary radio-inline">
                                <input type="radio" id="rdlSwamy" runat="server" value="Ayyappan" name="radioGender" checked tabindex="3">
                                <label for="cph_rdActive">Ayyappan</label>
                            </div>
                            <div class="radio radio-primary radio-inline">
                                <input type="radio" id="rdlMaaligaipuram" runat="server" value="Maaligaipuram" name="radioGender" tabindex="4">
                                <label for="cph_rdInActive">Maaligaipuram</label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Date Of Birth &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TabIndex="5" TextModeDate="" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtDOB" ControlToValidate="txtDOB" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="DOB is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Mobile Number&nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtMobileNumber" type="text" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtMobileNumber" ControlToValidate="txtMobileNumber" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Mobile Number is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Alternate Mobile Number&nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtAlternateMobile" type="text" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtAlternateMobile" ControlToValidate="txtAlternateMobile" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Alternate mobile is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <label>Place &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control" TabIndex="8" MaxLength="150"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtPlace" ControlToValidate="txtPlace" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Place is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Address &nbsp;<span class="errorstring">*</span></label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TabIndex="9" Height="68" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtAddress" ControlToValidate="txtAddress" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Address is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label>District &nbsp;<span class="errorstring">*</span></label>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" TabIndex="10">
                            <asp:ListItem Text="Ramanathapuram" Value="Ramanathapuram" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Sivagangai" Value="Sivagangai"></asp:ListItem>
                            <asp:ListItem Text="Madurai" Value="Madurai"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Blood Group &nbsp;<span class="errorstring">*</span></label>
                        <asp:DropDownList runat="server" ID="ddlBloodGroup" CssClass="form-control" TabIndex="11">
                            <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                            <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                            <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                            <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                            <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                            <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                            <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                            <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Malai Visit &nbsp; <span class="errorstring">*</span></label>
                        <asp:TextBox runat="server" ID="txtMalai" CssClass="form-control" TextMode="Number" TabIndex="12"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_txtMalai" ControlToValidate="txtMalai" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Malai is required." ValidationGroup="VG_Registration"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Kanni Poojai Date</label>
                        <asp:TextBox runat="server" ID="txtKanniPoojaiDate" TextMode="Date" CssClass="form-control" TabIndex="13"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <div class="card-box">
                            <label>Membership</label><br />
                            <br />
                            <div class="radio radio-primary radio-inline">
                                <input type="radio" id="rdlNonMeber" runat="server" value="Non Member" name="radioMemberType" checked tabindex="14">
                                <label for="cph_rdNonMember">Non Member</label>
                            </div>
                            <div class="radio radio-primary radio-inline">
                                <input type="radio" id="rdlLifetime" runat="server" value="Lifetime" name="radioMemberType" tabindex="15">
                                <label for="cph_rdLifetime">Lifetime</label>
                            </div>
                            <div class="radio radio-primary radio-inline">
                                <input type="radio" id="rdlShortTermMember" runat="server" value="Short Term Member" name="radioMemberType" tabindex="16">
                                <label for="cph_rdNonLifetime">Short Term </label>
                            </div>
                            <br /><br />
                            <div class="form-group">
                                <label>Expiry Date</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMembershipExpiry" TextMode="Date" TabIndex="17"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="card-box col-lg-12" style="height: 167px !important;">
                            <div class="col-lg-6">
                                <label>Photo Upload</label>
                                <br />
                                <asp:FileUpload runat="server" ID="flPhoto" TabIndex="18" />
                            </div>
                            <div class="col-lg-6 text-center">
                                <asp:Image runat="server" ID="imgPreviewPhoto" ImageUrl="~/management/Resources/temp/noimage.png" Height="130px" Width="150px" />
                                <%--<img id="previewPhoto" src="../../Resources/temp/noimage.png" class="img-circle" style="height: 130px; width: 150px;" alt="Photo" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary waves-light" OnClick="btnSave_Click" TabIndex="29" ValidationGroup="VG_Registration" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%=Page.ResolveUrl("~/management/assets/js/jquery.min.js") %>"></script>
    <script src="<%=Page.ResolveUrl("~/management/assets/js/Timepicker/bootstrap-timepicker.min.js") %>"></script>
    <script type="text/javascript">
        function funShowMessage(sparam) {
            $("#SuccessMsg").text(sparam); $("#dSuccessMsg").show();
            setTimeout(function () {
                $("#SuccessMsg").text(sparam); $("#dSuccessMsg").hide();
            }, 5000);
        }

        function readUrl(input)
        {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%= imgPreviewPhoto.ClientID%>').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $("#<%= flPhoto.ClientID%>").change(function () {
            readUrl(this);
        });
    </script>
</asp:Content>

