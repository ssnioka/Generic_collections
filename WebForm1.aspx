<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LABORAS3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratorinis</title>
    <style>
        body{
            background-image: url("https://g1.dcdn.lt/images/pix/valstybine-mokesciu-inspekcija-72447542.jpg");
            font-weight: bold;
        }
        #hidden
        {
            visibility:hidden;
        }
    </style>
</head>
<body style="height: 951px">
    <form id="form1" runat="server">
        <div aria-checked="true" style="height: 886px">
            Mokesčiai. Kiekvieną mėnesį gyventojai moka komunalinius mokesčius. Suraskite, kurį mėnesį ir kokie komunaliniai mokesčiai kainavo pigiausiai. Apskaičiuokite, kokią pinigų sumą komunaliniams mokesčiams išleido visi gyventojai. Sudarykite sąrašą gyventojų (pavardė ir vardas, adresas), kurie už komunalines paslaugas per metus mokėjo sumą, mažesnę už vidutinę. Sąrašas turi būti surikiuotas pagal gyventojų adresus, pavardes ir vardus abėcėlės tvarka.<br />
            Pašalinkite iš sąrašo gyventojus, kurie nemokėjo už nurodytą paslaugą, nurodytą mėnesį (duomenys įvedami klaviatūra).
            <br />
            <br />
            Initial data:<br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" GridLines="Both" Width="35px">
            </asp:Table>
            <br />
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" GridLines="Both">
            </asp:Table>
            <br />
&nbsp;Įkelti gyventojų failą:&nbsp;
            <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;Įkelti komunalinių paslaugų failą:
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            <br />
            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
            <br />
             <div id="hidden" runat="server"> 
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Month:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            ServiceID:<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Pašalinti" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table3" runat="server" BorderColor="Black" BorderStyle="Solid" GridLines="Both">
            </asp:Table>    
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
           </div>
        </div>
    </form>
</body>
</html>
