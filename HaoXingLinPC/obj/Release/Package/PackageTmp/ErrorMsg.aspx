<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorMsg.aspx.cs" Inherits="HaoXingLinPC.ErrorMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .text {
            margin: 150px auto;
            padding: 10px;
            width: 80%;
            /* height: 25px; */
            font-size: 20px;
            font-weight: 600;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            line-height: 25px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text">
            <%=Msg %>
        </div>
    </form>
</body>
</html>
