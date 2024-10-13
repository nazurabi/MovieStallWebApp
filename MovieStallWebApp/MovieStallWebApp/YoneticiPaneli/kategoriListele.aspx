<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="kategoriListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.kategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>Aktif Kategoriler</h3>
    </div>
    <div class="tabloTasiyici">
        <asp:ListView ID="lv_kategorilerAktif" runat="server" OnItemCommand="lv_kategorilerAktif_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>ID</th>
                        <th>Kategori İsmi</th>
                        <th>Durum</th>
                        <th>Silinmiş</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <a href='kategoriDuzenle.aspx?KategoriID=<%# Eval("KategoriID") %>' class="geriAl">Kategori Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("KategoriID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("KategoriID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <a href='kategoriDuzenle.aspx?KategoriID=<%# Eval("KategoriID") %>' class="geriAl">Kategori Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("KategoriID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("KategoriID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>

    <div class="sayfaBaslik">
        <h3>Silinmiş Kategoriler</h3>
    </div>
    <div class="tabloTasiyici">
        <asp:ListView ID="lv_kategorilerSilinmis" runat="server" OnItemCommand="lv_kategorilerSilinmis_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>ID</th>
                        <th>Kategori İsmi</th>
                        <th>Durum</th>
                        <th>Silinmiş</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_geriAl" runat="server" CssClass="geriAl" CommandArgument='<%# Eval("KategoriID")%>' CommandName="SilinmisiGeriAl">Geri Al</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_geriAl" runat="server" CssClass="geriAl" CommandArgument='<%# Eval("KategoriID")%>' CommandName="SilinmisiGeriAl">Geri Al</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
