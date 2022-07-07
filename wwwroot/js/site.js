// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*
 * 
 * Function that handles the search input to make sure it is used as intended
 * 
 */
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
/*
 *
 * Function that handles the filter checkboxes to make sure it is used as intended
 *
 */
function FilterMessage() {
    
    const FilterButton = document.getElementById("FilterButton");

    let CheckBoxes = document.querySelectorAll('input[name="Filter"]:checked');

    if (CheckBoxes.length > 0)
        FilterButton.disabled = false;
    else
        FilterButton.disabled = true;
}