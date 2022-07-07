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
    
    const SearchLabel = document.getElementById("SearchLabel");

    const AnErrorMessage = document.getElementById("ErrorMessage");

    const SearchButton = document.getElementById("SearchButton");

    if (SearchLabel.value.length < 4) {
        SearchButton.disabled = true;
        AnErrorMessage.innerHTML = "Search input cannot be lower than three letters";
        
    } else {
        SearchButton.disabled = false;
        AnErrorMessage.innerHTML = "";
    }      
}

function FilterMessage() {
    
    const FilterButton = document.getElementById("FilterButton");

    let CheckBoxes = document.querySelectorAll('input[name="Filter"]:checked');

    if (CheckBoxes.length > 0)
        FilterButton.disabled = false;
    else
        FilterButton.disabled = true;
}