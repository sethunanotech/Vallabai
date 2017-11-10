<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>.::Sabari::.</title>
	<link rel="shortcut icon" href="favicon.ico" type="image/icon1.jpg">
	<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="assets/css/core.css" rel="stylesheet" type="text/css" />
	<link href="assets/css/components.css" rel="stylesheet" type="text/css" />   
	<link href="assets/css/Login.css" rel="stylesheet" type="text/css" />   
	<link rel="stylesheet" type="text/css" media="screen" href="assets/css/animation.css"/>
	<link rel="stylesheet" type="text/css" media="screen" href="assets/css/bootstrap-switch.css"/>
</head>
<body >
	<form id="form1" runat="server">
		<div id="authenty_preview">
			<div id="signin_main" class="authenty signin-main">                
				<div class="section-content">
					<div class="container" style="margin-top:15%">	  
						<div class="form-wrap">
							<div class="smart-form client-form animated bounceIn" data-animation="bounceIn">						
								<div class="card-box" style="background-color:#ffffff !important">
									<div class="form-group"><h2>Sabari</h2></div>
									<div class="form-group">
										<label>Access Code</label>
										<asp:TextBox ID="txtAccessCode" runat="server" TabIndex="1" placeholder="Enter Access Code" CssClass="form-control" onkeypress="return onKeyValidate(event,numeric);" MaxLength="15"></asp:TextBox>   
										<asp:RequiredFieldValidator runat="server" ID="RFV_txtAccessCode" ControlToValidate="txtAccessCode" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Access code is required." ValidationGroup="VG_Login"></asp:RequiredFieldValidator>                                     
										
									</div>                               
									<div class="form-group">
										<label>Password</label>
										<asp:TextBox ID="txtPassword" runat="server" TabIndex="2" placeholder="Enter Password" CssClass="form-control" TextMode="Password" MaxLength="10"></asp:TextBox>    
										<asp:RequiredFieldValidator runat="server" ID="RFV_txtPassword" ControlToValidate="txtAccessCode" CssClass="errorstring" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Password is required." ValidationGroup="VG_Login"></asp:RequiredFieldValidator>                                                                           
									</div> 
									<div class="form-group">
										<asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary btn-block waves-effect waves-light" Text="Login" OnClick="btnSubmit_Click"  ValidationGroup="VG_Login"/>  										
									</div> 
                                    <div class="form-group">
										<span style="float:left;margin-left:30%;margin-right:30%;"><asp:Label ID="lblErrMsg" runat="server" CssClass="errorstring"></asp:Label></span>
                                    </div>                        
								</div>
							</div>
						</div>
					</div>
				</div>                
			</div>
		</div>
	</form>
	<script src="<%=Page.ResolveUrl("~/assets/js/jquery.min.js") %>"></script>
	<script src="<%=Page.ResolveUrl("~/assets/js/bootstrap.min.js") %>"></script>
	<script src='<%=Page.ResolveUrl("~/assets/js/highlight.js") %>' type="text/javascript"></script>
	<script src='<%=Page.ResolveUrl("~/assets/js/bootstrap-switch.js") %>' type="text/javascript"></script>
	<script src='<%=Page.ResolveUrl("~/assets/js/main.js") %>' type="text/javascript"></script>
	<script src='<%=Page.ResolveUrl("~/assets/js/Validation/Validation.js") %>' type="text/javascript"></script>
</body>
</html>
