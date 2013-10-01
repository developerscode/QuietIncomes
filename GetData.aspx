<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetData.aspx.cs" Inherits="GetData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr><td><label id="lblPost" runat="server" />:
        <label id="lblUserName" runat="server"></label>,&nbsp;<a href="#">Logout</a></td></tr>
        <tr><td><a href="#"><span class="tag">Dream: </span></a>
        <label id="lblDream" runat="server"></label></td></tr>
        <tr><td><a href="#"><span class="tag">Next Goal: </span></a>
        <label id="lblNextGoal" runat="server"></label></td></tr>
        <tr><td><span class="tag">Status: </span>
        <label id="lblStatus" runat="server" /></td></tr>
        <tr><td>
   
    Time is ticking... what have you done for your future today?&nbsp;&nbsp;
     <label id="lblServerDate" runat="server"></label>
     <label id="lblServerTime" runat="server"></label>
               
        </td></tr>
        </table>    
        
        
        
        
    </div>
    </form>
</body>
</html>
