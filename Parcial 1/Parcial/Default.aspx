<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>Abonados</h1>
	</div>

	<div class="row">
		<div class="col-12">
			<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

			<%--<table class="table">
				<thead>
					<tr>
						<th scope="col">#</th>
						<th scope="col">Nombre</th>
						<th scope="col">Dni</th>
						<th scope="col">Numero</th>
						<th scope="col">Tipo</th>
						<th scope="col"></th>
					</tr>
				</thead>
				<tbody>
					<%
						int i = 1;
						foreach (Entidades.Cliente cliente in new Negocio.ClienteBl().listar()) {
							Response.Write("<tr> " +
								"<td>" + i++ + "</td>" +
								"<td>" + cliente.nombre + "</td>" +
								"<td>" + cliente.dni + "</td>" +
								"<td>" + cliente.numero + "</td>" +
								"<td>" + cliente.tipo.nombre + "</td>" +
								"<td> <button onClick=\"borrarAbonado(" + cliente.idCliente + ")\" type=\"button\" class=\"btn btn-danger\">Borrar</button> </td>" +
							"</tr>");
						}
					%>
				</tbody>
			</table>--%>
			
			<asp:GridView ID="GridView1" runat="server">
			</asp:GridView>

		</div>
	</div>

</asp:Content>
