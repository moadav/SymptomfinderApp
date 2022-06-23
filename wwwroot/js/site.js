﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddItemsToSearch() {
   
    const SearchLabel = document.getElementById("SearchLabel");

    const li_element = document.createElement("li");

    li_element.appendChild(document.createTextNode(SearchLabel.value));

    document.getElementById("SearchOption").appendChild(li_element);
    
}
