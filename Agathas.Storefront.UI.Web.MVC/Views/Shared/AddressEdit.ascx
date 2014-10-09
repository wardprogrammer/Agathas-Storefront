<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DeliveryAddressView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
                                   
            <%= Html.Hidden("Id", Model.Id) %>                
            <p>
                <label for="Name">Name:</label><br />
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="AddressLine1">AddressLine1:</label><br />
                <%= Html.TextBox("AddressLine1", Model.AddressLine1) %>
                <%= Html.ValidationMessage("AddressLine1", "*") %>
            </p>
            <p>
                <label for="AddressLine2">AddressLine2:</label><br />
                <%= Html.TextBox("AddressLine2", Model.AddressLine2) %>
                <%= Html.ValidationMessage("AddressLine2", "*") %>
            </p>
            <p>
                <label for="City">City:</label><br />
                <%= Html.TextBox("City", Model.City) %>
                <%= Html.ValidationMessage("City", "*") %>
            </p>
            <p>
                <label for="State">State:</label><br />
                <%= Html.TextBox("State", Model.State) %>
                <%= Html.ValidationMessage("State", "*") %>
            </p>
            <p>
                <label for="Country">Country:</label><br />
                <%= Html.TextBox("Country", Model.Country) %>
                <%= Html.ValidationMessage("Country", "*") %>
            </p>
            <p>
                <label for="ZipCode">ZipCode:</label><br />
                <%= Html.TextBox("ZipCode", Model.ZipCode) %>
                <%= Html.ValidationMessage("ZipCode", "*") %>
            </p>                  
    


