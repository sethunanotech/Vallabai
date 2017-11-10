<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Management_Modules_Common_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" Runat="Server">
    <div class="row">
        <div class="col-lg-4">
            <div class="card-box"></div>
        </div>
        <div class="col-lg-4">
            <div class="card-box"></div>
        </div>
        <div class="col-lg-4">
            <div class="card-box">
                <h4 class="m-t-0 m-b-20 header-title"><b>Recent Birthdays</b></h4>
                <div class="inbox-widget nicescroll mx-box" id="recentbirthdays">
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>

