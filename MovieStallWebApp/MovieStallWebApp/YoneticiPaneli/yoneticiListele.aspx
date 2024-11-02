<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="yoneticiListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.yoneticiListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sayfaBaslik">
        <h3>Yöneticiler</h3>
        <br />
        <asp:Label ID="lbl_bilgi" runat="server" Visible="false" CssClass="girisbilgipaneli" Text="Admin Yetkisinde Değilsiniz"></asp:Label>
    </div>
    <div>
        <asp:ListView ID="lv_yoneticiler" runat="server" OnItemCommand="lv_yoneticiler_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="esertablo">
                    <tr>
                        <th>Yönetici Türü</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Kullanıcı Adı</th>
                        <th>Mail</th>
                        <th>Şifre</th>
                        <th>Durum</th>
                        <th style="width: 350px;">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("YntTur") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td class="gizle"><%# Eval("Sifre") %></td>
                    <td><%# Eval("aktiflikGostergesi") %></td>
                    <td>
                        <a href='yoneticiDuzenle.aspx?YntID=<%# Eval("YntID") %>' class="geriAl">Yönetici Düzenle</a>
                        <asp:LinkButton ID="lb_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("YntID")%>' CommandName="sil">Yönetici Sil</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td><%# Eval("YntTur") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td class="gizle"><%# Eval("Sifre") %></td>
                    <td><%# Eval("aktiflikGostergesi") %></td>
                    <td>
                        <a href='yoneticiDuzenle.aspx?YntID=<%# Eval("YntID") %>' class="geriAl">Yönetici Düzenle</a>
                        <asp:LinkButton ID="lb_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("YntID")%>' CommandName="sil">Yönetici Sil</asp:LinkButton>

                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
