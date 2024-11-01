<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="uyeListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.uyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sayfaBaslik">
        <h3>Üyeler</h3>
    </div>
    <div>
        <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="esertablo">
                    <tr>
                        <th>Avatar</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Kullanıcı Adı</th>
                        <th>Mail</th>
                        <th>Şifre</th>
                        <th>Durum</th>
                        <th style="width: 200px;">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 160px;">
                        <img src='../resimler/Avatarlar/<%# Eval("Avatar") %>' height="100" />
                    </td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td class="gizle"><%# Eval("Sifre") %></td>
                    <%--   <td class="gizle">
                        <asp:Literal Text='<%# Eval("Sifre") %>'  runat="server" />
                    </td>--%>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <a href='uyeDuzenle.aspx?UyeID=<%# Eval("UyeID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("UyeID")%>' CommandName="sil">Üye Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td>
                        <img src='../resimler/Avatarlar/<%# Eval("Avatar") %>' height="100" />
                    </td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td class="gizle"><%# Eval("Sifre") %></td>
                    <%--   <td class="gizle">
                        <asp:Literal Text='<%# Eval("Sifre") %>' EnableViewState="false" runat="server" />
                    </td>--%>
                    <td><%# Eval("Durum") %></td>



                    <td>
                        <a href='uyeDuzenle.aspx?UyeID=<%# Eval("UyeID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("UyeID")%>' CommandName="sil">Üye Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

