<%@ Page Language="C#" Title="Produits" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Produits.aspx.cs" Inherits="Produits" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div> 
        <asp:Label ID="Label1" runat="server" Text="Nom"></asp:Label>
        <asp:TextBox ID="txtnom" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>        
        <br /><br />

        <asp:Label ID="Label3" runat="server" Text="Categorie"></asp:Label>
        <asp:TextBox ID="txtcategorie" runat="server"></asp:TextBox>
         <br /><br />

        <asp:Label ID="Label4" runat="server" Text="Couleur"></asp:Label>
        <asp:TextBox ID="txtcouleur" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label5" runat="server" Text="Genre"></asp:Label>
        <asp:TextBox ID="txtgenre" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label6" runat="server" Text="Taille"></asp:Label>
        <asp:TextBox ID="txttaille" runat="server"></asp:TextBox>
         <br /><br />

        <asp:Label ID="Label7" runat="server" Text="Prix"></asp:Label>
        <asp:TextBox  ID="txtprix" runat="server" TextMode="Number"></asp:TextBox>

        <br /><br />

        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        <br /><br />

        <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
        <br /><br />


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField DataField="nom" HeaderText="Nom" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="categorie" HeaderText="Categorie" />
                <asp:BoundField DataField="couleur" HeaderText="Couleur" />
                <asp:BoundField DataField="genre" HeaderText="Genre" />
                <asp:BoundField DataField="taille" HeaderText="Taille" />
                <asp:BoundField DataField="prix" HeaderText="Prix" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkselect" runat="server" CommandArgument='<%# Eval("idart") %>' OnClick="lnkselect_Click" >Selectionner</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>

        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="Sample" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ecommerce.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Article]"></asp:SqlDataSource>

</asp:Content>
