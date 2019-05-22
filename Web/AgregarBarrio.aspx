<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarBarrio.aspx.cs" Inherits="Web.AgregarBarrio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Agregar un barrio "></asp:Label>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
    <br/>
    <asp:TextBox ID="TxtNombreBarrio" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="Label3" runat="server" Text="Descripción: "></asp:Label>
    <br/>
    <asp:TextBox ID="TxtDescripcionBarrio" runat="server"></asp:TextBox>
    <br/><br/>
    <asp:Button ID="Button1" runat="server" Text="Button" onClick="BtnAgregarBarrio_Click"/>

    <asp:Label ID="LblBarrioAgregado" runat="server" Text=""></asp:Label>
</asp:Content>
