<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LotterySim.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <H3>Current Standings</H3><br />
            
            <asp:GridView ID="teamStandingsGridView" runat="server">
            </asp:GridView>
            <br />
            <H3>
                <asp:Label ID="lotteryResultsLabel" runat="server" Text="Lottery Results" Visible="False"></asp:Label>
            </H3>
            <br />
            <asp:GridView ID="lotteryResultsGridView" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="Generate Lottery" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="pick1Label" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="teamsLabel" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
