<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Lista Studentów</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container">
            <!-- Header -->
            <header>
                <div class="header-content">
                    <h1>Lista Studentów</h1>
                </div>
            </header>

            <!-- Main Content -->
            <main>
                <div class="student-list">
                    <h2>Lista studentów</h2>
                    <asp:UpdatePanel ID="UpdatePanelStudents" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewStudents" runat="server" CssClass="student-grid">
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="add-student">
                    <h2>Dodaj nowego studenta</h2>
                    <asp:Panel ID="PanelAddStudent" runat="server" CssClass="student-form">
                        <table>
                            <tr>
                                <td><strong>ID Studenta:</strong></td>
                                <td>
                                    <asp:Label ID="LabelStudentID" runat="server" CssClass="student-id" Text="ID Studenta"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Imię:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="input-field" />
                                </td>
                            </tr>
                            <tr>
                                <td>Nazwisko:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="input-field" />
                                </td>
                            </tr>
                            <tr>
                                <td>Data urodzenia:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxBirthDate" runat="server" CssClass="input-field" TextMode="Date" />
                                </td>
                            </tr>
                            <tr>
                                <td>Klasa:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxClass" runat="server" CssClass="input-field" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="ButtonAddStudent" runat="server" Text="Dodaj Studenta" OnClick="ButtonAddStudent_Click" CssClass="btn primary" />
                                    <asp:Button ID="ButtonSearchStudent" runat="server" Text="Szukaj Studenta" OnClick="ButtonSearchStudent_Click" CssClass="btn secondary" />
                                    <asp:Button ID="ButtonClear" runat="server" Text="Wyczyść" OnClick="ButtonClear_Click" CssClass="btn clear" />
                                    <asp:Button ID="ButtonEditStudent" runat="server" Text="Edytuj Studenta" OnClick="ButtonEditStudent_Click" CssClass="btn edit" Visible="false" />
                                    <asp:Button ID="ButtonDeleteStudent" runat="server" Text="Usuń Studenta" OnClick="ButtonDeleteStudent_Click" CssClass="btn delete" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </main>

            <!-- Footer -->
            <footer>
                <p>&copy; 2025 Lista Studentów. Wszystkie prawa zastrzeżone.</p>
            </footer>
        </div>
    </form>
</body>
</html>
