<%@Page Inherits="BasicWebApp.WebCtrlTestPage" Language="C#" CodeFile="webctrltest.aspx.cs"%>
<%@Register TagPrefix="bwa" Namespace="BasicWebApp" Assembly="basicwebapp" %>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1><bwa:Greeter Person="Master" runat="server"/></h1>
		<b>Time on server: </b><asp:Label ID="TimeLabel" runat="server"/>
	</body>
</html>