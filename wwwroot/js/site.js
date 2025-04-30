

function GetSearchBar(string) {
	//get search bar input
	var filter = document.querySelector("#search-filter").value;
	//check if search bar is empty
	if (filter == "") {
		alert("Please enter a search term.");
		return false;
	} else {
		return filter;
	}
}

function SearchTrigger() {

    //get search button
        document.querySelector("#search-button").addEventListener("click", async () => {
        //get search bar input
            var filter = await document.querySelector("#search-filter").value;
			//check if search bar is empty  
            

        alert(filter);//testing works ok

        var response = await fetch(`/departments/SearchDepartments/${filter}`);
        //check if response is ok
        if (response.ok) {
            //get the data from the response
            var departmentsHTML = await response.text();
			document.querySelector("#department-list").innerHTML = departmentsHTML;
        } else {
            alert("Error: " + response.statusText);
        }
        });
    "#search-button".onclick(GetSearchBar);
}
