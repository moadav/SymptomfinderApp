// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddItemsToSearch() {
   
    const SearchLabel = document.getElementById("SearchLabel");

    const li_element = document.createElement("li");

    li_element.appendChild(document.createTextNode(SearchLabel.value));
    
    document.getElementById("SearchOption").appendChild(li_element);
    
}

function GetSearchResults() {
    let list = document.getElementById("SearchOption").getElementsByTagName('li');
    list.
    console.log(list[0].innerHTML)
}

function ErrorMessage() {
    
    const AnErrorMessage = document.getElementById("ErrorMessage");
    const searchInput = document.getElementById("SearchLabel");

    if (searchInput.innerHTML.length > 0)
        AnErrorMessage.innerHTML = "Search bar cannot be zero!"
        
}